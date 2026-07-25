using System.ComponentModel.DataAnnotations;

namespace SIGEBI.AppWeb.Models.Penalizaciones
{
    public class ResolverPenalizacionViewModel
    {
        [Required]
        public int IdPenalizacion { get; set; }

        [Required(ErrorMessage = "La matrícula o identificación es obligatoria para validar el pago.")]
        [Display(Name = "Identificación del Usuario (Matrícula/Empleado)")]
        public string MatriculaONumeroEmpleado { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe especificar cómo se resolvió esta penalización.")]
        [Display(Name = "Método o Motivo de Resolución")]
        [MinLength(5, ErrorMessage = "El motivo debe ser más descriptivo (Ej: Pago en efectivo, Exoneración por error de sistema).")]
        public string MotivoResolucion { get; set; } = string.Empty;

        // Propiedades de solo lectura para mostrar en la vista de confirmación
        public double MontoAdeudado { get; set; }
        public string Concepto { get; set; } = string.Empty;
    }
}