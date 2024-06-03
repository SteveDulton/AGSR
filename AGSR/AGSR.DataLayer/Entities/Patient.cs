using AGSR.DataLayer.Entities.Enum;

namespace AGSR.DataLayer.Entities
{
    public class Patient
    {
        public Guid Id { get; set; }

        public string Use { get; set; }

        public string Family { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public bool Active { get; set; }
    }
}
/*
 {
  "name": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "use": "official",
    "family": "Иванов",
    "given": [
      "Иван", "Иванович"
    ]
  },
  "gender": "Male",
  "birthDate": "2024-05-31T15:08:01.297Z",
  "active": true
}
 
 */