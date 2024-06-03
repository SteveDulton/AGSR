using AGSR.Common.Dto;
using AGSR.Common.Interfaces;
using AGSR.DataLayer.Entities;
using AGSR.DataLayer.Entities.Enum;
using AGSR.DataLayer.Repository.IRepository;

namespace AGSR.Common.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task CreatePatientAsync(PatientDto dto)
        {
            await _patientRepository.CreatePatientAsync(ConvertToEntity(dto));
        }

        public async Task DeletePatientAsync(Guid id)
        {
            await _patientRepository.DeletePatientAsync(id);
        }

        public async Task<PatientDto> GetPatientByIdAsync(Guid id)
        {
            return ConvertToDto(await _patientRepository.GetPatient(id));
        }

        public async Task<IEnumerable<PatientDto>> GetPatientListAsync()
        {
            return new List<Patient>(await _patientRepository.GetPatientListAsync()).Select(p => ConvertToDto(p));
        }

        public async Task UpdatePatientAsync(PatientDto dto)
        {
            await _patientRepository.UpdatePatientAsync(ConvertToEntity(dto));
        }

        public async Task<IEnumerable<PatientDto>> GetPatientByBirthdateAsync(DateTime birthdate)
        {
            return new List<Patient>(await _patientRepository.GetPatientByBirthdate(birthdate)).Select(p => ConvertToDto(p));
        }

        private Patient ConvertToEntity(PatientDto dto)
        {
            return new()
            {
                Id = dto.Name.Id,
                Family = dto.Name.Family,
                FirstName = dto.Name.Given[0],
                Surname = dto.Name.Given[1],
                Use = dto.Name.Use,
                Active = dto.Active,
                BirthDate = dto.BirthDate,
                Gender = Enum.Parse<Gender>(dto.Gender)
            };
        }

        private PatientDto ConvertToDto(Patient patient)
        {
            return new()
            {
                Name = new PatientNameDto
                {
                    Family = patient.Family,
                    Given = new[] { patient.FirstName, patient.Surname },
                    Use = patient.Use,
                    Id = patient.Id
                },
                Active = patient.Active,
                BirthDate = patient.BirthDate,
                Gender = patient.Gender.ToString()
            };

        }
    }
}
