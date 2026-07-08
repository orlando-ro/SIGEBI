using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Application.Interfaces
{
    public interface IRepositorioLibro : IBaseRepository<Libro>
    {
        // metodo para traer el libro con el nombre de su categoria
        Task<Libro?> ObtenerLibroConCategoriaAsync(string isbn);

        Task<Libro?> BuscarLibroPorIsbnAsync(string isbn);

        Task<IEnumerable<Libro>> ObtenerCatalogoFiltradoAsync(string? titulo, string? autor, int? idCategoria, bool soloDisponibles);
    }
}