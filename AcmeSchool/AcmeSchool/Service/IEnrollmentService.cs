using AcmeSchool.Commands;

namespace AcmeSchool.Service
{
    public interface IEnrollmentService
    {
        Guid Create(EnrollStudentCommand enrollStudentCommand);
    }
}
