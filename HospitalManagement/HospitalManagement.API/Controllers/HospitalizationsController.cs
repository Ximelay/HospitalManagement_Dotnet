using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalizationsController : Controller
    {
        private readonly IHospitalizationService _hospitalizationService;
        private readonly ILogger<HospitalizationsController> _logger;

        public HospitalizationsController(IHospitalizationService hospitalizationService, ILogger<HospitalizationsController> logger)
        {
            _hospitalizationService = hospitalizationService;
            _logger = logger;
        }

        // Получить список всех госпитализаций
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var hospitalizations = await _hospitalizationService.GetAllHospitalizationsAsync();
            return Ok(hospitalizations);
        }


        // Получить конкретную госпитализацию
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hospitalization = await _hospitalizationService.GetHospitalizationByIdAsync(id);
            if (hospitalization == null) return NotFound();
            return Ok(hospitalization);
        }

        // Добавить новую госпитализацию
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Hospitalization hospitalization)
        {
            if (hospitalization == null)
            {
                _logger.LogError("Received null hospitalization data.");
                return BadRequest("Hospitalization data is required.");
            }

            try
            {
                var newHospitalization = await _hospitalizationService.CreateHospitalizationAsync(hospitalization);
                return CreatedAtAction(nameof(GetById), new { id = newHospitalization.Id }, newHospitalization);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating hospitalization: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }

        // Обновить описание состояния пациента
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCondition(int id, [FromBody] string conditionDescription)
        {
            var updatedHospitalization = await _hospitalizationService.UpdateConditionAsync(id, conditionDescription);
            if (updatedHospitalization == null) return NotFound();
            return Ok(updatedHospitalization);
        }

        // Выписать пациента (удаление госпитализации)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Discharge(int id)
        {
            var result = await _hospitalizationService.DischargePatientAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
