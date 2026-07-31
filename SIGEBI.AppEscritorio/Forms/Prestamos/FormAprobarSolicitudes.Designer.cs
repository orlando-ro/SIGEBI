namespace SIGEBI.AppEscritorio.Forms.Prestamos
{
    partial class FormAprobarSolicitudes
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
            lblIdSolicitud = new Label();
            txtIdSolicitud = new TextBox();
            btnAprobar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(30, 30);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(366, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Aprobar Solicitud de Préstamo";
            // 
            // lblIdSolicitud
            // 
            lblIdSolicitud.AutoSize = true;
            lblIdSolicitud.Font = new Font("Segoe UI", 10F);
            lblIdSolicitud.ForeColor = Color.Gainsboro;
            lblIdSolicitud.Location = new Point(30, 100);
            lblIdSolicitud.Name = "lblIdSolicitud";
            lblIdSolicitud.Size = new Size(125, 23);
            lblIdSolicitud.TabIndex = 1;
            lblIdSolicitud.Text = "ID de Solicitud:";
            // 
            // txtIdSolicitud
            // 
            txtIdSolicitud.BackColor = Color.FromArgb(40, 40, 60);
            txtIdSolicitud.BorderStyle = BorderStyle.FixedSingle;
            txtIdSolicitud.Font = new Font("Segoe UI", 11F);
            txtIdSolicitud.ForeColor = Color.White;
            txtIdSolicitud.Location = new Point(30, 130);
            txtIdSolicitud.Name = "txtIdSolicitud";
            txtIdSolicitud.Size = new Size(300, 32);
            txtIdSolicitud.TabIndex = 2;
            // 
            // btnAprobar
            // 
            btnAprobar.BackColor = Color.FromArgb(13, 110, 253);
            btnAprobar.Cursor = Cursors.Hand;
            btnAprobar.FlatAppearance.BorderSize = 0;
            btnAprobar.FlatStyle = FlatStyle.Flat;
            btnAprobar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAprobar.ForeColor = Color.White;
            btnAprobar.Location = new Point(30, 190);
            btnAprobar.Name = "btnAprobar";
            btnAprobar.Size = new Size(300, 45);
            btnAprobar.TabIndex = 3;
            btnAprobar.Text = "✓ Aprobar y Crear Préstamo";
            btnAprobar.UseVisualStyleBackColor = false;
            btnAprobar.Click += btnAprobar_Click;
            // 
            // FormAprobarSolicitudes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 45);
            ClientSize = new Size(850, 590);
            Controls.Add(btnAprobar);
            Controls.Add(txtIdSolicitud);
            Controls.Add(lblIdSolicitud);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormAprobarSolicitudes";
            Text = "FormAprobarSolicitudes";
            Load += FormAprobarSolicitudes_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblIdSolicitud;
        private System.Windows.Forms.TextBox txtIdSolicitud;
        private System.Windows.Forms.Button btnAprobar;
    }
}