using System;
using System.Text.Json.Serialization;

namespace SIGEBI.AppEscritorio.DTOs.Penalizaciones
{
    public class PenalizacionResponseDTO
    {
        [JsonPropertyName("idPenalizacion")]
        public int IdPenalizacion { get; set; }

        [JsonPropertyName("monto")]
        public double Monto { get; set; }

        [JsonPropertyName("motivo")]
        public string Motivo { get; set; } = string.Empty;

        [JsonPropertyName("fechaEmision")]
        public DateTime FechaEmision { get; set; }

        [JsonPropertyName("pagada")]
        public bool Pagada { get; set; }

        [JsonPropertyName("idUsuario")]
        public int IdUsuario { get; set; }

        [JsonPropertyName("idPrestamo")]
        public int? IdPrestamo { get; set; }

        [JsonPropertyName("fechaResolucion")]
        public DateTime? FechaResolucion { get; set; }

        [JsonPropertyName("idUsuarioResolutor")]
        public int? IdUsuarioResolutor { get; set; }

        [JsonPropertyName("motivoResolucion")]
        public string MotivoResolucion { get; set; } = string.Empty;

        [JsonPropertyName("nombreUsuario")]
        public string? NombreUsuario { get; set; }

        [JsonPropertyName("matricula")]
        public string? Matricula { get; set; }

        [JsonPropertyName("numeroEmpleado")]
        public string? NumeroEmpleado { get; set; }
    }
}