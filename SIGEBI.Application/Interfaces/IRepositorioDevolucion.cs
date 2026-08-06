using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IRepositorioDevolucion : IBaseRepository<Devolucion>
    {
        Task<Devolucion?> ObtenerPorPrestamoAsync(int IdPrestamo);

        // Métodos separados por responsabilidad, con filtro opcional de condición
        Task<IEnumerable<Devolucion>> ConsultarHistorialPorUsuarioAsync(int IdUsuario, CondicionDevolucion? condicion);
        Task<IEnumerable<Devolucion>> ConsultarHistorialPorTituloLibroAsync(string tituloLibro, CondicionDevolucion? condicion);
        Task<IEnumerable<Devolucion>> ConsultarHistorialCompletoAsync(CondicionDevolucion? condicion);
    }
}