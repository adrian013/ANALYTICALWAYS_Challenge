using AcmeSchool.Model;
using AcmeSchool.Persistence.InMemory;

namespace AcmeSchool.Repositories
{
    public class CourseRepository : Repository<Course, ApiContext>, ICourseRepository
    {
        private readonly ApiContext _context;
        private readonly IEnrollmentRepository _enrollmentRepository;

        public CourseRepository(ApiContext context, IEnrollmentRepository enrollmentRepository) : base(context)
        {
            _context = context;
            _enrollmentRepository = enrollmentRepository;
        }

        public IEnumerable<Course> GetAllWithStudents()
        {
            //As in-memory database doesn't support relationships, I resolve the relation in the repository, for future implementations should re write the repositories

            var courses = _context.Courses.ToList();

            foreach(var course in courses)
            {
                //course.Enrollments = _enrollmentRepository.GetByIdAsync
            }

            return _context.Courses.ToList();

        }

    }
}
