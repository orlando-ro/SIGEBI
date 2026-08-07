using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase // el controllerbase sirve para obtener el contexto del usuario y sus claims
    {
        protected int ObtenerIdResponsable()
        {
            var idString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(idString) || !int.TryParse(idString, out int idResponsable))
                throw new NegocioExeption("No se pudo identificar al usuario responsable en la sesión.");

            return idResponsable;
        }
    }
}