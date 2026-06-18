using SIGEBI.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Domain.Entities
{
    /// <summary>
    /// Entidad que representa una multa o sanción económica a un usuario
    /// por retrasos en devoluciones o daños a los recursos.
    /// </summary>
    public class Penalizacion
    {
        public int IdPenalizacion { get; set; }

        // Propiedades protegidas para evitar alteraciones externas
        public double Monto { get; private set; }
        public string Motivo { get; private set; }
        public DateTime FechaEmision { get; private set; }
        public bool Pagada { get; private set; }

        // Relaciones (A quién pertenece la multa)
        public string IdUsuario { get; private set; }
        public Usuario Usuario { get; set; }

        // Constructor vacío requerido por Entity Framework Core
        protected Penalizacion() { }

        // Constructor de negocio (CUMPLE REGLAS DE INTEGRIDAD DEL SISTEMA)
        public Penalizacion(string idUsuario, double monto, string motivo)
        {
            if (string.IsNullOrWhiteSpace(idUsuario))
                throw new NegocioExeption("La penalización debe estar asociada a un usuario.");

            if (monto <= 0)
                throw new NegocioExeption("El monto de la penalización debe ser mayor a cero.");

            if (string.IsNullOrWhiteSpace(motivo))
                throw new NegocioExeption("Se debe especificar el motivo de la penalización (ej. Retraso, Daño).");

            IdUsuario = idUsuario;
            Monto = monto;
            Motivo = motivo;
            FechaEmision = DateTime.Now;
            Pagada = false; // Toda penalización nace como 'no pagada' por defecto
        }

        // Método de negocio protegido
        public void MarcarComoPagada()
        {
            if (Pagada)
                throw new NegocioExeption("Esta penalización ya se encuentra pagada, no se puede volver a pagar.");

            Pagada = true;
        }
    }
}