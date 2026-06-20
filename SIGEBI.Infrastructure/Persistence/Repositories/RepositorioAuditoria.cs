using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGEBI.Infrastructure.Persistence.Repositories
{
    // Heredamos del repositorio base inmutable que acabamos de crear
    public class RepositorioAuditoria : InmutableRepository<RegistroAuditoria>, IRepositorioAuditoria
    {
        public RepositorioAuditoria(SIGEBIDbContext context) : base(context)
        {
        }

        // Ya no escribimos el CRUD básico, solo las consultas de LINQ específicas usando _dbSet
        public async Task<IEnumerable<RegistroAuditoria>> ObtenerPorActorAsync(string idUsuarioActor)
        {
            return await _dbSet
                .Where(r => r.IdUsuario == idUsuarioActor)
                .OrderByDescending(r => r.FechaHora)
                .ToListAsync();
        }

        public async Task<IEnumerable<RegistroAuditoria>> ObtenerPorEntidadAsync(string entidadAfectada)
        {
            return await _dbSet
                .Where(r => r.EntidadAfectada == entidadAfectada)
                .OrderByDescending(r => r.FechaHora)
                .ToListAsync();
        }
    }
}
