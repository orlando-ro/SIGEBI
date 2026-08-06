namespace SIGEBI.AppEscritorio.Forms.Prestamos
{
    partial class FormDetallePrestamo
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
            lblTituloFormulario = new Label();
            lblSeccionDatos = new Label();
            lblNombre = new Label();
            lblIdentificador = new Label();
            lblRetraso = new Label();
            lblSeccionLibros = new Label();
            lstLibros = new ListBox();
            btnCerrar = new Button();
            SuspendLayout();

            // 
            // lblTituloFormulario
            // 
            lblTituloFormulario.AutoSize = true;
            lblTituloFormulario.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTituloFormulario.ForeColor = Color.White;
            lblTituloFormulario.Location = new Point(20, 20);
            lblTituloFormulario.Name = "lblTituloFormulario";
            lblTituloFormulario.Size = new Size(251, 32);
            lblTituloFormulario.TabIndex = 0;
            lblTituloFormulario.Text = "Detalle del Préstamo";

            // 
            // lblSeccionDatos
            // 
            lblSeccionDatos.AutoSize = true;
            lblSeccionDatos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSeccionDatos.ForeColor = Color.FromArgb(13, 110, 253);
            lblSeccionDatos.Location = new Point(20, 68);
            lblSeccionDatos.Name = "lblSeccionDatos";
            lblSeccionDatos.Size = new Size(182, 23);
            lblSeccionDatos.TabIndex = 1;
            lblSeccionDatos.Text = "DATOS DEL USUARIO";

            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblNombre.ForeColor = Color.White;
            lblNombre.Location = new Point(20, 96);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(86, 25);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre:";

            // 
            // lblIdentificador
            // 
            lblIdentificador.AutoSize = true;
            lblIdentificador.Font = new Font("Segoe UI", 10F);
            lblIdentificador.ForeColor = Color.Gainsboro;
            lblIdentificador.Location = new Point(20, 124);
            lblIdentificador.Name = "lblIdentificador";
            lblIdentificador.Size = new Size(126, 23);
            lblIdentificador.TabIndex = 3;
            lblIdentificador.Text = "Matrícula/Emp:";

            // 
            // lblRetraso
            // 
            lblRetraso.AutoSize = true;
            lblRetraso.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblRetraso.ForeColor = Color.Tomato;
            lblRetraso.Location = new Point(20, 152);
            lblRetraso.Name = "lblRetraso";
            lblRetraso.Size = new Size(82, 25);
            lblRetraso.TabIndex = 4;
            lblRetraso.Text = "Retraso:";

            // 
            // lblSeccionLibros
            // 
            lblSeccionLibros.AutoSize = true;
            lblSeccionLibros.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSeccionLibros.ForeColor = Color.FromArgb(13, 110, 253);
            lblSeccionLibros.Location = new Point(20, 195);
            lblSeccionLibros.Name = "lblSeccionLibros";
            lblSeccionLibros.Size = new Size(171, 23);
            lblSeccionLibros.TabIndex = 5;
            lblSeccionLibros.Text = "LIBROS PRESTADOS";

            // 
            // lstLibros
            // 
            lstLibros.BackColor = Color.FromArgb(40, 40, 60);
            lstLibros.BorderStyle = BorderStyle.FixedSingle;
            lstLibros.Font = new Font("Segoe UI", 10F);
            lstLibros.ForeColor = Color.White;
            lstLibros.FormattingEnabled = true;
            lstLibros.ItemHeight = 23;
            lstLibros.Location = new Point(20, 223);
            lstLibros.Name = "lstLibros";
            lstLibros.SelectionMode = SelectionMode.None;
            lstLibros.Size = new Size(340, 117);
            lstLibros.TabIndex = 6;

            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(60, 60, 75);
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(260, 360);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(100, 35);
            btnCerrar.TabIndex = 7;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;

            // 
            // FormDetallePrestamo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 45);
            ClientSize = new Size(400, 420);
            Controls.Add(btnCerrar);
            Controls.Add(lstLibros);
            Controls.Add(lblSeccionLibros);
            Controls.Add(lblRetraso);
            Controls.Add(lblIdentificador);
            Controls.Add(lblNombre);
            Controls.Add(lblSeccionDatos);
            Controls.Add(lblTituloFormulario);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormDetallePrestamo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalles del Préstamo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTituloFormulario;
        private System.Windows.Forms.Label lblSeccionDatos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblIdentificador;
        private System.Windows.Forms.Label lblRetraso;
        private System.Windows.Forms.Label lblSeccionLibros;
        private System.Windows.Forms.ListBox lstLibros;
        private System.Windows.Forms.Button btnCerrar;
    }
}