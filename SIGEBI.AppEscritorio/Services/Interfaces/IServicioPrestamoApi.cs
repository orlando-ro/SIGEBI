using SIGEBI.AppEscritorio.DTOs.Prestamos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.AppEscritorio.Services.Interfaces
{
    public interface IServicioPrestamoApi
    {
        Task<PrestamoResponseDTO?> AprobarYCrearPrestamoAsync(PrestamoRequestDTO peticion);
        Task<List<PrestamoResponseDTO>> ConsultarPrestamosActivosPorUsuarioAsync(string identificador);
        Task<List<PrestamoResponseDTO>> ConsultarPrestamosActivosPorRecursoAsync(string isbnLibro);
        Task<List<PrestamoResponseDTO>> ConsultarHistorialPrestamosPorUsuarioAsync(string identificador);
        Task<List<PrestamoResponseDTO>> ConsultarHistorialPrestamosPorRecursoAsync(string isbnLibro);

        Task<IEnumerable<PrestamoResponseDTO>> ConsultarTodosAsync();
    }
}