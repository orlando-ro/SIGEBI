using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SIGEBI.AppEscritorio.DTOs.Auditoria
{
    public class AuditoriaResponseDTO
    {
        [Browsable(false)]
        [JsonPropertyName("idAuditoria")]
        public int IdAuditoria { get; set; }

        [Browsable(false)]
        [JsonPropertyName("idResponsable")]
        public int? IdResponsable { get; set; }

        [Browsable(false)]
        [JsonPropertyName("fechaHora")]
        public DateTime FechaHora { get; set; }

        [DisplayName("Fecha y Hora")]
        [JsonPropertyName("fechaFormateada")]
        public string FechaFormateada { get; set; } = string.Empty;

        [DisplayName("Acción Realizada")]
        [JsonPropertyName("accion")]
        public string Accion { get; set; } = string.Empty;

        [DisplayName("Módulo / Entidad")]
        [JsonPropertyName("entidadAfectada")]
        public string EntidadAfectada { get; set; } = string.Empty;

        [DisplayName("Detalles de la Operación")]
        [JsonPropertyName("detalles")]
        public string Detalles { get; set; } = string.Empty;
    }
}