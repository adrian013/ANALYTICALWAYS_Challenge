using AcmeSchool.Commands;
using AcmeSchool.Controllers;
using AcmeSchool.DTOs;
using AcmeSchool.Model;
using AcmeSchool.Service;
using AcmeSchool.Test.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AcmeSchool.Test.Controllers
{
    public class CourseControllerTest
    {
        private readonly Mock<ILogger<CourseController>> _loggerMock;
        private readonly Mock<ICourseService> _courseServiceMock;

        public CourseControllerTest()
        {
            _loggerMock = new Mock<ILogger<CourseController>>();
            _courseServiceMock = new Mock<ICourseService>();
        }


        #region GetCourse
        [Fact]
        public void GetCourse_Returns_200_If_Course_Exists()
        {
            var output = new CourseDTO { Name = "Fake Course", StartDate = DateTime.Now, EndtDate = DateTime.Now, RegistrationFee = 10 };

            _courseServiceMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns(output);

            var controller = new CourseController(_loggerMock.Object, _courseServiceMock.Object);

            var result = controller.Get(Guid.NewGuid());

            Assert.IsType<OkObjectResult>(result);

            string outputSerialized = JsonSerializer.Serialize(output);
            string resultSerialized = JsonSerializer.Serialize(((OkObjectResult)result).Value);

            Assert.Equal(outputSerialized, resultSerialized);
        }

        [Fact]
        public void GetCourse_Throws_KeyNotFoundExceptions_If_Course_Does_Not_Exist()
        {
            _courseServiceMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns((CourseDTO)null);

            var controller = new CourseController(_loggerMock.Object, _courseServiceMock.Object);
            var result = controller.Get(Guid.NewGuid());

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetCourse_Returns_400_If_wrong_parameter()
        {
            var controller = new CourseController(_loggerMock.Object, _courseServiceMock.Object);
            var result = controller.Get(null);

            Assert.IsType<BadRequestResult>(result);
        }
        #endregion

        #region GetAllWithStudents
        [Fact]
        public void GetAllWithStudents_Returns_200_If_Any_Course_Exists()
        {
            var output = new List<CourseDTO>
            {
                new CourseDTO { 
                    Name = "Fake Course", 
                    StartDate = DateTime.Now, 
                    EndtDate = DateTime.Now, 
                    RegistrationFee = 10,  
                    Enrollments = new List<EnrollmentDTO>{ 
                        new EnrollmentDTO { 
                            PaymentId = "FakePaymentId",
                            Student = new StudentDTO
                            {
                                Name = "Fake Student",
                                Age = 99
                            }
                        }
                    }
                }
            };

            _courseServiceMock.Setup(m => m.GetAllWithStudents()).Returns(output);

            var controller = new CourseController(_loggerMock.Object, _courseServiceMock.Object);

            var result = controller.GetAllWithStudents();

            Assert.IsType<OkObjectResult>(result);

            string outputSerialized = JsonSerializer.Serialize(output);
            string resultSerialized = JsonSerializer.Serialize(((OkObjectResult)result).Value);

            Assert.Equal(outputSerialized, resultSerialized);
        }

        [Fact]
        public void GetAllWithStudents_returns_204_If_No_Course_Exist()
        {
            _courseServiceMock.Setup(m => m.GetAllWithStudents()).Returns((List<CourseDTO>)null);

            var controller = new CourseController(_loggerMock.Object, _courseServiceMock.Object);
            var result = controller.GetAllWithStudents();

            Assert.IsType<NoContentResult>(result);
        }

        #endregion


        #region PostCourse
        [Fact]
        public void PostCourse_Returns_200_If_Date_Changes_Successfully()
        {
            var command = new CreateCourseCommand { Name = "FakeName FakeLastName", RegistrationFee = 99, StartDate = DateTime.Now, EndtDate = DateTime.Now };
            var guid = new Guid("10000000-0000-0000-0000-000000000000");

            _courseServiceMock.Setup(m => m.Create(It.IsAny<CreateCourseCommand>())).Returns(guid);

            var controller = new CourseController(_loggerMock.Object, _courseServiceMock.Object);

            var result = controller.Post(command);

            Assert.IsType<OkObjectResult>(result);

            Assert.Equal(guid, ((OkObjectResult)result).Value);
        }

        [Fact]
        public void PostCourse_Returns_400_If_Wrong_Parameters()
        {
            var command = new CreateCourseCommand();

            var controller = new CourseController(_loggerMock.Object, _courseServiceMock.Object);

            ModelStateTestHelper.MockModelState(command, controller);
            var result = controller.Post(command);

            Assert.IsType<BadRequestObjectResult>(result);
        }
        #endregion
    }
}
