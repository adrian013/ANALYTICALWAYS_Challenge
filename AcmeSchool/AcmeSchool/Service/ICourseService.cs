using AcmeSchool.Commands;
using AcmeSchool.DTOs;

namespace AcmeSchool.Service
{
    public interface ICourseService
    {
        Guid Create(CreateCourseCommand createCourseCommand);
        IEnumerable<CourseDTO> GetAllWithStudents();
        CourseDTO GetById(Guid courseId);
    }
}
