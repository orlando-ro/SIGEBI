using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Infrastructure.Repositories;

namespace SIGEBI.Infrastructure.Persistence.Repositories
{
    internal class RepositorioDevoluciones : BaseRepository<Devolucion>, IRepositorioDevolucion
    {
        public RepositorioDevoluciones(SIGEBIDbContext context) : base(context) { }

        public async Task<IEnumerable<Devolucion?>> ConsultarHistorialPorRecurso(string isbnLibro)
        {

            return await _dbSet
                .Include(d => d.Prestamo)
                    .ThenInclude(p => p.Usuario)
                .Include(d => d.Prestamo)
                    .ThenInclude(p => p.Libros)
                .Where(d => d.Prestamo.Libros.Any(l => l.ISBN == isbnLibro))
                .OrderByDescending(d => d.FechaDevolucion)
                .ToListAsync();

        }

        public async Task<IEnumerable<Devolucion?>> ConsultarHistorialPorUsuario(string IdUsuario)
        {
            return await _dbSet
                .Include(d => d.Prestamo)
                .ThenInclude(p => p.Usuario)
                .Include(d => d.Prestamo)
                .ThenInclude(p => p.Libros)
                .Where(d => d.Prestamo.IdUsuario == IdUsuario)
                .OrderByDescending(d => d.FechaDevolucion)
                .ToListAsync();

        }

        public async Task<Devolucion?> ObtenerPorPrestamoAsync(int IdPrestamo) {

            return await _dbSet
                .Include(d => d.Prestamo)
                    .ThenInclude(p => p.Usuario)
                .Include(d => d.Prestamo)
                    .ThenInclude(p => p.Libros)
                .FirstOrDefaultAsync(d => d.IdPrestamo == IdPrestamo);

        }

    }
}
