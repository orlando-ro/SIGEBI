using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Application.Interfaces
{
    public interface IRepositorioLibro : IBaseRepository<Libro>
    {
        // metodo exclusivo para traer el libro con el nombre de su categoría
        Task<Libro?> ObtenerLibroConCategoriaAsync(string isbn);
    }
}