using AGSR.DataLayer.Entities;

namespace AGSR.DataLayer.Repository.IRepository
{
    public interface IPatientRepository
    {
        Task<Patient> GetPatient(Guid id);

        Task CreatePatientAsync(Patient patient);

        Task DeletePatientAsync(Guid id);

        Task<IEnumerable<Patient>> GetPatientListAsync();

        Task UpdatePatientAsync(Patient patient);
    }
}
