using Microsoft.EntityFrameworkCore;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Infrastructure.Persistence.Repositories
{
    public class RepositorioAuditoria
        : InmutableRepository<RegistroAuditoria>,
          IRepositorioAuditoria
    {
        public RepositorioAuditoria(
            SIGEBIDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<RegistroAuditoria>>
            ConsultarHistorialAsync(
                int? idResponsable = null,
                string? entidadAfectada = null)
        {
            IQueryable<RegistroAuditoria> consulta =
                _dbSet.AsNoTracking();

            if (idResponsable.HasValue)
            {
                consulta = consulta.Where(
                    registro =>
                        registro.IdResponsable ==
                        idResponsable.Value);
            }

            if (!string.IsNullOrWhiteSpace(
                entidadAfectada))
            {
                string entidadNormalizada =
                    entidadAfectada.Trim();

                consulta = consulta.Where(
                    registro =>
                        registro.EntidadAfectada ==
                        entidadNormalizada);
            }

            return await consulta
                .OrderByDescending(
                    registro => registro.FechaHora)
                .ToListAsync();
        }
    }
}