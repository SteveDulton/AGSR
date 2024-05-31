using AGSR.DataLayer.Repository;
using AGSR.DataLayer.Repository.IRepository;

namespace AGSR.Extensions
{
    public static class AddRepositoryDependeciesExtensions
    {
        public static void AddRepositoriesDependecies(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
        }
    }
}