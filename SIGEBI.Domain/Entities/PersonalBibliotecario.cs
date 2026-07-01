using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Domain.Entities
{
    public class PersonalBibliotecario : Usuario
    {
        public string NumeroEmpleado { get; set; } = string.Empty;
    }
}