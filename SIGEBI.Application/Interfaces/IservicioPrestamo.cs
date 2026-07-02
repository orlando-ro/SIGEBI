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
        Task AprobarYRegistrarPrestamoAsync(int idSolicitud, string idBibliotecario);

        Task ProcesarDevolucionAsync(int idPrestamo, string condicionLibro);

        Task<IEnumerable<PrestamoResponseDTO>> ConsultarPrestamosActivosPorUsuarioAsync(string idUsuario);

        Task<IEnumerable<PrestamoResponseDTO>> ConsultarPrestamosActivosPorRecursoAsync(string isbn);

        Task<IEnumerable<PrestamoResponseDTO>> ConsultarHistorialPorUsuarioAsync(string idUsuario);

        Task<IEnumerable<PrestamoResponseDTO>> ConsultarHistorialPorRecursoAsync(string isbn);
    }
}
