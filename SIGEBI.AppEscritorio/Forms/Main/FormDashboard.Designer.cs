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
            components = new System.ComponentModel.Container();
            lblBienvenida = new Label();
            lblSubtitulo = new Label();
            lblHora = new Label();
            lblFecha = new Label();
            timerReloj = new System.Windows.Forms.Timer(components);
            flpModulos = new FlowLayoutPanel();
            picIlustracion = new PictureBox();
            flpModulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIlustracion).BeginInit();
            SuspendLayout();
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.White;
            lblBienvenida.Location = new Point(40, 30);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(657, 60);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "¡Bienvenido al Sistema SIGEBI!";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 11.5F);
            lblSubtitulo.ForeColor = Color.Gainsboro;
            lblSubtitulo.Location = new Point(48, 95);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(426, 28);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Resumen de módulos disponibles para su perfil.";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Segoe UI Light", 44F);
            lblHora.ForeColor = Color.FromArgb(13, 110, 253);
            lblHora.Location = new Point(35, 140);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(302, 99);
            lblHora.TabIndex = 2;
            lblHora.Text = "00:00:00";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFecha.ForeColor = Color.FromArgb(100, 110, 140);
            lblFecha.Location = new Point(50, 240);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(74, 28);
            lblFecha.TabIndex = 3;
            lblFecha.Text = "FECHA";
            // 
            // timerReloj
            // 
            timerReloj.Interval = 1000;
            timerReloj.Tick += timerReloj_Tick;
            // 
            // flpModulos
            // 
            flpModulos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flpModulos.AutoScroll = true;
            flpModulos.BackColor = Color.Transparent;
            flpModulos.Controls.Add(picIlustracion);
            flpModulos.Location = new Point(40, 310);
            flpModulos.Name = "flpModulos";
            flpModulos.Size = new Size(770, 150);
            flpModulos.TabIndex = 5;
            // 
            // picIlustracion
            // 
            picIlustracion.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            picIlustracion.BackColor = Color.Transparent;
            picIlustracion.Location = new Point(3, 3);
            picIlustracion.Name = "picIlustracion";
            picIlustracion.Size = new Size(400, 310);
            picIlustracion.SizeMode = PictureBoxSizeMode.Zoom;
            picIlustracion.TabIndex = 4;
            picIlustracion.TabStop = false;
            // 
            // FormDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 45);
            ClientSize = new Size(850, 590);
            Controls.Add(flpModulos);
            Controls.Add(lblFecha);
            Controls.Add(lblHora);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblBienvenida);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormDashboard";
            Text = "FormDashboard";
            Load += FormDashboard_Load;
            flpModulos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picIlustracion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Timer timerReloj;
        private System.Windows.Forms.FlowLayoutPanel flpModulos;
        private System.Windows.Forms.PictureBox picIlustracion;
    }
}