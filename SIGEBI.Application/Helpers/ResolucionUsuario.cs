using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Application.Helpers
{
    public static class ResolucionUsuario
    {
        public static async Task<Usuario> ObtenerPorIdentificadorAsync(IUsuarios usuarios, string matriculaONumeroEmpleado)
        {
            if (string.IsNullOrWhiteSpace(matriculaONumeroEmpleado))
                throw new NegocioExeption("Debe ingresar el identificador del usuario.");

            var identificador = matriculaONumeroEmpleado.Trim();

            var usuario = await usuarios.ObtenerPorMatriculaONumeroEmpleadoAsync(identificador);

            if (usuario == null)
                throw new NegocioExeption("Este usuario no está registrado en el sistema.");

            return usuario;
        }
    }
}
