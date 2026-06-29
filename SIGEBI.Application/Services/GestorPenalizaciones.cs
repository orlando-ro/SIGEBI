using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.Services
{
    public class GestorPenalizaciones : IServicioPenalizacion
    {
        private readonly IRepoPenalizacion _repoPenalizacion;
        private readonly IServicioAuditoria _servicioAuditoria;

        public GestorPenalizaciones(IRepoPenalizacion repoPenalizacion, IServicioAuditoria servicioAuditoria)
        {
            _repoPenalizacion = repoPenalizacion;
            _servicioAuditoria = servicioAuditoria;
        }

        // Método automático llamado por GestorDevoluciones (CU-DEV-02)
        public async Task GenerarMultaPorRetrasoAsync(string idUsuario, int diasRetraso)
        {
            double tarifaPorDia = 50.0;
            double montoTotal = diasRetraso * tarifaPorDia;

            var nuevaPenalizacion = new Penalizacion(idUsuario, montoTotal, $"Retraso de {diasRetraso} días en devolución.");

            await _repoPenalizacion.AgregarAsync(nuevaPenalizacion);
        }

        // Método manual ejecutado por el Bibliotecario/Admin para resolver multas (CU-PEN-03)
        // Sobrecargado para aceptar el DTO de entrada.
        public async Task ProcesarPagoMultaAsync(PenalizacionRequestDTO peticion, string idUsuarioResolutor)
        {
            var penalizacion = await _repoPenalizacion.ObtenerPorIdAsync(peticion.IdPenalizacion);

            if (penalizacion == null)
                throw new NegocioExeption("La penalización indicada no existe.");

            // Lógica de Dominio
            penalizacion.MarcarComoPagada();

            // Persistencia
            await _repoPenalizacion.ActualizarAsync(penalizacion);

            // Auditoría
            await _servicioAuditoria.RegistrarAccionAsync(
                idUsuarioResolutor,
                "Resolver Penalización",
                "Penalizacion",
                $"Penalización {peticion.IdPenalizacion} marcada como pagada. Motivo: {peticion.MotivoResolucion}"
            );
        }

        // Mantenemos la firma de la interfaz original por retrocompatibilidad
         public async Task ProcesarPagoMultaAsync(int idPenalizacion)
        {
            // Reutiliza la lógica con un DTO básico si solo se provee el ID
            var peticion = new PenalizacionRequestDTO
            {
                IdPenalizacion = idPenalizacion,
                MotivoResolucion = "Pago estándar"
            };
            await ProcesarPagoMultaAsync(peticion, "Sistema"); 
        } 
    }
}
