using System.Collections.Generic;
using SPA.Models;

namespace SPA.Data
{
    public static class StudentData
    {
        public static List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student{FirstName = "St_1", LastName = "Bla_1", Class = "TestClass_1", Email = "st_1@mail.com", StudentID = 1},
                new Student{FirstName = "St_2", LastName = "Bla_2", Class = "TestClass_2", Email = "st_2@mail.com", StudentID = 2}
            };
        }
    }
}