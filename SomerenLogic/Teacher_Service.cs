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
    public class Teacher_Service
    {
        readonly Teacher_DAO dao = new Teacher_DAO();

        public List<Teacher> GetTeachers()
        {
            try
            {
                // get the list with teachers by calling a function from the DAL layer
                List<Teacher> teacher = dao.Db_Get_All_Teachers();
                return teacher; // return list
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong!");
            }
        }

        public void AddMentor(int groupId, int teacherID)
        {
            if (dao.CheckExistingMentor(teacherID) > 0)
            {
                throw new Exception("This person is already a mentor");
            }
            else
            {
                dao.AddMentor(groupId, teacherID);
                dao.AssingGroupToTeacher(groupId, teacherID);
            }
        }

        public void DeleteMentor(int groupId, int teacherId)
        {
            dao.DeleteMentor(groupId, teacherId);
            dao.deleteGroupFromTeacher(teacherId);
        }
    }
}
