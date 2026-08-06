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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitulo = new System.Windows.Forms.Label();
            lblSubtitulo = new System.Windows.Forms.Label();
            panelControles = new System.Windows.Forms.Panel();
            lblTipoReporte = new System.Windows.Forms.Label();
            cmbTipoReporte = new System.Windows.Forms.ComboBox();
            lblDesde = new System.Windows.Forms.Label();
            dtpDesde = new System.Windows.Forms.DateTimePicker();
            lblHasta = new System.Windows.Forms.Label();
            dtpHasta = new System.Windows.Forms.DateTimePicker();
            btnGenerar = new System.Windows.Forms.Button();
            lblAyudaExportar = new System.Windows.Forms.Label();
            panelTip = new System.Windows.Forms.Panel();
            lblTipIcon = new System.Windows.Forms.Label();
            lblTipText = new System.Windows.Forms.Label();

            panelDetalle = new System.Windows.Forms.Panel();
            lblInfoTitulo = new System.Windows.Forms.Label();
            lblInfoBadge = new System.Windows.Forms.Label();
            lblInfoDescripcion = new System.Windows.Forms.Label();
            lblHeaderMetricas = new System.Windows.Forms.Label();
            txtInfoMetricas = new System.Windows.Forms.TextBox();

            panelControles.SuspendLayout();
            panelTip.SuspendLayout();
            panelDetalle.SuspendLayout();
            SuspendLayout();

            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(30, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(325, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Analítica / Centro de Reportes PDF";

            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            lblSubtitulo.ForeColor = System.Drawing.Color.Gainsboro;
            lblSubtitulo.Location = new System.Drawing.Point(35, 60);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new System.Drawing.Size(480, 23);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "👋 ¡Bienvenido! Configura los parámetros para exportar tu documento.";

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
            panelControles.Controls.Add(lblAyudaExportar);
            panelControles.Controls.Add(panelTip);
            panelControles.Location = new System.Drawing.Point(35, 95);
            panelControles.Name = "panelControles";
            panelControles.Size = new System.Drawing.Size(380, 460);
            panelControles.TabIndex = 2;

            // 
            // lblTipoReporte
            // 
            lblTipoReporte.AutoSize = true;
            lblTipoReporte.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblTipoReporte.ForeColor = System.Drawing.Color.Gainsboro;
            lblTipoReporte.Location = new System.Drawing.Point(25, 20);
            lblTipoReporte.Name = "lblTipoReporte";
            lblTipoReporte.Size = new System.Drawing.Size(217, 21);
            lblTipoReporte.TabIndex = 0;
            lblTipoReporte.Text = "Seleccione el tipo de reporte:";

            // 
            // cmbTipoReporte
            // 
            cmbTipoReporte.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            cmbTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbTipoReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbTipoReporte.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            cmbTipoReporte.ForeColor = System.Drawing.Color.White;
            cmbTipoReporte.FormattingEnabled = true;
            cmbTipoReporte.Location = new System.Drawing.Point(25, 45);
            cmbTipoReporte.Name = "cmbTipoReporte";
            cmbTipoReporte.Size = new System.Drawing.Size(330, 31);
            cmbTipoReporte.TabIndex = 1;
            cmbTipoReporte.SelectedIndexChanged += cmbTipoReporte_SelectedIndexChanged;

            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblDesde.ForeColor = System.Drawing.Color.Gainsboro;
            lblDesde.Location = new System.Drawing.Point(25, 95);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new System.Drawing.Size(107, 21);
            lblDesde.TabIndex = 2;
            lblDesde.Text = "Fecha Inicial:";

            // 
            // dtpDesde
            // 
            dtpDesde.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDesde.Location = new System.Drawing.Point(25, 120);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new System.Drawing.Size(330, 30);
            dtpDesde.TabIndex = 3;

            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblHasta.ForeColor = System.Drawing.Color.Gainsboro;
            lblHasta.Location = new System.Drawing.Point(25, 175);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new System.Drawing.Size(98, 21);
            lblHasta.TabIndex = 4;
            lblHasta.Text = "Fecha Final:";

            // 
            // dtpHasta
            // 
            dtpHasta.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpHasta.Location = new System.Drawing.Point(25, 200);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new System.Drawing.Size(330, 30);
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
            btnGenerar.Location = new System.Drawing.Point(25, 260);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new System.Drawing.Size(330, 50);
            btnGenerar.TabIndex = 6;
            btnGenerar.Text = "📄 Generar y Descargar PDF";
            btnGenerar.UseVisualStyleBackColor = false;
            btnGenerar.Click += btnGenerar_Click;

            // 
            // lblAyudaExportar
            // 
            lblAyudaExportar.AutoSize = true;
            lblAyudaExportar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblAyudaExportar.ForeColor = System.Drawing.Color.FromArgb(0, 190, 255);
            lblAyudaExportar.Location = new System.Drawing.Point(60, 315);
            lblAyudaExportar.Name = "lblAyudaExportar";
            lblAyudaExportar.Size = new System.Drawing.Size(260, 21);
            lblAyudaExportar.TabIndex = 7;
            lblAyudaExportar.Text = "⬆️ ¡Exporta tu documento aquí!";

            // 
            // panelTip
            // 
            panelTip.BackColor = System.Drawing.Color.FromArgb(40, 44, 60);
            panelTip.Controls.Add(lblTipIcon);
            panelTip.Controls.Add(lblTipText);
            panelTip.Location = new System.Drawing.Point(25, 360);
            panelTip.Name = "panelTip";
            panelTip.Size = new System.Drawing.Size(330, 75);
            panelTip.TabIndex = 8;

            // 
            // lblTipIcon
            // 
            lblTipIcon.AutoSize = true;
            lblTipIcon.Font = new System.Drawing.Font("Segoe UI", 14F);
            lblTipIcon.Location = new System.Drawing.Point(10, 20);
            lblTipIcon.Name = "lblTipIcon";
            lblTipIcon.Size = new System.Drawing.Size(38, 32);
            lblTipIcon.TabIndex = 0;
            lblTipIcon.Text = "💡";

            // 
            // lblTipText
            // 
            lblTipText.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            lblTipText.ForeColor = System.Drawing.Color.Gainsboro;
            lblTipText.Location = new System.Drawing.Point(50, 15);
            lblTipText.Name = "lblTipText";
            lblTipText.Size = new System.Drawing.Size(270, 50);
            lblTipText.TabIndex = 1;
            lblTipText.Text = "Tip: Los reportes son inmutables y reflejan la información exacta de la base de datos en tiempo real.";

            // 
            // panelDetalle
            // 
            panelDetalle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelDetalle.BackColor = System.Drawing.Color.FromArgb(25, 30, 48);
            panelDetalle.Controls.Add(txtInfoMetricas);
            panelDetalle.Controls.Add(lblHeaderMetricas);
            panelDetalle.Controls.Add(lblInfoDescripcion);
            panelDetalle.Controls.Add(lblInfoBadge);
            panelDetalle.Controls.Add(lblInfoTitulo);
            panelDetalle.Location = new System.Drawing.Point(435, 95);
            panelDetalle.Name = "panelDetalle";
            panelDetalle.Size = new System.Drawing.Size(435, 460);
            panelDetalle.TabIndex = 3;

            // 
            // lblInfoTitulo
            // 
            lblInfoTitulo.AutoSize = true;
            // 🔥 FUENTE AGRANDADA PARA ACCESIBILIDAD
            lblInfoTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblInfoTitulo.ForeColor = System.Drawing.Color.White;
            lblInfoTitulo.Location = new System.Drawing.Point(25, 20);
            lblInfoTitulo.Name = "lblInfoTitulo";
            lblInfoTitulo.Size = new System.Drawing.Size(268, 37);
            lblInfoTitulo.TabIndex = 0;
            lblInfoTitulo.Text = "Detalle del Reporte";

            // 
            // lblInfoBadge
            // 
            lblInfoBadge.AutoSize = true;
            lblInfoBadge.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            lblInfoBadge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblInfoBadge.ForeColor = System.Drawing.Color.White;
            lblInfoBadge.Location = new System.Drawing.Point(25, 65);
            lblInfoBadge.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            lblInfoBadge.Name = "lblInfoBadge";
            lblInfoBadge.Size = new System.Drawing.Size(76, 26);
            lblInfoBadge.TabIndex = 1;
            lblInfoBadge.Text = "ESTADO";

            // 
            // lblInfoDescripcion
            // 
            lblInfoDescripcion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            // 🔥 FUENTE AGRANDADA PARA ACCESIBILIDAD
            lblInfoDescripcion.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            lblInfoDescripcion.ForeColor = System.Drawing.Color.Gainsboro;
            lblInfoDescripcion.Location = new System.Drawing.Point(25, 110);
            lblInfoDescripcion.Name = "lblInfoDescripcion";
            lblInfoDescripcion.Size = new System.Drawing.Size(385, 80);
            lblInfoDescripcion.TabIndex = 2;
            lblInfoDescripcion.Text = "Descripción de la utilidad del reporte.";

            // 
            // lblHeaderMetricas
            // 
            lblHeaderMetricas.AutoSize = true;
            // 🔥 FUENTE AGRANDADA PARA ACCESIBILIDAD
            lblHeaderMetricas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblHeaderMetricas.ForeColor = System.Drawing.Color.FromArgb(13, 110, 253);
            lblHeaderMetricas.Location = new System.Drawing.Point(25, 200);
            lblHeaderMetricas.Name = "lblHeaderMetricas";
            lblHeaderMetricas.Size = new System.Drawing.Size(341, 28);
            lblHeaderMetricas.TabIndex = 3;
            lblHeaderMetricas.Text = "📊 Métricas e Indicadores del PDF:";

            // 
            // txtInfoMetricas
            // 
            txtInfoMetricas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtInfoMetricas.BackColor = System.Drawing.Color.FromArgb(20, 24, 38);
            txtInfoMetricas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            // 🔥 FUENTE AGRANDADA PARA ACCESIBILIDAD
            txtInfoMetricas.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            txtInfoMetricas.ForeColor = System.Drawing.Color.LightGray;
            txtInfoMetricas.Location = new System.Drawing.Point(25, 235);
            txtInfoMetricas.Multiline = true;
            txtInfoMetricas.Name = "txtInfoMetricas";
            txtInfoMetricas.ReadOnly = true;
            txtInfoMetricas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtInfoMetricas.Size = new System.Drawing.Size(385, 205);
            txtInfoMetricas.TabIndex = 4;

            // 
            // FormCentroReportes
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(20, 24, 38);
            ClientSize = new System.Drawing.Size(900, 580);
            Controls.Add(panelDetalle);
            Controls.Add(panelControles);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblTitulo);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "FormCentroReportes";
            Text = "FormCentroReportes";
            Load += FormCentroReportes_Load;
            panelControles.ResumeLayout(false);
            panelControles.PerformLayout();
            panelTip.ResumeLayout(false);
            panelTip.PerformLayout();
            panelDetalle.ResumeLayout(false);
            panelDetalle.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelControles;
        private System.Windows.Forms.Label lblTipoReporte;
        private System.Windows.Forms.ComboBox cmbTipoReporte;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label lblAyudaExportar;
        private System.Windows.Forms.Panel panelTip;
        private System.Windows.Forms.Label lblTipIcon;
        private System.Windows.Forms.Label lblTipText;

        private System.Windows.Forms.Panel panelDetalle;
        private System.Windows.Forms.Label lblInfoTitulo;
        private System.Windows.Forms.Label lblInfoBadge;
        private System.Windows.Forms.Label lblInfoDescripcion;
        private System.Windows.Forms.Label lblHeaderMetricas;
        private System.Windows.Forms.TextBox txtInfoMetricas;
    }
}