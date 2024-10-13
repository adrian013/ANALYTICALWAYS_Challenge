using AcmeSchool.Model;

namespace AcmeSchool.DTOs
{
    public class EnrollmentDTO
    {
        public string PaymentId { get; set; }
        public StudentDTO Student { get; set; }
    }
}
