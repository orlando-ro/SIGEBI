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
            lblBienvenida = new System.Windows.Forms.Label();
            lblSubtitulo = new System.Windows.Forms.Label();
            lblHora = new System.Windows.Forms.Label();
            lblFecha = new System.Windows.Forms.Label();
            timerReloj = new System.Windows.Forms.Timer(components);
            flpModulos = new System.Windows.Forms.FlowLayoutPanel();
            picIlustracion = new System.Windows.Forms.PictureBox();
            flpModulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIlustracion).BeginInit();
            SuspendLayout();

            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            lblBienvenida.ForeColor = System.Drawing.Color.White;
            lblBienvenida.Location = new System.Drawing.Point(40, 30);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new System.Drawing.Size(657, 60);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "¡Bienvenido al Sistema SIGEBI!";

            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            lblSubtitulo.ForeColor = System.Drawing.Color.Gainsboro;
            lblSubtitulo.Location = new System.Drawing.Point(48, 95);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new System.Drawing.Size(426, 28);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Resumen de módulos disponibles para su perfil.";

            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Font = new System.Drawing.Font("Segoe UI Light", 44F);
            lblHora.ForeColor = System.Drawing.Color.FromArgb(13, 110, 253);
            lblHora.Location = new System.Drawing.Point(35, 140);
            lblHora.Name = "lblHora";
            lblHora.Size = new System.Drawing.Size(302, 99);
            lblHora.TabIndex = 2;
            lblHora.Text = "00:00:00";

            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblFecha.ForeColor = System.Drawing.Color.FromArgb(100, 110, 140);
            lblFecha.Location = new System.Drawing.Point(50, 240);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new System.Drawing.Size(74, 28);
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
            
            flpModulos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flpModulos.AutoScroll = true;
            flpModulos.BackColor = System.Drawing.Color.Transparent;
            flpModulos.Controls.Add(picIlustracion);
            flpModulos.Location = new System.Drawing.Point(40, 310);
            flpModulos.Name = "flpModulos";
            flpModulos.Size = new System.Drawing.Size(770, 260);
            flpModulos.TabIndex = 5;
            flpModulos.Paint += flpModulos_Paint;

            // 
            // picIlustracion
            // 
            picIlustracion.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            picIlustracion.BackColor = System.Drawing.Color.Transparent;
            picIlustracion.Location = new System.Drawing.Point(3, 3);
            picIlustracion.Name = "picIlustracion";
            picIlustracion.Size = new System.Drawing.Size(400, 310);
            picIlustracion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picIlustracion.TabIndex = 4;
            picIlustracion.TabStop = false;

            // 
            // FormDashboard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            ClientSize = new System.Drawing.Size(850, 590);
            Controls.Add(flpModulos);
            Controls.Add(lblFecha);
            Controls.Add(lblHora);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblBienvenida);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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