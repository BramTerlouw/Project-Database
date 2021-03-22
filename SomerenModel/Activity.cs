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
        public readonly string type;
        public readonly string description;

        public Activity(int v1, string v2, string v3)
        {
            id = v1;
            type = v2;
            description = v3;
        }

        public string[] dataGridList()
        {
            // return the column names
            return new string[] { "id", "type", "description" };
        }

        public string[] dataGrid(Activity activity)
        {
            // return an array with all the teacher properties
            return new string[] {
                activity.id.ToString(),
                activity.type,
                activity.description
            };
        }
    }
}
