using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Application.Services
{
    public class GestorUsuarios : IServicioUsuarios
    {
        private readonly IUsuarios _repositorioUsuario;
        private readonly IServicioAuditoria _servicioAuditoria;

        public GestorUsuarios(
            IUsuarios repositorioUsuario,
            IServicioAuditoria servicioAuditoria)
        {
            _repositorioUsuario = repositorioUsuario;
            _servicioAuditoria = servicioAuditoria;
        }

        public async Task RegistrarUsuarioAsync(UsuarioRequestDTO dto)
        {
            if (dto == null)
                throw new NegocioExeption("Los datos del usuario son obligatorios.");

            ValidarDatosSegunTipoUsuario(dto);

            await ValidarDuplicadosParaRegistroAsync(dto);

            Usuario nuevoUsuario = CrearUsuarioSegunTipo(dto);

            nuevoUsuario.Nombre = dto.Nombre.Trim();
            nuevoUsuario.Email = dto.Email.Trim();
            nuevoUsuario.Estado = "Activo";
            nuevoUsuario.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            await _repositorioUsuario.AgregarAsync(nuevoUsuario);

            await _servicioAuditoria.RegistrarAccionAsync(
                idUsuario: nuevoUsuario.IdUsuario,
                tipoAccion: "Registrar usuario",
                entidadAfectada: "Usuario",
                detalles: $"Se ha registrado el usuario {nuevoUsuario.Nombre} con ID {nuevoUsuario.IdUsuario}."
            );
        }

        public async Task SuspenderUsuarioAsync(int idUsuario)
        {
            if (idUsuario <= 0)
                throw new NegocioExeption("El identificador del usuario no es válido.");

            var usuario = await _repositorioUsuario.ObtenerPorIdAsync(idUsuario);

            if (usuario == null)
                throw new NegocioExeption("El usuario no fue encontrado.");

            usuario.Estado = "Inactivo";

            await _repositorioUsuario.ActualizarAsync(usuario);

            await _servicioAuditoria.RegistrarAccionAsync(
                idUsuario: idUsuario,
                tipoAccion: "Suspender usuario",
                entidadAfectada: "Usuario",
                detalles: $"Se ha suspendido el usuario con ID {idUsuario}."
            );
        }

        public async Task SuspenderUsuarioPorIdentificadorAsync(string identificador)
        {
            var usuario = await _repositorioUsuario.ObtenerPorMatriculaONumeroEmpleadoAsync(identificador);

            if (usuario == null)
                throw new NegocioExeption("No se encontró ningún usuario con ese identificador.");

            await SuspenderUsuarioAsync(usuario.IdUsuario);
        }

        public async Task<UsuarioResponseDTO?> ObtenerUsuarioPorIdAsync(int idUsuario)
        {
            if (idUsuario <= 0)
                throw new NegocioExeption("El identificador del usuario no es válido.");

            var usuario = await _repositorioUsuario.ObtenerUsuarioConDetallesAsync(idUsuario);

            if (usuario == null)
                return null;

            return MapearUsuarioResponse(usuario);
        }

        public async Task<UsuarioResponseDTO?> ObtenerPorMatriculaONumeroEmpleadoAsync(string identificador)
        {
            var usuario = await _repositorioUsuario.ObtenerPorMatriculaONumeroEmpleadoAsync(identificador);

            if (usuario == null)
                return null;

            var usuarioConDetalles = await _repositorioUsuario.ObtenerUsuarioConDetallesAsync(usuario.IdUsuario);

            return usuarioConDetalles == null
                ? MapearUsuarioResponse(usuario)
                : MapearUsuarioResponse(usuarioConDetalles);
        }

        public async Task<IEnumerable<UsuarioResponseDTO>> ConsultarTodosAsync()
        {
            var usuarios = await _repositorioUsuario.ObtenerTodosConDetallesAsync();

            return usuarios.Select(MapearUsuarioResponse);
        }

        public async Task<LoginResponseDTO> AutenticarUsuarioAsync(LoginRequestDTO dto)
        {
            if (dto == null)
                throw new NegocioExeption("Las credenciales son obligatorias.");

            var usuario = await _repositorioUsuario.ObtenerPorEmailAsync(dto.Email);

            if (usuario == null)
                throw new NegocioExeption("Credenciales incorrectas.");

            bool passwordValida = BCrypt.Net.BCrypt.Verify(dto.Password, usuario.Password);

            if (!passwordValida)
                throw new NegocioExeption("Credenciales incorrectas.");

            if (usuario.Estado == "Inactivo")
                throw new NegocioExeption("El usuario se encuentra suspendido.");

            var usuarioConDetalles = await _repositorioUsuario.ObtenerUsuarioConDetallesAsync(usuario.IdUsuario);

            usuario = usuarioConDetalles ?? usuario;

            return new LoginResponseDTO
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Estado = usuario.Estado,
                TipoUsuario = usuario.GetType().Name,
                Matricula = usuario is Estudiante estudiante ? estudiante.Matricula : null,
                NumeroEmpleado = usuario.NumeroEmpleado,
                HabilitadoParaPrestamos = usuario.Estado == "Activo" && !usuario.VerificarPenalizaciones()
            };
        }

        public async Task ActualizarUsuarioAsync(int idUsuario, UsuarioUpdateRequestDTO dto)
        {
            if (idUsuario <= 0)
                throw new NegocioExeption("El identificador del usuario no es válido.");

            if (dto == null)
                throw new NegocioExeption("Los datos de actualización son obligatorios.");

            var usuario = await _repositorioUsuario.ObtenerPorIdAsync(idUsuario);

            if (usuario == null)
                throw new NegocioExeption("No se encontró el usuario.");

            await ValidarDuplicadosParaActualizacionAsync(usuario, dto);

            usuario.Nombre = dto.Nombre.Trim();
            usuario.Email = dto.Email.Trim();

            if (usuario is Estudiante estudiante)
            {
                if (!string.IsNullOrWhiteSpace(dto.NumeroEmpleado))
                    throw new NegocioExeption("Un estudiante no debe actualizarse con número de empleado.");

                if (!string.IsNullOrWhiteSpace(dto.Matricula))
                    estudiante.Matricula = dto.Matricula.Trim();
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(dto.Matricula))
                    throw new NegocioExeption("Este tipo de usuario no debe actualizarse con matrícula.");

                if (!string.IsNullOrWhiteSpace(dto.NumeroEmpleado))
                    usuario.NumeroEmpleado = dto.NumeroEmpleado.Trim();
            }

            await _repositorioUsuario.ActualizarAsync(usuario);
        }

        public async Task ActualizarPorIdentificadorAsync(string identificador, UsuarioUpdateRequestDTO dto)
        {
            var usuario = await _repositorioUsuario.ObtenerPorMatriculaONumeroEmpleadoAsync(identificador);

            if (usuario == null)
                throw new NegocioExeption("No se encontró ningún usuario con ese identificador.");

            await ActualizarUsuarioAsync(usuario.IdUsuario, dto);
        }

        private async Task ValidarDuplicadosParaRegistroAsync(UsuarioRequestDTO dto)
        {
            var usuarioPorEmail = await _repositorioUsuario.ObtenerPorEmailAsync(dto.Email);

            if (usuarioPorEmail != null)
                throw new NegocioExeption("Ya existe un usuario registrado con ese correo.");

            string? identificador = ObtenerIdentificadorDesdeRequest(dto);

            if (!string.IsNullOrWhiteSpace(identificador))
            {
                var usuarioPorIdentificador = await _repositorioUsuario.ObtenerPorMatriculaONumeroEmpleadoAsync(identificador);

                if (usuarioPorIdentificador != null)
                    throw new NegocioExeption("Ya existe un usuario registrado con esa matrícula o número de empleado.");
            }
        }

        private async Task ValidarDuplicadosParaActualizacionAsync(Usuario usuarioActual, UsuarioUpdateRequestDTO dto)
        {
            var usuarioPorEmail = await _repositorioUsuario.ObtenerPorEmailAsync(dto.Email);

            if (usuarioPorEmail != null && usuarioPorEmail.IdUsuario != usuarioActual.IdUsuario)
                throw new NegocioExeption("Ya existe otro usuario registrado con ese correo.");

            string? identificadorNuevo = usuarioActual is Estudiante
                ? dto.Matricula
                : dto.NumeroEmpleado;

            if (!string.IsNullOrWhiteSpace(identificadorNuevo))
            {
                var usuarioPorIdentificador = await _repositorioUsuario.ObtenerPorMatriculaONumeroEmpleadoAsync(identificadorNuevo);

                if (usuarioPorIdentificador != null && usuarioPorIdentificador.IdUsuario != usuarioActual.IdUsuario)
                    throw new NegocioExeption("Ya existe otro usuario con esa matrícula o número de empleado.");
            }
        }

        private static void ValidarDatosSegunTipoUsuario(UsuarioRequestDTO dto)
        {
            string tipo = NormalizarTipoUsuario(dto.TipoUsuario);

            if (tipo == "estudiante")
            {
                if (string.IsNullOrWhiteSpace(dto.Matricula))
                    throw new NegocioExeption("La matrícula es obligatoria para estudiantes.");

                if (!string.IsNullOrWhiteSpace(dto.NumeroEmpleado))
                    throw new NegocioExeption("Un estudiante no debe registrarse con número de empleado.");

                return;
            }

            if (string.IsNullOrWhiteSpace(dto.NumeroEmpleado))
                throw new NegocioExeption("El número de empleado es obligatorio para este tipo de usuario.");

            if (!string.IsNullOrWhiteSpace(dto.Matricula))
                throw new NegocioExeption("Este tipo de usuario no debe registrarse con matrícula.");
        }

        private static Usuario CrearUsuarioSegunTipo(UsuarioRequestDTO dto)
        {
            string tipo = NormalizarTipoUsuario(dto.TipoUsuario);

            return tipo switch
            {
                "estudiante" => new Estudiante
                {
                    Matricula = dto.Matricula!.Trim()
                },

                "docente" => new Docente
                {
                    NumeroEmpleado = dto.NumeroEmpleado!.Trim()
                },

                "administrador" => new Administrador
                {
                    NumeroEmpleado = dto.NumeroEmpleado!.Trim()
                },

                "bibliotecario" => new PersonalBibliotecario
                {
                    NumeroEmpleado = dto.NumeroEmpleado!.Trim()
                },

                "personalbibliotecario" => new PersonalBibliotecario
                {
                    NumeroEmpleado = dto.NumeroEmpleado!.Trim()
                },

                "auditor" => new Auditor
                {
                    NumeroEmpleado = dto.NumeroEmpleado!.Trim()
                },

                _ => throw new NegocioExeption("Tipo de usuario inválido.")
            };
        }

        private static string? ObtenerIdentificadorDesdeRequest(UsuarioRequestDTO dto)
        {
            string tipo = NormalizarTipoUsuario(dto.TipoUsuario);

            return tipo == "estudiante"
                ? dto.Matricula?.Trim()
                : dto.NumeroEmpleado?.Trim();
        }

        private static string NormalizarTipoUsuario(string tipoUsuario)
        {
            return tipoUsuario
                .Trim()
                .ToLowerInvariant()
                .Replace(" ", "");
        }

        private static UsuarioResponseDTO MapearUsuarioResponse(Usuario usuario)
        {
            return new UsuarioResponseDTO
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Estado = usuario.Estado,
                TipoUsuario = usuario.GetType().Name,
                Matricula = usuario is Estudiante estudiante ? estudiante.Matricula : null,
                NumeroEmpleado = usuario.NumeroEmpleado,
                HabilitadoParaPrestamos = usuario.Estado == "Activo" && !usuario.VerificarPenalizaciones()
            };
        }
    }
}