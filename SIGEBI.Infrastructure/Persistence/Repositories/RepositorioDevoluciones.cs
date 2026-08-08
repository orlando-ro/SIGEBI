using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Enums;
using SIGEBI.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGEBI.Infrastructure.Persistence.Repositories
{
    public class RepositorioDevoluciones : BaseRepository<Devolucion>, IRepositorioDevolucion
    {
        public RepositorioDevoluciones(SIGEBIDbContext context) : base(context)
        {
        }

        public async Task<Devolucion?> ObtenerPorPrestamoAsync(int idPrestamo)
        {
            return await _dbSet
                .Include(d => d.Prestamo)
                    .ThenInclude(p => p!.Usuario)
                .Include(d => d.Prestamo)
                    .ThenInclude(p => p!.EjemplaresAprestar)
                        .ThenInclude(e => e.Libro)
                .FirstOrDefaultAsync(d => d.IdPrestamo == idPrestamo);
        }

        public async Task<IEnumerable<Devolucion>> ConsultarHistorialPorTituloLibroAsync(string tituloLibro, CondicionDevolucion? condicion)
        {
            if (string.IsNullOrWhiteSpace(tituloLibro))
                return new List<Devolucion>();

            string tituloNormalizado = tituloLibro.Trim().ToLower();

            var query = _dbSet
                .AsNoTracking()
                .Include(d => d.Prestamo)
                    .ThenInclude(p => p!.Usuario)
                .Include(d => d.Prestamo)
                    .ThenInclude(p => p!.EjemplaresAprestar)
                        .ThenInclude(e => e.Libro)
                .Where(d => d.Prestamo != null &&
                            d.Prestamo.EjemplaresAprestar.Any(e => e.Libro != null && e.Libro.Titulo.ToLower().Contains(tituloNormalizado)));

            if (condicion.HasValue)
                query = query.Where(d => d.CondicionLibro == condicion.Value);

            return await query.OrderByDescending(d => d.FechaDevolucion).ToListAsync();
        }

        public async Task<IEnumerable<Devolucion>> ConsultarHistorialPorUsuarioAsync(int idUsuario, CondicionDevolucion? condicion)
        {
            var query = _dbSet
                .AsNoTracking()
                .Include(d => d.Prestamo)
                    .ThenInclude(p => p!.Usuario)
                .Include(d => d.Prestamo)
                    .ThenInclude(p => p!.EjemplaresAprestar)
                        .ThenInclude(e => e.Libro)
                .Where(d => d.Prestamo != null && d.Prestamo.IdUsuario == idUsuario);

            if (condicion.HasValue)
                query = query.Where(d => d.CondicionLibro == condicion.Value);

            return await query.OrderByDescending(d => d.FechaDevolucion).ToListAsync();
        }

        public async Task<IEnumerable<Devolucion>> ConsultarHistorialCompletoAsync(CondicionDevolucion? condicion)
        {
            var query = _dbSet
                .AsNoTracking()
                .Include(d => d.Prestamo)
                    .ThenInclude(p => p!.Usuario)
                .Include(d => d.Prestamo)
                    .ThenInclude(p => p!.EjemplaresAprestar)
                        .ThenInclude(e => e.Libro)
                .Where(d => d.Prestamo != null);

            if (condicion.HasValue)
                query = query.Where(d => d.CondicionLibro == condicion.Value);

            return await query.OrderByDescending(d => d.FechaDevolucion).ToListAsync();
        }
    }
}