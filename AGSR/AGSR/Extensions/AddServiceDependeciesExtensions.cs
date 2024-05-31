using AGSR.Common.Interfaces;
using AGSR.Common.Services;

namespace AGSR.Extensions
{
    public static class AddServiceDependeciesExtensions
    {
        public static void AddServicesDependecies(this IServiceCollection services)
        {
            services.AddScoped<IPatientService, PatientService>();
        }
    }
}