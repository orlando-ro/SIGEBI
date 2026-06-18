using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Domain.Entities
{
        // Enumerador para controlar los tipos válidos de notificación
        public enum TipoNotificacion
        {
            RecordatorioPrestamo,
            AlertaRetraso,
            ConfirmacionDevolucion,
            AvisoPenalizacion
        }

        public class Notificacion
        {
            public int IdNotificacion { get; set; }
            public string IdUsuario { get; set; } = string.Empty; // Relación con el usuario que recibe
            public string Mensaje { get; set; } = string.Empty;
            public DateTime FechaEnvio { get; set; } = DateTime.Now;
            public bool Leida { get; set; } = false;
            public TipoNotificacion Tipo { get; set; }

            // Propiedad de navegación hacia la clase base Usuario que creaste antes
            public virtual Usuario? Usuario { get; set; }

            // Regla de negocio del Dominio: Marcar como leída
            public void MarcarComoLeida()
            {
                Leida = true;
            }
        }
    }
