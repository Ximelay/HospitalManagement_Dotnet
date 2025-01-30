using Microsoft.AspNetCore.Mvc;
using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : Controller
    {
        public readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
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
            if (patient == null) return BadRequest("Patient data is required");

            // Проверка адресов
            if (patient.Addresses == null || patient.Addresses.Count == 0)
                return BadRequest("At least one address is required");

            //Проверка на существование адреса и типа адреса
            foreach (var address in patient.Addresses)
            {
                if (address.AddressTypeId == 0 || string.IsNullOrEmpty(address.FullAddress))
                {
                    return BadRequest("AddressTypeId and FullAddress are required for each address");
                }
            }

            if (patient.Passport == null) return BadRequest("Passport data is required");

            var newPatient = await _patientService.CreatePatientAsync(patient);
            return CreatedAtAction(nameof(GetById), new { id = newPatient.Id }, newPatient);
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
