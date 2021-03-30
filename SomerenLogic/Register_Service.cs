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
            // when more then zero, user exists
            if (dao.CheckForExistance(email) > 0)
                return true;
            else
                return false;
        }

        public bool CheckForExistenceSecretQuestion(string email, string sQ, string sA)
        {
            // when combination of email, question and answer exists return true
            if (dao.CheckForExistenceSecretQuestion(email, sQ, sA) > 0)
                return true;
            else
                return false;
        }

        public void updateUserPassword(string v1, string v2)
        {
            // update user
            dao.UpdateUser(v1, v2);
        }



        public void InsertUser(string v1, string v2, string v3, string v4, string v5)
        {
            // insert user
            dao.InsertUser(v1, v2, v3, v4, v5);
        }

        public bool CheckUserLogin(string email, string password)
        {
            // check for combination with email and password
            if (dao.CheckUser(email, password) == 1)
                return true;
            else
                return false;
        }

        public string GetSecretQuestion(string email)
        {
            // get question
            return dao.GetSecretQuestion(email);
        }

        public string GetRole(string email)
        {
            // get role
            return dao.GetRole(email);
        }
    }
}
