using System;
using System.Threading.Tasks;

namespace SIGEBI.AppEscritorio.Services.Interfaces
{
    public interface IServicioReportesApi
    {
        Task<byte[]> DescargarReportePrestamosPdfAsync(DateTime fechaInicio, DateTime fechaFin);
        Task<byte[]> DescargarReporteInventarioPdfAsync();
        Task<byte[]> DescargarReporteCatalogoPdfAsync(DateTime fechaInicio, DateTime fechaFin);
        Task<byte[]> DescargarReportePenalizacionesPdfAsync(DateTime fechaInicio, DateTime fechaFin);
        Task<byte[]> DescargarReporteAuditoriaPdfAsync(DateTime? fechaInicio = null, DateTime? fechaFin = null, int? idResponsable = null, string? entidadAfectada = null);
    }
}