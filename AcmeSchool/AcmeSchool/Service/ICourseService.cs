using AcmeSchool.Commands;
using AcmeSchool.DTOs;

namespace AcmeSchool.Service
{
    public interface ICourseService
    {
        void Create(CreateCourseCommand createCourseCommand);
        void Enroll(EnrollStudentCommand enrollStudentCommand);
        IEnumerable<CourseDTO> GetAllWithStudents(Guid courseId);
        CourseDTO GetById(Guid courseId);
    }
}
