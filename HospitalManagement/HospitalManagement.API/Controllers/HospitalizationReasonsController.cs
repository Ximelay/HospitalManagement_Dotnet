using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalizationReasonsController : ControllerBase
    {
        private readonly IHospitalizationService _hospitalizationService;

        public HospitalizationReasonsController(IHospitalizationService hospitalizationService)
        {
            _hospitalizationService = hospitalizationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<HospitalizationReason>>> GetAll()
        {
            var reasons = await _hospitalizationService.GetAllHospitalizationReasonsAsync();
            return Ok(reasons);
        }
    }
}
