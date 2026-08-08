namespace SIGEBI.AppEscritorio.Forms.Devoluciones
{
    partial class FormDetalleTransaccion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblHeaderInfo = new Label();
            lblNombreUsuario = new Label();
            lblFecha = new Label();
            lblCondicion = new Label();
            lblRetraso = new Label();
            lblLibrosTitulo = new Label();
            txtLibros = new TextBox();
            lblObservacionesTitulo = new Label();
            txtObservaciones = new TextBox();
            btnCerrar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(298, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Detalle de la Transacción";
            // 
            // lblHeaderInfo
            // 
            lblHeaderInfo.AutoSize = true;
            lblHeaderInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHeaderInfo.ForeColor = Color.FromArgb(13, 110, 253);
            lblHeaderInfo.Location = new Point(20, 70);
            lblHeaderInfo.Name = "lblHeaderInfo";
            lblHeaderInfo.Size = new Size(197, 23);
            lblHeaderInfo.TabIndex = 1;
            lblHeaderInfo.Text = "DATOS DEL PRÉSTAMO";
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNombreUsuario.ForeColor = Color.White;
            lblNombreUsuario.Location = new Point(20, 100);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(206, 25);
            lblNombreUsuario.TabIndex = 2;
            lblNombreUsuario.Text = "[Nombre del Usuario]";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 10F);
            lblFecha.ForeColor = Color.Gainsboro;
            lblFecha.Location = new Point(20, 130);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(194, 23);
            lblFecha.TabIndex = 3;
            lblFecha.Text = "Fecha: 00/00/0000 00:00";
            // 
            // lblCondicion
            // 
            lblCondicion.AutoSize = true;
            lblCondicion.Font = new Font("Segoe UI", 10F);
            lblCondicion.ForeColor = Color.Gainsboro;
            lblCondicion.Location = new Point(20, 160);
            lblCondicion.Name = "lblCondicion";
            lblCondicion.Size = new Size(186, 23);
            lblCondicion.TabIndex = 4;
            lblCondicion.Text = "Condición: BuenEstado";
            // 
            // lblRetraso
            // 
            lblRetraso.AutoSize = true;
            lblRetraso.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRetraso.ForeColor = Color.Gainsboro;
            lblRetraso.Location = new Point(20, 190);
            lblRetraso.Name = "lblRetraso";
            lblRetraso.Size = new Size(127, 23);
            lblRetraso.TabIndex = 5;
            lblRetraso.Text = "Retraso: 0 días";
            // 
            // lblLibrosTitulo
            // 
            lblLibrosTitulo.AutoSize = true;
            lblLibrosTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLibrosTitulo.ForeColor = Color.FromArgb(13, 110, 253);
            lblLibrosTitulo.Location = new Point(20, 230);
            lblLibrosTitulo.Name = "lblLibrosTitulo";
            lblLibrosTitulo.Size = new Size(186, 23);
            lblLibrosTitulo.TabIndex = 6;
            lblLibrosTitulo.Text = "LIBROS ENTREGADOS";
            // 
            // txtLibros
            // 
            txtLibros.BackColor = Color.FromArgb(40, 40, 60);
            txtLibros.BorderStyle = BorderStyle.FixedSingle;
            txtLibros.Font = new Font("Segoe UI", 10.5F);
            txtLibros.ForeColor = Color.White;
            txtLibros.Location = new Point(20, 260);
            txtLibros.Multiline = true;
            txtLibros.Name = "txtLibros";
            txtLibros.ReadOnly = true;
            txtLibros.Size = new Size(340, 80);
            txtLibros.TabIndex = 7;
            // 
            // lblObservacionesTitulo
            // 
            lblObservacionesTitulo.AutoSize = true;
            lblObservacionesTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblObservacionesTitulo.ForeColor = Color.FromArgb(13, 110, 253);
            lblObservacionesTitulo.Location = new Point(20, 355);
            lblObservacionesTitulo.Name = "lblObservacionesTitulo";
            lblObservacionesTitulo.Size = new Size(147, 23);
            lblObservacionesTitulo.TabIndex = 8;
            lblObservacionesTitulo.Text = "OBSERVACIONES";
            // 
            // txtObservaciones
            // 
            txtObservaciones.BackColor = Color.FromArgb(40, 40, 60);
            txtObservaciones.BorderStyle = BorderStyle.FixedSingle;
            txtObservaciones.Font = new Font("Segoe UI", 10.5F);
            txtObservaciones.ForeColor = Color.White;
            txtObservaciones.Location = new Point(20, 385);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.ReadOnly = true;
            txtObservaciones.Size = new Size(340, 70);
            txtObservaciones.TabIndex = 9;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(70, 75, 90);
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(220, 475);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(140, 40);
            btnCerrar.TabIndex = 10;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FormDetalleTransaccion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 45);
            ClientSize = new Size(380, 535);
            Controls.Add(btnCerrar);
            Controls.Add(txtObservaciones);
            Controls.Add(lblObservacionesTitulo);
            Controls.Add(txtLibros);
            Controls.Add(lblLibrosTitulo);
            Controls.Add(lblRetraso);
            Controls.Add(lblCondicion);
            Controls.Add(lblFecha);
            Controls.Add(lblNombreUsuario);
            Controls.Add(lblHeaderInfo);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormDetalleTransaccion";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalles de la Transacción";
            Load += FormDetalleTransaccion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblHeaderInfo;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblCondicion;
        private System.Windows.Forms.Label lblRetraso;
        private System.Windows.Forms.Label lblLibrosTitulo;
        private System.Windows.Forms.TextBox txtLibros;
        private System.Windows.Forms.Label lblObservacionesTitulo;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button btnCerrar;
    }
}