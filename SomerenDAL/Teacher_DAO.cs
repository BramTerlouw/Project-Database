using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class Teacher_DAO : Base
    {

        public List<Teacher> Db_Get_All_Teachers()
        {
            // the query for the database, selecting id, name, lastname, group_id and room_id
            string query = "SELECT id, name, lastname, group_id, room_id FROM teacher";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            // return a list with teachers
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Teacher> ReadTables(DataTable dataTable)
        {
            List<Teacher> teachers = new List<Teacher>();

            // retrieve all data and convert if needed using a foreach
            foreach (DataRow dr in dataTable.Rows)
            {
                Teacher teacher = new Teacher(
                    Convert.ToInt32(dr["id"]), 
                    dr["name"].ToString(),
                    dr["lastname"].ToString(),
                    Convert.ToInt32(dr["group_id"]),
                    Convert.ToInt32(dr["room_id"])
                );

                // add teacher to the list
                teachers.Add(teacher);
            }

            // return the list with teachers
            return teachers;
        }

        public void AddMentor(int groupId, int teacherId)
        {
            string query = "INSERT INTO group_foreign_teacher VALUES(@group, @teacher)";

            SqlParameter[] sqlParameters = new SqlParameter[2];

            SqlParameter paraGroup = new SqlParameter("@group", SqlDbType.BigInt);
            paraGroup.Value = groupId;
            sqlParameters[0] = paraGroup;

            SqlParameter paraTeacher = new SqlParameter("@teacher", SqlDbType.BigInt);
            paraTeacher.Value = teacherId;
            sqlParameters[1] = paraTeacher;

            ExecuteEditQuery(query, sqlParameters);
        }

        public int CheckExistingMentor(int teacherId)
        {
            string query = "SELECT COUNT(*) FROM group_foreign_teacher WHERE teacher_id = @teacher";

            SqlParameter[] sqlParameters = new SqlParameter[1];

            SqlParameter paraTeacher = new SqlParameter("@teacher", SqlDbType.BigInt);
            paraTeacher.Value = teacherId;
            sqlParameters[0] = paraTeacher;

            return ExecuteCountInteger(query, sqlParameters);
        }

        public void AssingGroupToTeacher(int groupId, int teacherId)
        {
            string query = "UPDATE teacher SET group_id = @group WHERE id = @teacher";

            SqlParameter[] sqlParameters = new SqlParameter[2];

            SqlParameter paraGroup = new SqlParameter("@group", SqlDbType.BigInt);
            paraGroup.Value = groupId;
            sqlParameters[0] = paraGroup;

            SqlParameter paraTeacher = new SqlParameter("@teacher", SqlDbType.BigInt);
            paraTeacher.Value = teacherId;
            sqlParameters[1] = paraTeacher;

            ExecuteEditQuery(query, sqlParameters);
        }

        public void DeleteMentor(int groupId, int teacherId)
        {
            string query = "DELETE FROM group_foreign_teacher WHERE group_id = @group AND teacher_id = @teacher";

            SqlParameter[] sqlParameters = new SqlParameter[2];

            SqlParameter paraGroup = new SqlParameter("@group", SqlDbType.BigInt);
            paraGroup.Value = groupId;
            sqlParameters[0] = paraGroup;

            SqlParameter paraTeacher = new SqlParameter("@teacher", SqlDbType.BigInt);
            paraTeacher.Value = teacherId;
            sqlParameters[1] = paraTeacher;

            ExecuteEditQuery(query, sqlParameters);
        }

        public void deleteGroupFromTeacher(int teacherId)
        {
            string query = "UPDATE teacher SET group_id = 0 WHERE id = @teacher ";

            SqlParameter[] sqlParameters = new SqlParameter[1];

            SqlParameter paraTeacher = new SqlParameter("@teacher", SqlDbType.BigInt);
            paraTeacher.Value = teacherId;
            sqlParameters[0] = paraTeacher;

            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
