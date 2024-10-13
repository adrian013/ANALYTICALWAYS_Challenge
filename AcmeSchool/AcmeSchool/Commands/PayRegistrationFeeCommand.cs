using System.ComponentModel.DataAnnotations;

namespace AcmeSchool.Commands
{
    public class PayRegistrationFeeCommand
    {
        [Required]
        public Guid CourseId { get; set; }

    }
}
