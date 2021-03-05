using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class Student_DAO : Base
    {
      
        public List<Student> Db_Get_All_Students()
        {
            string query = "SELECT id, name, email, age, dutch_student, group_id, room_id FROM student";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Student> ReadTables(DataTable dataTable)
        {
            List<Student> students = new List<Student>();

            foreach (DataRow dr in dataTable.Rows) //@todo fix potential rows null references?
            {
                Student student = new Student(
                    Convert.ToInt32(dr["id"]), 
                    dr["name"].ToString(),
                    dr["email"].ToString(),
                    Convert.ToInt32(dr["age"]),
                    Convert.ToBoolean(dr["dutch_student"]),
                    Convert.ToInt32(dr["group_id"]),
                    Convert.ToInt32(dr["room_id"])
                );
                students.Add(student);
            }
            return students;
        }
    }
}
