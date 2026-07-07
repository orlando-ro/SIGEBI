using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IRepositorioEjemplar : IBaseRepository<Ejemplar>
    {
        // consultar el inventario físico de un libro
        Task<IEnumerable<Ejemplar>> ObtenerEjemplaresPorIsbnAsync(string isbn);
    }
}