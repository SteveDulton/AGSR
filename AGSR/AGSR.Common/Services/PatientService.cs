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

        private Patient ConvertToEntity(PatientDto dto)
        {
            return new()
            {
                Name = new PatientName
                {
                    Family = dto.Name.Family,
                    Given = dto.Name.Given,
                    Use = dto.Name.Use,
                    Id = Guid.NewGuid()
                },
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
                    Family = patient.Name.Family,
                    Given = patient.Name.Given,
                    Use = patient.Name.Use,
                    Id = patient.Name.Id
                },
                Active = patient.Active,
                BirthDate = patient.BirthDate,
                Gender = patient.Gender.ToString()
            };

        }
    }
}
