using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class Teacher_DAO : Base
    {

        public List<Teacher> Db_Get_All_Teachers()
        {
            // the query for the database, selecting id, name, lastname, group_id and room_id
            string query = "SELECT id, name, lastname, group_id, room_id FROM teacher";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // return a list with teachers
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Teacher> ReadTables(DataTable dataTable)
        {
            List<Teacher> teachers = new List<Teacher>();

            // retrieve all data and convert if needed using a foreach
            foreach (DataRow dr in dataTable.Rows)
            {
                Teacher teacher = new Teacher(
                    Convert.ToInt32(dr["id"]), 
                    dr["name"].ToString(),
                    dr["lastname"].ToString(),
                    Convert.ToInt32(dr["group_id"]),
                    Convert.ToInt32(dr["room_id"])
                );

                // add teacher to the list
                teachers.Add(teacher);
            }

            // return the list with teachers
            return teachers;
        }
    }
}
