using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class Room_DAO : Base
    {

        public List<Room> Db_Get_All_Rooms()
        {
            // the query for the database, selecting the id, location_id, type(docent or student room) and the room size
            string query = "SELECT id, location_id, [type], [size] FROM room";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // return a list with rooms
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Room> ReadTables(DataTable dataTable)
        {
            List<Room> rooms = new List<Room>();

            // retrieve data from database and convert if needed using a foreach
            foreach (DataRow dr in dataTable.Rows)
            {
                Room room = new Room(
                    Convert.ToInt32(dr["id"]), 
                    dr["type"].ToString(),
                    Convert.ToInt32(dr["size"]),
                    Convert.ToInt32(dr["location_id"])
                );
                // add the room to the list
                rooms.Add(room);
            }
            
            // return the list
            return rooms;
        }
    }
}
