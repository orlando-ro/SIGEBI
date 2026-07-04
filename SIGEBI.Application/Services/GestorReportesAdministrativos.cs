using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.Services
{
    public class GestorReportesAdministrativos : IServicioReportes
    {
    
        private readonly IRepositorioReporte _repoReporte;
        private readonly IUsuarios _repoUsuarios;
        private readonly IServicioAuditoria _servicioAuditoria;

        // Inyectamos las dependencias
        public GestorReportesAdministrativos(IRepositorioReporte repoReporte, IServicioAuditoria servicioAuditoria, IUsuarios repoUsuarios)
        {
            _repoReporte = repoReporte;
            _servicioAuditoria = servicioAuditoria;
            _repoUsuarios = repoUsuarios;
        }

        public async Task<ReporteResponseDTO> SolicitarGeneracionReporteAsync(ReporteRequestDTO peticion)
        {
            if (peticion == null)
                throw new NegocioExeption("Los datos de la solicitud del reporte son obligatorios.");

            if (string.IsNullOrWhiteSpace(peticion.TipoReporte))
                throw new NegocioExeption("Debe especificar el tipo de reporte.");

            if (string.IsNullOrWhiteSpace(peticion.MatriculaONumeroEmpleado))
                throw new NegocioExeption("Debe indicar la matrícula o número de empleado del solicitante.");

            var usuarioSolicitante = await _repoUsuarios
                .ObtenerPorMatriculaONumeroEmpleadoAsync(peticion.MatriculaONumeroEmpleado);

            if (usuarioSolicitante == null)
                throw new NegocioExeption("No existe un usuario con esa matrícula o número de empleado.");

            var nuevoReporte = new Reporte(
                peticion.TipoReporte,
                usuarioSolicitante.IdUsuario
            );

            await _repoReporte.AgregarAsync(nuevoReporte);

            await _servicioAuditoria.RegistrarAccionAsync(
                idUsuario: usuarioSolicitante.IdUsuario,
                tipoAccion: "Solicitud Reporte",
                entidadAfectada: "Reporte",
                detalles: $"El usuario {usuarioSolicitante.Nombre} solicitó la generación de un reporte de tipo: {peticion.TipoReporte}."
            );

            return MapearReporteResponse(nuevoReporte, usuarioSolicitante);
        }

        public async Task<IEnumerable<ReporteResponseDTO>> ConsultarTodosAsync()
        {
            var reportes = await _repoReporte.ObtenerTodosAsync();

            return await MapearListaReportesAsync(reportes);
        }

        public async Task<IEnumerable<ReporteResponseDTO>> ConsultarPendientesAsync()
        {
            var reportes = await _repoReporte.ObtenerPendientesAsync();

            return await MapearListaReportesAsync(reportes);
        }

        public async Task<IEnumerable<ReporteResponseDTO>> ConsultarPorEstadoAsync(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado))
                throw new NegocioExeption("Debe indicar el estado del reporte.");

            var reportes = await _repoReporte.ObtenerPorEstadoAsync(estado);

            return await MapearListaReportesAsync(reportes);
        }

        public async Task<IEnumerable<ReporteResponseDTO>> ConsultarPorSolicitanteAsync(string matriculaONumeroEmpleado)
        {
            if (string.IsNullOrWhiteSpace(matriculaONumeroEmpleado))
                throw new NegocioExeption("Debe indicar la matrícula o número de empleado del solicitante.");

            var usuario = await _repoUsuarios
                .ObtenerPorMatriculaONumeroEmpleadoAsync(matriculaONumeroEmpleado);

            if (usuario == null)
                throw new NegocioExeption("No existe un usuario con esa matrícula o número de empleado.");

            var reportes = await _repoReporte.ObtenerPorUsuarioAsync(usuario.IdUsuario);

            return reportes.Select(r => MapearReporteResponse(r, usuario));
        }

        private async Task<IEnumerable<ReporteResponseDTO>> MapearListaReportesAsync(IEnumerable<Reporte> reportes)
        {
            var resultado = new List<ReporteResponseDTO>();

            foreach (var reporte in reportes)
            {
                var usuario = await _repoUsuarios.ObtenerPorIdAsync(reporte.IdUsuarioSolicitante);

                if (usuario == null)
                    continue;

                resultado.Add(MapearReporteResponse(reporte, usuario));
            }

            return resultado;
        }

        private static ReporteResponseDTO MapearReporteResponse(Reporte reporte, Usuario usuario)
        {
            return new ReporteResponseDTO
            {
                IdReporte = reporte.IdReporte,
                TipoReporte = reporte.TipoReporte,
                FechaSolicitud = reporte.FechaSolicitud,
                FechaGeneracion = reporte.FechaGeneracion,
                Estado = reporte.Estado,
                RutaArchivo = reporte.RutaArchivo,
                IdUsuarioSolicitante = reporte.IdUsuarioSolicitante,
                NombreUsuarioSolicitante = usuario.Nombre,
                Matricula = usuario is Estudiante estudiante ? estudiante.Matricula : null,
                NumeroEmpleado = usuario.NumeroEmpleado
            };
        }
    }
}
