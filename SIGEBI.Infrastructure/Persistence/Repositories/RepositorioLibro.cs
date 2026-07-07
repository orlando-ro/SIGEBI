using System;
using System.Collections.Generic;
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
            // JOIN con la tabla Categorías y la tabla Ejemplares
            return await _dbSet
                .AsNoTracking()
                .Include(l => l.Categoria)
                .Include(l => l.Ejemplares) // <-- CLAVE
                .FirstOrDefaultAsync(l => l.ISBN == isbn);
        }

        public async Task<Libro?> BuscarLibroPorIsbnAsync(string isbn)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(l => l.Ejemplares) // <-- CLAVE
                .FirstOrDefaultAsync(l => l.ISBN == isbn);
        }

        public new async Task<IEnumerable<Libro>> ObtenerTodosAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .Include(l => l.Categoria)
                .Include(l => l.Ejemplares) // <-- CLAVE
                .ToListAsync();
        }
    }
}