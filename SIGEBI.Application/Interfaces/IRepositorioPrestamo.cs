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
        Task<IEnumerable<Prestamo>> ObtenerActivoPorUsuarioAsync(string idUsuario);
    }
}
