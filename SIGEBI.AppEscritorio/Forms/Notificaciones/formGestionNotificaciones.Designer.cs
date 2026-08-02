namespace SIGEBI.AppEscritorio.Forms.Notificaciones
{
    partial class formGestionNotificaciones
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblTitulo = new Label();
            panelAcciones = new Panel();
            btnActualizar = new Button();
            lblDiasAntelacion = new Label();
            nudDiasAntelacion = new NumericUpDown();
            btnDispararVencimientos = new Button();
            dgvNotificaciones = new DataGridView();
            panelAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiasAntelacion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvNotificaciones).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(25, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(358, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Historial de Notificaciones";
            // 
            // panelAcciones
            // 
            panelAcciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelAcciones.BackColor = Color.FromArgb(25, 30, 48);
            panelAcciones.Controls.Add(btnActualizar);
            panelAcciones.Controls.Add(lblDiasAntelacion);
            panelAcciones.Controls.Add(nudDiasAntelacion);
            panelAcciones.Controls.Add(btnDispararVencimientos);
            panelAcciones.Location = new Point(30, 75);
            panelAcciones.Name = "panelAcciones";
            panelAcciones.Size = new Size(790, 80);
            panelAcciones.TabIndex = 1;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(13, 110, 253);
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(20, 18);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(120, 45);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            // 
            // lblDiasAntelacion
            // 
            lblDiasAntelacion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDiasAntelacion.AutoSize = true;
            lblDiasAntelacion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDiasAntelacion.ForeColor = Color.Gainsboro;
            lblDiasAntelacion.Location = new Point(229, 31);
            lblDiasAntelacion.Name = "lblDiasAntelacion";
            lblDiasAntelacion.Size = new Size(136, 23);
            lblDiasAntelacion.TabIndex = 4;
            lblDiasAntelacion.Text = "Días antelación:";
            // 
            // nudDiasAntelacion
            // 
            nudDiasAntelacion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nudDiasAntelacion.Font = new Font("Segoe UI", 11F);
            nudDiasAntelacion.Location = new Point(455, 27);
            nudDiasAntelacion.Maximum = new decimal(new int[] { 7, 0, 0, 0 });
            nudDiasAntelacion.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDiasAntelacion.Name = "nudDiasAntelacion";
            nudDiasAntelacion.Size = new Size(70, 32);
            nudDiasAntelacion.TabIndex = 5;
            nudDiasAntelacion.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // btnDispararVencimientos
            // 
            btnDispararVencimientos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDispararVencimientos.BackColor = Color.FromArgb(253, 126, 20);
            btnDispararVencimientos.FlatAppearance.BorderSize = 0;
            btnDispararVencimientos.FlatStyle = FlatStyle.Flat;
            btnDispararVencimientos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDispararVencimientos.ForeColor = Color.White;
            btnDispararVencimientos.Location = new Point(540, 18);
            btnDispararVencimientos.Name = "btnDispararVencimientos";
            btnDispararVencimientos.Size = new Size(230, 45);
            btnDispararVencimientos.TabIndex = 3;
            btnDispararVencimientos.Text = "⚠ Disparar Alertas de Préstamo";
            btnDispararVencimientos.UseVisualStyleBackColor = false;
            // 
            // dgvNotificaciones
            // 
            dgvNotificaciones.AllowUserToAddRows = false;
            dgvNotificaciones.AllowUserToDeleteRows = false;
            dgvNotificaciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNotificaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNotificaciones.BackgroundColor = Color.FromArgb(20, 24, 38);
            dgvNotificaciones.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(15, 18, 28);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dgvNotificaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvNotificaciones.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 30, 45);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = Color.Gainsboro;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(45, 45, 60);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvNotificaciones.DefaultCellStyle = dataGridViewCellStyle2;
            dgvNotificaciones.EnableHeadersVisualStyles = false;
            dgvNotificaciones.Location = new Point(30, 175);
            dgvNotificaciones.MultiSelect = false;
            dgvNotificaciones.Name = "dgvNotificaciones";
            dgvNotificaciones.ReadOnly = true;
            dgvNotificaciones.RowHeadersVisible = false;
            dgvNotificaciones.RowHeadersWidth = 82;
            dgvNotificaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNotificaciones.Size = new Size(790, 385);
            dgvNotificaciones.TabIndex = 2;
            // 
            // formGestionNotificaciones
            // 
            BackColor = Color.FromArgb(30, 30, 45);
            ClientSize = new Size(850, 590);
            Controls.Add(dgvNotificaciones);
            Controls.Add(panelAcciones);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formGestionNotificaciones";
            Text = "Historial de Notificaciones";
            panelAcciones.ResumeLayout(false);
            panelAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiasAntelacion).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvNotificaciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelAcciones;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblDiasAntelacion;
        private System.Windows.Forms.NumericUpDown nudDiasAntelacion;
        private System.Windows.Forms.Button btnDispararVencimientos;
        private System.Windows.Forms.DataGridView dgvNotificaciones;
    }
}