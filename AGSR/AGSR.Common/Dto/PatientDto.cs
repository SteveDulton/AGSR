namespace AGSR.Common.Dto
{
    public class PatientDto
    {
        public PatientNameDto Name { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public bool Active { get; set; }
    }
}
