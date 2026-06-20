using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Domain.Entities
{
        
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
            public string IdUsuario { get; set; } = string.Empty; 
            public string Mensaje { get; set; } = string.Empty;
            public DateTime FechaEnvio { get; set; } = DateTime.Now;
            public bool Leida { get; set; } = false;
            public TipoNotificacion Tipo { get; set; }

            
            public virtual Usuario? Usuario { get; set; }

            
            public void MarcarComoLeida()
            {
                Leida = true;
            }
        }
    }
