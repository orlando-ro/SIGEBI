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

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            lblTitulo = new System.Windows.Forms.Label();
            cmbCriterio = new System.Windows.Forms.ComboBox();
            txtBusqueda = new System.Windows.Forms.TextBox();
            btnBuscar = new System.Windows.Forms.Button();
            btnMostrarTodo = new System.Windows.Forms.Button();
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
            lblTitulo.Size = new System.Drawing.Size(307, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Historial de Devoluciones";
            // 
            // cmbCriterio
            // 
            cmbCriterio.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            cmbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbCriterio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbCriterio.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            cmbCriterio.ForeColor = System.Drawing.Color.White;
            cmbCriterio.FormattingEnabled = true;
            cmbCriterio.Items.AddRange(new object[] { "Matrícula / Empleado", "ISBN Libro" });
            cmbCriterio.Location = new System.Drawing.Point(25, 75);
            cmbCriterio.Name = "cmbCriterio";
            cmbCriterio.Size = new System.Drawing.Size(200, 31);
            cmbCriterio.TabIndex = 1;
            cmbCriterio.SelectedIndexChanged += cmbCriterio_SelectedIndexChanged;
            // 
            // txtBusqueda
            // 
            txtBusqueda.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtBusqueda.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            txtBusqueda.ForeColor = System.Drawing.Color.White;
            txtBusqueda.Location = new System.Drawing.Point(240, 75);
            txtBusqueda.Name = "txtBusqueda";
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
            // btnMostrarTodo
            // 
            btnMostrarTodo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnMostrarTodo.BackColor = System.Drawing.Color.FromArgb(40, 44, 60);
            btnMostrarTodo.Cursor = System.Windows.Forms.Cursors.Hand;
            btnMostrarTodo.FlatAppearance.BorderSize = 0;
            btnMostrarTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMostrarTodo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnMostrarTodo.ForeColor = System.Drawing.Color.White;
            btnMostrarTodo.Location = new System.Drawing.Point(695, 75);
            btnMostrarTodo.Name = "btnMostrarTodo";
            btnMostrarTodo.Size = new System.Drawing.Size(130, 31);
            btnMostrarTodo.TabIndex = 5;
            btnMostrarTodo.Text = "🔄 Recargar";
            btnMostrarTodo.UseVisualStyleBackColor = false;
            btnMostrarTodo.Click += btnMostrarTodo_Click;
            // 
            // dgvHistorial
            // 
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.AllowUserToResizeRows = false;
            dgvHistorial.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.BackgroundColor = System.Drawing.Color.FromArgb(20, 24, 38);
            dgvHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHistorial.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistorial.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(15, 18, 28);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(15, 18, 28);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvHistorial.ColumnHeadersHeight = 45;
            dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(30, 34, 48);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvHistorial.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(38, 43, 60);
            dgvHistorial.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
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
            // 
            // FormHistorialDevoluciones
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            ClientSize = new System.Drawing.Size(850, 590);
            Controls.Add(btnMostrarTodo);
            Controls.Add(dgvHistorial);
            Controls.Add(btnBuscar);
            Controls.Add(txtBusqueda);
            Controls.Add(cmbCriterio);
            Controls.Add(lblTitulo);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "FormHistorialDevoluciones";
            Text = "FormHistorialDevoluciones";
            Load += FormHistorialDevoluciones_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cmbCriterio;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnMostrarTodo;
        private System.Windows.Forms.DataGridView dgvHistorial;
    }
}