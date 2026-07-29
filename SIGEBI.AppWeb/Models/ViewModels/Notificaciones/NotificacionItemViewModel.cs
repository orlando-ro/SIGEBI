using System;

namespace SIGEBI.AppWeb.Models.Notificaciones
{
    public class NotificacionItemViewModel
    {
        public int Id { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public DateTime FechaEnvio { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public bool Leida { get; set; }

        // Lógica de presentación: Asigna un color de Bootstrap según el tipo de evento del SRS
        public string ColorBadge => Tipo switch
        {
            "RecordatorioPrestamo" => "bg-warning text-dark", // CU-NOT-01
            "AlertaRetraso" => "bg-danger",
            "AvisoPenalizacion" => "bg-danger",             // CU-NOT-02
            "ConfirmacionDevolucion" => "bg-success",
            "PrestamoFormalizado" => "bg-primary",          // CU-NOT-03
            "penalizacionResuelta" => "bg-info text-dark",  // CU-NOT-04
            _ => "bg-secondary"
        };

        // Lógica de presentación: Asigna un icono de Bootstrap Icons según el tipo
        public string Icono => Tipo switch
        {
            "RecordatorioPrestamo" => "bi-calendar-event",
            "AlertaRetraso" => "bi-clock-history",
            "AvisoPenalizacion" => "bi-exclamation-triangle-fill",
            "ConfirmacionDevolucion" => "bi-box-arrow-in-left",
            "PrestamoFormalizado" => "bi-journal-check",
            "penalizacionResuelta" => "bi-shield-check",
            _ => "bi-bell"
        };
    }
}