using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;

namespace SomerenDAL
{
    public class Register_DAO : Base
    {
        public int CheckForExistance(string email)
        {
            // query for counting the users that match the email
            string query = "SELECT COUNT(*) FROM[user] WHERE email = @email";

            // an array with parameters
            SqlParameter[] sqlParameters = new SqlParameter[1];

            SqlParameter paraEmail = new SqlParameter("@email", SqlDbType.VarChar);
            paraEmail.Value = email;
            sqlParameters[0] = paraEmail;

            // return how much matches
            return ExecuteCountInteger(query, sqlParameters);
        }

        public int CheckForExistenceSecretQuestion(string email, string sQ, string sA)
        {
            string query = "SELECT COUNT(*) FROM[user] WHERE email = @email AND secret_question = @sq AND secret_awnser = @sa";

            // an array with parameters
            SqlParameter[] sqlParameters = new SqlParameter[3];

            SqlParameter paraEmail = new SqlParameter("@email", SqlDbType.VarChar);
            paraEmail.Value = email;
            sqlParameters[0] = paraEmail;

            SqlParameter psq = new SqlParameter("@sq", SqlDbType.VarChar);
            psq.Value = sQ;
            sqlParameters[1] = psq;

            SqlParameter psa = new SqlParameter("@sa", SqlDbType.VarChar);
            psa.Value = sA;
            sqlParameters[2] = psa;

            // return how many matches
            return ExecuteCountInteger(query, sqlParameters);
        }

        public void InsertUser(string v1, string v2, string v3, string v4, string v5)
        {
            // query for inserting the new user
            string query = "INSERT INTO [user] VALUES(@name, @email, @password, @role, @SecretQuestion, @SecretAnswer)";

            // an array with parameters
            SqlParameter[] sqlParameters = new SqlParameter[6];

            SqlParameter paraName = new SqlParameter("@name", SqlDbType.VarChar);
            paraName.Value = v1;
            sqlParameters[0] = paraName;

            SqlParameter paraEmail = new SqlParameter("@email", SqlDbType.VarChar);
            paraEmail.Value = v2;
            sqlParameters[1] = paraEmail;

            SqlParameter paraPassword = new SqlParameter("@password", SqlDbType.VarChar);
            paraPassword.Value = v3;
            sqlParameters[2] = paraPassword;

            SqlParameter paraRole = new SqlParameter("@role", SqlDbType.VarChar);
            paraRole.Value = "user";
            sqlParameters[3] = paraRole;

            SqlParameter paraQuestion = new SqlParameter("@SecretQuestion", SqlDbType.VarChar);
            paraQuestion.Value = v4;
            sqlParameters[4] = paraQuestion;

            SqlParameter paraAnswer = new SqlParameter("@SecretAnswer", SqlDbType.VarChar);
            paraAnswer.Value = v5;
            sqlParameters[5] = paraAnswer;

            // insert
            ExecuteEditQuery(query, sqlParameters);
        }
        public void UpdateUser(string v1, string v2)
        {
            // query for updating the password
            string query = "UPDATE [user] SET password = @password WHERE email = @email";

            // an array with parameters
            SqlParameter[] sqlParameters = new SqlParameter[2];

            SqlParameter paraEmail = new SqlParameter("@email", SqlDbType.VarChar);
            paraEmail.Value = v1;
            sqlParameters[0] = paraEmail;

            SqlParameter paraPassword = new SqlParameter("@password", SqlDbType.VarChar);
            paraPassword.Value = v2;
            sqlParameters[1] = paraPassword;

            // execute edit query
            ExecuteEditQuery(query, sqlParameters);
        }

        public int CheckUser(string email, string password)
        {
            // query for counting users with specifik email and password
            string query = "SELECT COUNT(*) FROM[user] WHERE email = @email AND[password] = @password";

            // an array with parameters
            SqlParameter[] sqlParameters = new SqlParameter[2];

            SqlParameter paraemail = new SqlParameter("@email", SqlDbType.VarChar);
            paraemail.Value = email;
            sqlParameters[0] = paraemail;

            SqlParameter paraPassword = new SqlParameter("@password", SqlDbType.VarChar);
            paraPassword.Value = password;
            sqlParameters[1] = paraPassword;

            // return the count
            return ExecuteCountInteger(query, sqlParameters);
        }

        public string GetSecretQuestion(string email)
        {
            // query for selecting the secret question
            string query = "SELECT secret_question FROM [user] WHERE email = @email";

            // an array with parameters
            SqlParameter[] sqlParameters = new SqlParameter[1];

            SqlParameter paraEmail = new SqlParameter("@email", SqlDbType.VarChar);
            paraEmail.Value = email;
            sqlParameters[0] = paraEmail;

            // return the question
            return ReadQuestion(ExecuteSelectQuery(query, sqlParameters));
        }

        private string ReadQuestion(DataTable dataTable)
        {
            string secretQuestion = "";
            
            // read the question and turn to string
            foreach (DataRow dr in dataTable.Rows)
            {
                secretQuestion = dr["secret_question"].ToString();
            }
            return secretQuestion;
        }

        public string GetRole(string email)
        {
            // query for selecting the role of a specifik user
            string query = "SELECT role FROM [user] WHERE email = @email";

            // an array with parameters
            SqlParameter[] sqlParameters = new SqlParameter[1];

            SqlParameter paraEmail = new SqlParameter("@email", SqlDbType.VarChar);
            paraEmail.Value = email;
            sqlParameters[0] = paraEmail;

            // return the role
            return ReadRole(ExecuteSelectQuery(query, sqlParameters));
        }

        private string ReadRole(DataTable dataTable)
        {
            string role = "";
            
            // read role and convert to string
            foreach (DataRow dr in dataTable.Rows)
            {
                role = dr["role"].ToString();
            }
            return role;
        }
    }
}
