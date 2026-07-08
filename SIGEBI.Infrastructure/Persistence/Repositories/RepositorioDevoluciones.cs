using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Infrastructure.Repositories;

namespace SIGEBI.Infrastructure.Persistence.Repositories
{
    public class RepositorioDevoluciones : BaseRepository<Devolucion>, IRepositorioDevolucion
    {
        public RepositorioDevoluciones(SIGEBIDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Devolucion>> ConsultarHistorialPorRecurso(string isbnLibro)
        {
            if (string.IsNullOrWhiteSpace(isbnLibro))
                return new List<Devolucion>();

            string isbnNormalizado = isbnLibro.Trim();

            return await _dbSet
                .AsNoTracking()
                .Include(d => d.Prestamo)
                    .ThenInclude(p => p.Usuario)
                .Include(d => d.Prestamo)
                    .ThenInclude(p => p.EjemplaresAprestar)
                        .ThenInclude(e => e.Libro)
                .Where(d => d.Prestamo.EjemplaresAprestar
                    .Any(e => e.ISBN == isbnNormalizado))
                .OrderByDescending(d => d.FechaDevolucion)
                .ToListAsync();
        }

        public async Task<IEnumerable<Devolucion>> ConsultarHistorialPorUsuario(int idUsuario)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(d => d.Prestamo)
                    .ThenInclude(p => p.Usuario)
                .Include(d => d.Prestamo)
                    .ThenInclude(p => p.EjemplaresAprestar)
                        .ThenInclude(e => e.Libro)
                .Where(d => d.Prestamo.IdUsuario == idUsuario)
                .OrderByDescending(d => d.FechaDevolucion)
                .ToListAsync();
        }

        public async Task<Devolucion?> ObtenerPorPrestamoAsync(int idPrestamo)
        {
            return await _dbSet
                .Include(d => d.Prestamo)
                    .ThenInclude(p => p.Usuario)
                .Include(d => d.Prestamo)
                    .ThenInclude(p => p.EjemplaresAprestar)
                        .ThenInclude(e => e.Libro)
                .FirstOrDefaultAsync(d => d.IdPrestamo == idPrestamo);
        }
    }
}