using SIGEBI.Application.DTOs;
using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IservicioPrestamo
    {
        Task<PrestamoResponseDTO> AprobarYRegistrarPrestamoAsync(PrestamoRequestDTO peticion, int idBibliotecarioResponsable);

        Task<IEnumerable<PrestamoResponseDTO>> ConsultarPrestamosActivosPorIdentificadorAsync(string identificador);

        Task<IEnumerable<PrestamoResponseDTO>> ConsultarPrestamosActivosPorRecursoAsync(string isbn);

        Task<IEnumerable<PrestamoResponseDTO>> ConsultarHistorialPorUsuarioAsync(string identificador);

        Task<IEnumerable<PrestamoResponseDTO>> ConsultarHistorialPorRecursoAsync(string isbn);

        Task<IEnumerable<PrestamoResponseDTO>> ConsultarTodosAsync();

        Task<IEnumerable<PrestamoResponseDTO>> ConsultarHistorialCompletoAsync();
    }
}