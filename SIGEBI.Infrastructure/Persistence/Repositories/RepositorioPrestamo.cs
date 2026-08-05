using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Infrastructure.Repositories;

namespace SIGEBI.Infrastructure.Persistence.Repositories
{
    public class RepositorioPrestamo : BaseRepository<Prestamo>, IRepositorioPrestamo
    {
        public RepositorioPrestamo(SIGEBIDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Prestamo>> ObtenerActivoPorUsuarioAsync(int idUsuario)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(p => p.Usuario)
                .Include(p => p.EjemplaresAprestar)
                    .ThenInclude(e => e.Libro)
                .Where(p => p.IdUsuario == idUsuario && p.Estado == "Activo")
                .ToListAsync();
        }

        public async Task<IEnumerable<Prestamo>> ObtenerActivosPorRecursoAsync(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                return new List<Prestamo>();

            string isbnNormalizado = isbn.Trim();

            return await _dbSet
                .AsNoTracking()
                .Include(p => p.Usuario)
                .Include(p => p.EjemplaresAprestar)
                    .ThenInclude(e => e.Libro)
                .Where(p =>
                    p.Estado == "Activo" &&
                    p.EjemplaresAprestar.Any(e => e.ISBN == isbnNormalizado))
                .ToListAsync();
        }

        public async Task<IEnumerable<Prestamo>> ObtenerHistorialPorRecurso(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                return new List<Prestamo>();

            string isbnNormalizado = isbn.Trim();

            return await _dbSet
                .AsNoTracking()
                .Include(p => p.Usuario)
                .Include(p => p.EjemplaresAprestar)
                    .ThenInclude(e => e.Libro)
                .Where(p => p.EjemplaresAprestar.Any(e => e.ISBN == isbnNormalizado))
                .OrderByDescending(p => p.FechaInicio)
                .ToListAsync();
        }

        public async Task<IEnumerable<Prestamo>> ObtenerHistorialPorUsuarioAsync(int idUsuario)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(p => p.Usuario)
                .Include(p => p.EjemplaresAprestar)
                    .ThenInclude(e => e.Libro)
                .Where(p => p.IdUsuario == idUsuario)
                .OrderByDescending(p => p.FechaInicio)
                .ToListAsync();
        }

        public async Task<Prestamo?> obtenerPrestamoConDetalleAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Usuario)
                .Include(p => p.EjemplaresAprestar)
                    .ThenInclude(e => e.Libro)
                .FirstOrDefaultAsync(p => p.IdPrestamo == id);
        }

        public async Task<IEnumerable<Prestamo>> ObtenerActivosPorFechaVencimientoAsync(DateTime fechaObjetivo)
        {
            return await _dbSet
                .Include(p => p.Usuario)
                .Include(p => p.EjemplaresAprestar)
                    .ThenInclude(e => e.Libro)
                .Where(p => p.Estado != "Devuelto" && p.FechaVencimiento.Date == fechaObjetivo.Date)
                .ToListAsync();
        }

        // 🔥 AQUÍ ESTABA EL ERROR PRINCIPAL: Faltaba el ThenInclude
        public async Task<IEnumerable<Prestamo>> ConsultarTodosAsync()
        {
            return await _context.Prestamos
                .Include(p => p.Usuario)
                .Include(p => p.EjemplaresAprestar)
                    .ThenInclude(e => e.Libro) // <--- ESTA LÍNEA RESUELVE EL BUG
                .Where(p => p.Estado == "Activo" || p.Estado == "Prestado")
                .ToListAsync();
        }

        public async Task<IEnumerable<Prestamo>> ConsultarHistorialCompletoAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .Include(p => p.Usuario)
                .Include(p => p.EjemplaresAprestar)
                    .ThenInclude(e => e.Libro)
                .OrderByDescending(p => p.FechaInicio)
                .ToListAsync();
        }
    }
}