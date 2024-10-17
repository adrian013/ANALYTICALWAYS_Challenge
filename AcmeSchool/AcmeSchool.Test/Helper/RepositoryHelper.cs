using AcmeSchool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchool.Test.Helper
{
    internal static class RepositoryHelper
    {
        public static IEnumerable<Student> FakeStudents()
        {
            var students = new List<Student>();

            var student1 = new Student
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                Age = 99,
                Name = "Fake Student 1"
            };

            var student2 = new Student
            {
                Id = new Guid("00000000-0000-0000-0000-000000000002"),
                Age = 99,
                Name = "Fake Student 2"
            };

            students.Add(student1);
            students.Add(student2);

            return students;
        }

        public static Student FakeStudent1()
        {
            return  new Student
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                Age = 99,
                Name = "Fake Student 1"
            };
        }
    }
}
