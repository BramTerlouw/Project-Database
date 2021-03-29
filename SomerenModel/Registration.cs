using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Registration
    {
        public int id;
        public string name;
        public string password;
        public string role;
        public string secret_question;
        public string secret_answer;

        public Registration(int v1, string v2, string v3, string v4, string v5, string v6)
        {
            id = v1;
            name = v2;
            password = v3;
            role = v4;
            secret_question = v5;
            secret_answer = v6;
        }
    }
}
