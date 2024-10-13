using AcmeSchool.Model;
using AcmeSchool.Persistence.InMemory;

namespace AcmeSchool.Repositories
{
    public class StudentRepository : Repository<Student, ApiContext>, IStudentRepository
    {
        private readonly ApiContext _context;

        public StudentRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
    }
}
