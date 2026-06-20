using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Infrastructure.Persistence.Repositories
{
    internal class RepositorioSolicitudes : BaseRepository<Solicitud>, IRepoSolicitud
    {

        
        private readonly SIGEBIDbContext _contextLocal;
        public RepositorioSolicitudes(SIGEBIDbContext context) : base(context)
        {
            _contextLocal = context;
        }

        public async Task GuardarResolucionAsync(Resolucion resolucion)
        {
            await _contextLocal.Set <Resolucion>().AddAsync(resolucion);
            await _contextLocal.SaveChangesAsync();
        }

        public async Task<IEnumerable<Solicitud>> ObtenerPendientesAsync()
        {
            return await _dbSet
                .Where(s => s.Estado == "Pendiente")
                .ToListAsync();
        }

        public async Task<Solicitud?> ObtenerSolicitudConDetallesAsync(int id)
        {
            return await _dbSet
                .Include(s => s.LibrosSolicitados)
                .FirstOrDefaultAsync(s => s.IdSolicitud == id);
        }
    }
}
