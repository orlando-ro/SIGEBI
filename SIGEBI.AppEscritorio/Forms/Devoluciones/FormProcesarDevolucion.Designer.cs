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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            lblTitulo = new System.Windows.Forms.Label();
            lblHeaderInfo = new System.Windows.Forms.Label();
            lblNombreUsuario = new System.Windows.Forms.Label();
            lblIdentificador = new System.Windows.Forms.Label();
            lblFechas = new System.Windows.Forms.Label();
            lblRetraso = new System.Windows.Forms.Label();
            lblEjemplaresTitulo = new System.Windows.Forms.Label();
            dgvEjemplares = new System.Windows.Forms.DataGridView();
            lblSeparador = new System.Windows.Forms.Label();
            btnProcesar = new System.Windows.Forms.Button();
            btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(dgvEjemplares)).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(20, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Detalles y Devolución Múltiple";
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
            lblEjemplaresTitulo.Text = "EVALUACIÓN DE EJEMPLARES FÍSICOS";
            // 
            // dgvEjemplares
            // 
            dgvEjemplares.AllowUserToAddRows = false;
            dgvEjemplares.AllowUserToDeleteRows = false;
            dgvEjemplares.AllowUserToResizeRows = false;
            dgvEjemplares.BackgroundColor = System.Drawing.Color.FromArgb(40, 40, 60);
            dgvEjemplares.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dgvEjemplares.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(15, 18, 28);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(15, 18, 28);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dgvEjemplares.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvEjemplares.ColumnHeadersHeight = 35;
            dgvEjemplares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(30, 34, 48);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dgvEjemplares.DefaultCellStyle = dataGridViewCellStyle2;
            dgvEjemplares.EnableHeadersVisualStyles = false;
            dgvEjemplares.GridColor = System.Drawing.Color.FromArgb(70, 75, 90);
            dgvEjemplares.Location = new System.Drawing.Point(20, 230);
            dgvEjemplares.Name = "dgvEjemplares";
            dgvEjemplares.RowHeadersVisible = false;
            dgvEjemplares.RowTemplate.Height = 35;
            dgvEjemplares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            dgvEjemplares.Size = new System.Drawing.Size(650, 160);
            dgvEjemplares.TabIndex = 0;
            // 
            // lblSeparador
            // 
            lblSeparador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lblSeparador.Location = new System.Drawing.Point(20, 410);
            lblSeparador.Size = new System.Drawing.Size(650, 2);
            // 
            // btnProcesar
            // 
            btnProcesar.BackColor = System.Drawing.Color.FromArgb(25, 135, 84);
            btnProcesar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnProcesar.FlatAppearance.BorderSize = 0;
            btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnProcesar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnProcesar.ForeColor = System.Drawing.Color.White;
            btnProcesar.Location = new System.Drawing.Point(20, 430);
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
            btnCerrar.Location = new System.Drawing.Point(530, 430);
            btnCerrar.Size = new System.Drawing.Size(140, 45);
            btnCerrar.Text = "Cancelar";
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FormProcesarDevolucion
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            ClientSize = new System.Drawing.Size(690, 500);
            Controls.Add(btnCerrar);
            Controls.Add(btnProcesar);
            Controls.Add(lblSeparador);
            Controls.Add(dgvEjemplares);
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
            Text = "Gestión de Préstamo - Evaluación Individual";
            Load += FormProcesarDevolucion_Load;
            ((System.ComponentModel.ISupportInitialize)(dgvEjemplares)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvEjemplares;
        private System.Windows.Forms.Label lblSeparador;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Button btnCerrar;
    }
}