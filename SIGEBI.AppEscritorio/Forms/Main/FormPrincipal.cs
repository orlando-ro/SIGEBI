using Microsoft.Extensions.DependencyInjection;
using SIGEBI.AppEscritorio.Forms.Prestamos;
using SIGEBI.AppEscritorio.Forms.Solicitudes;
using SIGEBI.AppEscritorio.Utils;
using System;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Main
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
        }

        private void FormPrincipal_Load(object? sender, EventArgs e)
        {
            this.Text = $"SIGEBI - Panel Principal [{SessionManager.Nombre} ({SessionManager.TipoUsuario})]";

            if (lblUserInfo != null)
            {
                lblUserInfo.Text = $"Usuario: {SessionManager.Nombre} | Rol: {SessionManager.TipoUsuario}";
            }

            ConfigurarAccesosPorRol();

            // 👇 Abrir el Home automáticamente al iniciar sesión
            AbrirFormularioEnPanel(new FormDashboard());
        }

        private void ConfigurarAccesosPorRol()
        {
            string rol = SessionManager.TipoUsuario;

            btnAprobarPrestamos.Visible = false;
            btnConsultarActivos.Visible = false;
            btnHistorial.Visible = false;
            btnGestionUsuarios.Visible = false;
            btnCatalogo.Visible = false;
            btnCategorias.Visible = false; // Agregado aquí

            if (rol == "PersonalBibliotecario" || rol == "Administrador")
            {
                btnAprobarPrestamos.Visible = true;
                btnConsultarActivos.Visible = true;
                btnHistorial.Visible = true;
                btnCatalogo.Visible = true;
                btnCategorias.Visible = true; // Agregado aquí
            }
            else if (rol == "Auditor")
            {
                btnHistorial.Visible = true;
            }

            if (rol == "Administrador")
            {
                btnGestionUsuarios.Visible = true;
            }
        }

        private void AbrirFormularioEnPanel(Form formularioHijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }

            formularioHijo.TopLevel = false;
            formularioHijo.Dock = DockStyle.Fill;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;

            this.panelContenedor.Controls.Add(formularioHijo);
            this.panelContenedor.Tag = formularioHijo;
            formularioHijo.Show();
        }

        // Botón Inicio
        private void btnInicio_Click(object sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Inicio / Dashboard";
            AbrirFormularioEnPanel(new FormDashboard());
        }

        private void btnAprobarPrestamos_Click(object? sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Préstamos y Devoluciones / Gestión de Solicitudes";
            var formSolicitudes = Program.ServiceProvider.GetRequiredService<FormGestionSolicitudes>();
            AbrirFormularioEnPanel(formSolicitudes);
        }

        private void btnConsultarActivos_Click(object? sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Préstamos y Devoluciones / Préstamos Activos";
            var formActivos = Program.ServiceProvider.GetRequiredService<FormConsultarActivos>();
            AbrirFormularioEnPanel(formActivos);
        }

        private void btnHistorial_Click(object? sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Préstamos y Devoluciones / Historial General";
            var formHistorial = Program.ServiceProvider.GetRequiredService<FormHistorialPrestamos>();
            AbrirFormularioEnPanel(formHistorial);
        }

        private void btnCatalogo_Click(object? sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Catálogo / Gestión Bibliográfica";
            var formCatalogo = Program.ServiceProvider.GetRequiredService<SIGEBI.AppEscritorio.Forms.Catalogo.formGestionCatalogo>();
            AbrirFormularioEnPanel(formCatalogo);
        }

        private void btnCategorias_Click(object? sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Catálogo / Gestión de Categorías";
            var formCategorias = Program.ServiceProvider.GetRequiredService<SIGEBI.AppEscritorio.Forms.Catalogo.formGestionCategorias>();
            AbrirFormularioEnPanel(formCategorias);
        }

        private void btnGestionUsuarios_Click(object? sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Administración / Gestión de Usuarios";

            var formUsuarios = Program.ServiceProvider.GetRequiredService<SIGEBI.AppEscritorio.Forms.Usuarios.formGestionUsuarios>();

            AbrirFormularioEnPanel(formUsuarios);
        }

        // Botón Cerrar Sesión
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Está seguro que desea cerrar la sesión actual?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
    }
}