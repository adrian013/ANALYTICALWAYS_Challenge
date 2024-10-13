using AcmeSchool.Persistence.InMemory;
using AcmeSchool.Persistence;
using AcmeSchool.Model;

namespace AcmeSchool.Repositories
{
    public interface ICourseRepository : IRepository<Course>, IUnitOfWork
    {
        IEnumerable<Course> GetAllWithStudents();

    }
}
