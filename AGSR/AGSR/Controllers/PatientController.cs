using AGSR.Common.Dto;
using AGSR.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AGSR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientService _patientService;

        public PatientController(ILogger<PatientController> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }

        [HttpGet("{id}")]
        public async Task<PatientDto> GetByIdAsync(Guid id)
        {
            return await _patientService.GetPatientByIdAsync(id);
        }

        [HttpGet(Name = "PatientList")]
        public async Task<IEnumerable<PatientDto>> GetListAsync()
        {
            return await _patientService.GetPatientListAsync();
        }

        [HttpPost]
        public async Task CreateAsync(PatientDto patientDto)
        {
            await _patientService.CreatePatientAsync(patientDto);
        }

        [HttpPut]
        public async Task UpdateAsync(PatientDto patientDto)
        {
            await _patientService.UpdatePatientAsync(patientDto);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _patientService.DeletePatientAsync(id);
        }

        [HttpGet("find/{birthdate}")]
        public async Task<PatientDto> GetByBirthdateAsync(DateTime birthdate)
        {
            return await _patientService.GetPatientByBirthdateAsync(birthdate);
        }
    }
}
