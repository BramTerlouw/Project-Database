using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SomerenDAL
{
    public abstract class Base
    {
        private SqlDataAdapter adapter;
        private SqlConnection conn;
        public Base()
        {
            // DO NOT FORGET TO INSERT YOUR CONNECTION STRING NAMED 'SOMEREN DATABASE' IN YOUR APP.CONFIG!!
            
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SomerenDatabase"].ConnectionString);
                adapter = new SqlDataAdapter();
             
        }

        protected SqlConnection OpenConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        private void CloseConnection()
        {
            conn.Close();
        }

        /* For Insert/Update/Delete Queries with transaction */
        protected void ExecuteEditTranQuery(String query, SqlParameter[] sqlParameters, SqlTransaction sqlTransaction)
        {
            SqlCommand command = new SqlCommand(query, conn, sqlTransaction);
            try
            {
                command.Parameters.AddRange(sqlParameters);
                adapter.InsertCommand = command;
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Write(e);
                throw;
            }
        }

        /* For Insert/Update/Delete Queries */
        protected void ExecuteEditQuery(String query, SqlParameter[] sqlParameters)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Parameters.AddRange(sqlParameters);
                adapter.InsertCommand = command;
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.Write(e);
                throw new Exception("Not succesfull");
            }
            finally
            {
                CloseConnection();
            }
        }



        /* For Select Queries */
        protected DataTable ExecuteSelectQuery(String query, params SqlParameter[] sqlParameters)
        {
            SqlCommand command = new SqlCommand();
            DataTable dataTable;
            DataSet dataSet = new DataSet();

            try
            {
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Parameters.AddRange(sqlParameters);
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }
            catch (SqlException e)
            {
                Console.Write(e);
                return null;
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }

        
        
        // Select query with count
        protected double ExecuteCountDouble(string query, SqlParameter[] sqlParameters)
        {
            // new command and double value
            SqlCommand command = new SqlCommand();
            double value = 0;
            
            // Because we used Count() in our query we made a new execute query and used command.ExecuteScalar to perform the query for a double value
            try
            {
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Parameters.AddRange(sqlParameters);
                value = (double) command.ExecuteScalar(); // get and cast
            }
            catch (Exception)
            {
                throw new Exception("No revenue!"); // Or throw exception, program keeps running
            }
            finally
            {
                CloseConnection(); // close connection
            }
            return value; // return the value
        }



        // Select query with count
        protected Int32 ExecuteCountInteger(string query, SqlParameter[] sqlParameters)
        {
            // new command and int32 value
            SqlCommand command = new SqlCommand();
            Int32 value = 0;

            // Because we used Count() in our query we made a new execute query and used command.ExecuteScalar to perform the query for a int32 value
            try
            {
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Parameters.AddRange(sqlParameters);
                value = (Int32)command.ExecuteScalar(); // get and cast
            }
            catch (Exception)
            {
                throw new Exception("No revenue!"); // or throw exception, program keeps running
            }
            finally
            {
                CloseConnection(); // close connection
            }
            return value; // return the value
        }
    }
}
