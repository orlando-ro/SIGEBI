namespace SIGEBI.AppEscritorio.Forms.Devoluciones
{
    partial class FormProcesarDevolucion
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
            lblIdPrestamo = new Label();
            txtIdPrestamo = new TextBox();
            lblCondicion = new Label();
            cmbCondicion = new ComboBox();
            lblObservaciones = new Label();
            txtObservaciones = new TextBox();
            btnProcesar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(30, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(244, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Procesar Devolución";
            // 
            // lblIdPrestamo
            // 
            lblIdPrestamo.AutoSize = true;
            lblIdPrestamo.ForeColor = Color.Gainsboro;
            lblIdPrestamo.Location = new Point(30, 90);
            lblIdPrestamo.Name = "lblIdPrestamo";
            lblIdPrestamo.Size = new Size(111, 20);
            lblIdPrestamo.TabIndex = 1;
            lblIdPrestamo.Text = "ID de Préstamo:";
            // 
            // txtIdPrestamo
            // 
            txtIdPrestamo.BackColor = Color.FromArgb(40, 40, 60);
            txtIdPrestamo.BorderStyle = BorderStyle.FixedSingle;
            txtIdPrestamo.Font = new Font("Segoe UI", 10.5F);
            txtIdPrestamo.ForeColor = Color.White;
            txtIdPrestamo.Location = new Point(30, 115);
            txtIdPrestamo.Name = "txtIdPrestamo";
            txtIdPrestamo.Size = new Size(300, 31);
            txtIdPrestamo.TabIndex = 2;
            // 
            // lblCondicion
            // 
            lblCondicion.AutoSize = true;
            lblCondicion.ForeColor = Color.Gainsboro;
            lblCondicion.Location = new Point(30, 160);
            lblCondicion.Name = "lblCondicion";
            lblCondicion.Size = new Size(141, 20);
            lblCondicion.TabIndex = 3;
            lblCondicion.Text = "Condición del Libro:";
            // 
            // cmbCondicion
            // 
            cmbCondicion.BackColor = Color.FromArgb(40, 40, 60);
            cmbCondicion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCondicion.FlatStyle = FlatStyle.Flat;
            cmbCondicion.Font = new Font("Segoe UI", 10.5F);
            cmbCondicion.ForeColor = Color.White;
            cmbCondicion.Location = new Point(30, 185);
            cmbCondicion.Name = "cmbCondicion";
            cmbCondicion.Size = new Size(300, 31);
            cmbCondicion.TabIndex = 4;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.ForeColor = Color.Gainsboro;
            lblObservaciones.Location = new Point(30, 230);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(108, 20);
            lblObservaciones.TabIndex = 5;
            lblObservaciones.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            txtObservaciones.BackColor = Color.FromArgb(40, 40, 60);
            txtObservaciones.BorderStyle = BorderStyle.FixedSingle;
            txtObservaciones.Font = new Font("Segoe UI", 10.5F);
            txtObservaciones.ForeColor = Color.White;
            txtObservaciones.Location = new Point(30, 255);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(300, 80);
            txtObservaciones.TabIndex = 6;
            // 
            // btnProcesar
            // 
            btnProcesar.BackColor = Color.FromArgb(13, 110, 253);
            btnProcesar.Cursor = Cursors.Hand;
            btnProcesar.FlatAppearance.BorderSize = 0;
            btnProcesar.FlatStyle = FlatStyle.Flat;
            btnProcesar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProcesar.ForeColor = Color.White;
            btnProcesar.Location = new Point(30, 360);
            btnProcesar.Name = "btnProcesar";
            btnProcesar.Size = new Size(300, 45);
            btnProcesar.TabIndex = 7;
            btnProcesar.Text = "✓ Procesar Devolución";
            btnProcesar.UseVisualStyleBackColor = false;
            btnProcesar.Click += btnProcesar_Click;
            // 
            // FormProcesarDevolucion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 45);
            ClientSize = new Size(850, 590);
            Controls.Add(btnProcesar);
            Controls.Add(txtObservaciones);
            Controls.Add(lblObservaciones);
            Controls.Add(cmbCondicion);
            Controls.Add(lblCondicion);
            Controls.Add(txtIdPrestamo);
            Controls.Add(lblIdPrestamo);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormProcesarDevolucion";
            Text = "FormProcesarDevolucion";
            Load += FormProcesarDevolucion_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblIdPrestamo;
        private System.Windows.Forms.TextBox txtIdPrestamo;
        private System.Windows.Forms.Label lblCondicion;
        private System.Windows.Forms.ComboBox cmbCondicion;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button btnProcesar;
    }
}