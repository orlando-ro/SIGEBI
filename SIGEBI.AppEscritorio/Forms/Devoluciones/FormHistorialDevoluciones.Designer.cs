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
            lblTitulo = new Label();
            cmbCriterio = new ComboBox();
            txtBusqueda = new TextBox();
            btnBuscar = new Button();
            btnMostrarTodo = new Button();
            dgvHistorial = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(25, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(302, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Historial de Devoluciones";
            // 
            // cmbCriterio
            // 
            cmbCriterio.BackColor = Color.FromArgb(40, 40, 60);
            cmbCriterio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCriterio.FlatStyle = FlatStyle.Flat;
            cmbCriterio.Font = new Font("Segoe UI", 10.5F);
            cmbCriterio.ForeColor = Color.White;
            cmbCriterio.FormattingEnabled = true;
            cmbCriterio.Items.AddRange(new object[] { "Matrícula / Empleado", "ISBN Libro" });
            cmbCriterio.Location = new Point(25, 75);
            cmbCriterio.Name = "cmbCriterio";
            cmbCriterio.Size = new Size(200, 31);
            cmbCriterio.TabIndex = 1;
            cmbCriterio.SelectedIndexChanged += cmbCriterio_SelectedIndexChanged;
            // 
            // txtBusqueda
            // 
            txtBusqueda.BackColor = Color.FromArgb(40, 40, 60);
            txtBusqueda.BorderStyle = BorderStyle.FixedSingle;
            txtBusqueda.Font = new Font("Segoe UI", 10.5F);
            txtBusqueda.ForeColor = Color.White;
            txtBusqueda.Location = new Point(240, 75);
            txtBusqueda.Name = "txtBusqueda";
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
            // btnMostrarTodo
            // 
            btnMostrarTodo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMostrarTodo.BackColor = Color.FromArgb(40, 44, 60);
            btnMostrarTodo.Cursor = Cursors.Hand;
            btnMostrarTodo.FlatAppearance.BorderSize = 0;
            btnMostrarTodo.FlatStyle = FlatStyle.Flat;
            btnMostrarTodo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMostrarTodo.ForeColor = Color.White;
            btnMostrarTodo.Location = new Point(695, 75);
            btnMostrarTodo.Name = "btnMostrarTodo";
            btnMostrarTodo.Size = new Size(130, 31);
            btnMostrarTodo.TabIndex = 5;
            btnMostrarTodo.Text = "🔄 Mostrar Todo";
            btnMostrarTodo.UseVisualStyleBackColor = false;
            btnMostrarTodo.Click += btnMostrarTodo_Click;
            // 
            // dgvHistorial
            // 
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.BackgroundColor = Color.FromArgb(25, 25, 35);
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Location = new Point(25, 125);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.RowHeadersWidth = 51;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.Size = new Size(800, 440);
            dgvHistorial.TabIndex = 4;
            // 
            // FormHistorialDevoluciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 45);
            ClientSize = new Size(850, 590);
            Controls.Add(btnMostrarTodo);
            Controls.Add(dgvHistorial);
            Controls.Add(btnBuscar);
            Controls.Add(txtBusqueda);
            Controls.Add(cmbCriterio);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
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