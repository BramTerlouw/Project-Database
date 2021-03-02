using System;
using System.Collections.Generic;

namespace SomerenModel
{
    public class Student
    {
        public String Name { get; set; }
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }

        public Student(int v1, string v2)
        {
            Id = v1;
            Name = v2;
        }

        public Student(int v1, string v2, DateTime v3) 
        : this (v1, v2) {
            BirthDate = v3;
        }
    }
}
