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
    public class CourseServiceTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ICourseRepository> _courseRepositoryMock;
        public CourseServiceTest()
        {
            _mapperMock = new Mock<IMapper>();
            _courseRepositoryMock = new Mock<ICourseRepository>();
        }

        #region GetCourseById
        [Fact]
        public void GetCourseById_Returns_Course_If_Exists()
        {
            var now = DateTime.Now;
            var course = new Course { Id = Guid.NewGuid(), Name = "FakeCourse", StartDate = now, EndtDate = now, RegistrationFee = 99 };
            var courseDTO = new CourseDTO { Name = "FakeCourse", StartDate = now, EndtDate = now, RegistrationFee = 99 };

            _mapperMock.Setup(m => m.Map<CourseDTO>(It.IsAny<Course>())).Returns(courseDTO);
            _courseRepositoryMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns(course);

            var service = new CourseService(_mapperMock.Object, _courseRepositoryMock.Object);

            var result = service.GetById(Guid.NewGuid());

            Assert.NotNull(result);

            string fakeStudentSerialized = JsonSerializer.Serialize(courseDTO);
            string resultSerialized = JsonSerializer.Serialize(result);

            Assert.Equal(fakeStudentSerialized, resultSerialized);
        }

        [Fact]
        public void GetCourseById_Returns_Null_If_Course_Not_Exists()
        {
            _mapperMock.Setup(m => m.Map<CourseDTO>(It.IsAny<Course>())).Returns((CourseDTO)null);
            _courseRepositoryMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns((Course)null);

            var service = new CourseService(_mapperMock.Object, _courseRepositoryMock.Object);

            var result = service.GetById(Guid.NewGuid());

            Assert.Null(result);
        }
        #endregion

        #region CreateStudent

        [Fact]
        public void CreateCourse_Returns_Guid_And_Not_Throw_Exception_If_Successfully()
        {
            var guid = new Guid("10000000-0000-0000-0000-000000000000");
            var command = new CreateCourseCommand { Name = "FakeCourse", StartDate = DateTime.Now, EndtDate = DateTime.Now, RegistrationFee = 99 };
            var course = new Course { Id = guid, Name = "FakeCourse", StartDate = DateTime.Now, EndtDate = DateTime.Now, RegistrationFee = 99 };

            var service = new CourseService(_mapperMock.Object, _courseRepositoryMock.Object);
            _mapperMock.Setup(m => m.Map<Course>(It.IsAny<CreateCourseCommand>())).Returns(course);

            var exception = Record.Exception(() => service.Create(command));

            Assert.Null(exception);
        }

        #endregion

        #region GetAllWithStudents
        [Fact]
        public void GetAllWithStudents_Returns_Courses_If_Exists()
        {
            var now = DateTime.Now;
            var courseList = new List<Course> {
                new Course { Id = Guid.NewGuid(), Name = "FakeCourse", StartDate = now, EndtDate = now, RegistrationFee = 99 }
            };

            var courseDTO = new CourseDTO { Name = "FakeCourse", StartDate = now, EndtDate = now, RegistrationFee = 99 };
            var courseDTOList = new List<CourseDTO> { courseDTO };
            _mapperMock.Setup(m => m.Map<CourseDTO>(It.IsAny<Course>())).Returns(courseDTO);
            _courseRepositoryMock.Setup(m => m.GetAllWithStudents()).Returns(courseList);

            var service = new CourseService(_mapperMock.Object, _courseRepositoryMock.Object);

            var result = service.GetAllWithStudents();

            Assert.NotNull(result);

            string fakeStudentSerialized = JsonSerializer.Serialize(courseDTOList);
            string resultSerialized = JsonSerializer.Serialize(result);

            Assert.Equal(fakeStudentSerialized, resultSerialized);
        }

        [Fact]
        public void GetAllWithStudents_Returns_Null_No_Courses()
        {
            _mapperMock.Setup(m => m.Map<CourseDTO>(It.IsAny<Course>())).Returns((CourseDTO)null);
            _courseRepositoryMock.Setup(m => m.GetAllWithStudents()).Returns((IEnumerable<Course>)null);

            var service = new CourseService(_mapperMock.Object, _courseRepositoryMock.Object);

            var result = service.GetAllWithStudents();

            Assert.Equal(new List<CourseDTO>(), result);
        }
        #endregion

    }
}
