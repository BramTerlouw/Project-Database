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
            string query = "SELECT id, location_id, [type], [size] FROM room";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Room> ReadTables(DataTable dataTable)
        {
            List<Room> rooms = new List<Room>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Room room = new Room(
                    Convert.ToInt32(dr["id"]), 
                    dr["type"].ToString(),
                    Convert.ToInt32(dr["size"]),
                    Convert.ToInt32(dr["location_id"])
                );
                rooms.Add(room);
            }
            return rooms;
        }
    }
}
