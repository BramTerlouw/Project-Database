using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Register_Service
    {
        SomerenDAL.Register_DAO dao = new Register_DAO();

        public bool CheckForExistence(string email)
        {
            if (dao.CheckForExistance(email) > 0)
                return true;
            else
                return false;
        }

        public bool CheckForExistenceSecretQuestion(string email, string sQ, string sA)
        {
            if (dao.CheckForExistenceSecretQuestion(email, sQ, sA) > 0)
                return true;
            else
                return false;
        }

        public void updateUserPassword(string v1, string v2)
        {
            dao.UpdateUser(v1, v2);
        }



        public void InsertUser(string v1, string v2, string v3, string v4, string v5)
        {
            dao.InsertUser(v1, v2, v3, v4, v5);
        }

        public bool CheckUserLogin(string email, string password)
        {
            if (dao.CheckUser(email, password) == 1)
                return true;
            else
                return false;
            
        }
    }
}
