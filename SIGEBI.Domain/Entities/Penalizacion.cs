using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Domain.Entities
{
    
    public class Penalizacion
    {
        public int IdPenalizacion { get; set; }

        
        public double Monto { get; private set; }
        public string Motivo { get; private set; }
        public DateTime FechaEmision { get; private set; }
        public bool Pagada { get; private set; }

        
        public int IdUsuario { get; private set; }
        public Usuario Usuario { get; set; }

        
        protected Penalizacion() { }

        
        public Penalizacion(int idUsuario, double monto, string motivo)
        {
            if (idUsuario <= 0)
                throw new NegocioExeption("La penalización debe estar asociada a un usuario.");

            if (monto <= 0)
                throw new NegocioExeption("El monto de la penalización debe ser mayor a cero.");

            if (motivo == null)
                throw new NegocioExeption("Se debe especificar el motivo de la penalización (ej. Retraso, Daño).");

            IdUsuario = idUsuario;
            Monto = monto;
            Motivo = motivo;
            FechaEmision = DateTime.Now;
            Pagada = false; 
        }

        
        public void MarcarComoPagada()
        {
            if (Pagada)
                throw new NegocioExeption("Esta penalización ya se encuentra pagada, no se puede volver a pagar.");

            Pagada = true;
        }
    }
}