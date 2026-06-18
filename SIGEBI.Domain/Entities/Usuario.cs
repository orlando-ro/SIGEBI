using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Domain.Entities
{
    public abstract class Usuario
    {
        // para hacer la relacion
        public string IdUsuario { get; set; } = string.Empty;

        // para que el feature funcione
        public virtual ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();
    }
}