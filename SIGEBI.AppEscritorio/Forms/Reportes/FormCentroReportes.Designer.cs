namespace SIGEBI.AppEscritorio.Forms.Reportes
{
    partial class FormCentroReportes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new System.Windows.Forms.Label();
            lblTipoReporte = new System.Windows.Forms.Label();
            cmbTipoReporte = new System.Windows.Forms.ComboBox();
            lblDesde = new System.Windows.Forms.Label();
            dtpDesde = new System.Windows.Forms.DateTimePicker();
            lblHasta = new System.Windows.Forms.Label();
            dtpHasta = new System.Windows.Forms.DateTimePicker();
            btnGenerar = new System.Windows.Forms.Button();
            panelControles = new System.Windows.Forms.Panel();
            panelControles.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(30, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(325, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Centro de Reportes PDF";
            // 
            // panelControles
            // 
            panelControles.BackColor = System.Drawing.Color.FromArgb(25, 30, 48);
            panelControles.Controls.Add(lblTipoReporte);
            panelControles.Controls.Add(cmbTipoReporte);
            panelControles.Controls.Add(lblDesde);
            panelControles.Controls.Add(dtpDesde);
            panelControles.Controls.Add(lblHasta);
            panelControles.Controls.Add(dtpHasta);
            panelControles.Controls.Add(btnGenerar);
            panelControles.Location = new System.Drawing.Point(35, 100);
            panelControles.Name = "panelControles";
            panelControles.Size = new System.Drawing.Size(450, 400);
            panelControles.TabIndex = 1;
            // 
            // lblTipoReporte
            // 
            lblTipoReporte.AutoSize = true;
            lblTipoReporte.ForeColor = System.Drawing.Color.Gainsboro;
            lblTipoReporte.Location = new System.Drawing.Point(30, 30);
            lblTipoReporte.Name = "lblTipoReporte";
            lblTipoReporte.Size = new System.Drawing.Size(189, 20);
            lblTipoReporte.TabIndex = 0;
            lblTipoReporte.Text = "Seleccione el tipo de reporte:";
            // 
            // cmbTipoReporte
            // 
            cmbTipoReporte.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            cmbTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbTipoReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbTipoReporte.Font = new System.Drawing.Font("Segoe UI", 11F);
            cmbTipoReporte.ForeColor = System.Drawing.Color.White;
            cmbTipoReporte.FormattingEnabled = true;
            cmbTipoReporte.Items.AddRange(new object[] {
            "Préstamos",
            "Penalizaciones",
            "Uso del Catálogo",
            "Inventario Físico",
            "Auditoría General"});
            cmbTipoReporte.Location = new System.Drawing.Point(30, 55);
            cmbTipoReporte.Name = "cmbTipoReporte";
            cmbTipoReporte.Size = new System.Drawing.Size(390, 33);
            cmbTipoReporte.TabIndex = 1;
            cmbTipoReporte.SelectedIndexChanged += cmbTipoReporte_SelectedIndexChanged;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.ForeColor = System.Drawing.Color.Gainsboro;
            lblDesde.Location = new System.Drawing.Point(30, 110);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new System.Drawing.Size(95, 20);
            lblDesde.TabIndex = 2;
            lblDesde.Text = "Fecha Inicial:";
            // 
            // dtpDesde
            // 
            dtpDesde.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDesde.Location = new System.Drawing.Point(30, 135);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new System.Drawing.Size(390, 30);
            dtpDesde.TabIndex = 3;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.ForeColor = System.Drawing.Color.Gainsboro;
            lblHasta.Location = new System.Drawing.Point(30, 190);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new System.Drawing.Size(89, 20);
            lblHasta.TabIndex = 4;
            lblHasta.Text = "Fecha Final:";
            // 
            // dtpHasta
            // 
            dtpHasta.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpHasta.Location = new System.Drawing.Point(30, 215);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new System.Drawing.Size(390, 30);
            dtpHasta.TabIndex = 5;
            // 
            // btnGenerar
            // 
            btnGenerar.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            btnGenerar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnGenerar.FlatAppearance.BorderSize = 0;
            btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGenerar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnGenerar.ForeColor = System.Drawing.Color.White;
            btnGenerar.Location = new System.Drawing.Point(30, 290);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new System.Drawing.Size(390, 50);
            btnGenerar.TabIndex = 6;
            btnGenerar.Text = "📄 Generar y Descargar PDF";
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // FormCentroReportes
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(20, 24, 38);
            ClientSize = new System.Drawing.Size(850, 590);
            Controls.Add(panelControles);
            Controls.Add(lblTitulo);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "FormCentroReportes";
            Text = "FormCentroReportes";
            Load += FormCentroReportes_Load;
            panelControles.ResumeLayout(false);
            panelControles.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelControles;
        private System.Windows.Forms.Label lblTipoReporte;
        private System.Windows.Forms.ComboBox cmbTipoReporte;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnGenerar;
    }
}