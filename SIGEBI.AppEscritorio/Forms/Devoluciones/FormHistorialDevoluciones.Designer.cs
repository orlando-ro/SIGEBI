namespace SIGEBI.AppEscritorio.Forms.Devoluciones
{
    partial class FormHistorialDevoluciones
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            lblTitulo = new System.Windows.Forms.Label();
            txtBusqueda = new System.Windows.Forms.TextBox();
            lblFiltroEstado = new System.Windows.Forms.Label();
            cmbCondicion = new System.Windows.Forms.ComboBox();
            btnBuscar = new System.Windows.Forms.Button();
            btnMostrarTodo = new System.Windows.Forms.Button();
            btnExportarExcel = new System.Windows.Forms.Button();
            dgvHistorial = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(25, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(641, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Historial de Devoluciones (Doble clic para ver detalles)";
            // 
            // txtBusqueda
            // 
            txtBusqueda.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtBusqueda.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            txtBusqueda.ForeColor = System.Drawing.Color.White;
            txtBusqueda.Location = new System.Drawing.Point(25, 75);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new System.Drawing.Size(300, 31);
            txtBusqueda.TabIndex = 2;
            // 
            // lblFiltroEstado
            // 
            lblFiltroEstado.AutoSize = true;
            lblFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            lblFiltroEstado.ForeColor = System.Drawing.Color.White;
            lblFiltroEstado.Location = new System.Drawing.Point(340, 78);
            lblFiltroEstado.Name = "lblFiltroEstado";
            lblFiltroEstado.Size = new System.Drawing.Size(73, 25);
            lblFiltroEstado.TabIndex = 8;
            lblFiltroEstado.Text = "Estado:";
            // 
            // cmbCondicion
            // 
            cmbCondicion.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            cmbCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbCondicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbCondicion.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            cmbCondicion.ForeColor = System.Drawing.Color.White;
            cmbCondicion.FormattingEnabled = true;
            cmbCondicion.Location = new System.Drawing.Point(415, 75);
            cmbCondicion.Name = "cmbCondicion";
            cmbCondicion.Size = new System.Drawing.Size(150, 31);
            cmbCondicion.TabIndex = 1;
            cmbCondicion.SelectedIndexChanged += cmbCondicion_SelectedIndexChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnBuscar.ForeColor = System.Drawing.Color.White;
            btnBuscar.Location = new System.Drawing.Point(580, 75);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new System.Drawing.Size(110, 31);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "🔍 Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnMostrarTodo
            // 
            btnMostrarTodo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnMostrarTodo.BackColor = System.Drawing.Color.FromArgb(40, 44, 60);
            btnMostrarTodo.Cursor = System.Windows.Forms.Cursors.Hand;
            btnMostrarTodo.FlatAppearance.BorderSize = 0;
            btnMostrarTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMostrarTodo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnMostrarTodo.ForeColor = System.Drawing.Color.White;
            btnMostrarTodo.Location = new System.Drawing.Point(710, 75);
            btnMostrarTodo.Name = "btnMostrarTodo";
            btnMostrarTodo.Size = new System.Drawing.Size(115, 31);
            btnMostrarTodo.TabIndex = 5;
            btnMostrarTodo.Text = "🔄 Recargar";
            btnMostrarTodo.UseVisualStyleBackColor = false;
            btnMostrarTodo.Click += btnMostrarTodo_Click;
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnExportarExcel.BackColor = System.Drawing.Color.FromArgb(25, 135, 84);
            btnExportarExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            btnExportarExcel.FlatAppearance.BorderSize = 0;
            btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnExportarExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnExportarExcel.ForeColor = System.Drawing.Color.White;
            btnExportarExcel.Location = new System.Drawing.Point(710, 20);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new System.Drawing.Size(115, 31);
            btnExportarExcel.TabIndex = 6;
            btnExportarExcel.Text = "📗 Excel";
            btnExportarExcel.UseVisualStyleBackColor = false;
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // dgvHistorial
            // 
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(38, 43, 60);
            dgvHistorial.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvHistorial.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.BackgroundColor = System.Drawing.Color.FromArgb(20, 24, 38);
            dgvHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHistorial.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistorial.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(15, 18, 28);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(15, 18, 28);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvHistorial.ColumnHeadersHeight = 45;
            dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(30, 34, 48);
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvHistorial.DefaultCellStyle = dataGridViewCellStyle3;
            dgvHistorial.EnableHeadersVisualStyles = false;
            dgvHistorial.GridColor = System.Drawing.Color.FromArgb(70, 75, 90);
            dgvHistorial.Location = new System.Drawing.Point(25, 125);
            dgvHistorial.MultiSelect = false;
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.RowHeadersVisible = false;
            dgvHistorial.RowHeadersWidth = 51;
            dgvHistorial.RowTemplate.Height = 40;
            dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.Size = new System.Drawing.Size(800, 440);
            dgvHistorial.TabIndex = 4;
            dgvHistorial.CellContentClick += dgvHistorial_CellContentClick;
            dgvHistorial.CellDoubleClick += dgvHistorial_CellDoubleClick;
            // 
            // FormHistorialDevoluciones
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            ClientSize = new System.Drawing.Size(850, 590);
            Controls.Add(btnExportarExcel);
            Controls.Add(btnMostrarTodo);
            Controls.Add(dgvHistorial);
            Controls.Add(btnBuscar);
            Controls.Add(cmbCondicion);
            Controls.Add(lblFiltroEstado);
            Controls.Add(txtBusqueda);
            Controls.Add(lblTitulo);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "FormHistorialDevoluciones";
            Text = "FormHistorialDevoluciones";
            Load += FormHistorialDevoluciones_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label lblFiltroEstado;
        private System.Windows.Forms.ComboBox cmbCondicion;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnMostrarTodo;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.DataGridView dgvHistorial;
    }
}