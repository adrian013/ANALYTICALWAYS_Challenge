namespace AcmeSchool.Model
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal RegistrationFee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }

        public IEnumerable<Student>? Students { get; set; }
    }
}
