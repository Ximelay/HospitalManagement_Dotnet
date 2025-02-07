using Microsoft.AspNetCore.Mvc;
using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : Controller
    {
        public readonly IPatientService _patientService;
        private readonly ILogger<PatientsController> _logger;

        public PatientsController(IPatientService patientService, ILogger<PatientsController> logger)
        {
            _patientService = patientService;
            _logger = logger;
        }

        // Получение всех пациентов
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }

        //Получить по id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        // Создать нового пациента
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Patient patient)
        {
            if (patient == null)
            {
                _logger.LogError("Received a null patient object.");
                return BadRequest("Patient data is required");
            }

            _logger.LogInformation($"Received patient data: {patient.FirstName} {patient.LastName}");

            if (!ValidateAddresses(patient.Addresses))
            {
                return BadRequest("AddressTypeId and FullAddress are required for each address");
            }

            if (patient.Passport == null)
            {
                _logger.LogWarning("Patient has no passport data.");
                return BadRequest("Passport data is required");
            }

            try
            {
                var newPatient = await _patientService.CreatePatientAsync(patient);
                _logger.LogInformation($"Patient created successfully: {newPatient.Id}");
                return CreatedAtAction(nameof(GetById), new { id = newPatient.Id }, newPatient);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating patient: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        private bool ValidateAddresses(ICollection<Address> addresses)
        {
            if (addresses == null || addresses.Count == 0)
            {
                _logger.LogWarning("Patient has no addresses.");
                return false;
            }

            foreach (var address in addresses)
            {
                if (address.AddressTypeId == 0 || string.IsNullOrEmpty(address.FullAddress))
                {
                    _logger.LogWarning("Address missing required fields: AddressTypeId or FullAddress.");
                    return false;
                }
            }

            return true;
        }

        // Обновить данные пациента
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Patient updatePatient)
        {
            if (updatePatient == null) return BadRequest("Patient data is required.");

            // Проверка адресов
            if (updatePatient.Addresses == null || updatePatient.Addresses.Count == 0)
                return BadRequest("At least one address is required");

            // Проверяем, что тип адреса и полный адрес присутствуют
            foreach (var address in updatePatient.Addresses)
            {
                if (address.AddressTypeId == 0 || string.IsNullOrEmpty(address.FullAddress))
                {
                    return BadRequest("AddressTypeId and FullAddress are required for each address.");
                }
            }

            var patient = await _patientService.UpdatePatientAsync(id, updatePatient);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        // Удалить данные
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _patientService.DeletePatientAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
