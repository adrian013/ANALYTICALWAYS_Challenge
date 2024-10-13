using AcmeSchool.Commands;
using AcmeSchool.DTOs;
using AcmeSchool.External;
using AcmeSchool.Service;
using Microsoft.AspNetCore.Mvc;

namespace AcmeSchool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly ILogger<EnrollmentController> _logger;
        private readonly IEnrollmentService _enrollmentService;
        private readonly ICourseService _courseService;
        private readonly IPaymentGateway _paymentGateway;

        public EnrollmentController(ILogger<EnrollmentController> logger, IEnrollmentService enrollmentService, ICourseService courseService, IPaymentGateway paymentGateway)
        {
            _logger = logger;
            _enrollmentService = enrollmentService;
            _courseService = courseService;
            _paymentGateway = paymentGateway;
        }


        [HttpPost]
        [Route("PaymentLink")]
        public IActionResult PaymentLink([FromBody] PayRegistrationFeeCommand payRegistrationFeeCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = _courseService.GetById(payRegistrationFeeCommand.CourseId);

            if (course == null) 
            {
                throw new KeyNotFoundException();
            }

            if(!course.RegistrationFee.HasValue || course.RegistrationFee.Value <= 0)
            {
                return BadRequest("No fee for course");
            }

            return Ok(_paymentGateway.GetPaymentLink(course.RegistrationFee.Value));
        }

      

        [HttpPost()]
        public IActionResult Enroll([FromBody] EnrollStudentCommand enrollStudentCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _enrollmentService.Create(enrollStudentCommand);
            return Ok();
        }
    }
}
