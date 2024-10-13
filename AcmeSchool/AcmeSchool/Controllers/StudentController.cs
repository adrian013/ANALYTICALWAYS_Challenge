using AcmeSchool.Commands;
using AcmeSchool.DTOs;
using AcmeSchool.Service;
using Microsoft.AspNetCore.Mvc;

namespace AcmeSchool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }


        [HttpGet]
        public ActionResult Get(Guid? studentId)
        {
            if (!studentId.HasValue)
            {
                return BadRequest();
            }

            var courses = _studentService.GetById(studentId.Value);
            return Ok(courses);
        }


        [HttpPost]
        public IActionResult Post([FromBody] CreateStudentCommand createStudentCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityId = _studentService.Create(createStudentCommand);
            return Ok(entityId);
        }
    }
}
