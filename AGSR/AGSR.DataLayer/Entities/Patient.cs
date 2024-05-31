using AGSR.DataLayer.Entities.Enum;

namespace AGSR.DataLayer.Entities
{
    public class Patient
    {
        public PatientName Name { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public bool Active { get; set; }
    }
}
