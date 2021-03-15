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
            // query for selecting the database
            string query = "SELECT student.id, name, email, age, dutch_student, group_id, room_name FROM student INNER JOIN room ON room_id = room.id";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // return a list with students
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Student> ReadTables(DataTable dataTable)
        {
            List<Student> students = new List<Student>();

            // retrieve all data from database and convert if needed
            foreach (DataRow dr in dataTable.Rows) //@todo fix potential rows null references?
            {
                Student student = new Student(
                    Convert.ToInt32(dr["id"]),
                    dr["name"].ToString(),
                    dr["email"].ToString(),
                    Convert.ToInt32(dr["age"]),
                    Convert.ToBoolean(dr["dutch_student"]),
                    Convert.ToInt32(dr["group_id"]),
                    dr["room_name"].ToString()
                ) ;

                // add student to the list
                students.Add(student);
            }

            // return the list with students
            return students;
        }
    }
}
