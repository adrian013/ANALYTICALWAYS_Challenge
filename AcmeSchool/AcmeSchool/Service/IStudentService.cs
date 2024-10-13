using AcmeSchool.Commands;
using AcmeSchool.DTOs;

namespace AcmeSchool.Service
{
    public interface IStudentService
    {
        Guid Create(CreateStudentCommand createStudentCommand);
        StudentDTO GetById(Guid studentId);

    }
}
