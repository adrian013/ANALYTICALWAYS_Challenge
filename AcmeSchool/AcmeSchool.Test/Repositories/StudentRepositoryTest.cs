using AcmeSchool.DTOs;
using AcmeSchool.Model;
using AcmeSchool.Persistence.InMemory;
using AcmeSchool.Repositories;
using AcmeSchool.Test.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AcmeSchool.Test.Repositories
{
    public class StudentRepositoryTest
    {
        private const string IN_MEMORY_DB_NAME = "ACMESchool_InMemoryTest";

        public StudentRepositoryTest() { }

      

        private ApiContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(IN_MEMORY_DB_NAME)
                .Options;
            var context = new ApiContext(options);

            context.Students.AddRange(RepositoryHelper.FakeStudents());
            context.SaveChanges();

            return context;
        }

        [Fact]
        public void GetById_Returns_Proper_Student()
        {
            StudentRepository studentRepository = new StudentRepository(CreateDbContext());
            var student = studentRepository.GetById(new Guid("00000000-0000-0000-0000-000000000001"));

            Assert.Equal(JsonSerializer.Serialize(student), JsonSerializer.Serialize(RepositoryHelper.FakeStudent1()));
        }
    }
}
