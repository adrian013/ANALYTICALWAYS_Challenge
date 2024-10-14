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
    public class StudentControllerTest
    {
        private readonly Mock<ILogger<StudentController>> _loggerMock;
        private readonly Mock<IStudentService> _studentServiceMock;

        public StudentControllerTest()
        {
            _loggerMock = new Mock<ILogger<StudentController>>();
            _studentServiceMock = new Mock<IStudentService>();
        }


        #region GetStudent
        [Fact]
        public void GetStudent_Returns_200_If_Student_Exists()
        {
            var output = new StudentDTO { Age = 20, Name = "FakeName FakeLastName" };

            _studentServiceMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns(output);

            var controller = new StudentController(_loggerMock.Object, _studentServiceMock.Object);

            var result = controller.Get(Guid.NewGuid());

            Assert.IsType<OkObjectResult>(result);

            string outputSerialized = JsonSerializer.Serialize(output);
            string resultSerialized = JsonSerializer.Serialize(((OkObjectResult)result).Value);

            Assert.Equal(outputSerialized, resultSerialized);
        }

        [Fact]
        public void GetStudent_Throws_KeyNotFoundExceptions_If_Student_Does_Not_Exist()
        {
            _studentServiceMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns((StudentDTO)null);

            var controller = new StudentController(_loggerMock.Object, _studentServiceMock.Object);
            var result = controller.Get(Guid.NewGuid());

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetStudent_Returns_400_If_wrong_parameter()
        {
            var controller = new StudentController(_loggerMock.Object, _studentServiceMock.Object);
            var result = controller.Get(null);

            Assert.IsType<BadRequestResult>(result);
        }
        #endregion


        #region PostStudent
        [Fact]
        public void PostStudent_Returns_200_If_Date_Changes_Successfully()
        {
            var command = new CreateStudentCommand { Age = 20, Name = "FakeName FakeLastName" };
            var guid = new Guid("10000000-0000-0000-0000-000000000000");

            _studentServiceMock.Setup(m => m.Create(It.IsAny<CreateStudentCommand>())).Returns(guid);

            var controller = new StudentController(_loggerMock.Object, _studentServiceMock.Object);

            var result = controller.Post(command);

            Assert.IsType<OkObjectResult>(result);

            Assert.Equal(guid, ((OkObjectResult)result).Value);
        }

        [Fact]
        public void PostStudent_Returns_400_If_Wrong_Parameters()
        {
            var controller = new StudentController(_loggerMock.Object, _studentServiceMock.Object);
            var command = new CreateStudentCommand { Age = 5, Name = "FakeName FakeLastName" };

            ModelStateTestHelper.MockModelState(command, controller);
            var result = controller.Post(command);

            Assert.IsType<BadRequestObjectResult>(result);
        }
        #endregion
    }
}
