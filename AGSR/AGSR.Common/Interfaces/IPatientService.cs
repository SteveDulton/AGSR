using AGSR.Common.Dto;

namespace AGSR.Common.Interfaces
{
    public interface IPatientService
    {
        Task CreatePatientAsync(PatientDto dto);

        Task DeletePatientAsync(Guid id);

        Task<IEnumerable<PatientDto>> GetPatientListAsync();

        Task<PatientDto> GetPatientByIdAsync(Guid id);

        Task UpdatePatientAsync(PatientDto dto);
    }
}