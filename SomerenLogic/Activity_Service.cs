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
                // get the list with activities by calling a function from the DAL layer
                List<Activity> activities = dao.Db_Get_All_Activities();
                return activities;
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong!"); // or throw new exception
            }
        }

        public void InsertActivity(int id, string description, int aantal_Students, int aantal_Begeleiders)
        {
            // insert an activity by calling function from DAL layer
            dao.InsertActivity(id, description, aantal_Students, aantal_Begeleiders);
        }

        public void DeleteActivity(int id)
        {
            // delete an activity by calling a function from the DAL layer
            dao.DeleteActivity(id);
        }

        public void ChangeActivity(int id, string description)
        {
            // changing a activity by calling a function from the DAL layer
            dao.ChangeActivity(id, description);
        }

        public List<ActivityForeignGroup> GetActivityForiegnGroup()
        {
            try
            {
                // get the list with activities by calling a function from the DAL layer
                List<ActivityForeignGroup> s = dao.Db_Get_All_ActivityForeignGroup();
                return s;
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong!"); // or throw new exception
            }
        }

        public int getAantalStudenten(int activityId)
        {
            return dao.getAantalStudenten(activityId);
        }

        public int getAantalBegeleiders(int activityId)
        {
            return dao.getAantalBegeleiders(activityId);
        }
    }
}
