using Microsoft.Extensions.DependencyInjection;
using SIGEBI.AppEscritorio.Forms.Auditoria;
using SIGEBI.AppEscritorio.Forms.Catalogo;
using SIGEBI.AppEscritorio.Forms.Notificaciones;
using SIGEBI.AppEscritorio.Forms.Penalizaciones;
using SIGEBI.AppEscritorio.Forms.Prestamos;
using SIGEBI.AppEscritorio.Forms.Reportes;
using SIGEBI.AppEscritorio.Forms.Solicitudes;
using SIGEBI.AppEscritorio.Forms.Usuarios;
using SIGEBI.AppEscritorio.Utils;
using System;
using System.Windows.Forms;
using SIGEBI.AppEscritorio.Forms.Perfil;

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

                lblUserInfo.Cursor = Cursors.Hand;
                lblUserInfo.MouseEnter += (s, ev) => lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(100, 150, 255);
                lblUserInfo.MouseLeave += (s, ev) => lblUserInfo.ForeColor = System.Drawing.Color.White;

                lblUserInfo.Click += lblUserInfo_Click;
            }

            ConfigurarAccesosPorRol();
            AbrirFormularioEnPanel(new FormDashboard(NavegarDesdeDashboard));
        }

        public void NavegarDesdeDashboard(string tituloModulo)
        {
            switch (tituloModulo)
            {
                case "📝 Solicitudes":
                    btnAprobarPrestamos.PerformClick();
                    break;
                case "📦 Préstamos": 
                case "📁 Historiales": 
                    btnConsultarActivos.PerformClick();
                    break;
                case "💰 Multas":
                    btnPenalizaciones.PerformClick();
                    break;
                case "📚 Catálogo":
                    btnCatalogo.PerformClick();
                    break;
                case "🏷️ Categorías":
                    btnCategorias.PerformClick();
                    break;
                case "👥 Usuarios":
                    btnGestionUsuarios.PerformClick();
                    break;
                case "🔔 Notificaciones":
                    btnNotificaciones.PerformClick();
                    break;
                case "🛡️ Auditoría":
                    btnAuditoria.PerformClick();
                    break;
                case "📊 Reportes":
                    btnCentroReportes.PerformClick();
                    break;
            }
        }

        private void ConfigurarAccesosPorRol()
        {
            string rol = SessionManager.TipoUsuario;

            btnAprobarPrestamos.Visible = false;
            btnConsultarActivos.Visible = false; 
            btnPenalizaciones.Visible = false;
            btnGestionUsuarios.Visible = false;
            btnCatalogo.Visible = false;
            btnCategorias.Visible = false;
            btnNotificaciones.Visible = false;
            btnAuditoria.Visible = false;
            btnCentroReportes.Visible = false;

            switch (rol)
            {
                case "PersonalBibliotecario":
                    btnAprobarPrestamos.Visible = true;
                    btnConsultarActivos.Visible = true;
                    btnPenalizaciones.Visible = true;
                    btnCatalogo.Visible = true;
                    btnCategorias.Visible = true;
                    btnCentroReportes.Visible = true;
                    break;

                case "Administrador":
                    btnAprobarPrestamos.Visible = true;
                    btnConsultarActivos.Visible = true;
                    btnPenalizaciones.Visible = true;
                    btnGestionUsuarios.Visible = true;
                    btnCatalogo.Visible = true;
                    btnCategorias.Visible = true;
                    btnNotificaciones.Visible = true;
                    btnAuditoria.Visible = true;
                    btnCentroReportes.Visible = true;
                    break;

                case "Auditor":
                    btnConsultarActivos.Visible = true; 
                    btnNotificaciones.Visible = true;
                    btnAuditoria.Visible = true;
                    btnCentroReportes.Visible = true;
                    break;
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

        // 👇 Evento de clic en el nombre de usuario (Esquina superior derecha)
        private void lblUserInfo_Click(object? sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Configuración / Mi Perfil";
            AbrirFormularioEnPanel(new FormPerfil());
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Inicio / Dashboard";
            AbrirFormularioEnPanel(new FormDashboard(NavegarDesdeDashboard));
        }

        private void btnAprobarPrestamos_Click(object? sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Préstamos / Gestión de Solicitudes";
            var formSolicitudes = Program.ServiceProvider.GetRequiredService<FormGestionSolicitudes>();
            AbrirFormularioEnPanel(formSolicitudes);
        }

       
        private void btnConsultarActivos_Click(object? sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Préstamos / Préstamos y Devoluciones";
            var formContenedor = Program.ServiceProvider.GetRequiredService<FormContenedorPrestamosDevoluciones>();
            AbrirFormularioEnPanel(formContenedor);
        }

        private void btnPenalizaciones_Click(object sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Caja / Multas y Penalizaciones";
            var formPenalizaciones = Program.ServiceProvider.GetRequiredService<FormGestionPenalizaciones>();
            AbrirFormularioEnPanel(formPenalizaciones);
        }

        private void btnNotificaciones_Click(object sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Alertas / Historial de Notificaciones";
            var formNotificaciones = Program.ServiceProvider.GetRequiredService<formGestionNotificaciones>();
            AbrirFormularioEnPanel(formNotificaciones);
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Administración / Gestión de Usuarios";
            var formUsuarios = Program.ServiceProvider.GetRequiredService<formGestionUsuarios>();
            AbrirFormularioEnPanel(formUsuarios);
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Catálogo / Gestión de Categorías";
            var formCategorias = Program.ServiceProvider.GetRequiredService<formGestionCategorias>();
            AbrirFormularioEnPanel(formCategorias);
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Catálogo / Recursos Bibliográficos";
            var formCatalogo = Program.ServiceProvider.GetRequiredService<formGestionCatalogo>();
            AbrirFormularioEnPanel(formCatalogo);
        }

        private void btnAuditoria_Click(object sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Seguridad / Registro de Auditoría";
            var formAuditoria = Program.ServiceProvider.GetRequiredService<FormAuditoria>();
            AbrirFormularioEnPanel(formAuditoria);
        }

        private void btnCentroReportes_Click(object sender, EventArgs e)
        {
            lblTituloSeccion.Text = "Analítica / Centro de Reportes PDF";
            var formReportes = Program.ServiceProvider.GetRequiredService<FormCentroReportes>();
            AbrirFormularioEnPanel(formReportes);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Está seguro que desea cerrar la sesión actual?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e) { }
        private void panelContenedor_Paint_1(object sender, PaintEventArgs e) { }
    }
}