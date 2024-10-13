using AcmeSchool.Model;
using AcmeSchool.Persistence.InMemory;

namespace AcmeSchool.Repositories
{
    public class EnrollmentRepository : Repository<Enrollment, ApiContext>, IEnrollmentRepository
    {
        private readonly ApiContext _context;

        public EnrollmentRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
    }
}
