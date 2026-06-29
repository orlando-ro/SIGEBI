using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.Services
{
    public class GestorReportesAdministrativos
    {
        private readonly IRepositorioReporte _repoReporte;
        private readonly IServicioAuditoria _servicioAuditoria;

        // Inyectamos las dependencias
        public GestorReportesAdministrativos(IRepositorioReporte repoReporte, IServicioAuditoria servicioAuditoria)
        {
            _repoReporte = repoReporte;
            _servicioAuditoria = servicioAuditoria;
        }

        public async Task SolicitarGeneracionReporteAsync(ReporteRequestDTO peticion)
        {
           
            var nuevoReporte = new Reporte(peticion.TipoReporte, peticion.IdUsuarioSolicitante);

            
            await _repoReporte.AgregarAsync(nuevoReporte);

            
            await _servicioAuditoria.RegistrarAccionAsync(
                idUsuario: peticion.IdUsuarioSolicitante,
                tipoAccion: "Solicitud Reporte",
                entidadAfectada: "Reporte",
                detalles: $"El usuario solicitó la generación de un reporte de tipo: {peticion.TipoReporte}"
            );
        }
    }
}
