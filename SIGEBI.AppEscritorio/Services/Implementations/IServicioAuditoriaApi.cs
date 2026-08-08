using SIGEBI.AppEscritorio.DTOs.Auditoria;
using SIGEBI.AppEscritorio.Services.Helper;
using SIGEBI.AppEscritorio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SIGEBI.AppEscritorio.Services.Implementations
{
    public class ServicioAuditoriaApi : IServicioAuditoriaApi
    {
        private readonly HttpClient _httpClient;

        public ServicioAuditoriaApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AuditoriaResponseDTO>> ConsultarHistorialAuditoriaAsync(
            DateTime? fechaInicio = null,
            DateTime? fechaFin = null,
            string? accion = null,
            string? entidadAfectada = null)
        {
            var queryParams = new List<string>();

            if (fechaInicio.HasValue)
                queryParams.Add($"fechaInicio={fechaInicio.Value:yyyy-MM-dd}");

            if (fechaFin.HasValue)
                queryParams.Add($"fechaFin={fechaFin.Value:yyyy-MM-dd}");

            if (!string.IsNullOrWhiteSpace(accion))
                queryParams.Add($"accion={Uri.EscapeDataString(accion)}");

            if (!string.IsNullOrWhiteSpace(entidadAfectada) && entidadAfectada != "Todos")
                queryParams.Add($"entidadAfectada={Uri.EscapeDataString(entidadAfectada)}");

            string queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";

            var response = await _httpClient.GetAsync($"RegistroAuditoria/ConsultarRegistrosAuditoria{queryString}");
            await ApiHelper.ProcesarErrorApiAsync(response);

            return await response.Content.ReadFromJsonAsync<List<AuditoriaResponseDTO>>() ?? new List<AuditoriaResponseDTO>();
        }

        public async Task<byte[]> ExportarHistorialPDFAsync(
            DateTime? fechaInicio = null,
            DateTime? fechaFin = null,
            string? accion = null,
            string? entidadAfectada = null)
        {
            var queryParams = new List<string>();

            if (fechaInicio.HasValue) queryParams.Add($"fechaInicio={fechaInicio.Value:yyyy-MM-dd}");
            if (fechaFin.HasValue) queryParams.Add($"fechaFin={fechaFin.Value:yyyy-MM-dd}");
            if (!string.IsNullOrWhiteSpace(accion)) queryParams.Add($"accion={Uri.EscapeDataString(accion)}");
            if (!string.IsNullOrWhiteSpace(entidadAfectada) && entidadAfectada != "Todos") queryParams.Add($"entidadAfectada={Uri.EscapeDataString(entidadAfectada)}");

            string queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";

            var response = await _httpClient.GetAsync($"RegistroAuditoria/ExportarPDF{queryString}");
            await ApiHelper.ProcesarErrorApiAsync(response);

            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}