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
            lblTitulo = new System.Windows.Forms.Label();
            lblIdentificador = new System.Windows.Forms.Label();
            txtIdentificador = new System.Windows.Forms.TextBox();
            btnHistorialUsuario = new System.Windows.Forms.Button();
            lblIsbn = new System.Windows.Forms.Label();
            txtIsbn = new System.Windows.Forms.TextBox();
            btnHistorialRecurso = new System.Windows.Forms.Button();
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
            lblTitulo.Size = new System.Drawing.Size(407, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Historial de Préstamos y Auditoría";
            // 
            // lblIdentificador
            // 
            lblIdentificador.AutoSize = true;
            lblIdentificador.ForeColor = System.Drawing.Color.Gainsboro;
            lblIdentificador.Location = new System.Drawing.Point(25, 75);
            lblIdentificador.Name = "lblIdentificador";
            lblIdentificador.Size = new System.Drawing.Size(177, 20);
            lblIdentificador.TabIndex = 1;
            lblIdentificador.Text = "Matrícula / N° Empleado:";
            // 
            // txtIdentificador
            // 
            txtIdentificador.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            txtIdentificador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtIdentificador.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            txtIdentificador.ForeColor = System.Drawing.Color.White;
            txtIdentificador.Location = new System.Drawing.Point(25, 100);
            txtIdentificador.Name = "txtIdentificador";
            txtIdentificador.Size = new System.Drawing.Size(200, 31);
            txtIdentificador.TabIndex = 2;
            // 
            // btnHistorialUsuario
            // 
            btnHistorialUsuario.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            btnHistorialUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            btnHistorialUsuario.FlatAppearance.BorderSize = 0;
            btnHistorialUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnHistorialUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnHistorialUsuario.ForeColor = System.Drawing.Color.White;
            btnHistorialUsuario.Location = new System.Drawing.Point(235, 99);
            btnHistorialUsuario.Name = "btnHistorialUsuario";
            btnHistorialUsuario.Size = new System.Drawing.Size(130, 31);
            btnHistorialUsuario.TabIndex = 3;
            btnHistorialUsuario.Text = "📁 Ver Historial";
            btnHistorialUsuario.UseVisualStyleBackColor = false;
            btnHistorialUsuario.Click += btnHistorialUsuario_Click;
            // 
            // lblIsbn
            // 
            lblIsbn.AutoSize = true;
            lblIsbn.ForeColor = System.Drawing.Color.Gainsboro;
            lblIsbn.Location = new System.Drawing.Point(395, 75);
            lblIsbn.Name = "lblIsbn";
            lblIsbn.Size = new System.Drawing.Size(82, 20);
            lblIsbn.TabIndex = 4;
            lblIsbn.Text = "ISBN Libro:";
            // 
            // txtIsbn
            // 
            txtIsbn.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            txtIsbn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtIsbn.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            txtIsbn.ForeColor = System.Drawing.Color.White;
            txtIsbn.Location = new System.Drawing.Point(395, 100);
            txtIsbn.Name = "txtIsbn";
            txtIsbn.Size = new System.Drawing.Size(200, 31);
            txtIsbn.TabIndex = 5;
            // 
            // btnHistorialRecurso
            // 
            btnHistorialRecurso.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            btnHistorialRecurso.Cursor = System.Windows.Forms.Cursors.Hand;
            btnHistorialRecurso.FlatAppearance.BorderSize = 0;
            btnHistorialRecurso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnHistorialRecurso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnHistorialRecurso.ForeColor = System.Drawing.Color.White;
            btnHistorialRecurso.Location = new System.Drawing.Point(605, 99);
            btnHistorialRecurso.Name = "btnHistorialRecurso";
            btnHistorialRecurso.Size = new System.Drawing.Size(130, 31);
            btnHistorialRecurso.TabIndex = 6;
            btnHistorialRecurso.Text = "📁 Historial ISBN";
            btnHistorialRecurso.UseVisualStyleBackColor = false;
            btnHistorialRecurso.Click += btnHistorialRecurso_Click;
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
            btnMostrarTodo.TabIndex = 8;
            btnMostrarTodo.Text = "🔄 Recargar";
            btnMostrarTodo.UseVisualStyleBackColor = false;
            btnMostrarTodo.Click += btnMostrarTodo_Click;
            // 
            // dgvHistorial
            // 
            dgvHistorial.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.BackgroundColor = System.Drawing.Color.FromArgb(25, 25, 35);
            dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Location = new System.Drawing.Point(25, 155);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.RowHeadersWidth = 51;
            dgvHistorial.Size = new System.Drawing.Size(800, 400);
            dgvHistorial.TabIndex = 7;
            // 
            // FormHistorialPrestamos
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            ClientSize = new System.Drawing.Size(850, 590);
            Controls.Add(btnMostrarTodo);
            Controls.Add(dgvHistorial);
            Controls.Add(btnHistorialRecurso);
            Controls.Add(txtIsbn);
            Controls.Add(lblIsbn);
            Controls.Add(btnHistorialUsuario);
            Controls.Add(txtIdentificador);
            Controls.Add(lblIdentificador);
            Controls.Add(lblTitulo);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
        private System.Windows.Forms.Button btnMostrarTodo;
        private System.Windows.Forms.DataGridView dgvHistorial;
    }
}