using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Domain.Entities
{
    public class Penalizacion
    {
        public bool Pagada { get; set; } = false; // esto para que en usuario no me de error al verificar penalizaciones, ya que no se ha desarrollado la rama de desarrollo correspondiente a esta clase, pero es necesario para la regla de negocio del dominio en la clase Usuario
    }
}
