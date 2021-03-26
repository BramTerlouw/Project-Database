namespace SomerenModel
{
    public class ActivityForeignGroup
    {
        // all the fields
        public readonly int id;
        public readonly string description;
        public readonly string mentor_name;
        public readonly string date_start;
        public readonly string date_end;

        // constructor
        public ActivityForeignGroup(int v1, string v2, string v3, string v4, string v5)
        {
            id = v1;
            description = v2;
            mentor_name = v3;
            date_start = v4;
            date_end = v5;
        }

        public string[] dataGridList()
        {
            // return the column names
            return new string[] { "id", "description", "mentor_name", "date_start", "date_end" };
        }

        public string[] dataGrid(ActivityForeignGroup activityForeignGroup)
        {
            // return array with all the rooster properties
            return new string[] {
                activityForeignGroup.id.ToString(),
                activityForeignGroup.description.ToString(),
                activityForeignGroup.mentor_name.ToString(),
                activityForeignGroup.date_start.ToString(),
                activityForeignGroup.date_end.ToString()
            };
        }
    }
}