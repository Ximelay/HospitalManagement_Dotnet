using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationsController : Controller
    {
        private readonly ISpecializationService _specializationService;

        // Используем интерфейс
        public SpecializationsController(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }

        // Получение всех специализаций
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var specializations = await _specializationService.GetAllSpecializationsAsync();
            return Ok(specializations);
        }

        // Получить специализацию по ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var specialization = await _specializationService.GetSpecializationByIdAsync(id);
            if (specialization == null) return NotFound();
            return Ok(specialization);
        }

        // Создать новую специализацию
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Specialization specialization)
        {
            var newSpecialization = await _specializationService.CreateSpecializationAsync(specialization);
            return CreatedAtAction(nameof(GetById), new { id = newSpecialization.Id }, newSpecialization);
        }

        // Обновить специализацию
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Specialization updatedSpecialization)
        {
            var specialization = await _specializationService.UpdateSpecializationAsync(id, updatedSpecialization);
            if (specialization == null) return NotFound();
            return Ok(specialization);
        }

        // Удалить специализацию
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _specializationService.DeleteSpecializationAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
