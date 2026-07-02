using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.Interfaces
{
    public interface IRepositorioDevolucion : IBaseRepository<Devolucion>
    {
        Task<Devolucion?> ObtenerPorPrestamoAsync(int IdPrestamo);


        Task<IEnumerable<Devolucion>> ConsultarHistorialPorUsuario(string IdUsuario);

        Task<IEnumerable<Devolucion>> ConsultarHistorialPorRecurso(string isbnLibro);
    }
}
