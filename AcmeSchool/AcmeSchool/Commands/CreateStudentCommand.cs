using System.ComponentModel.DataAnnotations;

namespace AcmeSchool.Commands
{
    public class CreateStudentCommand
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Range(18, int.MaxValue)]
        public int Age { get; set; }
    }
}
