using AcmeSchool.Commands;

namespace AcmeSchool.Service
{
    public interface IStudentService
    {
        void Create(CreateStudentCommand createStudentCommand);
    }
}
