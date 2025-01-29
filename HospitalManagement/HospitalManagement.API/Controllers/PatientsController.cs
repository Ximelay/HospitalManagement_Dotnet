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
            var newPatient = await _patientService.CreatePatientAsync(patient);
            return CreatedAtAction(nameof(GetById), new { id = newPatient.Id }, newPatient);
        }

        // Обновить данные пациента
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Patient updatePatient)
        {
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
