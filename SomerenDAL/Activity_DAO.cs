using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class Activity_DAO : Base
    {
        public List<Activity> Db_Get_All_Activities()
        {
            // the query for the database, selecting info from activity
            string query = "SELECT id, description from activity"; 

            // an array for parameters
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // return a list with activities
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Activity> ReadTables(DataTable dataTable)
        {
            List<Activity> activities = new List<Activity>();

            // retrieve all data and convert if needed using a foreach
            foreach (DataRow dr in dataTable.Rows)
            {
                Activity activity = new Activity(
                    Convert.ToInt32(dr["id"]),
                    dr["description"].ToString()
                );

                // add activity to the list
                activities.Add(activity);
            }

            // return the list with activities
            return activities;
        }
        





        public List<ActivityForeignGroup> Db_Get_All_ActivityForeignGroup()
        {
            // the query for the database, selecting info from activity
            string query = "SELECT activity_foreign_group.id, activity.[description], teacher.[name] as [mentor_name], activity_foreign_group.date_start, activity_foreign_group.date_end " +
                "FROM activity_foreign_group JOIN activity ON activity_foreign_group.activity_id = activity.id JOIN group_foreign_teacher " +
                "ON group_foreign_teacher.group_id = activity_foreign_group.group_id JOIN teacher ON group_foreign_teacher.teacher_id = teacher.id ORDER BY activity_foreign_group.date_start";
            
            // an array for parameters
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // return a list with activities
            return ReadTablesActivityForeignGroup(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<ActivityForeignGroup> ReadTablesActivityForeignGroup(DataTable dataTable)
        {
            List<ActivityForeignGroup> list = new List<ActivityForeignGroup>();

            // retrieve all data and convert if needed using a foreach
            foreach (DataRow dr in dataTable.Rows)
            {
                ActivityForeignGroup s = new ActivityForeignGroup(
                    Convert.ToInt32(dr["id"]),
                    dr["description"].ToString(),
                    dr["mentor_name"].ToString(),
                    dr["date_start"].ToString(),
                    dr["date_end"].ToString()
                );

                // add activity to the list
                list.Add(s);
            }

            // return the list with activities
            return list;
        }

        public void InsertActivity(int id, string description)
        {
            // the query for inserting a activity
            string query = "INSERT INTO activity VALUES(@id, @description)";

            // array with 4 parameters
            SqlParameter[] sqlParameters = new SqlParameter[2];

            SqlParameter paraId = new SqlParameter("@id", SqlDbType.BigInt);
            paraId.Value = id;
            sqlParameters[0] = paraId;

            SqlParameter paraDescpription = new SqlParameter("@description", SqlDbType.VarChar);
            paraDescpription.Value = description;
            sqlParameters[1] = paraDescpription;


            // execute query
            ExecuteEditQuery(query, sqlParameters);
        }

        public void DeleteActivity(int id)
        {
            // query for deleting a activity
            string query = "DELETE FROM activity WHERE id = @id";
            
            // an array with 1 parameter
            SqlParameter[] sqlParameters = new SqlParameter[1];
            
            SqlParameter paraId = new SqlParameter("@id", SqlDbType.BigInt);
            paraId.Value = id;
            sqlParameters[0] = paraId;

            // execute query
            ExecuteEditQuery(query, sqlParameters);
        }

        public void ChangeActivity(int id, string description)
        {
            // query for changing a activity
            string query = "UPDATE activity SET description = @description WHERE id = @id";
            
            // an array with 2 parameters
            SqlParameter[] sqlParameters = new SqlParameter[2];

            SqlParameter paraId = new SqlParameter("@id", SqlDbType.BigInt);
            paraId.Value = id;
            sqlParameters[0] = paraId;

            SqlParameter paraDescription = new SqlParameter("@description", SqlDbType.Text);
            paraDescription.Value = description;
            sqlParameters[1] = paraDescription;

            // execute query
            ExecuteEditQuery(query, sqlParameters);
        }

        
        

        
        public int getAantalStudenten(int activityId)
        {
            // query for counting the amount of students
            string query = "SELECT COUNT(student.group_id) AS [amount] FROM activity JOIN activity_foreign_group ON activity.id = activity_foreign_group.activity_id " +
                "JOIN student ON activity_foreign_group.group_id = student.group_id WHERE activity.id = @id";

            // an array with parameters
            SqlParameter[] sqlParameters = new SqlParameter[1];

            SqlParameter paraId = new SqlParameter("@id", SqlDbType.BigInt);
            paraId.Value = activityId;
            sqlParameters[0] = paraId;

            // return the amount
            return  ReadAmountActivity(ExecuteSelectQuery(query, sqlParameters));
        }

        public int getAantalBegeleiders(int activityId)
        {
            // query for counting the amount of mentors
            string query = "SELECT COUNT(teacher_id) AS [amount] FROM activity JOIN activity_foreign_group ON activity.id = activity_foreign_group.activity_id " +
                "JOIN group_foreign_teacher ON activity_foreign_group.group_id = group_foreign_teacher.group_id WHERE activity.id = @id";

            // an array with parameters
            SqlParameter[] sqlParameters = new SqlParameter[1];

            SqlParameter paraId = new SqlParameter("@id", SqlDbType.BigInt);
            paraId.Value = activityId;
            sqlParameters[0] = paraId;

            // return the amount
            return ReadAmountActivity(ExecuteSelectQuery(query, sqlParameters));
        }

        private int ReadAmountActivity(DataTable dataTable)
        {
            // value is zero before going through the foreach
            int amount = 0;

            // retrieve all data and convert if needed using a foreach
            foreach (DataRow dr in dataTable.Rows)
            {
                amount = Convert.ToInt32(dr["amount"]);
            }

            // return the list with drinks
            return amount;
        }





        public string GetDateTimeByActivityStart(int activityId)
        {
            // query for selecting the startdate
            string query = "SELECT [date_start] FROM activity_foreign_group WHERE id = @activity";

            // an array with parameters
            SqlParameter[] sqlParameters = new SqlParameter[1];

            SqlParameter paraactivity = new SqlParameter("@activity", SqlDbType.BigInt);
            paraactivity.Value = activityId;
            sqlParameters[0] = paraactivity;

            // return the startdate
            return ReadDateTimeStart(ExecuteSelectQuery(query, sqlParameters));
        }

        public string GetDateTimeByActivityEnd(int activityId)
        {
            // query for selecting the enddate
            string query = "SELECT [date_end] FROM activity_foreign_group WHERE id = @activity";

            // an array with parameters
            SqlParameter[] sqlParameters = new SqlParameter[1];

            SqlParameter paraactivity = new SqlParameter("@activity", SqlDbType.BigInt);
            paraactivity.Value = activityId;
            sqlParameters[0] = paraactivity;

            // return the end date
            return ReadDateTimeEnd(ExecuteSelectQuery(query, sqlParameters));
        }

        private string ReadDateTimeStart(DataTable datatable)
        {
            string start = ""; // empty string
            foreach (DataRow dr in datatable.Rows)
            {
                start = dr["date_start"].ToString(); // assign date to the string
            }
            return start; // return
        }

        private string ReadDateTimeEnd(DataTable datatable)
        {
            string end = ""; // empty string
            foreach (DataRow dr in datatable.Rows)
            {
                end = dr["date_end"].ToString(); // assign date to the string
            }
            return end; // return
        }

        public void SwapActivities(int activityid, string start, string end)
        {
            // query for updating the database and swap the dates 
            string query = "UPDATE activity_foreign_group SET[date_start] = @start, [date_end] = @end WHERE id = @id";

            // an array with parameters
            SqlParameter[] sqlParameters = new SqlParameter[3];

            SqlParameter paraId = new SqlParameter("@id", SqlDbType.BigInt);
            paraId.Value = activityid;
            sqlParameters[0] = paraId;

            SqlParameter paraStart = new SqlParameter("@start", SqlDbType.DateTime);
            paraStart.Value = start;
            sqlParameters[1] = paraStart;

            SqlParameter paraEnd = new SqlParameter("@end", SqlDbType.DateTime);
            paraEnd.Value = end;
            sqlParameters[2] = paraEnd;

            // execute the quert
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
