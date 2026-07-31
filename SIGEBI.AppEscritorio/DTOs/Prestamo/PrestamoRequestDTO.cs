using System.Text.Json.Serialization;

namespace SIGEBI.AppEscritorio.DTOs.Prestamos
{
    public class PrestamoRequestDTO
    {
        [JsonPropertyName("idSolicitud")]
        public int IdSolicitud { get; set; }
    }
}