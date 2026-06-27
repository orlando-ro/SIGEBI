using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioAuditoria
    {
        // --- MÉTODOS DE REGISTRO (Utilizados por Gestores como GestorDevoluciones y GestorPenalizaciones) ---
        Task RegistrarAccionAsync(string usuario, string modulo, string estado, string accion, string descripcion);
    }
}
