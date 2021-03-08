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
                List<Room> room = dao.Db_Get_All_Rooms();
                return room;
            }
            catch (Exception)
            {
                // something went wrong connecting to the database, so we will add a fake room to the list to make sure the rest of the application continues working!

                return null;
            }
        }
    }
}
