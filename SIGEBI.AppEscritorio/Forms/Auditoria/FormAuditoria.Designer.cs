namespace SIGEBI.AppEscritorio.Forms.Auditoria
{
    partial class FormAuditoria
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panelTop = new Panel();
            lblDobleClickInfo = new Label();
            btnExportarPdf = new Button();
            btnExportarExcel = new Button();
            btnRefrescar = new Button();
            btnBuscar = new Button();
            txtAccion = new TextBox();
            lblAccion = new Label();
            cboModulo = new ComboBox();
            lblModulo = new Label();
            dtpFechaFin = new DateTimePicker();
            lblHasta = new Label();
            dtpFechaInicio = new DateTimePicker();
            chkUsarFechas = new CheckBox();
            lblTitulo = new Label();
            dgvAuditoria = new DataGridView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditoria).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(20, 24, 38);
            panelTop.Controls.Add(lblDobleClickInfo);
            panelTop.Controls.Add(btnExportarPdf);
            panelTop.Controls.Add(btnExportarExcel);
            panelTop.Controls.Add(btnRefrescar);
            panelTop.Controls.Add(btnBuscar);
            panelTop.Controls.Add(txtAccion);
            panelTop.Controls.Add(lblAccion);
            panelTop.Controls.Add(cboModulo);
            panelTop.Controls.Add(lblModulo);
            panelTop.Controls.Add(dtpFechaFin);
            panelTop.Controls.Add(lblHasta);
            panelTop.Controls.Add(dtpFechaInicio);
            panelTop.Controls.Add(chkUsarFechas);
            panelTop.Controls.Add(lblTitulo);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1000, 130);
            panelTop.TabIndex = 0;
            // 
            // lblDobleClickInfo
            // 
            lblDobleClickInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDobleClickInfo.AutoSize = true;
            lblDobleClickInfo.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblDobleClickInfo.ForeColor = Color.DarkGray;
            lblDobleClickInfo.Location = new Point(735, 48);
            lblDobleClickInfo.Name = "lblDobleClickInfo";
            lblDobleClickInfo.Size = new Size(314, 20);
            lblDobleClickInfo.TabIndex = 12;
            lblDobleClickInfo.Text = "💡 Haz doble clic en una fila para ver el detalle";
            // 
            // btnExportarPdf
            // 
            btnExportarPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportarPdf.BackColor = Color.FromArgb(220, 53, 69);
            btnExportarPdf.Cursor = Cursors.Hand;
            btnExportarPdf.FlatAppearance.BorderSize = 0;
            btnExportarPdf.FlatStyle = FlatStyle.Flat;
            btnExportarPdf.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExportarPdf.ForeColor = Color.White;
            btnExportarPdf.Location = new Point(695, 14);
            btnExportarPdf.Name = "btnExportarPdf";
            btnExportarPdf.Size = new Size(80, 31);
            btnExportarPdf.TabIndex = 11;
            btnExportarPdf.Text = "📄 PDF";
            btnExportarPdf.UseVisualStyleBackColor = false;
            btnExportarPdf.Click += btnExportarPdf_Click;
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportarExcel.BackColor = Color.SeaGreen;
            btnExportarExcel.Cursor = Cursors.Hand;
            btnExportarExcel.FlatAppearance.BorderSize = 0;
            btnExportarExcel.FlatStyle = FlatStyle.Flat;
            btnExportarExcel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExportarExcel.ForeColor = Color.White;
            btnExportarExcel.Location = new Point(781, 14);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(80, 31);
            btnExportarExcel.TabIndex = 10;
            btnExportarExcel.Text = "📗 Excel";
            btnExportarExcel.UseVisualStyleBackColor = false;
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // btnRefrescar
            // 
            btnRefrescar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefrescar.BackColor = Color.FromArgb(40, 44, 60);
            btnRefrescar.Cursor = Cursors.Hand;
            btnRefrescar.FlatAppearance.BorderSize = 0;
            btnRefrescar.FlatStyle = FlatStyle.Flat;
            btnRefrescar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefrescar.ForeColor = Color.White;
            btnRefrescar.Location = new Point(867, 14);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(108, 31);
            btnRefrescar.TabIndex = 9;
            btnRefrescar.Text = "🔄 Refrescar";
            btnRefrescar.UseVisualStyleBackColor = false;
            btnRefrescar.Click += btnRefrescar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(13, 110, 253);
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(855, 71);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(80, 31);
            btnBuscar.TabIndex = 9;
            btnBuscar.Text = "🔍 Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtAccion
            // 
            txtAccion.BackColor = Color.FromArgb(40, 40, 60);
            txtAccion.BorderStyle = BorderStyle.FixedSingle;
            txtAccion.ForeColor = Color.White;
            txtAccion.Location = new Point(695, 73);
            txtAccion.Name = "txtAccion";
            txtAccion.PlaceholderText = "Filtrar por acción...";
            txtAccion.Size = new Size(150, 27);
            txtAccion.TabIndex = 8;
            // 
            // lblAccion
            // 
            lblAccion.AutoSize = true;
            lblAccion.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAccion.ForeColor = Color.Gainsboro;
            lblAccion.Location = new Point(625, 76);
            lblAccion.Name = "lblAccion";
            lblAccion.Size = new Size(66, 21);
            lblAccion.TabIndex = 7;
            lblAccion.Text = "Acción:";
            // 
            // cboModulo
            // 
            cboModulo.BackColor = Color.FromArgb(40, 40, 60);
            cboModulo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboModulo.FlatStyle = FlatStyle.Flat;
            cboModulo.ForeColor = Color.White;
            cboModulo.FormattingEnabled = true;
            cboModulo.Items.AddRange(new object[] { "Todos", "Préstamos y Devoluciones", "Solicitudes", "Libro", "Categoria", "Usuario", "Penalizacion" });
            cboModulo.Location = new Point(460, 73);
            cboModulo.Name = "cboModulo";
            cboModulo.Size = new Size(150, 28);
            cboModulo.TabIndex = 6;
            // 
            // lblModulo
            // 
            lblModulo.AutoSize = true;
            lblModulo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblModulo.ForeColor = Color.Gainsboro;
            lblModulo.Location = new Point(385, 76);
            lblModulo.Name = "lblModulo";
            lblModulo.Size = new Size(74, 21);
            lblModulo.TabIndex = 5;
            lblModulo.Text = "Módulo:";
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.CustomFormat = "dd/MM/yyyy";
            dtpFechaFin.Format = DateTimePickerFormat.Custom;
            dtpFechaFin.Location = new Point(252, 74);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(115, 27);
            dtpFechaFin.TabIndex = 4;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.ForeColor = Color.Gainsboro;
            lblHasta.Location = new Point(231, 78);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(15, 20);
            lblHasta.TabIndex = 3;
            lblHasta.Text = "-";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.CustomFormat = "dd/MM/yyyy";
            dtpFechaInicio.Format = DateTimePickerFormat.Custom;
            dtpFechaInicio.Location = new Point(110, 74);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(115, 27);
            dtpFechaInicio.TabIndex = 2;
            // 
            // chkUsarFechas
            // 
            chkUsarFechas.AutoSize = true;
            chkUsarFechas.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            chkUsarFechas.ForeColor = Color.Gainsboro;
            chkUsarFechas.Location = new Point(25, 75);
            chkUsarFechas.Name = "chkUsarFechas";
            chkUsarFechas.Size = new Size(80, 25);
            chkUsarFechas.TabIndex = 1;
            chkUsarFechas.Text = "Fecha:";
            chkUsarFechas.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(25, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(383, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registro Inmutable de Auditoría";
            // 
            // dgvAuditoria
            // 
            dgvAuditoria.AllowUserToAddRows = false;
            dgvAuditoria.AllowUserToDeleteRows = false;
            dgvAuditoria.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(38, 43, 60);
            dgvAuditoria.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAuditoria.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAuditoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuditoria.BackgroundColor = Color.FromArgb(20, 24, 38);
            dgvAuditoria.BorderStyle = BorderStyle.None;
            dgvAuditoria.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAuditoria.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(15, 18, 28);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(15, 18, 28);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvAuditoria.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAuditoria.ColumnHeadersHeight = 45;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(30, 34, 48);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.Padding = new Padding(5, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(13, 110, 253);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvAuditoria.DefaultCellStyle = dataGridViewCellStyle3;
            dgvAuditoria.EnableHeadersVisualStyles = false;
            dgvAuditoria.GridColor = Color.FromArgb(70, 75, 90);
            dgvAuditoria.Location = new Point(25, 145);
            dgvAuditoria.MultiSelect = false;
            dgvAuditoria.Name = "dgvAuditoria";
            dgvAuditoria.ReadOnly = true;
            dgvAuditoria.RowHeadersVisible = false;
            dgvAuditoria.RowHeadersWidth = 51;
            dgvAuditoria.RowTemplate.Height = 40;
            dgvAuditoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuditoria.Size = new Size(950, 480);
            dgvAuditoria.TabIndex = 1;
            dgvAuditoria.CellContentClick += dgvAuditoria_CellContentClick;
            dgvAuditoria.CellDoubleClick += dgvAuditoria_CellDoubleClick;
            // 
            // FormAuditoria
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 45);
            ClientSize = new Size(1000, 650);
            Controls.Add(dgvAuditoria);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormAuditoria";
            Text = "FormAuditoria";
            Load += FormAuditoria_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditoria).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDobleClickInfo;
        private System.Windows.Forms.Button btnExportarPdf;
        private System.Windows.Forms.CheckBox chkUsarFechas;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblModulo;
        private System.Windows.Forms.ComboBox cboModulo;
        private System.Windows.Forms.Label lblAccion;
        private System.Windows.Forms.TextBox txtAccion;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.DataGridView dgvAuditoria;
    }
}