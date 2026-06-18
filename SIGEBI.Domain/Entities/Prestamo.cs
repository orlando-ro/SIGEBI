using SIGEBI.Domain.Exceptions;
using System;
using System.Collections.Generic;


namespace SIGEBI.Domain.Entities
{
    
    public class Prestamo
    {
        public int IdPrestamo { get; set; }

        public DateTime FechaInicio { get; private set; }
        public DateTime FechaVencimiento { get; private set; }

        // AQUÍ ESTABA EL ERROR: Ahora es un string simple
        public string Estado { get; private set; }

        public string IdUsuario { get; private set; }
        public Usuario Usuario { get; set; }
        public ICollection<Libro> Libros { get; private set; } = new List<Libro>();

        protected Prestamo() { }

        public Prestamo(string idUsuario, DateTime fechaInicio, DateTime fechaVencimiento, List<Libro> libros)
        {
            if (string.IsNullOrWhiteSpace(idUsuario))
                throw new NegocioExeption("El préstamo debe estar asociado a un usuario.");

            if (libros == null || !libros.Any())
                throw new NegocioExeption("El préstamo debe contener al menos un recurso bibliográfico.");

            if (fechaVencimiento <= fechaInicio)
                throw new NegocioExeption("La fecha límite de devolución debe ser posterior a la fecha de inicio.");

            IdUsuario = idUsuario;
            FechaInicio = fechaInicio;
            FechaVencimiento = fechaVencimiento;
            Estado = "Activo"; // Lo guardamos como texto
            Libros = libros;
        }

        public int CalcularDiasRetraso()
        {
            if (Estado != "Devuelto" && DateTime.Now > FechaVencimiento)
            {
                TimeSpan retraso = DateTime.Now - FechaVencimiento;
                return (int)retraso.TotalDays;
            }
            return 0;
        }

        public void RegistrarDevolucion()
        {
            if (Estado == "Devuelto")
                throw new NegocioExeption("Este préstamo ya se encuentra devuelto.");

            Estado = "Devuelto";

            foreach (var libro in Libros)
            {
                libro.IncrementarCopia();
            }
        }
    }
}
