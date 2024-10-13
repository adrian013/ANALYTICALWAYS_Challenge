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
        [Route("GetAllWithStudents")]
        public ActionResult GetAllWithStudents()
        {
            var courses = _courseService.GetAllWithStudents();
            return Ok(courses);
        }

        [HttpGet]
        public ActionResult Get(Guid? courseId)
        {
            if (!courseId.HasValue)
            {
                return BadRequest();
            }

            var courses = _courseService.GetById(courseId.Value);
            return Ok(courses);
        }


        [HttpPost]
        public IActionResult Post([FromBody] CreateCourseCommand createCourseCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityId = _courseService.Create(createCourseCommand);
            return Ok(entityId);
        }
      
    }
}
