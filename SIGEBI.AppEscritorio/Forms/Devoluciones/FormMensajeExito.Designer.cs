namespace SIGEBI.AppEscritorio.Forms.Devoluciones
{
    partial class FormMensajeExito
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
            lblMensaje = new Label();
            btnAceptar = new Button();
            lblIcono = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(183, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Operación Exitosa";
            // 
            // lblMensaje
            // 
            lblMensaje.Font = new Font("Segoe UI", 10.5F);
            lblMensaje.ForeColor = Color.Gainsboro;
            lblMensaje.Location = new Point(100, 65);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(280, 60);
            lblMensaje.TabIndex = 1;
            lblMensaje.Text = "¡Datos exportados exitosamente! Puede abrir el archivo en Excel.";
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.FromArgb(25, 135, 84);
            btnAceptar.Cursor = Cursors.Hand;
            btnAceptar.FlatAppearance.BorderSize = 0;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAceptar.ForeColor = Color.White;
            btnAceptar.Location = new Point(260, 140);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(120, 40);
            btnAceptar.TabIndex = 2;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblIcono
            // 
            lblIcono.AutoSize = true;
            lblIcono.Font = new Font("Segoe UI", 28F);
            lblIcono.ForeColor = Color.FromArgb(25, 135, 84);
            lblIcono.Location = new Point(20, 60);
            lblIcono.Name = "lblIcono";
            lblIcono.Size = new Size(62, 62);
            lblIcono.TabIndex = 3;
            lblIcono.Text = "✓";
            // 
            // FormMensajeExito
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 44, 60);
            ClientSize = new Size(400, 200);
            Controls.Add(lblIcono);
            Controls.Add(btnAceptar);
            Controls.Add(lblMensaje);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMensajeExito";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Notificación";
            Load += FormMensajeExito_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblIcono;
    }
}