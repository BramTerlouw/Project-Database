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
    public class Room_Service
    {
        readonly Room_DAO dao = new Room_DAO();

        public List<Room> GetRooms()
        {
            try
            {
                // get the list with rooms by calling a function from the DAL layer
                List<Room> room = dao.Db_Get_All_Rooms();
                return room;
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong!");
            }
        }
    }
}
