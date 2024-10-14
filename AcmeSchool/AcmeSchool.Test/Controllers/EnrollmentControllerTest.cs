using AcmeSchool.Commands;
using AcmeSchool.Controllers;
using AcmeSchool.DTOs;
using AcmeSchool.External;
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
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AcmeSchool.Test.Controllers
{
    public class EnrollmentControllerTest
    {
        private readonly Mock<ILogger<EnrollmentController>> _loggerMock;
        private readonly Mock<IEnrollmentService> _enrollmentServiceMock;
        private readonly Mock<ICourseService> _courseServiceMock;
        private readonly Mock<IPaymentGateway> _paymentGatewayMock;

        public EnrollmentControllerTest()
        {
            _loggerMock = new Mock<ILogger<EnrollmentController>>();
            _enrollmentServiceMock = new Mock<IEnrollmentService>();
            _courseServiceMock = new Mock<ICourseService>();
            _paymentGatewayMock = new Mock<IPaymentGateway>();
        }

        #region Enroll
        [Fact]
        public void Enroll_Returns_200_If_Date_Changes_Successfully()
        {
            var command = new EnrollStudentCommand { CourseId = Guid.NewGuid(), StudentId = Guid.NewGuid(), PaymentId = "FakePaymentId" };
            var guid = new Guid("10000000-0000-0000-0000-000000000000");

            _enrollmentServiceMock.Setup(m => m.Create(It.IsAny<EnrollStudentCommand>())).Returns(guid);

            var controller = new EnrollmentController(_loggerMock.Object, _enrollmentServiceMock.Object, _courseServiceMock.Object, _paymentGatewayMock.Object);

            var result = controller.Enroll(command);

            Assert.IsType<OkObjectResult>(result);

            Assert.Equal(guid, ((OkObjectResult)result).Value);
        }

        [Fact]
        public void Enroll_Returns_400_If_Wrong_Parameters()
        {
            var command = new EnrollStudentCommand();

            var controller = new EnrollmentController(_loggerMock.Object, _enrollmentServiceMock.Object, _courseServiceMock.Object, _paymentGatewayMock.Object);

            ModelStateTestHelper.MockModelState(command, controller);
            var result = controller.Enroll(command);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        #endregion

        #region PaymentLink
        [Fact]
        public void PaymentLink_Returns_200_If_Date_Changes_Successfully()
        {
            var command = new PayRegistrationFeeCommand { CourseId = Guid.NewGuid() };
            var link = "https://FakePaymentLink.com";
            var course = new CourseDTO { Name = "FakeCourse", StartDate = DateTime.Now, EndtDate = DateTime.Now, RegistrationFee = 99 };

            _paymentGatewayMock.Setup(m => m.GetPaymentLink(It.IsAny<decimal>())).Returns(link);
            _courseServiceMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns(course);

            var controller = new EnrollmentController(_loggerMock.Object, _enrollmentServiceMock.Object, _courseServiceMock.Object, _paymentGatewayMock.Object);

            var result = controller.PaymentLink(command);

            Assert.IsType<OkObjectResult>(result);

            Assert.Equal(link, ((OkObjectResult)result).Value);
        }

        [Fact]
        public void PaymentLink_Returns_404_If_Course_Not_Exists()
        {
            var command = new PayRegistrationFeeCommand { CourseId = Guid.NewGuid() };

            var controller = new EnrollmentController(_loggerMock.Object, _enrollmentServiceMock.Object, _courseServiceMock.Object, _paymentGatewayMock.Object);

            _courseServiceMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns((CourseDTO)null);

            var result = controller.PaymentLink(command);

            Assert.IsType<NotFoundResult>(result);
        }


        [Fact]
        public void PaymentLink_Returns_400_If_Course_Has_No_Register_Fee_Amount()
        {
            var command = new PayRegistrationFeeCommand { CourseId = Guid.NewGuid() };
            var course = new CourseDTO { Name = "FakeCourse", StartDate = DateTime.Now, EndtDate = DateTime.Now};

            var controller = new EnrollmentController(_loggerMock.Object, _enrollmentServiceMock.Object, _courseServiceMock.Object, _paymentGatewayMock.Object);

            _courseServiceMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns(course);

            var result = controller.PaymentLink(command);

            Assert.IsType<BadRequestObjectResult>(result);
        }
        #endregion
    }
}
