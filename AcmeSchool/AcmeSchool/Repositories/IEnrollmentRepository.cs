using AcmeSchool.Persistence.InMemory;
using AcmeSchool.Persistence;
using AcmeSchool.Model;

namespace AcmeSchool.Repositories
{
    public interface IEnrollmentRepository : IRepository<Enrollment>, IUnitOfWork
    {
    }
}
