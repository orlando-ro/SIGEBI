using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Infrastructure.Persistence.Repositories
{
    internal class RepositorioReporte : BaseRepository<Reporte>, IRepositorioReporte
    {
        public RepositorioReporte(SIGEBIDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Reporte>> ObtenerPorEstadoAsync(string estado)
        {
            return await _dbSet
               .Where(r => r.Estado == estado)
               .ToListAsync();
        }
    }
}
