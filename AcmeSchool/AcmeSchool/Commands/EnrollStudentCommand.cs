using System.ComponentModel.DataAnnotations;

namespace AcmeSchool.Commands
{
    public class EnrollStudentCommand
    {
        [Required]
        public Guid CourseId { get; set; }

        [Required]
        public Guid StudentId { get; set; }

        [Required(AllowEmptyStrings=false)]
        public string PaymentId { get; set; }
    }
}
