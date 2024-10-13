namespace AcmeSchool.Model
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public IEnumerable<Course>? Courses { get; set; }
    }
}
