using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IRepositorioPrestamo : IBaseRepository<Prestamo>
    {
        Task<Prestamo?> obtenerPrestamoConDetalleAsync(int id);
        Task<IEnumerable<Prestamo>> ObtenerActivoPorUsuarioAsync(int idUsuario);
        Task<IEnumerable<Prestamo>> ObtenerHistorialPorUsuarioAsync(int idUsuario);
        Task<IEnumerable<Prestamo>> ObtenerActivosPorFechaVencimientoAsync(DateTime fechaObjetivo);
        Task<IEnumerable<Prestamo>> ConsultarTodosAsync();
        Task<IEnumerable<Prestamo>> ConsultarHistorialCompletoAsync();
        Task<IEnumerable<Prestamo>> ConsultarHistorialAvanzadoAsync(string? terminoBusqueda, string? estado);

        Task<IEnumerable<Prestamo>> ConsultarActivosPorFiltroAsync(string criterio, string valor);
    }
}