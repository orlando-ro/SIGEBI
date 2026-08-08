namespace SIGEBI.AppEscritorio.Forms.Catalogo
{
    partial class formGestionCatalogo
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblTitulo = new Label();
            panelAcciones = new Panel();
            btnDesactivar = new Button();
            btnEjemplares = new Button();
            btnEditar = new Button();
            btnNuevo = new Button();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            dgvLibros = new DataGridView();
            panelAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(29, 33);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(307, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Catálogo Bibliográfico";
            // 
            // panelAcciones
            // 
            panelAcciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelAcciones.BackColor = Color.FromArgb(25, 30, 48);
            panelAcciones.Controls.Add(btnDesactivar);
            panelAcciones.Controls.Add(btnEjemplares);
            panelAcciones.Controls.Add(btnEditar);
            panelAcciones.Controls.Add(btnNuevo);
            panelAcciones.Controls.Add(btnBuscar);
            panelAcciones.Controls.Add(txtBuscar);
            panelAcciones.Controls.Add(lblBuscar);
            panelAcciones.Location = new Point(34, 100);
            panelAcciones.Margin = new Padding(3, 4, 3, 4);
            panelAcciones.Name = "panelAcciones";
            panelAcciones.Size = new Size(903, 93);
            panelAcciones.TabIndex = 1;
            // 
            // btnDesactivar
            // 
            btnDesactivar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDesactivar.BackColor = Color.FromArgb(220, 53, 69);
            btnDesactivar.FlatAppearance.BorderSize = 0;
            btnDesactivar.FlatStyle = FlatStyle.Flat;
            btnDesactivar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDesactivar.ForeColor = Color.White;
            btnDesactivar.Location = new Point(777, 23);
            btnDesactivar.Margin = new Padding(3, 4, 3, 4);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(103, 47);
            btnDesactivar.TabIndex = 6;
            btnDesactivar.Text = "Desactivar";
            btnDesactivar.UseVisualStyleBackColor = false;
            // 
            // btnEjemplares
            // 
            btnEjemplares.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEjemplares.BackColor = Color.FromArgb(23, 162, 184);
            btnEjemplares.FlatAppearance.BorderSize = 0;
            btnEjemplares.FlatStyle = FlatStyle.Flat;
            btnEjemplares.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEjemplares.ForeColor = Color.White;
            btnEjemplares.Location = new Point(474, 23);
            btnEjemplares.Margin = new Padding(3, 4, 3, 4);
            btnEjemplares.Name = "btnEjemplares";
            btnEjemplares.Size = new Size(97, 47);
            btnEjemplares.TabIndex = 3;
            btnEjemplares.Text = "Ejemplares";
            btnEjemplares.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditar.BackColor = Color.FromArgb(255, 193, 7);
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEditar.ForeColor = Color.FromArgb(33, 37, 41);
            btnEditar.Location = new Point(680, 23);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(86, 47);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevo.BackColor = Color.FromArgb(40, 167, 69);
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(583, 23);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(86, 47);
            btnNuevo.TabIndex = 4;
            btnNuevo.Text = "+ Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(13, 110, 253);
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(309, 25);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(91, 40);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtBuscar.Location = new Point(91, 28);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "ISBN o Título...";
            txtBuscar.Size = new Size(205, 30);
            txtBuscar.TabIndex = 1;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 10F);
            lblBuscar.ForeColor = Color.Gainsboro;
            lblBuscar.Location = new Point(23, 32);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(64, 23);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar:";
            // 
            // dgvLibros
            // 
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.AllowUserToDeleteRows = false;
            dgvLibros.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibros.BackgroundColor = Color.FromArgb(20, 24, 38);
            dgvLibros.BorderStyle = BorderStyle.None;
            dgvLibros.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(15, 18, 28);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(15, 18, 28);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvLibros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvLibros.ColumnHeadersHeight = 40;
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 30, 45);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = Color.Gainsboro;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(45, 45, 60);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvLibros.DefaultCellStyle = dataGridViewCellStyle2;
            dgvLibros.EnableHeadersVisualStyles = false;
            dgvLibros.GridColor = Color.FromArgb(45, 45, 60);
            dgvLibros.Location = new Point(34, 220);
            dgvLibros.Margin = new Padding(3, 4, 3, 4);
            dgvLibros.MultiSelect = false;
            dgvLibros.Name = "dgvLibros";
            dgvLibros.ReadOnly = true;
            dgvLibros.RowHeadersVisible = false;
            dgvLibros.RowHeadersWidth = 51;
            dgvLibros.RowTemplate.Height = 35;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.Size = new Size(903, 527);
            dgvLibros.TabIndex = 2;
            dgvLibros.CellContentClick += dgvLibros_CellContentClick;
            // 
            // formGestionCatalogo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 45);
            ClientSize = new Size(971, 787);
            Controls.Add(dgvLibros);
            Controls.Add(panelAcciones);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "formGestionCatalogo";
            Text = "Catálogo Bibliográfico";
            panelAcciones.ResumeLayout(false);
            panelAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelAcciones;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEjemplares;
        private System.Windows.Forms.Button btnDesactivar;
        private System.Windows.Forms.DataGridView dgvLibros;
    }
}