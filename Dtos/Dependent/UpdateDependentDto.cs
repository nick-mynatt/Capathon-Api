namespace Capathon.Dtos.Dependent
{
    public class UpdateDependentDto
    {
        public int DId { get; set; }

        public int UId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? Age { get; set; }

        public string? Gender { get; set; }

        public string? Accomodations { get; set; }

        public string? MedicalInfo { get; set; }

        //ublic virtual User UIdNavigation { get; set; } = null!; ERROR HERE
    }
}