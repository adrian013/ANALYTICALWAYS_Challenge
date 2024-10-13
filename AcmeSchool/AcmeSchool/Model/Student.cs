using AcmeSchool.Persistence;

namespace AcmeSchool.Model
{
    public class Student : Entity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Enrollment> Enrollments { get; set; }
    }
}
