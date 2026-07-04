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

        public async Task<IEnumerable<Reporte>> ObtenerPendientesAsync()
        {
            return await _dbSet
                .Where(r => r.Estado == "Pendiente")
                .ToListAsync();
        }

        public async Task<IEnumerable<Reporte>> ObtenerPorEstadoAsync(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado))
                return new List<Reporte>();

            string estadoNormalizado = estado.Trim();

            return await _dbSet
                .Where(r => r.Estado == estadoNormalizado)
                .ToListAsync();
        }

        public async Task<IEnumerable<Reporte>> ObtenerPorUsuarioAsync(int idusuario)
        {
            return await _dbSet
               .Where(r => r.IdUsuarioSolicitante == idusuario)
               .ToListAsync();
        }
    }
}
