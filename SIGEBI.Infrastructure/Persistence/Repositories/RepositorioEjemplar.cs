using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Infrastructure.Persistence;

namespace SIGEBI.Infrastructure.Repositories
{
    public class RepositorioEjemplar : BaseRepository<Ejemplar>, IRepositorioEjemplar
    {
        public RepositorioEjemplar(SIGEBIDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Ejemplar>> ObtenerEjemplaresPorIsbnAsync(string isbn)
        {
            return await _context.Ejemplares
       .Include(e => e.Libro)
       .Where(e => e.ISBN == isbn)
       .ToListAsync();
        }
    }
}