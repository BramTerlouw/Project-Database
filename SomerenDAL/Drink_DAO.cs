using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class Drink_DAO : Base
    {

        public List<Drink> Db_Get_All_Drinks()
        {
            // the query for the database, selecting [type], amount, price, alcohol FROM drinks WHERE amount > 1 AND price > 1.00
            string query = "SELECT id, [type], amount, price, alcohol FROM drinks WHERE amount > 1 AND price > 1.00";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // return a list with drinks
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public int Db_Get_Sold_Drinks(int drinkId){
            // the query for the database, selecting [type], amount, price, alcohol FROM drinks WHERE amount > 1 AND price > 1.00
            string query = "SELECT id FROM sold WHERE drink_id = " + drinkId;
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // return a list with drinks
            return getCount(ExecuteSelectQuery(query, sqlParameters));
        }

        private int getCount(DataTable dataTable){
            //return dataTable.Rows.Count;
            return dataTable.Rows.Count;
        }

        private List<Drink> ReadTables(DataTable dataTable)
        {
            List<Drink> drinks = new List<Drink>();

            // retrieve all data and convert if needed using a foreach
            foreach (DataRow dr in dataTable.Rows)
            {
                Drink drink = new Drink(
                    Convert.ToInt32(dr["id"]),
                    dr["type"].ToString(),
                    Convert.ToInt32(dr["amount"]),
                    dr["price"].ToString(),
                    Convert.ToBoolean(dr["alcohol"])
                );

                // add drink to the list
                drinks.Add(drink);
            }

            // return the list with drinks
            return drinks;
        }
    }
}
