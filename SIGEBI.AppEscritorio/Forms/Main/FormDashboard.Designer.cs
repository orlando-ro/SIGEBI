namespace SIGEBI.AppEscritorio.Forms.Main
{
    partial class FormDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblBienvenida = new Label();
            lblSubtitulo = new Label();
            SuspendLayout();
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.White;
            lblBienvenida.Location = new Point(50, 50);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(544, 54);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "¡Bienvenido al Sistema SIGEBI!";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 12F);
            lblSubtitulo.ForeColor = Color.Gainsboro;
            lblSubtitulo.Location = new Point(55, 120);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(491, 28);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Seleccione una opción del menú lateral para comenzar.";
            // 
            // FormDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 45);
            ClientSize = new Size(850, 590);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblBienvenida);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormDashboard";
            Text = "FormDashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblSubtitulo;
    }
}