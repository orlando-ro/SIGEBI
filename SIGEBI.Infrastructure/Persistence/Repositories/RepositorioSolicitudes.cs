using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Infrastructure.Repositories;

namespace SIGEBI.Infrastructure.Persistence.Repositories
{
    public class RepositorioSolicitudes : BaseRepository<Solicitud>, IRepoSolicitud
    {
        private readonly SIGEBIDbContext _contextLocal;

        public RepositorioSolicitudes(SIGEBIDbContext context) : base(context)
        {
            _contextLocal = context;
        }

        public async Task<bool> ExisteSolicitudPendienteAsync(int IdUsuario, string isbn)
        {
            return await _dbSet.AnyAsync(s =>
                  s.IdUsuario == IdUsuario &&
                  s.EjemplaresSolicitados.Any(e => e.ISBN == isbn) &&
                  s.Estado == "Pendiente"

            );
        }

        public async Task GuardarResolucionAsync(Resolucion resolucion)
        {
            await _contextLocal.Set<Resolucion>().AddAsync(resolucion);
            await _contextLocal.SaveChangesAsync();
        }

        public async Task<IEnumerable<Solicitud>> ObtenerPendientesAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .Include(s => s.Usuario)
                .Include(s => s.EjemplaresSolicitados)
                    .ThenInclude(e => e.Libro)
                .Where(s => s.Estado == "Pendiente")
                .OrderByDescending(s => s.FechaSolicitud)
                .ToListAsync();
        }

        public async Task<IEnumerable<Solicitud>> ObtenerPorUsuarioAsync(int idusuario)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(s => s.Usuario)
                .Include(s => s.EjemplaresSolicitados)
                    .ThenInclude(e => e.Libro)
                .Where(s => s.IdUsuario == idusuario)
                .OrderByDescending(s => s.FechaSolicitud)
                .ToListAsync();
        }

        public async Task<Solicitud?> ObtenerSolicitudConDetallesAsync(int id)
        {
            return await _dbSet
                .Include(s => s.Usuario)
                .Include(s => s.EjemplaresSolicitados)
                    .ThenInclude(e => e.Libro)
                .FirstOrDefaultAsync(s => s.IdSolicitud == id);
        }


        public async Task<IEnumerable<Solicitud>> ObtenerPendientesPorUsuarioAsync(int idUsuario)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(s => s.Usuario)
                .Include(s => s.EjemplaresSolicitados)
                    .ThenInclude(e => e.Libro)
                // El filtrado vive aquí, en la capa de datos
                .Where(s => s.IdUsuario == idUsuario && s.Estado == "Pendiente")
                .OrderByDescending(s => s.FechaSolicitud)
                .ToListAsync();
        }
    }
}
