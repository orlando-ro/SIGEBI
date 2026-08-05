namespace SIGEBI.AppEscritorio.Forms.Penalizaciones
{
    partial class FormGestionPenalizaciones
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
            lblBusqueda = new System.Windows.Forms.Label();
            txtBusqueda = new System.Windows.Forms.TextBox();
            btnBuscar = new System.Windows.Forms.Button();
            lblFiltro = new System.Windows.Forms.Label();
            cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            btnMostrarTodo = new System.Windows.Forms.Button();
            dgvPenalizaciones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPenalizaciones).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(25, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Gestión y Consulta de Penalizaciones (Doble Clic para Ver Detalles)";
            // 
            // lblBusqueda
            // 
            lblBusqueda.AutoSize = true;
            lblBusqueda.ForeColor = System.Drawing.Color.Gainsboro;
            lblBusqueda.Location = new System.Drawing.Point(25, 75);
            lblBusqueda.Name = "lblBusqueda";
            lblBusqueda.Text = "Matrícula / N° Empleado:";
            // 
            // txtBusqueda
            // 
            txtBusqueda.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtBusqueda.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            txtBusqueda.ForeColor = System.Drawing.Color.White;
            txtBusqueda.Location = new System.Drawing.Point(25, 100);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.PlaceholderText = "Ej: 2025-2050";
            txtBusqueda.Size = new System.Drawing.Size(200, 31);
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnBuscar.ForeColor = System.Drawing.Color.White;
            btnBuscar.Location = new System.Drawing.Point(235, 100);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new System.Drawing.Size(120, 31);
            btnBuscar.Text = "🔍 Buscar";
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblFiltro
            // 
            lblFiltro.AutoSize = true;
            lblFiltro.ForeColor = System.Drawing.Color.Gainsboro;
            lblFiltro.Location = new System.Drawing.Point(380, 75);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Text = "Mostrar:";
            // 
            // cmbFiltroEstado
            // 
            cmbFiltroEstado.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbFiltroEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            cmbFiltroEstado.ForeColor = System.Drawing.Color.White;
            cmbFiltroEstado.Location = new System.Drawing.Point(380, 100);
            cmbFiltroEstado.Name = "cmbFiltroEstado";
            cmbFiltroEstado.Size = new System.Drawing.Size(200, 31);
            cmbFiltroEstado.SelectedIndexChanged += cmbFiltroEstado_SelectedIndexChanged;
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
            btnMostrarTodo.Location = new System.Drawing.Point(695, 20);
            btnMostrarTodo.Name = "btnMostrarTodo";
            btnMostrarTodo.Size = new System.Drawing.Size(130, 31);
            btnMostrarTodo.Text = "🔄 Recargar";
            btnMostrarTodo.Click += btnMostrarTodo_Click;
            // 
            // dgvPenalizaciones
            // 
            dgvPenalizaciones.AllowUserToAddRows = false;
            dgvPenalizaciones.AllowUserToDeleteRows = false;
            dgvPenalizaciones.AllowUserToResizeRows = false;
            dgvPenalizaciones.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvPenalizaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvPenalizaciones.BackgroundColor = System.Drawing.Color.FromArgb(20, 24, 38);
            dgvPenalizaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvPenalizaciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPenalizaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(15, 18, 28);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(15, 18, 28);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvPenalizaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPenalizaciones.ColumnHeadersHeight = 45;
            dgvPenalizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(30, 34, 48);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvPenalizaciones.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(38, 43, 60);
            dgvPenalizaciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvPenalizaciones.EnableHeadersVisualStyles = false;
            dgvPenalizaciones.GridColor = System.Drawing.Color.FromArgb(70, 75, 90);
            dgvPenalizaciones.Location = new System.Drawing.Point(25, 155);
            dgvPenalizaciones.MultiSelect = false;
            dgvPenalizaciones.Name = "dgvPenalizaciones";
            dgvPenalizaciones.ReadOnly = true;
            dgvPenalizaciones.RowHeadersVisible = false;
            dgvPenalizaciones.RowTemplate.Height = 40;
            dgvPenalizaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvPenalizaciones.Size = new System.Drawing.Size(800, 410);
            dgvPenalizaciones.CellDoubleClick += dgvPenalizaciones_CellDoubleClick;
            // 
            // FormGestionPenalizaciones
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            ClientSize = new System.Drawing.Size(850, 590);
            Controls.Add(cmbFiltroEstado);
            Controls.Add(lblFiltro);
            Controls.Add(btnMostrarTodo);
            Controls.Add(dgvPenalizaciones);
            Controls.Add(btnBuscar);
            Controls.Add(txtBusqueda);
            Controls.Add(lblBusqueda);
            Controls.Add(lblTitulo);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "FormGestionPenalizaciones";
            Text = "FormGestionPenalizaciones";
            Load += FormGestionPenalizaciones_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPenalizaciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private System.Windows.Forms.Button btnMostrarTodo;
        private System.Windows.Forms.DataGridView dgvPenalizaciones;
    }
}