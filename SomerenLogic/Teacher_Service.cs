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
                // get the list with teachers by calling a function from the DAL layer
                List<Teacher> teacher = dao.Db_Get_All_Teachers();
                return teacher; // return list
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!

                return null;
            }
        }
    }
}
