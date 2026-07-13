using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using System.Threading.Tasks;

namespace SIGEBI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly IServicioAcceso _servicioAcceso;

        public AccesoController(IServicioAcceso servicioAcceso)
        {
            _servicioAcceso = servicioAcceso;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {

            var response = await _servicioAcceso.LoginAsync(request);

            return Ok(response);
        }
    }
}
