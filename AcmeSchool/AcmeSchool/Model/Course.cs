using AcmeSchool.Persistence;

namespace AcmeSchool.Model
{
    public class Course : Entity
    {
        public string Name { get; set; }
        public decimal RegistrationFee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }

        public List<Enrollment> Enrollments { get; set; }
    }
}
