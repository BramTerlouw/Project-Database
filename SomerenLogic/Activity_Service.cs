using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class Activity_Service
    {
        readonly Activity_DAO dao = new Activity_DAO();

        public List<Activity> GetActivities()
        {
            try
            {
                // get the list with rooms by calling a function from the DAL layer
                List<Activity> activities = dao.Db_Get_All_Activities();
                return activities;
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong!");
            }
        }

        public void InsertActivity(int id, string description, int aantal_Students, int aantal_Begeleiders)
        {
            dao.InsertActivity(id, description, aantal_Students, aantal_Begeleiders);
        }

        public void DeleteActivity(int id)
        {
            dao.DeleteActivity(id);
        }
    }
}
