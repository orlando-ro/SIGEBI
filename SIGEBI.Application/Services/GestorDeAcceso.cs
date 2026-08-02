using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Exceptions;
using System.Threading.Tasks;

namespace SIGEBI.Application.Services
{
    public class GestorDeAcceso : IServicioAcceso
    {
        private readonly IUsuarios _repositorioUsuario;
        private readonly IServicioJwt _servicioJwt;

        public GestorDeAcceso(IUsuarios repositorioUsuario, IServicioJwt servicioJwt)
        {
            _repositorioUsuario = repositorioUsuario;
            _servicioJwt = servicioJwt;
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO request)
        {
            
            var usuario = await _repositorioUsuario.ObtenerPorMatriculaONumeroEmpleadoAsync(request.Identificador);

            if (usuario == null)
                throw new NegocioExeption("Credenciales incorrectas.");

            bool passwordValido = BCrypt.Net.BCrypt.Verify(request.Password, usuario.Password);

            if (!passwordValido)
                throw new NegocioExeption("Credenciales incorrectas.");

            if (usuario.Estado == "Inactivo")
                throw new NegocioExeption("El usuario se encuentra suspendido.");

            var usuarioConDetalles = await _repositorioUsuario.ObtenerUsuarioConDetallesAsync(usuario.IdUsuario);
            usuario = usuarioConDetalles ?? usuario;

            string tipoUsuario = usuario.GetType().Name;

            string? matricula = null;

            if (usuario is Estudiante estudiante)
            {
                matricula = estudiante.Matricula;
            }

            
            string tokenString = _servicioJwt.GenerarToken(usuario.IdUsuario, request.Identificador, tipoUsuario, usuario.Nombre);

            return new LoginResponseDTO
            {
                IdUsuario = usuario.IdUsuario,
                Matricula = matricula,
                NumeroEmpleado = usuario.NumeroEmpleado,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                TipoUsuario = tipoUsuario,
                Estado = usuario.Estado,
                Token = tokenString,
                HabilitadoParaPrestamos = usuario.Estado == "Activo" && !usuario.VerificarPenalizaciones()
            };
        }

        public async Task ValidarElegibilidadPorIdentificadorAsync(string identificador)
        {
            if (string.IsNullOrWhiteSpace(identificador))
                throw new NegocioExeption("Debe indicar la matricula o el numero de empleado");

            var usuario = await _repositorioUsuario.ObtenerPorMatriculaONumeroEmpleadoAsync(identificador);

            if (usuario == null)
                throw new NegocioExeption("El usuario no fue encontrado en el sistema.");

            usuario.ValidarElegibilidadParaPrestamo();
        }
    }
}