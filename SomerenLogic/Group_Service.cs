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
    public class Group_Service
    {
        readonly Group_DAO dao = new Group_DAO();

        public List<GroupForeignTeacher> GetGroupForeignTeacher()
        {
            try
            {
                // get the list with teachers by calling a function from the DAL layer
                List<GroupForeignTeacher> s = dao.Db_Get_All_GroupForeignTeacher();
                return s; // return list
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong!");
            }
        }
    }
}
