using SIGEBI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioAuditoria
    {
        // --- MÉTODOS DE REGISTRO (Utilizados por Gestores como GestorDevoluciones y GestorPenalizaciones) ---
        Task RegistrarAccionAsync(string idUsuario, string tipoAccion, string entidadAfectada, string detalles = "");

        // Método de LECTURA (Lo usará el Controlador de la API para el Auditor)
        Task<IEnumerable<AuditoriaResponseDTO>> ConsultarHistorialAsync(string? idUsuarioActor = null, string? entidadAfectada = null);
    }
}
