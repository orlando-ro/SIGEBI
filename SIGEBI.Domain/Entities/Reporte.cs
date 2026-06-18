using SIGEBI.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Domain.Entities
{
    public class Reporte
    {
        public int IdReporte { get; private set; }

        public string TipoReporte { get; private set; } // Ej: "PrestamosVencidos", "InventarioLibros"
        public DateTime FechaSolicitud { get; private set; }
        public DateTime? FechaGeneracion { get; private set; } // Nullable porque al inicio no se ha generado

        public string IdUsuarioSolicitante { get; private set; }
        public string Estado { get; private set; } // "Pendiente", "Completado", "Fallido"

        public string RutaArchivo { get; private set; } // Ruta donde se guardó el PDF o Excel generado

        // Constructor vacío requerido por Entity Framework
        protected Reporte() { }

        // El reporte nace cuando un usuario lo solicita
        public Reporte(string tipoReporte, string idUsuarioSolicitante)
        {
            if (string.IsNullOrWhiteSpace(tipoReporte))
                throw new NegocioExeption("Debe especificar el tipo de reporte a generar.");

            if (string.IsNullOrWhiteSpace(idUsuarioSolicitante))
                throw new NegocioExeption("El reporte debe estar asociado al usuario que lo solicitó.");

            TipoReporte = tipoReporte;
            IdUsuarioSolicitante = idUsuarioSolicitante;
            FechaSolicitud = DateTime.Now;
            Estado = "Pendiente"; // Todo reporte inicia en pendiente
            RutaArchivo = string.Empty;
        }

        // --- Reglas de Negocio / Métodos de Dominio ---

        public void MarcarComoCompletado(string rutaArchivoGuardado)
        {
            if (Estado != "Pendiente")
                throw new NegocioExeption($"No se puede completar un reporte que actualmente está en estado '{Estado}'.");

            if (string.IsNullOrWhiteSpace(rutaArchivoGuardado))
                throw new NegocioExeption("Para completar el reporte, debe proporcionar la ruta del archivo generado.");

            Estado = "Completado";
            RutaArchivo = rutaArchivoGuardado;
            FechaGeneracion = DateTime.Now;
        }

        public void MarcarComoFallido()
        {
            if (Estado != "Pendiente")
                throw new NegocioExeption($"No se puede fallar un reporte que actualmente está en estado '{Estado}'.");

            Estado = "Fallido";
            FechaGeneracion = DateTime.Now;
        }
    }
}
