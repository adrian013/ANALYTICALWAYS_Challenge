using AcmeSchool.Commands;
using AcmeSchool.DTOs;
using AcmeSchool.Service;
using Microsoft.AspNetCore.Mvc;

namespace AcmeSchool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;
        private readonly ICourseService _courseService;

        public CourseController(ILogger<CourseController> logger, ICourseService courseService)
        {
            _logger = logger;
            _courseService = courseService;
        }

        [HttpGet]
        public ActionResult GetAllWithStudents(Guid? courseId)
        {
            if(!courseId.HasValue)
            {
                return BadRequest();
            }

            var courses = _courseService.GetAllWithStudents(courseId.Value);
            return Ok(courses);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateCourseCommand createCourseCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _courseService.Create(createCourseCommand);
            return Ok();
        }
      
    }
}
