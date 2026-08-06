using SIGEBI.Application.DTOs;
using SIGEBI.Application.Helpers;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Application.Services
{
    public class GestorPenalizaciones : IServicioPenalizacion
    {
        private readonly IRepoPenalizacion _repoPenalizacion;
        private readonly IServicioAuditoria _servicioAuditoria;
        private readonly IServicioNotificacion _servicioNotificacion;
        private readonly IUsuarios _usuarios;
        public GestorPenalizaciones(IRepoPenalizacion repoPenalizacion, 
            IServicioAuditoria servicioAuditoria, 
            IServicioNotificacion servicioNotificacion,
            IUsuarios usuarios)
        {
            _repoPenalizacion = repoPenalizacion;
            _servicioAuditoria = servicioAuditoria;
            _servicioNotificacion = servicioNotificacion;
            _usuarios = usuarios;
        }

        
        public async Task GenerarMultaPorRetrasoAsync(
          int idUsuario,
          int idPrestamo,
          int diasRetraso)
        {
            if (idUsuario <= 0)
                throw new NegocioExeption("El usuario es obligatorio.");

            if (idPrestamo <= 0)
                throw new NegocioExeption("El préstamo es obligatorio.");

            if (diasRetraso <= 0)
                throw new NegocioExeption("Los días de retraso deben ser mayores que cero.");

            double tarifaPorDia = 50.0;
            double montoTotal = diasRetraso * tarifaPorDia;

            var nuevaPenalizacion = new Penalizacion(
                idUsuario,
                montoTotal,
                $"Retraso de {diasRetraso} días en devolución.",
                idPrestamo
            );

            await _repoPenalizacion.AgregarAsync(nuevaPenalizacion);

            var usuario = await _usuarios.ObtenerUsuarioConDetallesAsync(idUsuario);
            string nombre = usuario?.Nombre ?? "Desconocido";

            await _servicioAuditoria.RegistrarAccionAsync(
                idResponsable: idUsuario,
                tipoAccion: "Generar penalización",
                entidadAfectada: "Multas y Penalidades",
                detalles: $"El usuario {nombre} recibió una penalización automática por retraso de {diasRetraso} días."
            );

            await _servicioNotificacion.EnviarNotificacionAsync(
                idUsuario,
                $"Se generó una penalización por retraso del prestamo realizado en la fecha {nuevaPenalizacion.FechaEmision }." +
                $"Días de retraso: {diasRetraso}. " +
                $"Monto: RD$ {montoTotal:N2}.",
                TipoNotificacion.AvisoPenalizacion
);
        }

        public async Task GenerarPenalizacionPorCondicionAsync(
          int idUsuario,
          int idPrestamo,
          CondicionDevolucion condicion)
        {
            double monto = condicion switch
            {
                CondicionDevolucion.Dañado => 500,
                CondicionDevolucion.Extraviado => 1500,
                _ => 0
            };

            if (monto <= 0)
                return;

            string motivo = condicion switch
            {
                CondicionDevolucion.Dañado => "Daño del recurso bibliográfico",
                CondicionDevolucion.Extraviado => "Extravío del recurso bibliográfico",
                _ => string.Empty
            };

            var penalizacion = new Penalizacion(
                idUsuario,
                monto,
                motivo,
                idPrestamo
            );

            await _repoPenalizacion.AgregarAsync(penalizacion);

            var usuarioPen = await _usuarios.ObtenerUsuarioConDetallesAsync(idUsuario);
            string nombrePen = usuarioPen?.Nombre ?? "Desconocido";

            await _servicioAuditoria.RegistrarAccionAsync(
                idResponsable: idUsuario,
                tipoAccion: "Generar penalización",
                entidadAfectada: "Multas y Penalidades",
                detalles: $"El usuario {nombrePen} recibió una penalización por entregar el recurso {condicion}. Motivo: {motivo}."
            );
            await _servicioNotificacion.EnviarNotificacionAsync(
               idUsuario,
               $"Se generó una penalización asociada al préstamo realizado en la fecha {penalizacion.FechaEmision}. " +
               $"Motivo: {motivo}. " +
               $"Monto: RD$ {monto:N2}.",
               TipoNotificacion.AvisoPenalizacion                   
);
        }

        public async Task<IEnumerable<PenalizacionResponseDTO>> ObtenerPendientesPorUsuariosAsync(string MatriculaONumeroEmpleado)
        {
            var usuario = await ResolucionUsuario.ObtenerPorIdentificadorAsync(_usuarios, MatriculaONumeroEmpleado);

            var penalizacionesPendientes = await _repoPenalizacion.ObtenerPendientesPorUsuarioAsync(usuario.IdUsuario);

            if (penalizacionesPendientes == null || !penalizacionesPendientes.Any())
               return new List<PenalizacionResponseDTO>();


            return penalizacionesPendientes.Select(p => MapearPenalizacionResponse(p, usuario));
        }

        public async Task ProcesarPagoMultaAsync(int idPenalizacion, PenalizacionRequestDTO peticion, int idUsuarioResolutor)
        {
            if (peticion == null)
                throw new NegocioExeption("La petición no puede ser nula.");

            if (idUsuarioResolutor <= 0)
                throw new NegocioExeption("El usuario resolutor es obligatorio.");

            var penalizacion = await _repoPenalizacion.ObtenerPendientePorIdYUsuarioAsync(
                idPenalizacion,
                peticion.MatriculaONumeroEmpleado
            );

            if (penalizacion == null)
                throw new NegocioExeption("La penalización indicada no existe.");

            // Lógica de Dominio
            penalizacion.MarcarComoPagada(
            idUsuarioResolutor,
            peticion.MotivoResolucion
             );

            // Persistencia
            await _repoPenalizacion.ActualizarAsync(penalizacion);

            var resolutor = await _usuarios.ObtenerUsuarioConDetallesAsync(idUsuarioResolutor);
            string nombrePenalizado = penalizacion.Usuario?.Nombre ?? peticion.MatriculaONumeroEmpleado;

            await _servicioAuditoria.RegistrarAccionAsync(
                idUsuarioResolutor,
                "Resolver Penalización",
                "Multas y Penalidades",
                $"El administrador/bibliotecario {resolutor?.Nombre} registró el pago y resolvió la penalización de {nombrePenalizado}. Motivo: {peticion.MotivoResolucion}."
            );

            await _servicioNotificacion.EnviarNotificacionAsync(
                 penalizacion.IdUsuario,
                 $"Tu penalización que fue realizada en la fecha {penalizacion.FechaEmision} ha sido resuelta " +
                 $"Motivo de resolución: {peticion.MotivoResolucion}.",
                 TipoNotificacion.penalizacionResuelta
);
        }


        public async Task<IEnumerable<PenalizacionResponseDTO>> ObtenerTodasPendientesAsync()
        {
            var penalizacionesPendientes = await _repoPenalizacion.ObtenerTodasPendientesAsync();

            if (penalizacionesPendientes == null || !penalizacionesPendientes.Any())
                return new List<PenalizacionResponseDTO>();

            return penalizacionesPendientes.Select(p => MapearPenalizacionResponse(p, p.Usuario));
        }

        public async Task<IEnumerable<PenalizacionResponseDTO>> ObtenerHistorialPorUsuariosAsync(string MatriculaONumeroEmpleado)
        {
            var usuario = await ResolucionUsuario.ObtenerPorIdentificadorAsync(_usuarios, MatriculaONumeroEmpleado);
            var penalizacionesHistorial = await _repoPenalizacion.ObtenerHistorialPorUsuarioAsync(usuario.IdUsuario);

            if (penalizacionesHistorial == null || !penalizacionesHistorial.Any())
                return new List<PenalizacionResponseDTO>();

            return penalizacionesHistorial.Select(p => MapearPenalizacionResponse(p, usuario));
        }

        public async Task<IEnumerable<PenalizacionResponseDTO>> ObtenerHistorialCompletoAsync()
        {
            var penalizacionesHistorial = await _repoPenalizacion.ObtenerHistorialCompletoAsync();

            if (penalizacionesHistorial == null || !penalizacionesHistorial.Any())
                return new List<PenalizacionResponseDTO>();

            return penalizacionesHistorial.Select(p => MapearPenalizacionResponse(p, p.Usuario));
        }

        private static PenalizacionResponseDTO MapearPenalizacionResponse(Penalizacion penalizacion, Usuario? usuario)
        {
            return new PenalizacionResponseDTO
            {
                IdPenalizacion = penalizacion.IdPenalizacion,
                IdUsuario = penalizacion.IdUsuario,
                NombreUsuario = usuario?.Nombre ?? string.Empty,
                Matricula = usuario is Estudiante estudiante ? estudiante.Matricula : null,
                NumeroEmpleado = usuario?.NumeroEmpleado ?? string.Empty,
                Monto = penalizacion.Monto,
                Motivo = penalizacion.Motivo,
                FechaEmision = penalizacion.FechaEmision,
                Pagada = penalizacion.Pagada,
                IdPrestamo = penalizacion.IdPrestamo,
                FechaResolucion = penalizacion.FechaResolucion,
                MotivoResolucion = penalizacion.MotivoResolucion,
                IdUsuarioResolutor = penalizacion.IdUsuarioResolutor,
                NombreResolutor = penalizacion.UsuarioResolutor?.Nombre ?? string.Empty
            };
        }

    }
}
