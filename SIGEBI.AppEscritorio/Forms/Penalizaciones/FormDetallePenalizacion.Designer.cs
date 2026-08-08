namespace SIGEBI.AppEscritorio.Forms.Penalizaciones
{
    partial class FormDetallePenalizacion
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
            lblEstado = new System.Windows.Forms.Label();
            lblMontoTitulo = new System.Windows.Forms.Label();
            lblMonto = new System.Windows.Forms.Label();
            lblFecha = new System.Windows.Forms.Label();
            lblSeparador = new System.Windows.Forms.Label();
            lblMotivo = new System.Windows.Forms.Label();
            txtMotivo = new System.Windows.Forms.TextBox();
            lblResolucion = new System.Windows.Forms.Label();
            txtResolucion = new System.Windows.Forms.TextBox();
            btnProcesarPago = new System.Windows.Forms.Button();
            btnCerrar = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(20, 20);
            lblTitulo.Text = "Detalle de Penalización";
            // 
            // lblHeaderInfo
            // 
            lblHeaderInfo.AutoSize = true;
            lblHeaderInfo.ForeColor = System.Drawing.Color.FromArgb(13, 110, 253);
            lblHeaderInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblHeaderInfo.Location = new System.Drawing.Point(20, 70);
            lblHeaderInfo.Text = "INFORMACIÓN DEL USUARIO";
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
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblEstado.Location = new System.Drawing.Point(20, 160);
            lblEstado.Text = "ESTADO: ...";
            // 
            // lblSeparador
            // 
            lblSeparador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lblSeparador.Location = new System.Drawing.Point(20, 190);
            lblSeparador.Size = new System.Drawing.Size(410, 2);
            // 
            // lblMontoTitulo
            // 
            lblMontoTitulo.AutoSize = true;
            lblMontoTitulo.ForeColor = System.Drawing.Color.Gainsboro;
            lblMontoTitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblMontoTitulo.Location = new System.Drawing.Point(20, 210);
            lblMontoTitulo.Text = "Monto a Pagar:";
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblMonto.Location = new System.Drawing.Point(20, 230);
            lblMonto.Text = "RD$ 0.00";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.ForeColor = System.Drawing.Color.Gainsboro;
            lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblFecha.Location = new System.Drawing.Point(20, 265);
            lblFecha.Text = "Emitida el: 00/00/0000";
            // 
            // lblMotivo
            // 
            lblMotivo.AutoSize = true;
            lblMotivo.ForeColor = System.Drawing.Color.Gainsboro;
            lblMotivo.Location = new System.Drawing.Point(20, 295);
            lblMotivo.Text = "Motivo de Penalización:";
            // 
            // txtMotivo
            // 
            txtMotivo.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            txtMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMotivo.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            txtMotivo.ForeColor = System.Drawing.Color.White;
            txtMotivo.Location = new System.Drawing.Point(20, 320);
            txtMotivo.Multiline = true;
            txtMotivo.ReadOnly = true;
            txtMotivo.Size = new System.Drawing.Size(410, 60);
            // 
            // lblResolucion
            // 
            lblResolucion.AutoSize = true;
            lblResolucion.ForeColor = System.Drawing.Color.Gainsboro;
            lblResolucion.Location = new System.Drawing.Point(20, 390);
            lblResolucion.Text = "Motivo de Resolución:";
            // 
            // txtResolucion
            // 
            txtResolucion.BackColor = System.Drawing.Color.FromArgb(40, 40, 60);
            txtResolucion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtResolucion.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            txtResolucion.ForeColor = System.Drawing.Color.White;
            txtResolucion.Location = new System.Drawing.Point(20, 415);
            txtResolucion.Multiline = true;
            txtResolucion.Size = new System.Drawing.Size(410, 60);
            // 
            // btnProcesarPago
            // 
            btnProcesarPago.BackColor = System.Drawing.Color.FromArgb(25, 135, 84);
            btnProcesarPago.Cursor = System.Windows.Forms.Cursors.Hand;
            btnProcesarPago.FlatAppearance.BorderSize = 0;
            btnProcesarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnProcesarPago.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnProcesarPago.ForeColor = System.Drawing.Color.White;
            btnProcesarPago.Location = new System.Drawing.Point(20, 500);
            btnProcesarPago.Size = new System.Drawing.Size(260, 45);
            btnProcesarPago.Text = "💲 Procesar Pago";
            btnProcesarPago.Click += btnProcesarPago_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = System.Drawing.Color.FromArgb(70, 75, 90);
            btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnCerrar.ForeColor = System.Drawing.Color.White;
            btnCerrar.Location = new System.Drawing.Point(290, 500);
            btnCerrar.Size = new System.Drawing.Size(140, 45);
            btnCerrar.Text = "Cerrar";
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FormDetallePenalizacion
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            ClientSize = new System.Drawing.Size(450, 570);
            Controls.Add(btnCerrar);
            Controls.Add(btnProcesarPago);
            Controls.Add(txtResolucion);
            Controls.Add(lblResolucion);
            Controls.Add(txtMotivo);
            Controls.Add(lblMotivo);
            Controls.Add(lblFecha);
            Controls.Add(lblMonto);
            Controls.Add(lblMontoTitulo);
            Controls.Add(lblSeparador);
            Controls.Add(lblEstado);
            Controls.Add(lblIdentificador);
            Controls.Add(lblNombreUsuario);
            Controls.Add(lblHeaderInfo);
            Controls.Add(lblTitulo);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Detalle de Penalización";
            Load += FormDetallePenalizacion_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblHeaderInfo;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Label lblIdentificador;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblMontoTitulo;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblSeparador;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label lblResolucion;
        private System.Windows.Forms.TextBox txtResolucion;
        private System.Windows.Forms.Button btnProcesarPago;
        private System.Windows.Forms.Button btnCerrar;
    }
}