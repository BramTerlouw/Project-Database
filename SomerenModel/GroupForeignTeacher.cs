namespace SomerenModel
{
    public class GroupForeignTeacher
    {
        public readonly int id;
        public readonly string name;
        public readonly string last_name;
        public readonly int group_id;
        public readonly string group_name;

        public GroupForeignTeacher(int v1, string v2, string v3, int v4, string v5)
        {
            id = v1;
            name = v2;
            last_name = v3;
            group_id = v4;
            group_name = v5;
        }

        public string[] dataGridList()
        {
            // return the column names
            return new string[] { "id", "name", "lastname", "group_id", "group_name" };
        }

        public string[] dataGrid(GroupForeignTeacher groupForeignTeacher)
        {
            // return array with all the room properties
            return new string[] {
                groupForeignTeacher.id.ToString(),
                groupForeignTeacher.name.ToString(),
                groupForeignTeacher.last_name.ToString(),
                groupForeignTeacher.group_id.ToString(),
                groupForeignTeacher.group_name.ToString()
            };
        }
    }
}