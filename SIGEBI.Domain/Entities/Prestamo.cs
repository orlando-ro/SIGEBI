using System;
using System.Collections.Generic;


namespace SIGEBI.Domain.Entities
{
    public class Prestamo
    {
        public int IdPrestamo { get; set; }
        public Usuario UsuarioResponsable { get; set; }
        public Libro LibroPrestado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaLimite { get; set; }
        public EstadoPrestamo Estado { get; set; }

    }
}
