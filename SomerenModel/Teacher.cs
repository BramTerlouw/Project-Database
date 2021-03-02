using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Teacher
    {

        public Teacher(int v1, string v2)
        {
            Id = v1;
            Name = v2;
        }

        public String Name { get; set; }
        public int Id { get; set; } 

    }
}
