using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;

namespace SomerenLogic
{
    public class Student_Service
    {
        Student_DAO student_db = new Student_DAO();

        public List<Student> GetStudents()
        {
            try
            {
                List<Student> student = student_db.Db_Get_All_Students(); // get the list with students from the DAL layer
                return student; // return the list
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong!");
            }
        }
    }
}
