namespace AcmeSchool.DTOs
{
    public class CourseDTO
    {
        public CourseDTO()
        {
            Enrollments = new List<EnrollmentDTO>();
        }

        public string Name { get; set; }
        public decimal? RegistrationFee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }

        public List<EnrollmentDTO> Enrollments{ get; set; }
    }
}
