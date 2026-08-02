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
            panelMenu = new System.Windows.Forms.Panel();
            btnCentroReportes = new System.Windows.Forms.Button();
            btnAuditoria = new System.Windows.Forms.Button();
            btnNotificaciones = new System.Windows.Forms.Button();
            btnGestionUsuarios = new System.Windows.Forms.Button();
            btnHistorial = new System.Windows.Forms.Button();
            btnHistorialDevoluciones = new System.Windows.Forms.Button();
            btnPenalizaciones = new System.Windows.Forms.Button();
            btnProcesarDevolucion = new System.Windows.Forms.Button();
            btnConsultarActivos = new System.Windows.Forms.Button();
            btnAprobarPrestamos = new System.Windows.Forms.Button();
            btnCategorias = new System.Windows.Forms.Button();
            btnCatalogo = new System.Windows.Forms.Button();
            btnInicio = new System.Windows.Forms.Button();
            btnCerrarSesion = new System.Windows.Forms.Button();
            panelLogo = new System.Windows.Forms.Panel();
            lblLogo = new System.Windows.Forms.Label();
            panelHeader = new System.Windows.Forms.Panel();
            lblUserInfo = new System.Windows.Forms.Label();
            lblTituloSeccion = new System.Windows.Forms.Label();
            panelContenedor = new System.Windows.Forms.Panel();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = System.Drawing.Color.FromArgb(20, 24, 38);
            panelMenu.Controls.Add(btnCentroReportes);
            panelMenu.Controls.Add(btnAuditoria);
            panelMenu.Controls.Add(btnNotificaciones);
            panelMenu.Controls.Add(btnGestionUsuarios);
            panelMenu.Controls.Add(btnHistorial);
            panelMenu.Controls.Add(btnHistorialDevoluciones);
            panelMenu.Controls.Add(btnPenalizaciones);
            panelMenu.Controls.Add(btnProcesarDevolucion);
            panelMenu.Controls.Add(btnConsultarActivos);
            panelMenu.Controls.Add(btnAprobarPrestamos);
            panelMenu.Controls.Add(btnCategorias);
            panelMenu.Controls.Add(btnCatalogo);
            panelMenu.Controls.Add(btnInicio);
            panelMenu.Controls.Add(btnCerrarSesion);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            panelMenu.Location = new System.Drawing.Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new System.Drawing.Size(250, 800);
            panelMenu.TabIndex = 0;
            // 
            // btnCentroReportes
            // 
            btnCentroReportes.Dock = System.Windows.Forms.DockStyle.Top;
            btnCentroReportes.FlatAppearance.BorderSize = 0;
            btnCentroReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCentroReportes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnCentroReportes.ForeColor = System.Drawing.Color.Gainsboro;
            btnCentroReportes.Location = new System.Drawing.Point(0, 640);
            btnCentroReportes.Name = "btnCentroReportes";
            btnCentroReportes.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnCentroReportes.Size = new System.Drawing.Size(250, 60);
            btnCentroReportes.TabIndex = 10;
            btnCentroReportes.Text = "📊 Centro de Reportes";
            btnCentroReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnCentroReportes.UseVisualStyleBackColor = true;
            btnCentroReportes.Click += btnCentroReportes_Click;
            // 
            // btnAuditoria
            // 
            btnAuditoria.Dock = System.Windows.Forms.DockStyle.Top;
            btnAuditoria.FlatAppearance.BorderSize = 0;
            btnAuditoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAuditoria.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnAuditoria.ForeColor = System.Drawing.Color.Gainsboro;
            btnAuditoria.Location = new System.Drawing.Point(0, 580);
            btnAuditoria.Name = "btnAuditoria";
            btnAuditoria.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnAuditoria.Size = new System.Drawing.Size(250, 60);
            btnAuditoria.TabIndex = 9;
            btnAuditoria.Text = "🛡️ Auditoría del Sistema";
            btnAuditoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnAuditoria.UseVisualStyleBackColor = true;
            btnAuditoria.Click += btnAuditoria_Click;
            // 
            // btnNotificaciones
            // 
            btnNotificaciones.Dock = System.Windows.Forms.DockStyle.Top;
            btnNotificaciones.FlatAppearance.BorderSize = 0;
            btnNotificaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNotificaciones.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnNotificaciones.ForeColor = System.Drawing.Color.Gainsboro;
            btnNotificaciones.Location = new System.Drawing.Point(0, 520);
            btnNotificaciones.Name = "btnNotificaciones";
            btnNotificaciones.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnNotificaciones.Size = new System.Drawing.Size(250, 60);
            btnNotificaciones.TabIndex = 8;
<<<<<<< HEAD
            btnNotificaciones.Text = "🔔 Notificaciones";
=======
            btnNotificaciones.Text = "🔔 Historial de Alertas";
>>>>>>> develop
            btnNotificaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnNotificaciones.UseVisualStyleBackColor = true;
            btnNotificaciones.Click += btnNotificaciones_Click;
            // 
            // btnGestionUsuarios
            // 
            btnGestionUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            btnGestionUsuarios.FlatAppearance.BorderSize = 0;
            btnGestionUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGestionUsuarios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnGestionUsuarios.ForeColor = System.Drawing.Color.Gainsboro;
            btnGestionUsuarios.Location = new System.Drawing.Point(0, 460);
            btnGestionUsuarios.Name = "btnGestionUsuarios";
            btnGestionUsuarios.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnGestionUsuarios.Size = new System.Drawing.Size(250, 60);
            btnGestionUsuarios.TabIndex = 6;
            btnGestionUsuarios.Text = "👥 Gestión de Usuarios";
            btnGestionUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnGestionUsuarios.UseVisualStyleBackColor = true;
            btnGestionUsuarios.Click += btnGestionUsuarios_Click;
            // 
            // btnHistorial
            // 
            btnHistorial.Dock = System.Windows.Forms.DockStyle.Top;
            btnHistorial.FlatAppearance.BorderSize = 0;
            btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnHistorial.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnHistorial.ForeColor = System.Drawing.Color.Gainsboro;
            btnHistorial.Location = new System.Drawing.Point(0, 400);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnHistorial.Size = new System.Drawing.Size(250, 60);
            btnHistorial.TabIndex = 5;
            btnHistorial.Text = "📁 Historial Préstamos";
            btnHistorial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnHistorial.UseVisualStyleBackColor = true;
            btnHistorial.Click += btnHistorial_Click;
            // 
            // btnHistorialDevoluciones
            // 
            btnHistorialDevoluciones.Dock = System.Windows.Forms.DockStyle.Top;
            btnHistorialDevoluciones.FlatAppearance.BorderSize = 0;
            btnHistorialDevoluciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnHistorialDevoluciones.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnHistorialDevoluciones.ForeColor = System.Drawing.Color.Gainsboro;
            btnHistorialDevoluciones.Location = new System.Drawing.Point(0, 340);
            btnHistorialDevoluciones.Name = "btnHistorialDevoluciones";
            btnHistorialDevoluciones.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnHistorialDevoluciones.Size = new System.Drawing.Size(250, 60);
            btnHistorialDevoluciones.TabIndex = 11;
            btnHistorialDevoluciones.Text = "📁 Historial Devoluciones";
            btnHistorialDevoluciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnHistorialDevoluciones.UseVisualStyleBackColor = true;
            btnHistorialDevoluciones.Click += btnHistorialDevoluciones_Click;
            // 
            // btnPenalizaciones
            // 
            btnPenalizaciones.Dock = System.Windows.Forms.DockStyle.Top;
            btnPenalizaciones.FlatAppearance.BorderSize = 0;
            btnPenalizaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPenalizaciones.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnPenalizaciones.ForeColor = System.Drawing.Color.Gainsboro;
            btnPenalizaciones.Location = new System.Drawing.Point(0, 280);
            btnPenalizaciones.Name = "btnPenalizaciones";
            btnPenalizaciones.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnPenalizaciones.Size = new System.Drawing.Size(250, 60);
            btnPenalizaciones.TabIndex = 8;
            btnPenalizaciones.Text = "💰 Multas y Penalidades";
            btnPenalizaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnPenalizaciones.UseVisualStyleBackColor = true;
            btnPenalizaciones.Click += btnPenalizaciones_Click;
            // 
            // btnProcesarDevolucion
            // 
            btnProcesarDevolucion.Dock = System.Windows.Forms.DockStyle.Top;
            btnProcesarDevolucion.FlatAppearance.BorderSize = 0;
            btnProcesarDevolucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnProcesarDevolucion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnProcesarDevolucion.ForeColor = System.Drawing.Color.Gainsboro;
            btnProcesarDevolucion.Location = new System.Drawing.Point(0, 220);
            btnProcesarDevolucion.Name = "btnProcesarDevolucion";
            btnProcesarDevolucion.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnProcesarDevolucion.Size = new System.Drawing.Size(250, 60);
            btnProcesarDevolucion.TabIndex = 4;
            btnProcesarDevolucion.Text = "📦 Procesar Devolución";
            btnProcesarDevolucion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnProcesarDevolucion.UseVisualStyleBackColor = true;
            btnProcesarDevolucion.Click += btnProcesarDevolucion_Click;
            // 
            // btnConsultarActivos
            // 
            btnConsultarActivos.Dock = System.Windows.Forms.DockStyle.Top;
            btnConsultarActivos.FlatAppearance.BorderSize = 0;
            btnConsultarActivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnConsultarActivos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnConsultarActivos.ForeColor = System.Drawing.Color.Gainsboro;
            btnConsultarActivos.Location = new System.Drawing.Point(0, 160);
            btnConsultarActivos.Name = "btnConsultarActivos";
            btnConsultarActivos.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnConsultarActivos.Size = new System.Drawing.Size(250, 60);
            btnConsultarActivos.TabIndex = 4;
            btnConsultarActivos.Text = "🔍 Préstamos Activos";
            btnConsultarActivos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnConsultarActivos.UseVisualStyleBackColor = true;
            btnConsultarActivos.Click += btnConsultarActivos_Click;
            // 
            // btnAprobarPrestamos
            // 
            btnAprobarPrestamos.Dock = System.Windows.Forms.DockStyle.Top;
            btnAprobarPrestamos.FlatAppearance.BorderSize = 0;
            btnAprobarPrestamos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAprobarPrestamos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnAprobarPrestamos.ForeColor = System.Drawing.Color.Gainsboro;
            btnAprobarPrestamos.Location = new System.Drawing.Point(0, 100);
            btnAprobarPrestamos.Name = "btnAprobarPrestamos";
            btnAprobarPrestamos.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnAprobarPrestamos.Size = new System.Drawing.Size(250, 60);
            btnAprobarPrestamos.TabIndex = 3;
            btnAprobarPrestamos.Text = "📝 Solicitudes Pendientes";
            btnAprobarPrestamos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnAprobarPrestamos.UseVisualStyleBackColor = true;
            btnAprobarPrestamos.Click += btnAprobarPrestamos_Click;
            // 
            // btnCategorias
            // 
            btnCategorias.Dock = System.Windows.Forms.DockStyle.Top;
            btnCategorias.FlatAppearance.BorderSize = 0;
            btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCategorias.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnCategorias.ForeColor = System.Drawing.Color.Gainsboro;
            btnCategorias.Location = new System.Drawing.Point(0, 100);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnCategorias.Size = new System.Drawing.Size(250, 60);
            btnCategorias.TabIndex = 2;
            btnCategorias.Text = "🏷️ Gestión Categorías";
            btnCategorias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnCategorias.UseVisualStyleBackColor = true;
            btnCategorias.Click += btnCategorias_Click;
            // 
            // btnCatalogo
            // 
            btnCatalogo.Dock = System.Windows.Forms.DockStyle.Top;
            btnCatalogo.FlatAppearance.BorderSize = 0;
            btnCatalogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCatalogo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnCatalogo.ForeColor = System.Drawing.Color.Gainsboro;
            btnCatalogo.Location = new System.Drawing.Point(0, 100);
            btnCatalogo.Name = "btnCatalogo";
            btnCatalogo.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnCatalogo.Size = new System.Drawing.Size(250, 60);
            btnCatalogo.TabIndex = 1;
            btnCatalogo.Text = "📚 Catálogo Bibliográfico";
            btnCatalogo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnCatalogo.UseVisualStyleBackColor = true;
            btnCatalogo.Click += btnCatalogo_Click;
            // 
            // btnInicio
            // 
            btnInicio.Dock = System.Windows.Forms.DockStyle.Top;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnInicio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnInicio.ForeColor = System.Drawing.Color.White;
            btnInicio.Location = new System.Drawing.Point(0, 100);
            btnInicio.Name = "btnInicio";
            btnInicio.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnInicio.Size = new System.Drawing.Size(250, 60);
            btnInicio.TabIndex = 0;
            btnInicio.Text = "🏠 Inicio / Dashboard";
            btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnInicio.UseVisualStyleBackColor = true;
            btnInicio.Click += btnInicio_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Bottom;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
            btnCerrarSesion.Location = new System.Drawing.Point(0, 740);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnCerrarSesion.Size = new System.Drawing.Size(250, 60);
            btnCerrarSesion.TabIndex = 7;
            btnCerrarSesion.Text = "🚪 Cerrar Sesión";
            btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = System.Drawing.Color.FromArgb(15, 18, 28);
            panelLogo.Controls.Add(lblLogo);
            panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            panelLogo.Location = new System.Drawing.Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new System.Drawing.Size(250, 100);
            panelLogo.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblLogo.ForeColor = System.Drawing.Color.White;
            lblLogo.Location = new System.Drawing.Point(25, 30);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new System.Drawing.Size(111, 37);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "SIGEBI";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.FromArgb(25, 30, 48);
            panelHeader.Controls.Add(lblUserInfo);
            panelHeader.Controls.Add(lblTituloSeccion);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(250, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(950, 60);
            panelHeader.TabIndex = 1;
            // 
            // lblUserInfo
            // 
            lblUserInfo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblUserInfo.AutoSize = true;
            lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblUserInfo.ForeColor = System.Drawing.Color.Gainsboro;
            lblUserInfo.Location = new System.Drawing.Point(600, 18);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new System.Drawing.Size(220, 21);
            lblUserInfo.TabIndex = 1;
            lblUserInfo.Text = "Usuario: ... | Rol: ...";
            lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTituloSeccion
            // 
            lblTituloSeccion.AutoSize = true;
            lblTituloSeccion.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            lblTituloSeccion.ForeColor = System.Drawing.Color.White;
            lblTituloSeccion.Location = new System.Drawing.Point(25, 15);
            lblTituloSeccion.Name = "lblTituloSeccion";
            lblTituloSeccion.Size = new System.Drawing.Size(207, 30);
            lblTituloSeccion.TabIndex = 0;
            lblTituloSeccion.Text = "Inicio / Dashboard";
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = System.Drawing.Color.FromArgb(20, 24, 38);
            panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            panelContenedor.Location = new System.Drawing.Point(250, 60);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new System.Drawing.Size(950, 740);
            panelContenedor.TabIndex = 2;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1200, 800);
            Controls.Add(panelContenedor);
            Controls.Add(panelHeader);
            Controls.Add(panelMenu);
            MinimumSize = new System.Drawing.Size(1000, 800);
            Name = "FormPrincipal";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Button btnHistorial;
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
        private System.Windows.Forms.Button btnProcesarDevolucion;
        private System.Windows.Forms.Button btnHistorialDevoluciones;
        private System.Windows.Forms.Button btnPenalizaciones;
    }
}