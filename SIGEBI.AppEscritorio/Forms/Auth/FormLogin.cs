using SIGEBI.AppEscritorio.DTOs.Auth;
using SIGEBI.AppEscritorio.Services.Interfaces;
using SIGEBI.AppEscritorio.Utils;
using System;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Auth
{
    public partial class FormLogin : Form
    {
        private readonly IServicioAccesoApi _servicioAccesoApi;

        // Inyectamos el servicio por el constructor
        public FormLogin(IServicioAccesoApi servicioAccesoApi)
        {
            InitializeComponent();
            _servicioAccesoApi = servicioAccesoApi;

            btnLogin.Click += BtnLogin_Click;
        }

        private async void BtnLogin_Click(object? sender, EventArgs e)
        {
            // Cambia txtIdentificador por txtEmail si renombraste el control
            string email = txtIdentificador.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MostrarError("Por favor, ingrese sus credenciales.");
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Verificando...";
            lblError.Visible = false;

            var request = new LoginRequestDTO
            {
                Email = email,
                Password = password
            };

            bool loginExitoso = await _servicioAccesoApi.IniciarSesionAsync(request);

            if (loginExitoso)
            {
                // REGLA DE NEGOCIO: Prohibir entrada a Estudiantes y Docentes
                string rol = SessionManager.TipoUsuario.ToLower();
                if (rol == "estudiante" || rol == "docente")
                {
                    MostrarError("Acceso denegado. Esta aplicación es exclusiva para el personal administrativo.");

                    // Borramos los datos que se habían guardado temporalmente
                    SessionManager.CerrarSesion();

                    btnLogin.Enabled = true;
                    btnLogin.Text = "Iniciar Sesión";
                    return;
                }

                // Si pasó el filtro, lo dejamos entrar
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MostrarError("Credenciales incorrectas o problema de conexión.");
                btnLogin.Enabled = true;
                btnLogin.Text = "Iniciar Sesión";
            }
        }
        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }
    }
}