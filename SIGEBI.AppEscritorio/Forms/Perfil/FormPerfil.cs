using Microsoft.Extensions.DependencyInjection;
using SIGEBI.AppEscritorio.DTOs.Perfil;
using SIGEBI.AppEscritorio.Services;
using SIGEBI.AppEscritorio.Services.Implementations;
using SIGEBI.AppEscritorio.Services.Interfaces;
using SIGEBI.AppEscritorio.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Perfil
{
    public partial class FormPerfil : Form
    {
        public FormPerfil()
        {
            InitializeComponent();

            this.btnActualizarPassword.Click += new System.EventHandler(this.btnActualizarPassword_Click);

            CargarDatosPersonales();
        }

        private void CargarDatosPersonales()
        {
            txtNombre.Text = SessionManager.Nombre;
            txtEmail.Text = SessionManager.Email;
            txtNumeroEmpleado.Text = SessionManager.NumeroEmpleado; // Muestra el número de empleado
            txtRol.Text = SessionManager.TipoUsuario;
        }

        private async void btnActualizarPassword_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPasswordActual.Text) ||
                string.IsNullOrWhiteSpace(txtNuevaPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmarPassword.Text))
            {
                MessageBox.Show("Todos los campos de contraseña son obligatorios.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNuevaPassword.Text.Length < 4)
            {
                MessageBox.Show("La nueva contraseña debe tener al menos 4 caracteres.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNuevaPassword.Text != txtConfirmarPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden. Verifica e intenta de nuevo.", "Error de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dto = new PasswordUpdateDTO
            {
                PasswordActual = txtPasswordActual.Text,
                NuevaPassword = txtNuevaPassword.Text
            };

            btnActualizarPassword.Enabled = false;
            btnActualizarPassword.Text = "Actualizando...";

            try
            {
                var servicio = Program.ServiceProvider.GetRequiredService<IServicioUsuarioApi>();

                string numeroEmpleado = SessionManager.NumeroEmpleado;

                await servicio.CambiarPropiaPasswordAsync(numeroEmpleado, dto);

                MessageBox.Show("¡Tu contraseña ha sido actualizada correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtPasswordActual.Clear();
                txtNuevaPassword.Clear();
                txtConfirmarPassword.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnActualizarPassword.Enabled = true;
                btnActualizarPassword.Text = "Actualizar Contraseña";
            }
        }
    }
}