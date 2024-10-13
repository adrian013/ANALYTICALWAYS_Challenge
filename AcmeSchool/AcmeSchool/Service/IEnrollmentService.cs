using AcmeSchool.Commands;

namespace AcmeSchool.Service
{
    public interface IEnrollmentService
    {
        void Create(EnrollStudentCommand enrollStudentCommand);
    }
}
