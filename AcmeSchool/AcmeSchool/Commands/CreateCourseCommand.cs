namespace AcmeSchool.Commands
{
    public class CreateCourseCommand
    {
        public string Name { get; set; }
        public decimal? RegistrationFee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }
    }
}
