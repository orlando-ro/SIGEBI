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

        public async Task<IEnumerable<Prestamo>> ConsultarTodosAsync()
        {
            return await _context.Prestamos
                .Include(p => p.Usuario)
                .Include(p => p.EjemplaresAprestar)
                    .ThenInclude(e => e.Libro)
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

        // RESUELTO: Omni-Search con casteo seguro para la propiedad Matricula
        public async Task<IEnumerable<Prestamo>> ConsultarHistorialAvanzadoAsync(string? terminoBusqueda, string? estado)
        {
            var query = _dbSet
                .AsNoTracking()
                .Include(p => p.Usuario)
                .Include(p => p.EjemplaresAprestar)
                    .ThenInclude(e => e.Libro)
                .AsQueryable();

            
            if (!string.IsNullOrWhiteSpace(estado) && estado != "Todos")
            {
                query = query.Where(p => p.Estado == estado);
            }

            
            if (!string.IsNullOrWhiteSpace(terminoBusqueda))
            {
                string termino = terminoBusqueda.ToLower().Trim();

                query = query.Where(p =>
                   
                    (p.Usuario != null && p.Usuario.Nombre != null && p.Usuario.Nombre.ToLower().Contains(termino)) ||
                    (p.Usuario != null && p.Usuario.NumeroEmpleado != null && p.Usuario.NumeroEmpleado.ToLower().Contains(termino)) ||
                    (p.Usuario is Estudiante && ((Estudiante)p.Usuario).Matricula != null && ((Estudiante)p.Usuario).Matricula.ToLower().Contains(termino)) ||
                    p.EjemplaresAprestar.Any(e => e.Libro != null && e.Libro.Titulo.ToLower().Contains(termino))
                );
            }

            return await query.OrderByDescending(p => p.FechaInicio).ToListAsync();
        }

        public async Task<IEnumerable<Prestamo>> ConsultarActivosPorFiltroAsync(string criterio, string valor)
        {
            var query = _dbSet
                .AsNoTracking()
                .Include(p => p.Usuario)
                .Include(p => p.EjemplaresAprestar)
                    .ThenInclude(e => e.Libro)
                .Where(p => p.Estado == "Activo")
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(valor))
            {
                string termino = valor.ToLower().Trim();

                if (criterio == "Usuario") // Búsqueda por Matrícula o Empleado
                {
                    query = query.Where(p =>
                        (p.Usuario != null && p.Usuario.NumeroEmpleado != null && p.Usuario.NumeroEmpleado.ToLower().Contains(termino)) ||
                        (p.Usuario is Estudiante && ((Estudiante)p.Usuario).Matricula != null && ((Estudiante)p.Usuario).Matricula.ToLower().Contains(termino))
                    );
                }
                else if (criterio == "Titulo") // Búsqueda por Título del Libro
                {
                    query = query.Where(p => p.EjemplaresAprestar.Any(e => e.Libro != null && e.Libro.Titulo.ToLower().Contains(termino)));
                }
            }

            return await query.OrderByDescending(p => p.FechaInicio).ToListAsync();
        }
    }
}