namespace SIGEBI.AppEscritorio.Forms.Solicitudes
{
    partial class FormGestionSolicitudes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            cmbCriterioBusqueda = new ComboBox();
            txtBusqueda = new TextBox();
            btnBuscar = new Button();
            btnRecargar = new Button();
            dgvSolicitudes = new DataGridView();
            panelAcciones = new Panel();
            lblMotivo = new Label();
            txtMotivoRechazo = new TextBox();
            btnRechazar = new Button();
            btnAprobar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSolicitudes).BeginInit();
            panelAcciones.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(25, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(265, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Solicitudes";
            // 
            // cmbCriterioBusqueda
            // 
            cmbCriterioBusqueda.BackColor = Color.FromArgb(40, 40, 60);
            cmbCriterioBusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCriterioBusqueda.FlatStyle = FlatStyle.Flat;
            cmbCriterioBusqueda.Font = new Font("Segoe UI", 10F);
            cmbCriterioBusqueda.ForeColor = Color.White;
            cmbCriterioBusqueda.FormattingEnabled = true;
            cmbCriterioBusqueda.Items.AddRange(new object[] { "Todas Pendientes", "ID de Solicitud", "Matrícula / Empleado" });
            cmbCriterioBusqueda.Location = new Point(25, 75);
            cmbCriterioBusqueda.Name = "cmbCriterioBusqueda";
            cmbCriterioBusqueda.Size = new Size(200, 31);
            cmbCriterioBusqueda.TabIndex = 1;
            cmbCriterioBusqueda.SelectedIndexChanged += cmbCriterioBusqueda_SelectedIndexChanged;
            // 
            // txtBusqueda
            // 
            txtBusqueda.BackColor = Color.FromArgb(40, 40, 60);
            txtBusqueda.BorderStyle = BorderStyle.FixedSingle;
            txtBusqueda.Font = new Font("Segoe UI", 10.5F);
            txtBusqueda.ForeColor = Color.White;
            txtBusqueda.Location = new Point(240, 75);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.PlaceholderText = "Seleccione un criterio...";
            txtBusqueda.Size = new Size(250, 31);
            txtBusqueda.TabIndex = 2;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(13, 110, 253);
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(505, 75);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(110, 31);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "🔍 Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnRecargar
            // 
            btnRecargar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRecargar.BackColor = Color.FromArgb(40, 44, 60);
            btnRecargar.Cursor = Cursors.Hand;
            btnRecargar.FlatAppearance.BorderSize = 0;
            btnRecargar.FlatStyle = FlatStyle.Flat;
            btnRecargar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRecargar.ForeColor = Color.White;
            btnRecargar.Location = new Point(700, 75);
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Size = new Size(125, 31);
            btnRecargar.TabIndex = 4;
            btnRecargar.Text = "🔄 Mostrar Todo";
            btnRecargar.UseVisualStyleBackColor = false;
            btnRecargar.Click += btnRecargar_Click;
            // 
            // dgvSolicitudes
            // 
            dgvSolicitudes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSolicitudes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSolicitudes.BackgroundColor = Color.FromArgb(25, 25, 35);
            dgvSolicitudes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSolicitudes.Location = new Point(25, 125);
            dgvSolicitudes.MultiSelect = false;
            dgvSolicitudes.Name = "dgvSolicitudes";
            dgvSolicitudes.ReadOnly = true;
            dgvSolicitudes.RowHeadersWidth = 51;
            dgvSolicitudes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSolicitudes.Size = new Size(800, 330);
            dgvSolicitudes.TabIndex = 5;
            // 
            // panelAcciones
            // 
            panelAcciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelAcciones.BackColor = Color.FromArgb(20, 24, 38);
            panelAcciones.Controls.Add(lblMotivo);
            panelAcciones.Controls.Add(txtMotivoRechazo);
            panelAcciones.Controls.Add(btnRechazar);
            panelAcciones.Controls.Add(btnAprobar);
            panelAcciones.Location = new Point(25, 470);
            panelAcciones.Name = "panelAcciones";
            panelAcciones.Size = new Size(800, 100);
            panelAcciones.TabIndex = 6;
            // 
            // lblMotivo
            // 
            lblMotivo.AutoSize = true;
            lblMotivo.ForeColor = Color.Gainsboro;
            lblMotivo.Location = new Point(245, 20);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new Size(207, 20);
            lblMotivo.TabIndex = 3;
            lblMotivo.Text = "Motivo (Solo para Rechazar):";
            // 
            // txtMotivoRechazo
            // 
            txtMotivoRechazo.BackColor = Color.FromArgb(40, 40, 60);
            txtMotivoRechazo.BorderStyle = BorderStyle.FixedSingle;
            txtMotivoRechazo.Font = new Font("Segoe UI", 10.5F);
            txtMotivoRechazo.ForeColor = Color.White;
            txtMotivoRechazo.Location = new Point(245, 45);
            txtMotivoRechazo.Name = "txtMotivoRechazo";
            txtMotivoRechazo.PlaceholderText = "Escriba la razón aquí...";
            txtMotivoRechazo.Size = new Size(350, 31);
            txtMotivoRechazo.TabIndex = 2;
            // 
            // btnRechazar
            // 
            btnRechazar.BackColor = Color.FromArgb(220, 53, 69);
            btnRechazar.Cursor = Cursors.Hand;
            btnRechazar.FlatAppearance.BorderSize = 0;
            btnRechazar.FlatStyle = FlatStyle.Flat;
            btnRechazar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRechazar.ForeColor = Color.White;
            btnRechazar.Location = new Point(610, 40);
            btnRechazar.Name = "btnRechazar";
            btnRechazar.Size = new Size(170, 40);
            btnRechazar.TabIndex = 1;
            btnRechazar.Text = "✖ Rechazar";
            btnRechazar.UseVisualStyleBackColor = false;
            btnRechazar.Click += btnRechazar_Click;
            // 
            // btnAprobar
            // 
            btnAprobar.BackColor = Color.FromArgb(13, 110, 253);
            btnAprobar.Cursor = Cursors.Hand;
            btnAprobar.FlatAppearance.BorderSize = 0;
            btnAprobar.FlatStyle = FlatStyle.Flat;
            btnAprobar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAprobar.ForeColor = Color.White;
            btnAprobar.Location = new Point(20, 40);
            btnAprobar.Name = "btnAprobar";
            btnAprobar.Size = new Size(200, 40);
            btnAprobar.TabIndex = 0;
            btnAprobar.Text = "✓ Aprobar Solicitud";
            btnAprobar.UseVisualStyleBackColor = false;
            btnAprobar.Click += btnAprobar_Click;
            // 
            // FormGestionSolicitudes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 45);
            ClientSize = new Size(850, 590);
            Controls.Add(panelAcciones);
            Controls.Add(dgvSolicitudes);
            Controls.Add(btnRecargar);
            Controls.Add(btnBuscar);
            Controls.Add(txtBusqueda);
            Controls.Add(cmbCriterioBusqueda);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormGestionSolicitudes";
            Text = "FormGestionSolicitudes";
            Load += FormGestionSolicitudes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSolicitudes).EndInit();
            panelAcciones.ResumeLayout(false);
            panelAcciones.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cmbCriterioBusqueda;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnRecargar;
        private System.Windows.Forms.DataGridView dgvSolicitudes;
        private System.Windows.Forms.Panel panelAcciones;
        private System.Windows.Forms.Button btnAprobar;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivoRechazo;
        private System.Windows.Forms.Button btnRechazar;
    }
}