using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.Interfaces
{
    public interface IRepositorioDevolucion : IBaseRepository<Devolucion>
    {
        Task<Devolucion?> ObtenerPorPrestamoAsync(int IdPrestamo);


        Task<IEnumerable<Devolucion>> ConsultarHistorialPorUsuario(int IdUsuario);

        Task<IEnumerable<Devolucion>> ConsultarHistorialPorRecurso(string isbnLibro);

        Task<IEnumerable<Devolucion>> ConsultarHistorialCompletoAsync();
    }
}
