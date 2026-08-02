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

        public async Task<List<AuditoriaResponseDTO>> ConsultarHistorialAuditoriaAsync(int? idResponsable = null, string? entidadAfectada = null)
        {
            var queryParams = new List<string>();
            if (idResponsable.HasValue)
                queryParams.Add($"idResponsable={idResponsable}");

            if (!string.IsNullOrWhiteSpace(entidadAfectada))
                queryParams.Add($"entidadAfectada={Uri.EscapeDataString(entidadAfectada)}");

            string queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";

            var response = await _httpClient.GetAsync($"RegistroAuditoria/ConsultarRegistrosAuditoria{queryString}");

            // Si hay error, el ApiHelper lanzará la excepción hacia el Formulario
            await ApiHelper.ProcesarErrorApiAsync(response);

            // Si llegamos aquí, fue un éxito (Status 200)
            return await response.Content.ReadFromJsonAsync<List<AuditoriaResponseDTO>>() ?? new List<AuditoriaResponseDTO>();
        }
    }
}