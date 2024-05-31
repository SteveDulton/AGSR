namespace AGSR.Common.Dto
{
    public class PatientNameDto
    {
        public Guid Id { get; set; }

        public string Use { get; set; }

        public string Family { get; set; }

        public string[] Given { get; set; }
    }
}
