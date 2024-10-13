namespace AcmeSchool.DTOs
{
    public class CourseDTO
    {
        public string Name { get; set; }
        public decimal RegistrationFee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }

        public IEnumerable<StudentDTO>? Students { get; set; }
    }
}
