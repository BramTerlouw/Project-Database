using System;
using System.Collections.Generic;

namespace SomerenModel
{
    public class Student
    {
        public readonly int Id;
        public readonly string Name;
        public readonly string Email;
        public readonly int age;
        public readonly bool dutch_student;
        public readonly int group_id;
        public readonly int room_id;

        //id , name, email, age , dutch_student, group_id. room_id
        public Student(int v1, string v2, string v3, int v4, bool v5, int v6, int v7)
        {
            this.Id = v1;
            this.Name = v2;
            this.Email = v3;
            this.age = v4;
            this.dutch_student = v5;
            this.group_id = v6;
            this.room_id = v7;
        }

        public string[] dataGridList()
        {
            return new string[] { "id", "name", "email", "age", "dutch_student", "group", "room" };
        }

        public string[] dataGrid(Student student)
        {
            string dutchStudent = this.dutchStudent(student.dutch_student);
            return new string[] {
                student.Id.ToString(),
                student.Name,
                student.Email,
                student.age.ToString(),
                dutchStudent,
                student.group_id.ToString(),
                student.room_id.ToString(),
            };
        }

        public string dutchStudent(bool b)
        {
            return b ? "true" : "false";
        }
    }
}
