using AcmeSchool.Commands;
using AcmeSchool.DTOs;

namespace AcmeSchool.Service
{
    public class CourseService : ICourseService
    {
        public void Create(CreateCourseCommand createCourseCommand)
        {
            throw new NotImplementedException();
        }

        public void Enroll(EnrollStudentCommand enrollStudentCommand)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseDTO> GetAllWithStudents(Guid courseId)
        {
            throw new NotImplementedException();
        }

        public CourseDTO GetById(Guid courseId)
        {
            throw new NotImplementedException();
        }
    }
}
