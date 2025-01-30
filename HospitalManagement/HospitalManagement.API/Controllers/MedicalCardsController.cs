using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalCardsController : Controller
    {
        private readonly IMedicalCardService _medicalCardService;

        // Используем интерфейс
        public MedicalCardsController(IMedicalCardService medicalCardService)
        {
            _medicalCardService = medicalCardService;
        }

        // Получение всех медицинских карт
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var medicalCards = await _medicalCardService.GetAllMedicalCardsAsync();
            return Ok(medicalCards);
        }

        // Получить медицинскую карту по ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var medicalCard = await _medicalCardService.GetMedicalCardByIdAsync(id);
            if (medicalCard == null) return NotFound();
            return Ok(medicalCard);
        }

        // Создать новую медицинскую карту
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MedicalCard medicalCard)
        {
            var newMedicalCard = await _medicalCardService.CreateMedicalCardAsync(medicalCard);
            return CreatedAtAction(nameof(GetById), new { id = newMedicalCard.Id }, newMedicalCard);
        }

        // Обновить медицинскую карту
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MedicalCard updatedMedicalCard)
        {
            var medicalCard = await _medicalCardService.UpdateMedicalCardAsync(id, updatedMedicalCard);
            if (medicalCard == null) return NotFound();
            return Ok(medicalCard);
        }

        // Удалить медицинскую карту
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _medicalCardService.DeleteMedicalCardAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
