namespace SIGEBI.AppEscritorio.Forms.Main
{
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            panelMenu = new Panel();
            btnCentroReportes = new Button();
            btnAuditoria = new Button();
            btnNotificaciones = new Button();
            btnGestionUsuarios = new Button();
            btnPenalizaciones = new Button();
            btnConsultarActivos = new Button();
            btnAprobarPrestamos = new Button();
            btnCategorias = new Button();
            btnCatalogo = new Button();
            btnInicio = new Button();
            btnCerrarSesion = new Button();
            panelLogo = new Panel();
            lblLogo = new Label();
            panelHeader = new Panel();
            lblUserInfo = new Label();
            lblTituloSeccion = new Label();
            panelContenedor = new Panel();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(20, 24, 38);
            panelMenu.Controls.Add(btnCentroReportes);
            panelMenu.Controls.Add(btnAuditoria);
            panelMenu.Controls.Add(btnNotificaciones);
            panelMenu.Controls.Add(btnGestionUsuarios);
            panelMenu.Controls.Add(btnPenalizaciones);
            panelMenu.Controls.Add(btnConsultarActivos);
            panelMenu.Controls.Add(btnAprobarPrestamos);
            panelMenu.Controls.Add(btnCategorias);
            panelMenu.Controls.Add(btnCatalogo);
            panelMenu.Controls.Add(btnInicio);
            panelMenu.Controls.Add(btnCerrarSesion);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(250, 800);
            panelMenu.TabIndex = 2;
            // 
            // btnCentroReportes
            // 
            btnCentroReportes.Dock = DockStyle.Top;
            btnCentroReportes.FlatAppearance.BorderSize = 0;
            btnCentroReportes.FlatStyle = FlatStyle.Flat;
            btnCentroReportes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCentroReportes.ForeColor = Color.Gainsboro;
            btnCentroReportes.Location = new Point(0, 640);
            btnCentroReportes.Name = "btnCentroReportes";
            btnCentroReportes.Padding = new Padding(20, 0, 0, 0);
            btnCentroReportes.Size = new Size(250, 60);
            btnCentroReportes.TabIndex = 0;
            btnCentroReportes.Text = "📊 Centro de Reportes";
            btnCentroReportes.TextAlign = ContentAlignment.MiddleLeft;
            btnCentroReportes.Click += btnCentroReportes_Click;
            // 
            // btnAuditoria
            // 
            btnAuditoria.Dock = DockStyle.Top;
            btnAuditoria.FlatAppearance.BorderSize = 0;
            btnAuditoria.FlatStyle = FlatStyle.Flat;
            btnAuditoria.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAuditoria.ForeColor = Color.Gainsboro;
            btnAuditoria.Location = new Point(0, 580);
            btnAuditoria.Name = "btnAuditoria";
            btnAuditoria.Padding = new Padding(20, 0, 0, 0);
            btnAuditoria.Size = new Size(250, 60);
            btnAuditoria.TabIndex = 1;
            btnAuditoria.Text = "🛡️ Auditoría del Sistema";
            btnAuditoria.TextAlign = ContentAlignment.MiddleLeft;
            btnAuditoria.Click += btnAuditoria_Click;
            // 
            // btnNotificaciones
            // 
            btnNotificaciones.Dock = DockStyle.Top;
            btnNotificaciones.FlatAppearance.BorderSize = 0;
            btnNotificaciones.FlatStyle = FlatStyle.Flat;
            btnNotificaciones.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNotificaciones.ForeColor = Color.Gainsboro;
            btnNotificaciones.Location = new Point(0, 520);
            btnNotificaciones.Name = "btnNotificaciones";
            btnNotificaciones.Padding = new Padding(20, 0, 0, 0);
            btnNotificaciones.Size = new Size(250, 60);
            btnNotificaciones.TabIndex = 2;
            btnNotificaciones.Text = "🔔 Notificaciones";
            btnNotificaciones.TextAlign = ContentAlignment.MiddleLeft;
            btnNotificaciones.Click += btnNotificaciones_Click;
            // 
            // btnGestionUsuarios
            // 
            btnGestionUsuarios.Dock = DockStyle.Top;
            btnGestionUsuarios.FlatAppearance.BorderSize = 0;
            btnGestionUsuarios.FlatStyle = FlatStyle.Flat;
            btnGestionUsuarios.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGestionUsuarios.ForeColor = Color.Gainsboro;
            btnGestionUsuarios.Location = new Point(0, 460);
            btnGestionUsuarios.Name = "btnGestionUsuarios";
            btnGestionUsuarios.Padding = new Padding(20, 0, 0, 0);
            btnGestionUsuarios.Size = new Size(250, 60);
            btnGestionUsuarios.TabIndex = 3;
            btnGestionUsuarios.Text = "👥 Gestión de Usuarios";
            btnGestionUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnGestionUsuarios.Click += btnGestionUsuarios_Click;
            // 
            // btnPenalizaciones
            // 
            btnPenalizaciones.Dock = DockStyle.Top;
            btnPenalizaciones.FlatAppearance.BorderSize = 0;
            btnPenalizaciones.FlatStyle = FlatStyle.Flat;
            btnPenalizaciones.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPenalizaciones.ForeColor = Color.Gainsboro;
            btnPenalizaciones.Location = new Point(0, 400);
            btnPenalizaciones.Name = "btnPenalizaciones";
            btnPenalizaciones.Padding = new Padding(20, 0, 0, 0);
            btnPenalizaciones.Size = new Size(250, 60);
            btnPenalizaciones.TabIndex = 6;
            btnPenalizaciones.Text = "💰 Multas y Penalidades";
            btnPenalizaciones.TextAlign = ContentAlignment.MiddleLeft;
            btnPenalizaciones.Click += btnPenalizaciones_Click;
            // 
            // btnConsultarActivos
            // 
            btnConsultarActivos.Dock = DockStyle.Top;
            btnConsultarActivos.FlatAppearance.BorderSize = 0;
            btnConsultarActivos.FlatStyle = FlatStyle.Flat;
            btnConsultarActivos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConsultarActivos.ForeColor = Color.Gainsboro;
            btnConsultarActivos.Location = new Point(0, 340);
            btnConsultarActivos.Name = "btnConsultarActivos";
            btnConsultarActivos.Padding = new Padding(20, 0, 0, 0);
            btnConsultarActivos.Size = new Size(250, 60);
            btnConsultarActivos.TabIndex = 7;
            btnConsultarActivos.Text = "📦 Préstamos y Devoluciones";
            btnConsultarActivos.TextAlign = ContentAlignment.MiddleLeft;
            btnConsultarActivos.Click += btnConsultarActivos_Click;
            // 
            // btnAprobarPrestamos
            // 
            btnAprobarPrestamos.Dock = DockStyle.Top;
            btnAprobarPrestamos.FlatAppearance.BorderSize = 0;
            btnAprobarPrestamos.FlatStyle = FlatStyle.Flat;
            btnAprobarPrestamos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAprobarPrestamos.ForeColor = Color.Gainsboro;
            btnAprobarPrestamos.Location = new Point(0, 280);
            btnAprobarPrestamos.Name = "btnAprobarPrestamos";
            btnAprobarPrestamos.Padding = new Padding(20, 0, 0, 0);
            btnAprobarPrestamos.Size = new Size(250, 60);
            btnAprobarPrestamos.TabIndex = 8;
            btnAprobarPrestamos.Text = "📝 Solicitudes Pendientes";
            btnAprobarPrestamos.TextAlign = ContentAlignment.MiddleLeft;
            btnAprobarPrestamos.Click += btnAprobarPrestamos_Click;
            // 
            // btnCategorias
            // 
            btnCategorias.Dock = DockStyle.Top;
            btnCategorias.FlatAppearance.BorderSize = 0;
            btnCategorias.FlatStyle = FlatStyle.Flat;
            btnCategorias.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCategorias.ForeColor = Color.Gainsboro;
            btnCategorias.Location = new Point(0, 220);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Padding = new Padding(20, 0, 0, 0);
            btnCategorias.Size = new Size(250, 60);
            btnCategorias.TabIndex = 9;
            btnCategorias.Text = "🏷️ Gestión Categorías";
            btnCategorias.TextAlign = ContentAlignment.MiddleLeft;
            btnCategorias.Click += btnCategorias_Click;
            // 
            // btnCatalogo
            // 
            btnCatalogo.Dock = DockStyle.Top;
            btnCatalogo.FlatAppearance.BorderSize = 0;
            btnCatalogo.FlatStyle = FlatStyle.Flat;
            btnCatalogo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCatalogo.ForeColor = Color.Gainsboro;
            btnCatalogo.Location = new Point(0, 160);
            btnCatalogo.Name = "btnCatalogo";
            btnCatalogo.Padding = new Padding(20, 0, 0, 0);
            btnCatalogo.Size = new Size(250, 60);
            btnCatalogo.TabIndex = 10;
            btnCatalogo.Text = "📚 Catálogo Bibliográfico";
            btnCatalogo.TextAlign = ContentAlignment.MiddleLeft;
            btnCatalogo.Click += btnCatalogo_Click;
            // 
            // btnInicio
            // 
            btnInicio.Dock = DockStyle.Top;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnInicio.ForeColor = Color.White;
            btnInicio.Location = new Point(0, 100);
            btnInicio.Name = "btnInicio";
            btnInicio.Padding = new Padding(20, 0, 0, 0);
            btnInicio.Size = new Size(250, 60);
            btnInicio.TabIndex = 11;
            btnInicio.Text = "🏠 Inicio / Dashboard";
            btnInicio.TextAlign = ContentAlignment.MiddleLeft;
            btnInicio.Click += btnInicio_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Dock = DockStyle.Bottom;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.FromArgb(220, 53, 69);
            btnCerrarSesion.Location = new Point(0, 740);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Padding = new Padding(20, 0, 0, 0);
            btnCerrarSesion.Size = new Size(250, 60);
            btnCerrarSesion.TabIndex = 12;
            btnCerrarSesion.Text = "🚪 Cerrar Sesión";
            btnCerrarSesion.TextAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(15, 18, 28);
            panelLogo.Controls.Add(lblLogo);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(250, 100);
            panelLogo.TabIndex = 13;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(25, 30);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(100, 37);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "SIGEBI";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(25, 30, 48);
            panelHeader.Controls.Add(lblUserInfo);
            panelHeader.Controls.Add(lblTituloSeccion);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(250, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(950, 60);
            panelHeader.TabIndex = 1;
            // 
            // lblUserInfo
            // 
            lblUserInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserInfo.AutoSize = true;
            lblUserInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUserInfo.ForeColor = Color.Gainsboro;
            lblUserInfo.Location = new Point(600, 18);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(147, 21);
            lblUserInfo.TabIndex = 0;
            lblUserInfo.Text = "Usuario: ... | Rol: ...";
            lblUserInfo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTituloSeccion
            // 
            lblTituloSeccion.AutoSize = true;
            lblTituloSeccion.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTituloSeccion.ForeColor = Color.White;
            lblTituloSeccion.Location = new Point(25, 15);
            lblTituloSeccion.Name = "lblTituloSeccion";
            lblTituloSeccion.Size = new Size(204, 30);
            lblTituloSeccion.TabIndex = 1;
            lblTituloSeccion.Text = "Inicio / Dashboard";
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.FromArgb(20, 24, 38);
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(250, 60);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(950, 740);
            panelContenedor.TabIndex = 0;
            panelContenedor.Paint += panelContenedor_Paint_1;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 800);
            Controls.Add(panelContenedor);
            Controls.Add(panelHeader);
            Controls.Add(panelMenu);
            MinimumSize = new Size(1000, 800);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SIGEBI - Sistema de Gestión Bibliotecaria";
            Load += FormPrincipal_Load;
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnAprobarPrestamos;
        private System.Windows.Forms.Button btnConsultarActivos;
        private System.Windows.Forms.Button btnPenalizaciones;
        private System.Windows.Forms.Button btnGestionUsuarios;
        private System.Windows.Forms.Button btnNotificaciones;
        private System.Windows.Forms.Button btnAuditoria;
        private System.Windows.Forms.Button btnCentroReportes;
        private System.Windows.Forms.Button btnCatalogo;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTituloSeccion;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Panel panelContenedor;
    }
}