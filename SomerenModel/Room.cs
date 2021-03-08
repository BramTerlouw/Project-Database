using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Room
    {
        public readonly int Id;
        public readonly string Type;
        public readonly int Size;
        public readonly int Location_Id;

        // Id , Type , Size, Location_Id
        public Room(int v1, string v2,int v3, int v4)
        {
            // constructor for the class room
            Id = v1;
            Type = v2;
            Size = v3;
            Location_Id = v4;
        }

        public string[] dataGridList()
        {
            // return the column names
            return new string[] { "id", "type", "size", "location" };
        }

        public string[] dataGrid(Room room)
        {
            // return array with all the room properties
            return new string[] {
                room.Id.ToString(),
                room.Type,
                room.Size.ToString(),
                room.Location_Id.ToString(),
            };
        }
    }
}
