using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Infrastructure.Persistence;
namespace SIGEBI.Infrastructure.Repositories
{
    public class RepositorioNotificaciones : BaseRepository<Notificacion>, IRepositorioNotificacion
    {
        public RepositorioNotificaciones(SIGEBIDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Notificacion>> ObtenerPorUsuarioAsync(string idUsuario)
        {
            return await _dbSet
                .Where(n => n.IdUsuario == idUsuario)
                .OrderByDescending(n => n.FechaEnvio) // ordenadas por nuevas primero
                .ToListAsync();
        }

        public async Task<IEnumerable<Notificacion>> ObtenerNoLeidasPorUsuarioAsync(string idUsuario)
        {
            return await _dbSet
                .Where(n => n.IdUsuario == idUsuario && !n.Leida)
                .OrderByDescending(n => n.FechaEnvio)
                .ToListAsync();
        }
    }
}