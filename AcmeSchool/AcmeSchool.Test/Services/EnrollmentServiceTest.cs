using AcmeSchool.Commands;
using AcmeSchool.Controllers;
using AcmeSchool.DTOs;
using AcmeSchool.External;
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
    public class EnrollmentServiceTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ICourseRepository> _courseRepositoryMock;
        private readonly Mock<IStudentRepository> _studentRepositoryMock;
        private readonly Mock<IEnrollmentRepository> _enrollmentRepositoryMock;
        private readonly Mock<IPaymentGateway> _paymentGatewayMock;
        public EnrollmentServiceTest()
        {
            _mapperMock = new Mock<IMapper>();
            _courseRepositoryMock = new Mock<ICourseRepository>();
            _studentRepositoryMock = new Mock<IStudentRepository>();
            _enrollmentRepositoryMock = new Mock<IEnrollmentRepository>();
            _paymentGatewayMock = new Mock<IPaymentGateway>();
        }

        #region CreateEnrollment

        [Fact]
        public void CreateEnrollment_Returns_Guid_And_Not_Throw_Exception_If_Successfully()
        {
            string paymentId = "FakePaymentId";
            var guidCourse = new Guid("10000000-0000-0000-0000-000000000000");
            var guidStudent = new Guid("20000000-0000-0000-0000-000000000000");
            var command = new EnrollStudentCommand { CourseId = Guid.NewGuid(), StudentId = Guid.NewGuid(), PaymentId = paymentId };

            var course = new Course { Id = guidCourse, Name = "FakeCourse", StartDate = DateTime.Now, EndtDate = DateTime.Now, RegistrationFee = 99 };
            var student = new Student { Id = guidStudent, Age = 20, Name = "FakeName FakeLastName" };
            var enrollment = new Enrollment { CourseId = guidCourse, StudentId = guidStudent, PaymentId = paymentId };

            var service = new EnrollmentService(_mapperMock.Object, _enrollmentRepositoryMock.Object, _studentRepositoryMock.Object, _courseRepositoryMock.Object, _paymentGatewayMock.Object);
            _mapperMock.Setup(m => m.Map<Enrollment>(It.IsAny<EnrollStudentCommand>())).Returns(enrollment);

            _courseRepositoryMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns(course);
            _studentRepositoryMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns(student);
            _paymentGatewayMock.Setup(m => m.ValidatePayment(It.IsAny<string>())).Returns(true);

            var exception = Record.Exception(() => service.Create(command));

            Assert.Null(exception);
        }

        [Fact]
        public void CreateEnrollment_Throws_KeyNotFoundException_If_Course_NotExists()
        {
            string paymentId = "FakePaymentId";
            var guidCourse = new Guid("10000000-0000-0000-0000-000000000000");
            var guidStudent = new Guid("20000000-0000-0000-0000-000000000000");
            var command = new EnrollStudentCommand { CourseId = Guid.NewGuid(), StudentId = Guid.NewGuid(), PaymentId = paymentId };

            var student = new Student { Id = guidStudent, Age = 20, Name = "FakeName FakeLastName" };
            var enrollment = new Enrollment { CourseId = guidCourse, StudentId = guidStudent, PaymentId = paymentId };

            var service = new EnrollmentService(_mapperMock.Object, _enrollmentRepositoryMock.Object, _studentRepositoryMock.Object, _courseRepositoryMock.Object, _paymentGatewayMock.Object);
            _mapperMock.Setup(m => m.Map<Enrollment>(It.IsAny<EnrollStudentCommand>())).Returns(enrollment);

            _courseRepositoryMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns((Course)null);
            _studentRepositoryMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns(student);
            _paymentGatewayMock.Setup(m => m.ValidatePayment(It.IsAny<string>())).Returns(true);

            Assert.Throws<KeyNotFoundException>(() => service.Create(command));
        }

        [Fact]
        public void CreateEnrollment_Throws_KeyNotFoundException_If_Student_NotExists()
        {
            string paymentId = "FakePaymentId";
            var guidCourse = new Guid("10000000-0000-0000-0000-000000000000");
            var guidStudent = new Guid("20000000-0000-0000-0000-000000000000");
            var command = new EnrollStudentCommand { CourseId = Guid.NewGuid(), StudentId = Guid.NewGuid(), PaymentId = paymentId };

            var course = new Course { Id = guidCourse, Name = "FakeCourse", StartDate = DateTime.Now, EndtDate = DateTime.Now, RegistrationFee = 99 };
            var enrollment = new Enrollment { CourseId = guidCourse, StudentId = guidStudent, PaymentId = paymentId };

            var service = new EnrollmentService(_mapperMock.Object, _enrollmentRepositoryMock.Object, _studentRepositoryMock.Object, _courseRepositoryMock.Object, _paymentGatewayMock.Object);
            _mapperMock.Setup(m => m.Map<Enrollment>(It.IsAny<EnrollStudentCommand>())).Returns(enrollment);

            _courseRepositoryMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns(course);
            _studentRepositoryMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns((Student)null);
            _paymentGatewayMock.Setup(m => m.ValidatePayment(It.IsAny<string>())).Returns(true);

            Assert.Throws<KeyNotFoundException>(() => service.Create(command));
        }

        [Fact]
        public void CreateEnrollment_Throws_KeyNotFoundException_If_PaymentId_IS_Not_Valid()
        {
            string paymentId = "FakePaymentId";
            var guidCourse = new Guid("10000000-0000-0000-0000-000000000000");
            var guidStudent = new Guid("20000000-0000-0000-0000-000000000000");
            var command = new EnrollStudentCommand { CourseId = Guid.NewGuid(), StudentId = Guid.NewGuid(), PaymentId = paymentId };

            var course = new Course { Id = guidCourse, Name = "FakeCourse", StartDate = DateTime.Now, EndtDate = DateTime.Now, RegistrationFee = 99 };
            var student = new Student { Id = guidStudent, Age = 20, Name = "FakeName FakeLastName" };
            var enrollment = new Enrollment { CourseId = guidCourse, StudentId = guidStudent, PaymentId = paymentId };

            var service = new EnrollmentService(_mapperMock.Object, _enrollmentRepositoryMock.Object, _studentRepositoryMock.Object, _courseRepositoryMock.Object, _paymentGatewayMock.Object);
            _mapperMock.Setup(m => m.Map<Enrollment>(It.IsAny<EnrollStudentCommand>())).Returns(enrollment);

            _courseRepositoryMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns(course);
            _studentRepositoryMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns(student);
            _paymentGatewayMock.Setup(m => m.ValidatePayment(It.IsAny<string>())).Returns(false);

            Assert.Throws<ArgumentException>(() => service.Create(command));
        }

        #endregion
    }
}
