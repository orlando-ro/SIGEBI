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
            ((System.ComponentModel.ISupportInitialize)dgvSolicitudes).BeginInit();
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
            cmbCriterioBusqueda.Items.AddRange(new object[] { "Todas Pendientes", "Matrícula / Empleado" });
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
            dgvSolicitudes.Size = new System.Drawing.Size(800, 440);
            dgvSolicitudes.TabIndex = 5;
            dgvSolicitudes.CellContentClick += dgvSolicitudes_CellContentClick;
            // 
            // FormGestionSolicitudes
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            ClientSize = new System.Drawing.Size(850, 590);
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
    }
}