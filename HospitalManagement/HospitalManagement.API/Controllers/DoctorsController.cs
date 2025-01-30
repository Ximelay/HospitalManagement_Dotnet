using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : Controller
    {
        private readonly IDoctorService _doctorService;

        // Используем интерфейс
        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // Получение всех врачей
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            return Ok(doctors);
        }

        // Получить врача по ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }

        // Создать нового врача
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Doctor doctor)
        {
            var newDoctor = await _doctorService.CreateDoctorAsync(doctor);
            return CreatedAtAction(nameof(GetById), new { id = newDoctor.Id }, newDoctor);
        }

        // Обновить данные врача
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Doctor updatedDoctor)
        {
            var doctor = await _doctorService.UpdateDoctorAsync(id, updatedDoctor);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }

        // Удалить врача
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _doctorService.DeleteDoctorAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
