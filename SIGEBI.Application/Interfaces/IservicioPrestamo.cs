using SIGEBI.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IservicioPrestamo
    {
        Task<PrestamoResponseDTO> AprobarYRegistrarPrestamoAsync(PrestamoRequestDTO peticion, int idBibliotecarioResponsable);
        Task<IEnumerable<PrestamoResponseDTO>> ConsultarPrestamosActivosPorIdentificadorAsync(string identificador);
        Task<IEnumerable<PrestamoResponseDTO>> ConsultarHistorialPorUsuarioAsync(string identificador);
        Task<IEnumerable<PrestamoResponseDTO>> ConsultarTodosAsync();
        Task<IEnumerable<PrestamoResponseDTO>> ConsultarHistorialCompletoAsync();
        Task<IEnumerable<PrestamoResponseDTO>> ConsultarHistorialAvanzadoAsync(string? terminoBusqueda, string? estado);

        Task<IEnumerable<PrestamoResponseDTO>> ConsultarActivosPorFiltroAsync(string criterio, string valor);
    }
}