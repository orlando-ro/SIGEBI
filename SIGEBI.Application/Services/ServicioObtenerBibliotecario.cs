using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Application.Services
{
    public class ServicioObtenerBibliotecario : IServiciosObtenerBibliotecario
    {
        private readonly IUsuarios _usuario;

        public ServicioObtenerBibliotecario(IUsuarios usuario)
        {
            _usuario = usuario;
        }

        public async Task<Usuario> ObtenerBibliotecarioAsync(string matriculaONumeroEmpleadoBibliotecario)
        {
            var usuario = await _usuario.ObtenerPorMatriculaONumeroEmpleadoAsync(matriculaONumeroEmpleadoBibliotecario);

            if (usuario is not PersonalBibliotecario)
                throw new NegocioExeption("Solo el personal bibliotecario puede aprobar, rechazar o registrar devoluciones.");

            return usuario;
        }

        public async Task<Usuario> ObtenerBibliotecarioPorIdAsync(int idBibliotecario)
        {
            var usuario = await _usuario.ObtenerUsuarioConDetallesAsync(idBibliotecario);

            if (usuario == null || usuario is not PersonalBibliotecario)
                throw new NegocioExeption("Solo el personal bibliotecario puede realizar esta operación.");

            return usuario;
        }
    }
}
