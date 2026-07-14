using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Infrastructure.Persistence;

namespace SIGEBI.Infrastructure.Repositories
{
    public class RepositorioLibro : BaseRepository<Libro>, IRepositorioLibro
    {
        public RepositorioLibro(SIGEBIDbContext context) : base(context)
        {
        }

        public async Task<Libro?> ObtenerLibroConCategoriaAsync(string isbn)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(l => l.Categoria)
                .Include(l => l.Ejemplares)
                .FirstOrDefaultAsync(l => l.ISBN == isbn);
        }

        public async Task<Libro?> BuscarLibroPorIsbnAsync(string isbn)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(l => l.Ejemplares)
                .FirstOrDefaultAsync(l => l.ISBN == isbn);
        }

        public new async Task<IEnumerable<Libro>> ObtenerTodosAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .Include(l => l.Categoria)
                .Include(l => l.Ejemplares)
                .ToListAsync();
        }

        public async Task<IEnumerable<Libro>> ObtenerCatalogoFiltradoAsync(string? titulo, string? autor, int? idCategoria, bool soloDisponibles)
        {
            var query = _context.Libros
                .Include(l => l.Categoria)
                .Include(l => l.Ejemplares)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(titulo))
                query = query.Where(l => l.Titulo.Contains(titulo));

            if (!string.IsNullOrWhiteSpace(autor))
                query = query.Where(l => l.NombreAutor.Contains(autor));

            if (idCategoria.HasValue && idCategoria.Value > 0)
                query = query.Where(l => l.IdCategoria == idCategoria.Value);

            if (soloDisponibles)
                query = query.Where(l => l.Ejemplares.Any(e => e.Estado.ToString() == "Disponible"));

            return await query.ToListAsync();
        }

        public async Task<Libro?> ObtenerLibroIgnorandoFiltrosAsync(string isbn)
        {
            return await _dbSet
                .IgnoreQueryFilters()
                .Include(l => l.Ejemplares)
                .FirstOrDefaultAsync(l => l.ISBN == isbn);
        }

        public async Task<IEnumerable<Libro>> ObtenerCatalogoCompletoAdminAsync()
        {
            return await _dbSet
                .IgnoreQueryFilters()
                .Include(l => l.Categoria)
                .Include(l => l.Ejemplares)
                .ToListAsync();
        }
    }
}