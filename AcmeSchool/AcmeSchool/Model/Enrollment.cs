using AcmeSchool.Persistence;

namespace AcmeSchool.Model
{
    public class Enrollment : Entity
    {
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public string PaymentId { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
