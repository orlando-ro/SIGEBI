using System;
using System.Collections.Generic;

namespace SIGEBI.AppWeb.Models.Devoluciones
{
    public class DevolucionItemViewModel
    {
        public int IdDevolucion { get; set; }
        public int IdPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public string CondicionLibro { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public bool GeneroPenalizacion { get; set; }
        public int DiasRetraso { get; set; }
        public List<string> TitulosLibros { get; set; } = new();
    }
}