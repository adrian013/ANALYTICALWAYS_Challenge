using AcmeSchool.Commands;
using AcmeSchool.Controllers;
using AcmeSchool.DTOs;
using AcmeSchool.Model;
using AcmeSchool.Repositories;
using AcmeSchool.Service;
using AcmeSchool.Test.Helper;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AcmeSchool.Test.Services
{
    public class StudentServiceTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IStudentRepository> _studentRepositoryMock;
        public StudentServiceTest()
        {
            _mapperMock = new Mock<IMapper>();
            _studentRepositoryMock = new Mock<IStudentRepository>();
        }

        #region GetStudentById
        [Fact]
        public void GetStudentById_Returns_Student_If_Exists()
        {
            var student = new Student { Age = 99, Id = Guid.NewGuid(), Name = "FakeStudent" };
            var studentDTO = new StudentDTO { Age = 99, Name = "FakeStudent" };

            _mapperMock.Setup(m => m.Map<StudentDTO>(It.IsAny<Student>())).Returns(studentDTO);
            _studentRepositoryMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns(student);

            var service = new StudentService(_mapperMock.Object, _studentRepositoryMock.Object);

            var result = service.GetById(Guid.NewGuid());

            Assert.NotNull(result);

            string fakeStudentSerialized = JsonSerializer.Serialize(studentDTO);
            string resultSerialized = JsonSerializer.Serialize(result);

            Assert.Equal(fakeStudentSerialized, resultSerialized);
        }

        [Fact]
        public void GetStudentById_Returns_Null_If_Student_Not_Exists()
        {
            _mapperMock.Setup(m => m.Map<StudentDTO>(It.IsAny<Student>())).Returns((StudentDTO)null);
            _studentRepositoryMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns((Student)null);

            var service = new StudentService(_mapperMock.Object, _studentRepositoryMock.Object);

            var result = service.GetById(Guid.NewGuid());

            Assert.Null(result);
        }
        #endregion

        #region CreateStudent

        [Fact]
        public void CreateStudent_Returns_Guid_And_Not_Throw_Exception_If_Successfully()
        {
            var guid = new Guid("10000000-0000-0000-0000-000000000000");
            var command = new CreateStudentCommand { Age = 20, Name = "FakeName FakeLastName" };
            var student = new Student { Id = guid, Age = 20, Name = "FakeName FakeLastName" };

            var service = new StudentService(_mapperMock.Object, _studentRepositoryMock.Object);
            _mapperMock.Setup(m => m.Map<Student>(It.IsAny<CreateStudentCommand>())).Returns(student);

            var exception = Record.Exception(() => service.Create(command));

            Assert.Null(exception);
        }

        #endregion
    }
}
