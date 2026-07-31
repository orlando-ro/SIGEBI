using System.Text.Json.Serialization;

namespace SIGEBI.AppEscritorio.DTOs.Solicitudes
{
    public class RechazoSolicitudRequestDTO
    {
        [JsonPropertyName("idSolicitud")]
        public int IdSolicitud { get; set; }

        [JsonPropertyName("motivoRechazo")]
        public string MotivoRechazo { get; set; } = string.Empty;
    }
}