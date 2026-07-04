using SIGEBI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioPenalizacion
    {
        Task GenerarMultaPorRetrasoAsync(int idUsuario, int diasRetraso);


        Task ProcesarPagoMultaAsync(
            int idPenalizacion,
            PenalizacionRequestDTO peticion,
            int idUsuarioResolutor
        );
    }
}

