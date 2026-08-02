namespace SIGEBI.AppEscritorio.Forms.Prestamos
{
    partial class FormConsultarActivos
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
            btnBuscarPorUsuario = new System.Windows.Forms.Button();
            lblIsbn = new System.Windows.Forms.Label();
            txtIsbn = new System.Windows.Forms.TextBox();
            btnBuscarPorRecurso = new System.Windows.Forms.Button();
            dgvPrestamos = new System.Windows.Forms.DataGridView();
            btnMostrarTodos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(25, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(366, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Consulta de Préstamos Activos";
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
            // btnBuscarPorUsuario
            // 
            btnBuscarPorUsuario.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            btnBuscarPorUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBuscarPorUsuario.FlatAppearance.BorderSize = 0;
            btnBuscarPorUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBuscarPorUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnBuscarPorUsuario.ForeColor = System.Drawing.Color.White;
            btnBuscarPorUsuario.Location = new System.Drawing.Point(235, 99);
            btnBuscarPorUsuario.Name = "btnBuscarPorUsuario";
            btnBuscarPorUsuario.Size = new System.Drawing.Size(120, 31);
            btnBuscarPorUsuario.TabIndex = 3;
            btnBuscarPorUsuario.Text = "🔍 Buscar";
            btnBuscarPorUsuario.UseVisualStyleBackColor = false;
            btnBuscarPorUsuario.Click += btnBuscarPorUsuario_Click;
            // 
            // lblIsbn
            // 
            lblIsbn.AutoSize = true;
            lblIsbn.ForeColor = System.Drawing.Color.Gainsboro;
            lblIsbn.Location = new System.Drawing.Point(385, 75);
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
            txtIsbn.Location = new System.Drawing.Point(385, 100);
            txtIsbn.Name = "txtIsbn";
            txtIsbn.Size = new System.Drawing.Size(200, 31);
            txtIsbn.TabIndex = 5;
            // 
            // btnBuscarPorRecurso
            // 
            btnBuscarPorRecurso.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            btnBuscarPorRecurso.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBuscarPorRecurso.FlatAppearance.BorderSize = 0;
            btnBuscarPorRecurso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBuscarPorRecurso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnBuscarPorRecurso.ForeColor = System.Drawing.Color.White;
            btnBuscarPorRecurso.Location = new System.Drawing.Point(595, 99);
            btnBuscarPorRecurso.Name = "btnBuscarPorRecurso";
            btnBuscarPorRecurso.Size = new System.Drawing.Size(120, 31);
            btnBuscarPorRecurso.TabIndex = 6;
            btnBuscarPorRecurso.Text = "🔍 Buscar ISBN";
            btnBuscarPorRecurso.UseVisualStyleBackColor = false;
            btnBuscarPorRecurso.Click += btnBuscarPorRecurso_Click;
            // 
            // dgvPrestamos
            // 
            dgvPrestamos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvPrestamos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrestamos.BackgroundColor = System.Drawing.Color.FromArgb(25, 25, 35);
            dgvPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrestamos.Location = new System.Drawing.Point(25, 155);
            dgvPrestamos.Name = "dgvPrestamos";
            dgvPrestamos.RowHeadersWidth = 51;
            dgvPrestamos.Size = new System.Drawing.Size(800, 400);
            dgvPrestamos.TabIndex = 7;
            dgvPrestamos.ReadOnly = true;
            dgvPrestamos.AllowUserToAddRows = false;
            dgvPrestamos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // btnMostrarTodos
            // 
            btnMostrarTodos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnMostrarTodos.BackColor = System.Drawing.Color.FromArgb(40, 44, 60);
            btnMostrarTodos.Cursor = System.Windows.Forms.Cursors.Hand;
            btnMostrarTodos.FlatAppearance.BorderSize = 0;
            btnMostrarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMostrarTodos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnMostrarTodos.ForeColor = System.Drawing.Color.White;
            btnMostrarTodos.Location = new System.Drawing.Point(695, 20);
            btnMostrarTodos.Name = "btnMostrarTodos";
            btnMostrarTodos.Size = new System.Drawing.Size(130, 31);
            btnMostrarTodos.TabIndex = 8;
            btnMostrarTodos.Text = "🔄 Recargar";
            btnMostrarTodos.UseVisualStyleBackColor = false;
            btnMostrarTodos.Click += btnMostrarTodos_Click;
            // 
            // FormConsultarActivos
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            ClientSize = new System.Drawing.Size(850, 590);
            Controls.Add(btnMostrarTodos);
            Controls.Add(dgvPrestamos);
            Controls.Add(btnBuscarPorRecurso);
            Controls.Add(txtIsbn);
            Controls.Add(lblIsbn);
            Controls.Add(btnBuscarPorUsuario);
            Controls.Add(txtIdentificador);
            Controls.Add(lblIdentificador);
            Controls.Add(lblTitulo);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "FormConsultarActivos";
            Text = "FormConsultarActivos";
            Load += FormConsultarActivos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblIdentificador;
        private System.Windows.Forms.TextBox txtIdentificador;
        private System.Windows.Forms.Button btnBuscarPorUsuario;
        private System.Windows.Forms.Label lblIsbn;
        private System.Windows.Forms.TextBox txtIsbn;
        private System.Windows.Forms.Button btnBuscarPorRecurso;
        private System.Windows.Forms.DataGridView dgvPrestamos;
        private System.Windows.Forms.Button btnMostrarTodos;
    }
}