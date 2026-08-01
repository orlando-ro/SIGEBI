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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblBusqueda = new Label();
            txtBusqueda = new TextBox();
            btnBuscar = new Button();
            btnMostrarTodo = new Button();
            dgvPenalizaciones = new DataGridView();
            panelAcciones = new Panel();
            lblMotivoResolucion = new Label();
            txtMotivoResolucion = new TextBox();
            btnRegistrarPago = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPenalizaciones).BeginInit();
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
            lblTitulo.Size = new Size(310, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Penalizaciones";
            // 
            // lblBusqueda
            // 
            lblBusqueda.AutoSize = true;
            lblBusqueda.ForeColor = Color.Gainsboro;
            lblBusqueda.Location = new Point(25, 75);
            lblBusqueda.Name = "lblBusqueda";
            lblBusqueda.Size = new Size(177, 20);
            lblBusqueda.TabIndex = 1;
            lblBusqueda.Text = "Matrícula / N° Empleado:";
            // 
            // txtBusqueda
            // 
            txtBusqueda.BackColor = Color.FromArgb(40, 40, 60);
            txtBusqueda.BorderStyle = BorderStyle.FixedSingle;
            txtBusqueda.Font = new Font("Segoe UI", 10.5F);
            txtBusqueda.ForeColor = Color.White;
            txtBusqueda.Location = new Point(25, 100);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.PlaceholderText = "Ej: 2025-2050";
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
            btnBuscar.Location = new Point(290, 100);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(120, 31);
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
            btnMostrarTodo.Location = new Point(695, 100);
            btnMostrarTodo.Name = "btnMostrarTodo";
            btnMostrarTodo.Size = new Size(130, 31);
            btnMostrarTodo.TabIndex = 9;
            btnMostrarTodo.Text = "🔄 Mostrar Todo";
            btnMostrarTodo.UseVisualStyleBackColor = false;
            btnMostrarTodo.Click += btnMostrarTodo_Click;
            // 
            // dgvPenalizaciones
            // 
            dgvPenalizaciones.AllowUserToAddRows = false;
            dgvPenalizaciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPenalizaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPenalizaciones.BackgroundColor = Color.FromArgb(25, 25, 35);
            dgvPenalizaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPenalizaciones.Location = new Point(25, 150);
            dgvPenalizaciones.MultiSelect = false;
            dgvPenalizaciones.Name = "dgvPenalizaciones";
            dgvPenalizaciones.ReadOnly = true;
            dgvPenalizaciones.RowHeadersWidth = 51;
            dgvPenalizaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPenalizaciones.Size = new Size(800, 300);
            dgvPenalizaciones.TabIndex = 4;
            // 
            // panelAcciones
            // 
            panelAcciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelAcciones.BackColor = Color.FromArgb(20, 24, 38);
            panelAcciones.Controls.Add(lblMotivoResolucion);
            panelAcciones.Controls.Add(txtMotivoResolucion);
            panelAcciones.Controls.Add(btnRegistrarPago);
            panelAcciones.Location = new Point(25, 470);
            panelAcciones.Name = "panelAcciones";
            panelAcciones.Size = new Size(800, 100);
            panelAcciones.TabIndex = 5;
            // 
            // lblMotivoResolucion
            // 
            lblMotivoResolucion.AutoSize = true;
            lblMotivoResolucion.ForeColor = Color.Gainsboro;
            lblMotivoResolucion.Location = new Point(20, 20);
            lblMotivoResolucion.Name = "lblMotivoResolucion";
            lblMotivoResolucion.Size = new Size(335, 20);
            lblMotivoResolucion.TabIndex = 6;
            lblMotivoResolucion.Text = "Motivo de Resolución (Ej: Efectivo, Exoneración):";
            // 
            // txtMotivoResolucion
            // 
            txtMotivoResolucion.BackColor = Color.FromArgb(40, 40, 60);
            txtMotivoResolucion.BorderStyle = BorderStyle.FixedSingle;
            txtMotivoResolucion.Font = new Font("Segoe UI", 10.5F);
            txtMotivoResolucion.ForeColor = Color.White;
            txtMotivoResolucion.Location = new Point(20, 45);
            txtMotivoResolucion.Name = "txtMotivoResolucion";
            txtMotivoResolucion.PlaceholderText = "Escriba el método de pago...";
            txtMotivoResolucion.Size = new Size(450, 31);
            txtMotivoResolucion.TabIndex = 7;
            // 
            // btnRegistrarPago
            // 
            btnRegistrarPago.BackColor = Color.FromArgb(25, 135, 84);
            btnRegistrarPago.Cursor = Cursors.Hand;
            btnRegistrarPago.FlatAppearance.BorderSize = 0;
            btnRegistrarPago.FlatStyle = FlatStyle.Flat;
            btnRegistrarPago.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegistrarPago.ForeColor = Color.White;
            btnRegistrarPago.Location = new Point(550, 40);
            btnRegistrarPago.Name = "btnRegistrarPago";
            btnRegistrarPago.Size = new Size(230, 40);
            btnRegistrarPago.TabIndex = 8;
            btnRegistrarPago.Text = "💲 Registrar Pago";
            btnRegistrarPago.UseVisualStyleBackColor = false;
            btnRegistrarPago.Click += btnRegistrarPago_Click;
            // 
            // FormGestionPenalizaciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 45);
            ClientSize = new Size(850, 590);
            Controls.Add(btnMostrarTodo);
            Controls.Add(panelAcciones);
            Controls.Add(dgvPenalizaciones);
            Controls.Add(btnBuscar);
            Controls.Add(txtBusqueda);
            Controls.Add(lblBusqueda);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormGestionPenalizaciones";
            Text = "FormGestionPenalizaciones";
            Load += FormGestionPenalizaciones_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPenalizaciones).EndInit();
            panelAcciones.ResumeLayout(false);
            panelAcciones.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnMostrarTodo;
        private System.Windows.Forms.DataGridView dgvPenalizaciones;
        private System.Windows.Forms.Panel panelAcciones;
        private System.Windows.Forms.Label lblMotivoResolucion;
        private System.Windows.Forms.TextBox txtMotivoResolucion;
        private System.Windows.Forms.Button btnRegistrarPago;
    }
}