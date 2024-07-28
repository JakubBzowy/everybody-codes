using EverybodyCodes.Application.Cameras;
using EverybodyCodes.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EverybodyCodes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CamerasController : ControllerBase
    {
        private readonly ICamerasService _camerasService;

        public CamerasController(ICamerasService camerasService)
        {
            _camerasService = camerasService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Camera>>> GetAll()
        {
            var result = await _camerasService.GetAllCamerasAsync();

            if (result == null) { 
                return NotFound();
            }

            return Ok(result);
        }
    }
}
