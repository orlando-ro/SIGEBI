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
            lblTitulo = new System.Windows.Forms.Label();
            lblHeaderInfo = new System.Windows.Forms.Label();
            lblNombreUsuario = new System.Windows.Forms.Label();
            lblIdentificador = new System.Windows.Forms.Label();
            lblFechas = new System.Windows.Forms.Label();
            lblRetraso = new System.Windows.Forms.Label();
            lblEjemplaresTitulo = new System.Windows.Forms.Label();
            txtEjemplares = new System.Windows.Forms.TextBox();
            lblSeparador = new System.Windows.Forms.Label();
            lblCondicion = new System.Windows.Forms.Label();
            cmbCondicion = new System.Windows.Forms.ComboBox();
            lblObservaciones = new System.Windows.Forms.Label();
            txtObservaciones = new System.Windows.Forms.TextBox();
            btnProcesar = new System.Windows.Forms.Button();
            btnCerrar = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(20, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Detalles y Devolución";
            // 
            // lblHeaderInfo
            // 
            lblHeaderInfo.AutoSize = true;
            lblHeaderInfo.ForeColor = System.Drawing.Color.FromArgb(13, 110, 253);
            lblHeaderInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblHeaderInfo.Location = new System.Drawing.Point(20, 70);
            lblHeaderInfo.Text = "INFORMACIÓN DEL PRÉSTAMO";
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.ForeColor = System.Drawing.Color.White;
            lblNombreUsuario.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblNombreUsuario.Location = new System.Drawing.Point(20, 100);
            lblNombreUsuario.Text = "[Nombre del Usuario]";
            // 
            // lblIdentificador
            // 
            lblIdentificador.AutoSize = true;
            lblIdentificador.ForeColor = System.Drawing.Color.Gainsboro;
            lblIdentificador.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblIdentificador.Location = new System.Drawing.Point(20, 125);
            lblIdentificador.Text = "[Identificador]";
            // 
            // lblFechas
            // 
            lblFechas.AutoSize = true;
            lblFechas.ForeColor = System.Drawing.Color.Gainsboro;
            lblFechas.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblFechas.Location = new System.Drawing.Point(20, 150);
            lblFechas.Text = "Vigencia: 00/00/0000 al 00/00/0000";
            // 
            // lblRetraso
            // 
            lblRetraso.AutoSize = true;
            lblRetraso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblRetraso.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
            lblRetraso.Location = new System.Drawing.Point(20, 175);
            lblRetraso.Text = "⚠️ PRÉSTAMO VENCIDO";
            lblRetraso.Visible = false;
            // 
            // lblEjemplaresTitulo
            // 
            lblEjemplaresTitulo.AutoSize = true;
            lblEjemplaresTitulo.ForeColor = System.Drawing.Color.FromArgb(13, 110, 253);
            lblEjemplaresTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblEjemplaresTitulo.Location = new System.Drawing.Point(20, 205);
            lblEjemplaresTitulo.Text = "EJEMPLARES FÍSICOS PRESTADOS";
            // 
            // txtEjemplares
            // 
            txtEjemplares.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            txtEjemplares.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtEjemplares.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            txtEjemplares.ForeColor = System.Drawing.Color.White;
            txtEjemplares.Location = new System.Drawing.Point(20, 230);
            txtEjemplares.Multiline = true;
            txtEjemplares.ReadOnly = true;
            txtEjemplares.Size = new System.Drawing.Size(410, 80);
            // 
            // lblSeparador
            // 
            lblSeparador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lblSeparador.Location = new System.Drawing.Point(20, 325);
            lblSeparador.Size = new System.Drawing.Size(410, 2);
            // 
            // lblCondicion
            // 
            lblCondicion.AutoSize = true;
            lblCondicion.ForeColor = System.Drawing.Color.Gainsboro;
            lblCondicion.Location = new System.Drawing.Point(20, 345);
            lblCondicion.Text = "Condición de entrega física:";
            // 
            // cmbCondicion
            // 
            cmbCondicion.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            cmbCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbCondicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbCondicion.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            cmbCondicion.ForeColor = System.Drawing.Color.White;
            cmbCondicion.Location = new System.Drawing.Point(20, 370);
            cmbCondicion.Size = new System.Drawing.Size(410, 31);
            cmbCondicion.SelectedIndexChanged += cmbCondicion_SelectedIndexChanged;
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.ForeColor = System.Drawing.Color.Gainsboro;
            lblObservaciones.Location = new System.Drawing.Point(20, 410);
            lblObservaciones.Text = "Observaciones (Opcional):";
            // 
            // txtObservaciones
            // 
            txtObservaciones.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            txtObservaciones.ForeColor = System.Drawing.Color.White;
            txtObservaciones.Location = new System.Drawing.Point(20, 435);
            txtObservaciones.Multiline = true;
            txtObservaciones.Size = new System.Drawing.Size(410, 80);
            // 
            // btnProcesar
            // 
            btnProcesar.BackColor = System.Drawing.Color.FromArgb(25, 135, 84);
            btnProcesar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnProcesar.FlatAppearance.BorderSize = 0;
            btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnProcesar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnProcesar.ForeColor = System.Drawing.Color.White;
            btnProcesar.Location = new System.Drawing.Point(20, 535);
            btnProcesar.Size = new System.Drawing.Size(260, 45);
            btnProcesar.Text = "✓ Registrar Devolución";
            btnProcesar.Click += btnProcesar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = System.Drawing.Color.FromArgb(70, 75, 90);
            btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnCerrar.ForeColor = System.Drawing.Color.White;
            btnCerrar.Location = new System.Drawing.Point(290, 535);
            btnCerrar.Size = new System.Drawing.Size(140, 45);
            btnCerrar.Text = "Cerrar";
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FormProcesarDevolucion
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            ClientSize = new System.Drawing.Size(450, 610); // Ligeramente más alto para el nuevo subtítulo
            Controls.Add(btnCerrar);
            Controls.Add(btnProcesar);
            Controls.Add(txtObservaciones);
            Controls.Add(lblObservaciones);
            Controls.Add(cmbCondicion);
            Controls.Add(lblCondicion);
            Controls.Add(lblSeparador);
            Controls.Add(txtEjemplares);
            Controls.Add(lblEjemplaresTitulo);
            Controls.Add(lblRetraso);
            Controls.Add(lblFechas);
            Controls.Add(lblIdentificador);
            Controls.Add(lblNombreUsuario);
            Controls.Add(lblHeaderInfo);
            Controls.Add(lblTitulo);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Name = "FormProcesarDevolucion";
            Text = "Gestión de Préstamo";
            Load += FormProcesarDevolucion_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblHeaderInfo;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Label lblIdentificador;
        private System.Windows.Forms.Label lblFechas;
        private System.Windows.Forms.Label lblRetraso;
        private System.Windows.Forms.Label lblEjemplaresTitulo;
        private System.Windows.Forms.TextBox txtEjemplares;
        private System.Windows.Forms.Label lblSeparador;
        private System.Windows.Forms.Label lblCondicion;
        private System.Windows.Forms.ComboBox cmbCondicion;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Button btnCerrar;
    }
}