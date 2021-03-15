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

        public void ModifyStock(int drinkId, int stock)
        {
            // the query for the database, selecting [type], amount, price, alcohol FROM drinks WHERE amount > 1 AND price > 1.00
            string query = "UPDATE drinks SET amount = @Stock WHERE id = @Id";

            SqlParameter[] sqlParameters = new SqlParameter[2];

            SqlParameter paraStock = new SqlParameter("@Stock", SqlDbType.Int);
            paraStock.Value = stock;
            sqlParameters[0] = paraStock;

            SqlParameter paraDrink = new SqlParameter("@Id", SqlDbType.BigInt);
            paraDrink.Value = drinkId;
            sqlParameters[1] = paraDrink;

            ExecuteEditQuery(query, sqlParameters);
        }

        public void ModifyName(string oldName, string newName)
        {
            // the query for the database, selecting [type], amount, price, alcohol FROM drinks WHERE amount > 1 AND price > 1.00
            string query = "UPDATE drinks SET type = @New WHERE type = @Old";

            SqlParameter[] sqlParameters = new SqlParameter[2];

            SqlParameter paraOld = new SqlParameter("@Old", SqlDbType.VarChar);
            paraOld.Value = oldName;
            sqlParameters[0] = paraOld;

            SqlParameter paraNew = new SqlParameter("@New", SqlDbType.VarChar);
            paraNew.Value = newName;
            sqlParameters[1] = paraNew;

            ExecuteEditQuery(query, sqlParameters);
        }

        public void addDrink(int id, string type, int amount, string price, bool alcohol)
        {
            // the query for the database, selecting [type], amount, price, alcohol FROM drinks WHERE amount > 1 AND price > 1.00
            string query = "INSERT INTO drinks VALUES(@id, @type, @amount, @price, @alcohol)";

            SqlParameter[] sqlParameters = new SqlParameter[5];

            SqlParameter paraId = new SqlParameter("@id", SqlDbType.BigInt);
            paraId.Value = id;
            sqlParameters[0] = paraId;

            SqlParameter paraType = new SqlParameter("@type", SqlDbType.VarChar);
            paraType.Value = type;
            sqlParameters[1] = paraType;

            SqlParameter paraAmount = new SqlParameter("@amount", SqlDbType.Int);
            paraAmount.Value = amount;
            sqlParameters[2] = paraAmount;

            SqlParameter paraPrice = new SqlParameter("@price", SqlDbType.Float);
            paraPrice.Value = price;
            sqlParameters[3] = paraPrice;

            SqlParameter paraAlcohol = new SqlParameter("@alcohol", SqlDbType.Bit);
            paraAlcohol.Value = alcohol;
            sqlParameters[4] = paraAlcohol;

            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
