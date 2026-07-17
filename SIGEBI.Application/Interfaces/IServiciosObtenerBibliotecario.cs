using SIGEBI.Domain.Entities;

namespace SIGEBI.Application.Interfaces
{
    public interface IServiciosObtenerBibliotecario
    {
        Task<Usuario> ObtenerBibliotecarioAsync(string matriculaONumeroEmpleadoBibliotecario);

        Task<Usuario> ObtenerBibliotecarioPorIdAsync(int idBibliotecario);
    }
}
