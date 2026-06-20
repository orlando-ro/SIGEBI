using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Infrastructure.Persistence.Repositories
{
    internal class RepositorioPenalizacion : BaseRepository<Penalizacion>, IRepoPenalizacion
    {
        public RepositorioPenalizacion(SIGEBIDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Penalizacion>> ObtenerPendientesPorUsuariosAsync(string IdUsuario)
        {
            return await _dbSet.Where(p => p.IdUsuario == IdUsuario && !p.Pagada).ToListAsync();
        }
    }
}
