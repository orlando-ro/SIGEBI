using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioPenalizacion
    {
        Task GenerarMultaPorRetrasoAsync(string idUsuario, int diasRetraso);

        Task ProcesarPagoMultaAsync(int idPenalizacion);
    }
}

