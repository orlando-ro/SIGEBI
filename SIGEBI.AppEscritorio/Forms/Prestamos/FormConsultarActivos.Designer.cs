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
            lblTitulo = new Label();
            lblIdentificador = new Label();
            txtIdentificador = new TextBox();
            btnBuscarPorUsuario = new Button();
            lblIsbn = new Label();
            txtIsbn = new TextBox();
            btnBuscarPorRecurso = new Button();
            dgvPrestamos = new DataGridView();
            btnMostrarTodos = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(25, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(366, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Consulta de Préstamos Activos";
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
            // btnBuscarPorUsuario
            // 
            btnBuscarPorUsuario.BackColor = Color.FromArgb(13, 110, 253);
            btnBuscarPorUsuario.Cursor = Cursors.Hand;
            btnBuscarPorUsuario.FlatAppearance.BorderSize = 0;
            btnBuscarPorUsuario.FlatStyle = FlatStyle.Flat;
            btnBuscarPorUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuscarPorUsuario.ForeColor = Color.White;
            btnBuscarPorUsuario.Location = new Point(235, 99);
            btnBuscarPorUsuario.Name = "btnBuscarPorUsuario";
            btnBuscarPorUsuario.Size = new Size(120, 31);
            btnBuscarPorUsuario.TabIndex = 3;
            btnBuscarPorUsuario.Text = "🔍 Buscar";
            btnBuscarPorUsuario.UseVisualStyleBackColor = false;
            btnBuscarPorUsuario.Click += btnBuscarPorUsuario_Click;
            // 
            // lblIsbn
            // 
            lblIsbn.AutoSize = true;
            lblIsbn.ForeColor = Color.Gainsboro;
            lblIsbn.Location = new Point(385, 75);
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
            txtIsbn.Location = new Point(385, 100);
            txtIsbn.Name = "txtIsbn";
            txtIsbn.Size = new Size(200, 31);
            txtIsbn.TabIndex = 5;
            // 
            // btnBuscarPorRecurso
            // 
            btnBuscarPorRecurso.BackColor = Color.FromArgb(13, 110, 253);
            btnBuscarPorRecurso.Cursor = Cursors.Hand;
            btnBuscarPorRecurso.FlatAppearance.BorderSize = 0;
            btnBuscarPorRecurso.FlatStyle = FlatStyle.Flat;
            btnBuscarPorRecurso.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuscarPorRecurso.ForeColor = Color.White;
            btnBuscarPorRecurso.Location = new Point(595, 99);
            btnBuscarPorRecurso.Name = "btnBuscarPorRecurso";
            btnBuscarPorRecurso.Size = new Size(120, 31);
            btnBuscarPorRecurso.TabIndex = 6;
            btnBuscarPorRecurso.Text = "🔍 Buscar ISBN";
            btnBuscarPorRecurso.UseVisualStyleBackColor = false;
            btnBuscarPorRecurso.Click += btnBuscarPorRecurso_Click;
            // 
            // dgvPrestamos
            // 
            dgvPrestamos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPrestamos.Location = new Point(25, 155);
            dgvPrestamos.Name = "dgvPrestamos";
            dgvPrestamos.Size = new Size(800, 400);
            dgvPrestamos.TabIndex = 7;
            dgvPrestamos.CellContentClick += dgvPrestamos_CellContentClick;
            // 
            // btnMostrarTodos
            // 
            btnMostrarTodos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMostrarTodos.BackColor = Color.FromArgb(40, 44, 60);
            btnMostrarTodos.Cursor = Cursors.Hand;
            btnMostrarTodos.FlatAppearance.BorderSize = 0;
            btnMostrarTodos.FlatStyle = FlatStyle.Flat;
            btnMostrarTodos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMostrarTodos.ForeColor = Color.White;
            btnMostrarTodos.Location = new Point(695, 20);
            btnMostrarTodos.Name = "btnMostrarTodos";
            btnMostrarTodos.Size = new Size(130, 31);
            btnMostrarTodos.TabIndex = 8;
            btnMostrarTodos.Text = "🔄 Recargar";
            btnMostrarTodos.UseVisualStyleBackColor = false;
            btnMostrarTodos.Click += btnMostrarTodos_Click;
            // 
            // FormConsultarActivos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 45);
            ClientSize = new Size(850, 590);
            Controls.Add(btnMostrarTodos);
            Controls.Add(dgvPrestamos);
            Controls.Add(btnBuscarPorRecurso);
            Controls.Add(txtIsbn);
            Controls.Add(lblIsbn);
            Controls.Add(btnBuscarPorUsuario);
            Controls.Add(txtIdentificador);
            Controls.Add(lblIdentificador);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
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