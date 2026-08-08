using SIGEBI.AppEscritorio.Services.Helper;
using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SIGEBI.AppEscritorio.Services.Implementations
{
    public class ServicioReportesApi : IServicioReportesApi
    {
        private readonly HttpClient _httpClient;

        public ServicioReportesApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<byte[]> DescargarReportePrestamosPdfAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            string url = $"Reportes/prestamos/pdf?fechaInicio={fechaInicio:yyyy-MM-dd}&fechaFin={fechaFin:yyyy-MM-dd}";
            return await ObtenerArchivoPdfAsync(url);
        }

        public async Task<byte[]> DescargarReporteInventarioPdfAsync()
        {
            return await ObtenerArchivoPdfAsync("Reportes/inventario/pdf");
        }

        public async Task<byte[]> DescargarReporteCatalogoPdfAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            string url = $"Reportes/catalogo/pdf?fechaInicio={fechaInicio:yyyy-MM-dd}&fechaFin={fechaFin:yyyy-MM-dd}";
            return await ObtenerArchivoPdfAsync(url);
        }

        public async Task<byte[]> DescargarReportePenalizacionesPdfAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            string url = $"Reportes/penalizaciones/pdf?fechaInicio={fechaInicio:yyyy-MM-dd}&fechaFin={fechaFin:yyyy-MM-dd}";
            return await ObtenerArchivoPdfAsync(url);
        }

        public async Task<byte[]> DescargarReporteAuditoriaPdfAsync(DateTime? fechaInicio = null, DateTime? fechaFin = null, int? idResponsable = null, string? entidadAfectada = null)
        {
            var queryParams = new List<string>();
            if (fechaInicio.HasValue) queryParams.Add($"fechaInicio={fechaInicio.Value:yyyy-MM-dd}");
            if (fechaFin.HasValue) queryParams.Add($"fechaFin={fechaFin.Value:yyyy-MM-dd}");
            if (idResponsable.HasValue) queryParams.Add($"idResponsable={idResponsable}");
            if (!string.IsNullOrWhiteSpace(entidadAfectada)) queryParams.Add($"entidadAfectada={Uri.EscapeDataString(entidadAfectada)}");

            string queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";
            return await ObtenerArchivoPdfAsync($"Reportes/auditoria/pdf{queryString}");
        }

        private async Task<byte[]> ObtenerArchivoPdfAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            await ApiHelper.ProcesarErrorApiAsync(response);
            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}