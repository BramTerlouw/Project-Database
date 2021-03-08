using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Teacher
    {
        public readonly int Id;
        public readonly string Name;
        public readonly string Last_Name;
        public readonly int group_id;
        public readonly int room_id;

        // id , name , lastname, group_id, room_id
        public Teacher(int v1, string v2, string v3, int v4, int v5)
        {
            Id = v1;
            Name = v2;
            Last_Name = v3;
            group_id = v4;
            room_id = v5;
        }

        public string[] dataGridList()
        {
            return new string[] { "id", "name", "lastname", "group", "room" };
        }

        public string[] dataGrid(Teacher teacher)
        {
            return new string[] {
                teacher.Id.ToString(),
                teacher.Name,
                teacher.Last_Name,
                teacher.group_id.ToString(),
                teacher.room_id.ToString(),
            };
        }
    }
}
