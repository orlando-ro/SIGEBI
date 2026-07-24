using System;
using System.Collections.Generic;

namespace SIGEBI.AppWeb.Models.Notificaciones
{
    public class HistorialNotificacionesViewModel
    {
        
        public IEnumerable<NotificacionItemViewModel> Notificaciones { get; set; } = new List<NotificacionItemViewModel>();

       
        public string? FiltroUsuario { get; set; }
        public string? FiltroTipoEvento { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
}