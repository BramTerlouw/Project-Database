using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Activity
    {
        public readonly int id;
        public readonly string description;
        //public readonly int aantal_Students;
        //public readonly int aantal_Begeleiders;

        public Activity(int v1, string v2 /*int v3, int v4*/)
        {
            id = v1;
            description = v2;
            //aantal_Students = v3;
            //aantal_Begeleiders = v4;
        }

        public string[] dataGridList()
        {
            // return the column names
            return new string[] { "id", "description", "aantal studenten", "aantal begeleiders" };
        }

        public string[] dataGrid(Activity activity, int studenten, int begeleiders)
        {
            // return an array with all the teacher properties
            return new string[] {
                activity.id.ToString(),
                activity.description,
                studenten.ToString(),
                begeleiders.ToString(),
            };
        }
    }
}
