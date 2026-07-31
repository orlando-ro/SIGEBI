namespace SIGEBI.AppEscritorio.Forms.Prestamos
{
    partial class FormHistorialPrestamos
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

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblIdentificador = new Label();
            txtIdentificador = new TextBox();
            btnHistorialUsuario = new Button();
            lblIsbn = new Label();
            txtIsbn = new TextBox();
            btnHistorialRecurso = new Button();
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
            lblTitulo.Size = new Size(407, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Historial de Préstamos y Auditoría";
            // 
            // lblIdentificador
            // 
            lblIdentificador.AutoSize = true;
            lblIdentificador.ForeColor = Color.Gainsboro;
            lblIdentificador.Location = new Point(25, 75);
            lblIdentificador.Name = "lblIdentificador";
            lblIdentificador.Size = new Size(177, 20);
            lblIdentificador.TabIndex = 1;
            lblIdentificador.Text = "Matrícula / N° Empleado:";
            // 
            // txtIdentificador
            // 
            txtIdentificador.BackColor = Color.FromArgb(40, 40, 60);
            txtIdentificador.BorderStyle = BorderStyle.FixedSingle;
            txtIdentificador.Font = new Font("Segoe UI", 10.5F);
            txtIdentificador.ForeColor = Color.White;
            txtIdentificador.Location = new Point(25, 100);
            txtIdentificador.Name = "txtIdentificador";
            txtIdentificador.Size = new Size(200, 31);
            txtIdentificador.TabIndex = 2;
            // 
            // btnHistorialUsuario
            // 
            btnHistorialUsuario.BackColor = Color.FromArgb(13, 110, 253);
            btnHistorialUsuario.Cursor = Cursors.Hand;
            btnHistorialUsuario.FlatAppearance.BorderSize = 0;
            btnHistorialUsuario.FlatStyle = FlatStyle.Flat;
            btnHistorialUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnHistorialUsuario.ForeColor = Color.White;
            btnHistorialUsuario.Location = new Point(235, 99);
            btnHistorialUsuario.Name = "btnHistorialUsuario";
            btnHistorialUsuario.Size = new Size(130, 31);
            btnHistorialUsuario.TabIndex = 3;
            btnHistorialUsuario.Text = "📁 Ver Historial";
            btnHistorialUsuario.UseVisualStyleBackColor = false;
            btnHistorialUsuario.Click += btnHistorialUsuario_Click;
            // 
            // lblIsbn
            // 
            lblIsbn.AutoSize = true;
            lblIsbn.ForeColor = Color.Gainsboro;
            lblIsbn.Location = new Point(395, 75);
            lblIsbn.Name = "lblIsbn";
            lblIsbn.Size = new Size(82, 20);
            lblIsbn.TabIndex = 4;
            lblIsbn.Text = "ISBN Libro:";
            // 
            // txtIsbn
            // 
            txtIsbn.BackColor = Color.FromArgb(40, 40, 60);
            txtIsbn.BorderStyle = BorderStyle.FixedSingle;
            txtIsbn.Font = new Font("Segoe UI", 10.5F);
            txtIsbn.ForeColor = Color.White;
            txtIsbn.Location = new Point(395, 100);
            txtIsbn.Name = "txtIsbn";
            txtIsbn.Size = new Size(200, 31);
            txtIsbn.TabIndex = 5;
            // 
            // btnHistorialRecurso
            // 
            btnHistorialRecurso.BackColor = Color.FromArgb(13, 110, 253);
            btnHistorialRecurso.Cursor = Cursors.Hand;
            btnHistorialRecurso.FlatAppearance.BorderSize = 0;
            btnHistorialRecurso.FlatStyle = FlatStyle.Flat;
            btnHistorialRecurso.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnHistorialRecurso.ForeColor = Color.White;
            btnHistorialRecurso.Location = new Point(605, 99);
            btnHistorialRecurso.Name = "btnHistorialRecurso";
            btnHistorialRecurso.Size = new Size(130, 31);
            btnHistorialRecurso.TabIndex = 6;
            btnHistorialRecurso.Text = "📁 Historial ISBN";
            btnHistorialRecurso.UseVisualStyleBackColor = false;
            btnHistorialRecurso.Click += btnHistorialRecurso_Click;
            // 
            // dgvHistorial
            // 
            dgvHistorial.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.BackgroundColor = Color.FromArgb(25, 25, 35);
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Location = new Point(25, 155);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.RowHeadersWidth = 51;
            dgvHistorial.Size = new Size(800, 400);
            dgvHistorial.TabIndex = 7;
            dgvHistorial.ReadOnly = true;
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 
            // FormHistorialPrestamos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 45);
            ClientSize = new Size(850, 590);
            Controls.Add(dgvHistorial);
            Controls.Add(btnHistorialRecurso);
            Controls.Add(txtIsbn);
            Controls.Add(lblIsbn);
            Controls.Add(btnHistorialUsuario);
            Controls.Add(txtIdentificador);
            Controls.Add(lblIdentificador);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormHistorialPrestamos";
            Text = "FormHistorialPrestamos";
            Load += FormHistorialPrestamos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblIdentificador;
        private System.Windows.Forms.TextBox txtIdentificador;
        private System.Windows.Forms.Button btnHistorialUsuario;
        private System.Windows.Forms.Label lblIsbn;
        private System.Windows.Forms.TextBox txtIsbn;
        private System.Windows.Forms.Button btnHistorialRecurso;
        private System.Windows.Forms.DataGridView dgvHistorial;
    }
}