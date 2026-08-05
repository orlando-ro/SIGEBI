using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SIGEBI.AppEscritorio.DTOs.Penalizaciones
{
    public class PenalizacionResponseDTO
    {
        // Columnas visibles en la tabla principal
        [DisplayName("Usuario Penalizado")]
        [JsonPropertyName("nombreUsuario")]
        public string? NombreUsuario { get; set; }

        [DisplayName("Fecha de Emisión")]
        [JsonPropertyName("fechaEmision")]
        public DateTime FechaEmision { get; set; }

        [DisplayName("Estado")]
        [JsonIgnore] // Calculado en el cliente, no viene en el JSON
        public string EstadoPago => Pagada ? "Resuelta / Pagada" : "Pendiente de Pago";

       
        [Browsable(false)]
        [JsonPropertyName("idPenalizacion")]
        public int IdPenalizacion { get; set; }

        [Browsable(false)]
        [JsonPropertyName("monto")]
        public double Monto { get; set; }

        [Browsable(false)]
        [JsonPropertyName("motivo")]
        public string Motivo { get; set; } = string.Empty;

        [Browsable(false)]
        [JsonPropertyName("pagada")]
        public bool Pagada { get; set; }

        [Browsable(false)]
        [JsonPropertyName("idUsuario")]
        public int IdUsuario { get; set; }

        [Browsable(false)]
        [JsonPropertyName("idPrestamo")]
        public int? IdPrestamo { get; set; }

        [Browsable(false)]
        [JsonPropertyName("fechaResolucion")]
        public DateTime? FechaResolucion { get; set; }

        [Browsable(false)]
        [JsonPropertyName("idUsuarioResolutor")]
        public int? IdUsuarioResolutor { get; set; }

        [Browsable(false)]
        [JsonPropertyName("motivoResolucion")]
        public string MotivoResolucion { get; set; } = string.Empty;

        [Browsable(false)]
        [JsonPropertyName("matricula")]
        public string? Matricula { get; set; }

        [Browsable(false)]
        [JsonPropertyName("numeroEmpleado")]
        public string? NumeroEmpleado { get; set; }

        [Browsable(false)]
        [JsonPropertyName("nombreResolutor")]
        public string? NombreResolutor { get; set; }
    }
}