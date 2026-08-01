using Microsoft.Extensions.DependencyInjection;
using SIGEBI.AppEscritorio.Forms.Devoluciones;
using SIGEBI.AppEscritorio.Forms.Penalizaciones; // 👈 Nuevo Using
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
        }

        private void FormPrincipal_Load(object? sender, EventArgs e)
        {
            this.Text = $"SIGEBI - Panel Principal [{SessionManager.Nombre} ({SessionManager.TipoUsuario})]";

            if (lblUserInfo != null)
            {
                lblUserInfo.Text = $"Usuario: {SessionManager.Nombre} | Rol: {SessionManager.TipoUsuario}";
            }

            ConfigurarAccesosPorRol();
            AbrirFormularioEnPanel(new FormDashboard());
        }

        private void ConfigurarAccesosPorRol()
        {
            string rol = SessionManager.TipoUsuario;

            // Por defecto ocultamos todo
            btnAprobarPrestamos.Visible = false;
            btnConsultarActivos.Visible = false;
            btnProcesarDevolucion.Visible = false;
            btnPenalizaciones.Visible = false; // 👈 Oculto por defecto
            btnHistorial.Visible = false;
            btnHistorialDevoluciones.Visible = false;

            if (rol == "PersonalBibliotecario")
            {
                btnAprobarPrestamos.Visible = true;
                btnConsultarActivos.Visible = true;
                btnProcesarDevolucion.Visible = true;
                btnPenalizaciones.Visible = true; // 👈 Bibliotecario puede cobrar y ver
                btnHistorial.Visible = true;
                btnHistorialDevoluciones.Visible = true;
            }
            else if (rol == "Administrador")
            {
                btnAprobarPrestamos.Visible = true;
                btnConsultarActivos.Visible = true;
                btnPenalizaciones.Visible = true; // 👈 Admin puede cobrar y ver
                btnHistorial.Visible = true;
                btnHistorialDevoluciones.Visible = true;
            }
            else if (rol == "Auditor")
            {
                // El Auditor NO ve el botón de Penalizaciones porque la API no le autoriza el GET ni el PATCH
                btnHistorial.Visible = true;
                btnHistorialDevoluciones.Visible = true;
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

        private void btnInicio_Click(object sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Inicio / Dashboard";
            AbrirFormularioEnPanel(new FormDashboard());
        }

        private void btnAprobarPrestamos_Click(object? sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Préstamos / Gestión de Solicitudes";
            var formSolicitudes = Program.ServiceProvider.GetRequiredService<FormGestionSolicitudes>();
            AbrirFormularioEnPanel(formSolicitudes);
        }

        private void btnConsultarActivos_Click(object? sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Préstamos / Préstamos Activos";
            var formActivos = Program.ServiceProvider.GetRequiredService<FormConsultarActivos>();
            AbrirFormularioEnPanel(formActivos);
        }

        private void btnProcesarDevolucion_Click(object sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Devoluciones / Procesar Devolución";
            var formProcesarDev = Program.ServiceProvider.GetRequiredService<FormProcesarDevolucion>();
            AbrirFormularioEnPanel(formProcesarDev);
        }

        // 👇 Nuevo Evento para abrir Penalizaciones
        private void btnPenalizaciones_Click(object sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Caja / Multas y Penalizaciones";
            var formPenalizaciones = Program.ServiceProvider.GetRequiredService<FormGestionPenalizaciones>();
            AbrirFormularioEnPanel(formPenalizaciones);
        }

        private void btnHistorialDevoluciones_Click(object sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Reportes / Historial de Devoluciones";
            var formHistorialDev = Program.ServiceProvider.GetRequiredService<FormHistorialDevoluciones>();
            AbrirFormularioEnPanel(formHistorialDev);
        }

        private void btnHistorial_Click(object? sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Reportes / Historial de Préstamos";
            var formHistorial = Program.ServiceProvider.GetRequiredService<FormHistorialPrestamos>();
            AbrirFormularioEnPanel(formHistorial);
        }

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