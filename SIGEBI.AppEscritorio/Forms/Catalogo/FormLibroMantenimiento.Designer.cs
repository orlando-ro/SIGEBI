namespace SIGEBI.AppEscritorio.Forms.Catalogo
{
    partial class FormLibroMantenimiento
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
            panelFondo = new System.Windows.Forms.Panel();
            btnCancelar = new System.Windows.Forms.Button();
            btnGuardar = new System.Windows.Forms.Button();
            btnSeleccionarImagen = new System.Windows.Forms.Button();
            picPortada = new System.Windows.Forms.PictureBox();
            cmbCategoria = new System.Windows.Forms.ComboBox();
            lblCategoria = new System.Windows.Forms.Label();
            txtCopias = new System.Windows.Forms.TextBox();
            lblCopias = new System.Windows.Forms.Label();
            txtAnio = new System.Windows.Forms.TextBox();
            lblAnio = new System.Windows.Forms.Label();
            txtAutor = new System.Windows.Forms.TextBox();
            lblAutor = new System.Windows.Forms.Label();
            txtTitulo = new System.Windows.Forms.TextBox();
            lblTituloLibro = new System.Windows.Forms.Label();
            txtIsbn = new System.Windows.Forms.TextBox();
            lblIsbn = new System.Windows.Forms.Label();
            lblTitulo = new System.Windows.Forms.Label();
            panelFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(picPortada)).BeginInit();
            SuspendLayout();
            // 
            // panelFondo
            // 
            panelFondo.BackColor = System.Drawing.Color.FromArgb(20, 24, 38);
            panelFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelFondo.Controls.Add(btnCancelar);
            panelFondo.Controls.Add(btnGuardar);
            panelFondo.Controls.Add(btnSeleccionarImagen);
            panelFondo.Controls.Add(picPortada);
            panelFondo.Controls.Add(cmbCategoria);
            panelFondo.Controls.Add(lblCategoria);
            panelFondo.Controls.Add(txtCopias);
            panelFondo.Controls.Add(lblCopias);
            panelFondo.Controls.Add(txtAnio);
            panelFondo.Controls.Add(lblAnio);
            panelFondo.Controls.Add(txtAutor);
            panelFondo.Controls.Add(lblAutor);
            panelFondo.Controls.Add(txtTitulo);
            panelFondo.Controls.Add(lblTituloLibro);
            panelFondo.Controls.Add(txtIsbn);
            panelFondo.Controls.Add(lblIsbn);
            panelFondo.Controls.Add(lblTitulo);
            panelFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            panelFondo.Location = new System.Drawing.Point(0, 0);
            panelFondo.Name = "panelFondo";
            panelFondo.Size = new System.Drawing.Size(650, 480);
            panelFondo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(20, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(264, 30);
            lblTitulo.Text = "Mantenimiento de Libro";
            // 
            // lblIsbn
            // 
            lblIsbn.AutoSize = true;
            lblIsbn.ForeColor = System.Drawing.Color.Gainsboro;
            lblIsbn.Location = new System.Drawing.Point(25, 70);
            lblIsbn.Name = "lblIsbn";
            lblIsbn.Size = new System.Drawing.Size(40, 15);
            lblIsbn.Text = "ISBN*";
            // 
            // txtIsbn
            // 
            txtIsbn.Location = new System.Drawing.Point(25, 90);
            txtIsbn.Name = "txtIsbn";
            txtIsbn.Size = new System.Drawing.Size(200, 23);
            // 
            // lblTituloLibro
            // 
            lblTituloLibro.AutoSize = true;
            lblTituloLibro.ForeColor = System.Drawing.Color.Gainsboro;
            lblTituloLibro.Location = new System.Drawing.Point(25, 125);
            lblTituloLibro.Name = "lblTituloLibro";
            lblTituloLibro.Size = new System.Drawing.Size(42, 15);
            lblTituloLibro.Text = "Título*";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new System.Drawing.Point(25, 145);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new System.Drawing.Size(395, 23);
            // 
            // lblAutor
            // 
            lblAutor.AutoSize = true;
            lblAutor.ForeColor = System.Drawing.Color.Gainsboro;
            lblAutor.Location = new System.Drawing.Point(25, 180);
            lblAutor.Name = "lblAutor";
            lblAutor.Size = new System.Drawing.Size(42, 15);
            lblAutor.Text = "Autor*";
            // 
            // txtAutor
            // 
            txtAutor.Location = new System.Drawing.Point(25, 200);
            txtAutor.Name = "txtAutor";
            txtAutor.Size = new System.Drawing.Size(395, 23);
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.ForeColor = System.Drawing.Color.Gainsboro;
            lblAnio.Location = new System.Drawing.Point(25, 235);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new System.Drawing.Size(116, 15);
            lblAnio.Text = "Año de Publicación*";
            // 
            // txtAnio
            // 
            txtAnio.Location = new System.Drawing.Point(25, 255);
            txtAnio.Name = "txtAnio";
            txtAnio.Size = new System.Drawing.Size(190, 23);
            // 
            // lblCopias
            // 
            lblCopias.AutoSize = true;
            lblCopias.ForeColor = System.Drawing.Color.Gainsboro;
            lblCopias.Location = new System.Drawing.Point(230, 235);
            lblCopias.Name = "lblCopias";
            lblCopias.Size = new System.Drawing.Size(87, 15);
            lblCopias.Text = "Copias Totales*";
            // 
            // txtCopias
            // 
            txtCopias.Location = new System.Drawing.Point(230, 255);
            txtCopias.Name = "txtCopias";
            txtCopias.Size = new System.Drawing.Size(190, 23);
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.ForeColor = System.Drawing.Color.Gainsboro;
            lblCategoria.Location = new System.Drawing.Point(25, 290);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new System.Drawing.Size(63, 15);
            lblCategoria.Text = "Categoría*";
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbCategoria.Location = new System.Drawing.Point(25, 310);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new System.Drawing.Size(395, 23);
            // 
            // picPortada
            // 
            picPortada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picPortada.Location = new System.Drawing.Point(450, 90);
            picPortada.Name = "picPortada";
            picPortada.Size = new System.Drawing.Size(160, 200);
            picPortada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picPortada.TabIndex = 16;
            picPortada.TabStop = false;
            // 
            // btnSeleccionarImagen
            // 
            btnSeleccionarImagen.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            btnSeleccionarImagen.FlatAppearance.BorderSize = 0;
            btnSeleccionarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSeleccionarImagen.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            btnSeleccionarImagen.ForeColor = System.Drawing.Color.White;
            btnSeleccionarImagen.Location = new System.Drawing.Point(450, 296);
            btnSeleccionarImagen.Name = "btnSeleccionarImagen";
            btnSeleccionarImagen.Size = new System.Drawing.Size(160, 30);
            btnSeleccionarImagen.Text = "Seleccionar Imagen";
            btnSeleccionarImagen.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnGuardar.ForeColor = System.Drawing.Color.White;
            btnGuardar.Location = new System.Drawing.Point(480, 410);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(130, 40);
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnCancelar.ForeColor = System.Drawing.Color.White;
            btnCancelar.Location = new System.Drawing.Point(335, 410);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(130, 40);
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // FormLibroMantenimiento
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(650, 480);
            Controls.Add(panelFondo);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Name = "FormLibroMantenimiento";
            Text = "Mantenimiento de Libro";
            panelFondo.ResumeLayout(false);
            panelFondo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(picPortada)).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelFondo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblIsbn;
        private System.Windows.Forms.TextBox txtIsbn;
        private System.Windows.Forms.Label lblTituloLibro;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.Label lblCopias;
        private System.Windows.Forms.TextBox txtCopias;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.PictureBox picPortada;
        private System.Windows.Forms.Button btnSeleccionarImagen;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}