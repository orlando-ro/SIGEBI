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

        public async Task ValidarElegibilidadPorIdentificadorAsync(string identificador)
        {
            if (string.IsNullOrWhiteSpace(identificador))
                throw new NegocioExeption("Debe indicar la matricula o el numero de empleado");

            var usuario = await _repositorioUsuario.ObtenerPorMatriculaONumeroEmpleadoAsync(identificador);

            if (usuario == null)
                throw new NegocioExeption("El usuario no fue encontrado en el sistema.");

            usuario.ValidarElegibilidadParaPrestamo();
        }
        
        
    }
}