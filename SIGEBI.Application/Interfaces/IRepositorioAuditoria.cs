using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IRepositorioAuditoria : IInmutableRepository<RegistroAuditoria>
    {
        Task<IEnumerable<RegistroAuditoria>> ConsultarHistorialAsync(
            DateTime? fechaInicio = null,
            DateTime? fechaFin = null,
            string? accion = null,
            string? entidadAfectada = null);
    }
}