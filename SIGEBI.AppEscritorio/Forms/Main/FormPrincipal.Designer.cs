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
            btnHistorial = new Button();
            btnConsultarActivos = new Button();
            btnAprobarPrestamos = new Button();
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
            panelMenu.Controls.Add(btnHistorial);
            panelMenu.Controls.Add(btnConsultarActivos);
            panelMenu.Controls.Add(btnAprobarPrestamos);
            panelMenu.Controls.Add(btnInicio);
            panelMenu.Controls.Add(btnCerrarSesion);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(250, 650);
            panelMenu.TabIndex = 0;
            // 
            // btnHistorial
            // 
            btnHistorial.Dock = DockStyle.Top;
            btnHistorial.FlatAppearance.BorderSize = 0;
            btnHistorial.FlatStyle = FlatStyle.Flat;
            btnHistorial.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHistorial.ForeColor = Color.Gainsboro;
            btnHistorial.Location = new Point(0, 280);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Padding = new Padding(20, 0, 0, 0);
            btnHistorial.Size = new Size(250, 60);
            btnHistorial.TabIndex = 4;
            btnHistorial.Text = "📁 Historial General";
            btnHistorial.TextAlign = ContentAlignment.MiddleLeft;
            btnHistorial.UseVisualStyleBackColor = true;
            btnHistorial.Click += btnHistorial_Click;
            // 
            // btnConsultarActivos
            // 
            btnConsultarActivos.Dock = DockStyle.Top;
            btnConsultarActivos.FlatAppearance.BorderSize = 0;
            btnConsultarActivos.FlatStyle = FlatStyle.Flat;
            btnConsultarActivos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConsultarActivos.ForeColor = Color.Gainsboro;
            btnConsultarActivos.Location = new Point(0, 220);
            btnConsultarActivos.Name = "btnConsultarActivos";
            btnConsultarActivos.Padding = new Padding(20, 0, 0, 0);
            btnConsultarActivos.Size = new Size(250, 60);
            btnConsultarActivos.TabIndex = 3;
            btnConsultarActivos.Text = "🔍 Préstamos Activos";
            btnConsultarActivos.TextAlign = ContentAlignment.MiddleLeft;
            btnConsultarActivos.UseVisualStyleBackColor = true;
            btnConsultarActivos.Click += btnConsultarActivos_Click;
            // 
            // btnAprobarPrestamos
            // 
            btnAprobarPrestamos.Dock = DockStyle.Top;
            btnAprobarPrestamos.FlatAppearance.BorderSize = 0;
            btnAprobarPrestamos.FlatStyle = FlatStyle.Flat;
            btnAprobarPrestamos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAprobarPrestamos.ForeColor = Color.Gainsboro;
            btnAprobarPrestamos.Location = new Point(0, 160);
            btnAprobarPrestamos.Name = "btnAprobarPrestamos";
            btnAprobarPrestamos.Padding = new Padding(20, 0, 0, 0);
            btnAprobarPrestamos.Size = new Size(250, 60);
            btnAprobarPrestamos.TabIndex = 2;
            btnAprobarPrestamos.Text = "📝 Solicitudes Pendientes";
            btnAprobarPrestamos.TextAlign = ContentAlignment.MiddleLeft;
            btnAprobarPrestamos.UseVisualStyleBackColor = true;
            btnAprobarPrestamos.Click += btnAprobarPrestamos_Click;
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
            btnInicio.TabIndex = 1;
            btnInicio.Text = "🏠 Inicio / Dashboard";
            btnInicio.TextAlign = ContentAlignment.MiddleLeft;
            btnInicio.UseVisualStyleBackColor = true;
            btnInicio.Click += btnInicio_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Dock = DockStyle.Bottom;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.FromArgb(220, 53, 69); // Rojo
            btnCerrarSesion.Location = new Point(0, 590);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Padding = new Padding(20, 0, 0, 0);
            btnCerrarSesion.Size = new Size(250, 60);
            btnCerrarSesion.TabIndex = 5;
            btnCerrarSesion.Text = "🚪 Cerrar Sesión";
            btnCerrarSesion.TextAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesion.UseVisualStyleBackColor = true;
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
            panelLogo.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(25, 30);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(111, 37);
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
            panelHeader.Size = new Size(850, 60);
            panelHeader.TabIndex = 1;
            // 
            // lblUserInfo
            // 
            lblUserInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserInfo.AutoSize = true;
            lblUserInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUserInfo.ForeColor = Color.Gainsboro;
            lblUserInfo.Location = new Point(500, 18);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(220, 21);
            lblUserInfo.TabIndex = 1;
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
            lblTituloSeccion.Size = new Size(207, 30);
            lblTituloSeccion.TabIndex = 0;
            lblTituloSeccion.Text = "Inicio / Dashboard";
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.FromArgb(20, 24, 38);
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(250, 60);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(850, 590);
            panelContenedor.TabIndex = 2;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 650);
            Controls.Add(panelContenedor);
            Controls.Add(panelHeader);
            Controls.Add(panelMenu);
            MinimumSize = new Size(1000, 600);
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
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTituloSeccion;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Panel panelContenedor;
    }
}