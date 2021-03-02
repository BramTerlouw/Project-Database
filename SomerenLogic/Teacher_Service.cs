using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Teacher_Service
    {
        readonly Teacher_DAO dao = new Teacher_DAO();

        public List<Teacher> GetTeachers()
        {
            try
            {
                List<Teacher> teacher = dao.Db_Get_All_Teachers();
                return teacher;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Teacher> teacher = new List<Teacher>();
                for (int i = 0; i < 4; i++)
                    teacher.Add(new Teacher(474791, ("Mr. Test Teacher" + i)));

                return teacher;
            }
        }
    }
}
