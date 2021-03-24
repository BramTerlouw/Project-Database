using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class Group_DAO : Base
    {

        public List<GroupForeignTeacher> Db_Get_All_GroupForeignTeacher()
        {
            // the query for the database, selecting the id, location_id, type(docent or student room) and the room size
            string query = "SELECT teacher.id, teacher.[name], teacher.lastname, teacher.group_id, [group].[name] as[group_name] FROM teacher JOIN group_foreign_teacher ON teacher.group_id = group_foreign_teacher.teacher_id JOIN[group] ON[group].id = group_foreign_teacher.group_id";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // return a list with rooms
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<GroupForeignTeacher> ReadTables(DataTable dataTable)
        {
            List<GroupForeignTeacher> list = new List<GroupForeignTeacher>();

            // retrieve data from database and convert if needed using a foreach
            foreach (DataRow dr in dataTable.Rows)
            {
                GroupForeignTeacher obj = new GroupForeignTeacher(
                    Convert.ToInt32(dr["id"]),
                    dr["name"].ToString(),
                    dr["lastname"].ToString(),
                    Convert.ToInt32(dr["group_id"]),
                    dr["group_name"].ToString()
                );
                // add the room to the list
                list.Add(obj);
            }

            // return the list
            return list;
        }
    }
}
