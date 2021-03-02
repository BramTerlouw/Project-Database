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
                List<Student> student = student_db.Db_Get_All_Students();
                return student;
            }
            catch (Exception)
            {
                //@todo make error class en leg error uit aan de gebruiker

                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Student> student = new List<Student>();
                for (int i = 0; i < 4; i++)
                    student.Add(new Student(474791, ("Mr. Test Student" + i), DateTime.Parse("1990-07-04")));

                return student;
            }
        }
    }
}
