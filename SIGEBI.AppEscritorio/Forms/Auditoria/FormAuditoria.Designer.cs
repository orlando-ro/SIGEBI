namespace SIGEBI.AppEscritorio.Forms.Auditoria
{
    partial class FormAuditoria
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            dgvAuditoria = new System.Windows.Forms.DataGridView();
            panelTop = new System.Windows.Forms.Panel();
            lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgvAuditoria).BeginInit();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(lblTitulo);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(900, 60);
            panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(12, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(394, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registro Inmutable de Auditoría";
            // 
            // dgvAuditoria
            // 
            dgvAuditoria.AllowUserToAddRows = false;
            dgvAuditoria.AllowUserToDeleteRows = false;
            dgvAuditoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuditoria.BackgroundColor = System.Drawing.Color.FromArgb(25, 30, 48);
            dgvAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(35, 40, 58);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvAuditoria.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAuditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(20, 24, 38);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(50, 55, 75);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvAuditoria.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAuditoria.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvAuditoria.EnableHeadersVisualStyles = false;
            dgvAuditoria.Location = new System.Drawing.Point(0, 60);
            dgvAuditoria.Name = "dgvAuditoria";
            dgvAuditoria.ReadOnly = true;
            dgvAuditoria.RowHeadersVisible = false;
            dgvAuditoria.RowHeadersWidth = 51;
            dgvAuditoria.RowTemplate.Height = 35;
            dgvAuditoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvAuditoria.Size = new System.Drawing.Size(900, 540);
            dgvAuditoria.TabIndex = 1;
            // 
            // FormAuditoria
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(20, 24, 38);
            ClientSize = new System.Drawing.Size(900, 600);
            Controls.Add(dgvAuditoria);
            Controls.Add(panelTop);
            Name = "FormAuditoria";
            Text = "Auditoría";
            Load += FormAuditoria_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAuditoria).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAuditoria;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
    }
}