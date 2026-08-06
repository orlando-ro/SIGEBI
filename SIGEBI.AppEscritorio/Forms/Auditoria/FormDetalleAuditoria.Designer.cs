using System.Drawing;
using System.Windows.Forms;

namespace SIGEBI.AppEscritorio.Forms.Auditoria
{
    partial class FormDetalleAuditoria
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
            panelHeader = new Panel();
            lblTituloModal = new Label();
            lblFechaTitulo = new Label();
            lblFechaVal = new Label();
            lblAccionTitulo = new Label();
            lblAccionVal = new Label();
            lblModuloTitulo = new Label();
            lblModuloVal = new Label();
            lblDescTitulo = new Label();
            txtDetalles = new TextBox();
            btnCerrar = new Button();
            panelHeader.SuspendLayout();
            SuspendLayout();

            // panelHeader
            panelHeader.BackColor = Color.FromArgb(13, 110, 253);
            panelHeader.Controls.Add(lblTituloModal);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Size = new Size(550, 50);

            // lblTituloModal
            lblTituloModal.AutoSize = true;
            lblTituloModal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTituloModal.ForeColor = Color.White;
            lblTituloModal.Location = new Point(15, 10);
            lblTituloModal.Text = "🔍 Detalle del Registro de Auditoría";

            // lblFechaTitulo
            lblFechaTitulo.AutoSize = true;
            lblFechaTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFechaTitulo.ForeColor = Color.FromArgb(13, 110, 253);
            lblFechaTitulo.Location = new Point(25, 70);
            lblFechaTitulo.Text = "📅 FECHA Y HORA:";

            // lblFechaVal
            lblFechaVal.AutoSize = true;
            lblFechaVal.Font = new Font("Segoe UI", 10F);
            lblFechaVal.ForeColor = Color.White;
            lblFechaVal.Location = new Point(25, 95);
            lblFechaVal.Text = "00/00/0000 00:00:00";

            // lblAccionTitulo
            lblAccionTitulo.AutoSize = true;
            lblAccionTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAccionTitulo.ForeColor = Color.FromArgb(13, 110, 253);
            lblAccionTitulo.Location = new Point(25, 135);
            lblAccionTitulo.Text = "⚡ ACCIÓN REALIZADA:";

            // lblAccionVal
            lblAccionVal.AutoSize = true;
            lblAccionVal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAccionVal.ForeColor = Color.Gainsboro;
            lblAccionVal.Location = new Point(25, 160);
            lblAccionVal.Text = "Acción";

            // lblModuloTitulo
            lblModuloTitulo.AutoSize = true;
            lblModuloTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblModuloTitulo.ForeColor = Color.FromArgb(13, 110, 253);
            lblModuloTitulo.Location = new Point(25, 200);
            lblModuloTitulo.Text = "📂 MÓDULO / ENTIDAD:";

            // lblModuloVal
            lblModuloVal.AutoSize = true;
            lblModuloVal.Font = new Font("Segoe UI", 10F);
            lblModuloVal.ForeColor = Color.White;
            lblModuloVal.Location = new Point(25, 225);
            lblModuloVal.Text = "Módulo";

            // lblDescTitulo
            lblDescTitulo.AutoSize = true;
            lblDescTitulo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDescTitulo.ForeColor = Color.FromArgb(13, 110, 253);
            lblDescTitulo.Location = new Point(25, 265);
            lblDescTitulo.Text = "📝 DESCRIPCIÓN COMPLETA DE LA OPERACIÓN:";

            // txtDetalles
            txtDetalles.BackColor = Color.FromArgb(20, 24, 38);
            txtDetalles.BorderStyle = BorderStyle.FixedSingle;
            txtDetalles.Font = new Font("Segoe UI", 10F);
            txtDetalles.ForeColor = Color.White;
            txtDetalles.Location = new Point(25, 290);
            txtDetalles.Multiline = true;
            txtDetalles.ReadOnly = true;
            txtDetalles.ScrollBars = ScrollBars.Vertical;
            txtDetalles.Size = new Size(500, 110);

            // btnCerrar
            btnCerrar.BackColor = Color.FromArgb(40, 44, 60);
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(425, 415);
            btnCerrar.Size = new Size(100, 35);
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;

            // FormDetalleAuditoria
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 34, 48);
            ClientSize = new Size(550, 465);
            Controls.Add(btnCerrar);
            Controls.Add(txtDetalles);
            Controls.Add(lblDescTitulo);
            Controls.Add(lblModuloVal);
            Controls.Add(lblModuloTitulo);
            Controls.Add(lblAccionVal);
            Controls.Add(lblAccionTitulo);
            Controls.Add(lblFechaVal);
            Controls.Add(lblFechaTitulo);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalle de Auditoría";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTituloModal;
        private Label lblFechaTitulo;
        private Label lblFechaVal;
        private Label lblAccionTitulo;
        private Label lblAccionVal;
        private Label lblModuloTitulo;
        private Label lblModuloVal;
        private Label lblDescTitulo;
        private TextBox txtDetalles;
        private Button btnCerrar;
    }
}