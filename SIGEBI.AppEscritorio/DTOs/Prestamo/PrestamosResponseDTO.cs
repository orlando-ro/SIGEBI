using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SIGEBI.AppEscritorio.DTOs.Prestamos
{
    public class PrestamoResponseDTO
    {
        [Browsable(false)]
        [JsonPropertyName("idPrestamo")]
        public int IdPrestamo { get; set; }

        [DisplayName("Usuario Solicitante")]
        [JsonPropertyName("nombreUsuario")]
        public string NombreUsuario { get; set; } = string.Empty;

        [DisplayName("Matrícula / Emp.")]
        [JsonIgnore]
        public string IdentificadorUsuario => !string.IsNullOrEmpty(Matricula) ? Matricula : NumeroEmpleado ?? string.Empty;

        [DisplayName("Fecha Inicio")]
        [JsonPropertyName("fechaInicio")]
        public DateTime FechaInicio { get; set; }

        [DisplayName("Fecha Vencimiento")]
        [JsonPropertyName("fechaVencimiento")]
        public DateTime FechaVencimiento { get; set; }

        [DisplayName("Estado")]
        [JsonPropertyName("estado")]
        public string Estado { get; set; } = string.Empty;

        [DisplayName("Días Retraso")]
        [JsonPropertyName("diasRetraso")]
        public int DiasRetraso { get; set; }

       
        [Browsable(false)]
        [JsonPropertyName("estaVencido")]
        public bool EstaVencido { get; set; }

        [Browsable(false)]
        [JsonPropertyName("matricula")]
        public string? Matricula { get; set; }

        [Browsable(false)]
        [JsonPropertyName("numeroEmpleado")]
        public string? NumeroEmpleado { get; set; }

        [Browsable(false)]
        [JsonPropertyName("idUsuario")]
        public int IdUsuario { get; set; }

        // 👇 Se transporta en memoria para el modal, pero no se pinta en la tabla
        [Browsable(false)]
        [JsonPropertyName("titulosLibros")]
        public List<string> TitulosLibros { get; set; } = new();
    }
}