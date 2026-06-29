using System.Threading.Tasks;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Application.Services
{
    public class GestorDeAcceso : IServicioAcceso
    {
        private readonly IUsuarios _repositorioUsuario;

        public GestorDeAcceso(IUsuarios repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public async Task ValidarElegibilidadUsuarioAsync(string idUsuario)
        {
            var usuario = await _repositorioUsuario.ObtenerUsuarioConDetallesAsync(idUsuario);

            if (usuario == null) throw new NegocioExeption("El usuario no fue encontrado en el sistema.");

            // Regla de negocio encapsulada en la entidad
            usuario.ValidarElegibilidadParaPrestamo();
        }
    }
}