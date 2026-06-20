using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IRepositorioAuditoria : IInmutableRepository<RegistroAuditoria>
    {
        Task<IEnumerable<RegistroAuditoria>> ObtenerPorActorAsync(string idUsuarioActor);
        Task<IEnumerable<RegistroAuditoria>> ObtenerPorEntidadAsync(string entidadAfectada);
    }
}
