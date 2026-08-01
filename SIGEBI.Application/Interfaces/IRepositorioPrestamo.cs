using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.Interfaces
{
    public interface IRepositorioPrestamo : IBaseRepository<Prestamo>

    {

        // para obtener los libros y los usuarios a los que pertenece
        Task<Prestamo?> obtenerPrestamoConDetalleAsync(int id);
        Task<IEnumerable<Prestamo>> ObtenerActivoPorUsuarioAsync(int idUsuario);

        Task<IEnumerable<Prestamo>> ObtenerHistorialPorUsuarioAsync(int idUsuario);

        Task<IEnumerable<Prestamo>> ObtenerHistorialPorRecurso(string isbn);

        Task<IEnumerable<Prestamo>> ObtenerActivosPorRecursoAsync(string isbn);

        Task<IEnumerable<Prestamo>> ObtenerActivosPorFechaVencimientoAsync(DateTime fechaObjetivo);

        Task<IEnumerable<Prestamo>> ConsultarTodosAsync();

        Task<IEnumerable<Prestamo>> ConsultarHistorialCompletoAsync();
    }


}

