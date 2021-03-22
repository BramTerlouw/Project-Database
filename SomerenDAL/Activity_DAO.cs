using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class Activity_DAO : Base
    {
        public List<Activity> Db_Get_All_Activities()
        {
            // the query for the database, selecting info from activity
            string query = "SELECT id, description, Aantal_Studenten, Aantal_Begeleiders from activity";
            
            // an array for parameters
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // return a list with activities
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Activity> ReadTables(DataTable dataTable)
        {
            List<Activity> activities = new List<Activity>();

            // retrieve all data and convert if needed using a foreach
            foreach (DataRow dr in dataTable.Rows)
            {
                Activity activity = new Activity(
                    Convert.ToInt32(dr["id"]),
                    dr["description"].ToString(),
                    Convert.ToInt32(dr["Aantal_Studenten"]),
                    Convert.ToInt32(dr["Aantal_Begeleiders"])
                );

                // add activity to the list
                activities.Add(activity);
            }

            // return the list with activities
            return activities;
        }

        public void InsertActivity(int id, string description, int aantal_Students, int aantal_Begeleiders)
        {
            // the query for inserting a activity
            string query = "INSERT INTO activity VALUES(@id, @description, @aantal_Students, @aantal_Begeleiders)";

            // array with 4 parameters
            SqlParameter[] sqlParameters = new SqlParameter[4];

            SqlParameter paraId = new SqlParameter("@id", SqlDbType.BigInt);
            paraId.Value = id;
            sqlParameters[0] = paraId;

            SqlParameter paraDescpription = new SqlParameter("@description", SqlDbType.VarChar);
            paraDescpription.Value = description;
            sqlParameters[1] = paraDescpription;

            SqlParameter paraAantalStudents = new SqlParameter("@aantal_Students", SqlDbType.BigInt);
            paraAantalStudents.Value = aantal_Students;
            sqlParameters[2] = paraAantalStudents;

            SqlParameter paraAantalBegeleiders = new SqlParameter("@aantal_Begeleiders", SqlDbType.BigInt);
            paraAantalBegeleiders.Value = aantal_Begeleiders;
            sqlParameters[3] = paraAantalBegeleiders;

            // execute query
            ExecuteEditQuery(query, sqlParameters);
        }

        public void DeleteActivity(int id)
        {
            // query for deleting a activity
            string query = "DELETE FROM activity WHERE id = @id";
            
            // an array with 1 parameter
            SqlParameter[] sqlParameters = new SqlParameter[1];
            
            SqlParameter paraId = new SqlParameter("@id", SqlDbType.BigInt);
            paraId.Value = id;
            sqlParameters[0] = paraId;

            // execute query
            ExecuteEditQuery(query, sqlParameters);
        }

        public void ChangeActivity(int id, string description)
        {
            // query for changing a activity
            string query = "UPDATE activity SET description = @description WHERE id = @id";
            
            // an array with 2 parameters
            SqlParameter[] sqlParameters = new SqlParameter[2];

            SqlParameter paraId = new SqlParameter("@id", SqlDbType.BigInt);
            paraId.Value = id;
            sqlParameters[0] = paraId;

            SqlParameter paraDescription = new SqlParameter("@description", SqlDbType.Text);
            paraDescription.Value = description;
            sqlParameters[1] = paraDescription;

            // execute query
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
