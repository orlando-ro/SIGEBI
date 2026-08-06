namespace SIGEBI.AppEscritorio.Forms.Prestamos
{
    partial class FormContenedorPrestamosDevoluciones
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelNavegacionInterna = new Panel();
            btnTabHistorialDevoluciones = new Button();
            btnTabHistorialPrestamos = new Button();
            btnTabActivos = new Button();
            tabContenedor = new TabControl();
            tabPageActivos = new TabPage();
            tabPageHistorialPrestamos = new TabPage();
            tabPageHistorialDevoluciones = new TabPage();
            panelNavegacionInterna.SuspendLayout();
            tabContenedor.SuspendLayout();
            SuspendLayout();
            // 
            // panelNavegacionInterna
            // 
            panelNavegacionInterna.BackColor = Color.FromArgb(20, 24, 38);
            panelNavegacionInterna.Controls.Add(btnTabHistorialDevoluciones);
            panelNavegacionInterna.Controls.Add(btnTabHistorialPrestamos);
            panelNavegacionInterna.Controls.Add(btnTabActivos);
            panelNavegacionInterna.Dock = DockStyle.Top;
            panelNavegacionInterna.Location = new Point(0, 0);
            panelNavegacionInterna.Name = "panelNavegacionInterna";
            panelNavegacionInterna.Size = new Size(950, 60);
            panelNavegacionInterna.TabIndex = 0;
            // 
            // btnTabHistorialDevoluciones
            // 
            btnTabHistorialDevoluciones.BackColor = Color.FromArgb(40, 44, 60);
            btnTabHistorialDevoluciones.Cursor = Cursors.Hand;
            btnTabHistorialDevoluciones.FlatAppearance.BorderSize = 0;
            btnTabHistorialDevoluciones.FlatStyle = FlatStyle.Flat;
            btnTabHistorialDevoluciones.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTabHistorialDevoluciones.ForeColor = Color.White;
            btnTabHistorialDevoluciones.Location = new Point(375, 12);
            btnTabHistorialDevoluciones.Name = "btnTabHistorialDevoluciones";
            btnTabHistorialDevoluciones.Size = new Size(200, 35);
            btnTabHistorialDevoluciones.TabIndex = 2;
            btnTabHistorialDevoluciones.Text = "📁 Hist. Devoluciones";
            btnTabHistorialDevoluciones.UseVisualStyleBackColor = false;
            btnTabHistorialDevoluciones.Click += btnTabHistorialDevoluciones_Click;
            // 
            // btnTabHistorialPrestamos
            // 
            btnTabHistorialPrestamos.BackColor = Color.FromArgb(40, 44, 60);
            btnTabHistorialPrestamos.Cursor = Cursors.Hand;
            btnTabHistorialPrestamos.FlatAppearance.BorderSize = 0;
            btnTabHistorialPrestamos.FlatStyle = FlatStyle.Flat;
            btnTabHistorialPrestamos.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTabHistorialPrestamos.ForeColor = Color.White;
            btnTabHistorialPrestamos.Location = new Point(200, 12);
            btnTabHistorialPrestamos.Name = "btnTabHistorialPrestamos";
            btnTabHistorialPrestamos.Size = new Size(165, 35);
            btnTabHistorialPrestamos.TabIndex = 1;
            btnTabHistorialPrestamos.Text = "📁 Hist. Préstamos";
            btnTabHistorialPrestamos.UseVisualStyleBackColor = false;
            btnTabHistorialPrestamos.Click += btnTabHistorialPrestamos_Click;
            // 
            // btnTabActivos
            // 
            btnTabActivos.BackColor = Color.FromArgb(13, 110, 253);
            btnTabActivos.Cursor = Cursors.Hand;
            btnTabActivos.FlatAppearance.BorderSize = 0;
            btnTabActivos.FlatStyle = FlatStyle.Flat;
            btnTabActivos.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTabActivos.ForeColor = Color.White;
            btnTabActivos.Location = new Point(25, 12);
            btnTabActivos.Name = "btnTabActivos";
            btnTabActivos.Size = new Size(165, 35);
            btnTabActivos.TabIndex = 0;
            btnTabActivos.Text = "🔍 Préstamos Activos";
            btnTabActivos.UseVisualStyleBackColor = false;
            btnTabActivos.Click += btnTabActivos_Click;
            // 
            // tabContenedor
            // 
            tabContenedor.Controls.Add(tabPageActivos);
            tabContenedor.Controls.Add(tabPageHistorialPrestamos);
            tabContenedor.Controls.Add(tabPageHistorialDevoluciones);
            tabContenedor.Dock = DockStyle.Fill;
            tabContenedor.Location = new Point(0, 60);
            tabContenedor.Name = "tabContenedor";
            tabContenedor.SelectedIndex = 0;
            tabContenedor.Size = new Size(950, 680);
            tabContenedor.TabIndex = 1;
            // 
            // tabPageActivos
            // 
            tabPageActivos.BackColor = Color.FromArgb(30, 30, 45);
            tabPageActivos.Location = new Point(4, 29);
            tabPageActivos.Name = "tabPageActivos";
            tabPageActivos.Padding = new Padding(3);
            tabPageActivos.Size = new Size(942, 647);
            tabPageActivos.TabIndex = 0;
            tabPageActivos.Text = "Activos";
            tabPageActivos.Click += tabPageActivos_Click;
            // 
            // tabPageHistorialPrestamos
            // 
            tabPageHistorialPrestamos.BackColor = Color.FromArgb(30, 30, 45);
            tabPageHistorialPrestamos.Location = new Point(4, 29);
            tabPageHistorialPrestamos.Name = "tabPageHistorialPrestamos";
            tabPageHistorialPrestamos.Padding = new Padding(3);
            tabPageHistorialPrestamos.Size = new Size(942, 647);
            tabPageHistorialPrestamos.TabIndex = 1;
            tabPageHistorialPrestamos.Text = "Historial P.";
            // 
            // tabPageHistorialDevoluciones
            // 
            tabPageHistorialDevoluciones.BackColor = Color.FromArgb(30, 30, 45);
            tabPageHistorialDevoluciones.Location = new Point(4, 29);
            tabPageHistorialDevoluciones.Name = "tabPageHistorialDevoluciones";
            tabPageHistorialDevoluciones.Padding = new Padding(3);
            tabPageHistorialDevoluciones.Size = new Size(942, 647);
            tabPageHistorialDevoluciones.TabIndex = 2;
            tabPageHistorialDevoluciones.Text = "Historial D.";
            // 
            // FormContenedorPrestamosDevoluciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 45);
            ClientSize = new Size(950, 740);
            Controls.Add(tabContenedor);
            Controls.Add(panelNavegacionInterna);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormContenedorPrestamosDevoluciones";
            Text = "FormContenedorPrestamosDevoluciones";
            Load += FormContenedorPrestamosDevoluciones_Load;
            panelNavegacionInterna.ResumeLayout(false);
            tabContenedor.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelNavegacionInterna;
        private System.Windows.Forms.Button btnTabActivos;
        private System.Windows.Forms.Button btnTabHistorialPrestamos;
        private System.Windows.Forms.Button btnTabHistorialDevoluciones;
        private System.Windows.Forms.TabControl tabContenedor;
        private System.Windows.Forms.TabPage tabPageActivos;
        private System.Windows.Forms.TabPage tabPageHistorialPrestamos;
        private System.Windows.Forms.TabPage tabPageHistorialDevoluciones;
    }
}