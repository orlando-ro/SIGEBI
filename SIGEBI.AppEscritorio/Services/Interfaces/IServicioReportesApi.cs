using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.AppEscritorio.Services.Interfaces
{
    public interface IServicioReportesApi
    {
        Task<byte[]> DescargarReportePrestamosPdfAsync(DateTime fechaInicio, DateTime fechaFin);
        Task<byte[]> DescargarReporteInventarioPdfAsync();
        Task<byte[]> DescargarReporteCatalogoPdfAsync(DateTime fechaInicio, DateTime fechaFin);
        Task<byte[]> DescargarReportePenalizacionesPdfAsync(DateTime fechaInicio, DateTime fechaFin);
        Task<byte[]> DescargarReporteAuditoriaPdfAsync(int? idResponsable = null, string? entidadAfectada = null);
    }
}
