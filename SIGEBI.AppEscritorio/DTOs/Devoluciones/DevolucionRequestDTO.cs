using SIGEBI.AppEscritorio.Enums;
using System.Text.Json.Serialization;

namespace SIGEBI.AppEscritorio.DTOs.Devoluciones
{
    public class DevolucionRequestDTO
    {
        [JsonPropertyName("idPrestamo")]
        public int IdPrestamo { get; set; }

        [JsonPropertyName("condicionLibro")]
        public CondicionDevolucion CondicionLibro { get; set; }

        [JsonPropertyName("observaciones")]
        public string Observaciones { get; set; } = string.Empty;
    }
}