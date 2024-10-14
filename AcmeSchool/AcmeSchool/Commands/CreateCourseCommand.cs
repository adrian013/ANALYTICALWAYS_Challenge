using System.ComponentModel.DataAnnotations;

namespace AcmeSchool.Commands
{
    public class CreateCourseCommand
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        
        public decimal? RegistrationFee { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
       
        [Required]
        public DateTime EndtDate { get; set; }
    }
}
