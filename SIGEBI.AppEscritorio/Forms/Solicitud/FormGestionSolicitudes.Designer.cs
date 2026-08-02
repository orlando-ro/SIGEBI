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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            lblTitulo = new System.Windows.Forms.Label();
            cmbCriterioBusqueda = new System.Windows.Forms.ComboBox();
            txtBusqueda = new System.Windows.Forms.TextBox();
            btnBuscar = new System.Windows.Forms.Button();
            btnRecargar = new System.Windows.Forms.Button();
            dgvSolicitudes = new System.Windows.Forms.DataGridView();
            panelAcciones = new System.Windows.Forms.Panel();
            lblMotivo = new System.Windows.Forms.Label();
            txtMotivoRechazo = new System.Windows.Forms.TextBox();
            btnRechazar = new System.Windows.Forms.Button();
            btnAprobar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvSolicitudes).BeginInit();
            panelAcciones.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(25, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(267, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Solicitudes";
            // 
            // cmbCriterioBusqueda
            // 
            cmbCriterioBusqueda.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            cmbCriterioBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbCriterioBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbCriterioBusqueda.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbCriterioBusqueda.ForeColor = System.Drawing.Color.White;
            cmbCriterioBusqueda.FormattingEnabled = true;
            cmbCriterioBusqueda.Items.AddRange(new object[] { "Todas Pendientes", "ID de Solicitud", "Matrícula / Empleado" });
            cmbCriterioBusqueda.Location = new System.Drawing.Point(25, 75);
            cmbCriterioBusqueda.Name = "cmbCriterioBusqueda";
            cmbCriterioBusqueda.Size = new System.Drawing.Size(200, 31);
            cmbCriterioBusqueda.TabIndex = 1;
            cmbCriterioBusqueda.SelectedIndexChanged += cmbCriterioBusqueda_SelectedIndexChanged;
            // 
            // txtBusqueda
            // 
            txtBusqueda.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtBusqueda.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            txtBusqueda.ForeColor = System.Drawing.Color.White;
            txtBusqueda.Location = new System.Drawing.Point(240, 75);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.PlaceholderText = "Seleccione un criterio...";
            txtBusqueda.Size = new System.Drawing.Size(250, 31);
            txtBusqueda.TabIndex = 2;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnBuscar.ForeColor = System.Drawing.Color.White;
            btnBuscar.Location = new System.Drawing.Point(505, 75);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new System.Drawing.Size(110, 31);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "🔍 Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnRecargar
            // 
            btnRecargar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRecargar.BackColor = System.Drawing.Color.FromArgb(40, 44, 60);
            btnRecargar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRecargar.FlatAppearance.BorderSize = 0;
            btnRecargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRecargar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnRecargar.ForeColor = System.Drawing.Color.White;
            btnRecargar.Location = new System.Drawing.Point(700, 75);
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Size = new System.Drawing.Size(125, 31);
            btnRecargar.TabIndex = 4;
            btnRecargar.Text = "🔄 Mostrar Todo";
            btnRecargar.UseVisualStyleBackColor = false;
            btnRecargar.Click += btnRecargar_Click;
            // 
            // dgvSolicitudes
            // 
            dgvSolicitudes.AllowUserToAddRows = false;
            dgvSolicitudes.AllowUserToDeleteRows = false;
            dgvSolicitudes.AllowUserToResizeRows = false;
            dgvSolicitudes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvSolicitudes.BackgroundColor = System.Drawing.Color.FromArgb(20, 24, 38);
            dgvSolicitudes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvSolicitudes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSolicitudes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(15, 18, 28);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(15, 18, 28);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvSolicitudes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSolicitudes.ColumnHeadersHeight = 45;
            dgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(30, 34, 48);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvSolicitudes.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(38, 43, 60);
            dgvSolicitudes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvSolicitudes.EnableHeadersVisualStyles = false;
            dgvSolicitudes.GridColor = System.Drawing.Color.FromArgb(70, 75, 90);
            dgvSolicitudes.Location = new System.Drawing.Point(25, 125);
            dgvSolicitudes.MultiSelect = false;
            dgvSolicitudes.Name = "dgvSolicitudes";
            dgvSolicitudes.ReadOnly = true;
            dgvSolicitudes.RowHeadersVisible = false;
            dgvSolicitudes.RowHeadersWidth = 51;
            dgvSolicitudes.RowTemplate.Height = 40;
            dgvSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvSolicitudes.Size = new System.Drawing.Size(800, 330);
            dgvSolicitudes.TabIndex = 5;
            dgvSolicitudes.CellContentClick += dgvSolicitudes_CellContentClick;
            // 
            // panelAcciones
            // 
            panelAcciones.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelAcciones.BackColor = System.Drawing.Color.FromArgb(20, 24, 38);
            panelAcciones.Controls.Add(lblMotivo);
            panelAcciones.Controls.Add(txtMotivoRechazo);
            panelAcciones.Controls.Add(btnRechazar);
            panelAcciones.Controls.Add(btnAprobar);
            panelAcciones.Location = new System.Drawing.Point(25, 470);
            panelAcciones.Name = "panelAcciones";
            panelAcciones.Size = new System.Drawing.Size(800, 100);
            panelAcciones.TabIndex = 6;
            // 
            // lblMotivo
            // 
            lblMotivo.AutoSize = true;
            lblMotivo.ForeColor = System.Drawing.Color.Gainsboro;
            lblMotivo.Location = new System.Drawing.Point(245, 20);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new System.Drawing.Size(201, 20);
            lblMotivo.TabIndex = 3;
            lblMotivo.Text = "Motivo (Solo para Rechazar):";
            // 
            // txtMotivoRechazo
            // 
            txtMotivoRechazo.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            txtMotivoRechazo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMotivoRechazo.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            txtMotivoRechazo.ForeColor = System.Drawing.Color.White;
            txtMotivoRechazo.Location = new System.Drawing.Point(245, 45);
            txtMotivoRechazo.Name = "txtMotivoRechazo";
            txtMotivoRechazo.PlaceholderText = "Escriba la razón aquí...";
            txtMotivoRechazo.Size = new System.Drawing.Size(350, 31);
            txtMotivoRechazo.TabIndex = 2;
            // 
            // btnRechazar
            // 
            btnRechazar.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            btnRechazar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRechazar.FlatAppearance.BorderSize = 0;
            btnRechazar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRechazar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnRechazar.ForeColor = System.Drawing.Color.White;
            btnRechazar.Location = new System.Drawing.Point(610, 40);
            btnRechazar.Name = "btnRechazar";
            btnRechazar.Size = new System.Drawing.Size(170, 40);
            btnRechazar.TabIndex = 1;
            btnRechazar.Text = "✖ Rechazar";
            btnRechazar.UseVisualStyleBackColor = false;
            btnRechazar.Click += btnRechazar_Click;
            // 
            // btnAprobar
            // 
            btnAprobar.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            btnAprobar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAprobar.FlatAppearance.BorderSize = 0;
            btnAprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAprobar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnAprobar.ForeColor = System.Drawing.Color.White;
            btnAprobar.Location = new System.Drawing.Point(20, 40);
            btnAprobar.Name = "btnAprobar";
            btnAprobar.Size = new System.Drawing.Size(200, 40);
            btnAprobar.TabIndex = 0;
            btnAprobar.Text = "✓ Aprobar Solicitud";
            btnAprobar.UseVisualStyleBackColor = false;
            btnAprobar.Click += btnAprobar_Click;
            // 
            // FormGestionSolicitudes
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            ClientSize = new System.Drawing.Size(850, 590);
            Controls.Add(panelAcciones);
            Controls.Add(dgvSolicitudes);
            Controls.Add(btnRecargar);
            Controls.Add(btnBuscar);
            Controls.Add(txtBusqueda);
            Controls.Add(cmbCriterioBusqueda);
            Controls.Add(lblTitulo);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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