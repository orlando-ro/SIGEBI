namespace SIGEBI.AppEscritorio.Forms.Usuarios
{
    partial class FormUsuarioMantenimiento
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
            lblNombre = new System.Windows.Forms.Label();
            txtNombre = new System.Windows.Forms.TextBox();
            lblEmail = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            lblTipoUsuario = new System.Windows.Forms.Label();
            cmbTipoUsuario = new System.Windows.Forms.ComboBox();
            lblPassword = new System.Windows.Forms.Label();
            txtPassword = new System.Windows.Forms.TextBox();
            lblMatricula = new System.Windows.Forms.Label();
            txtMatricula = new System.Windows.Forms.TextBox();
            lblNumeroEmpleado = new System.Windows.Forms.Label();
            txtNumeroEmpleado = new System.Windows.Forms.TextBox();
            lblEstado = new System.Windows.Forms.Label();
            cmbEstado = new System.Windows.Forms.ComboBox();
            btnGuardar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();
            panelFondo = new System.Windows.Forms.Panel();
            panelFondo.SuspendLayout();
            SuspendLayout();
            // 
            // panelFondo
            // 
            panelFondo.BackColor = System.Drawing.Color.FromArgb(20, 24, 38);
            panelFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelFondo.Controls.Add(btnCancelar);
            panelFondo.Controls.Add(btnGuardar);
            panelFondo.Controls.Add(cmbEstado);
            panelFondo.Controls.Add(lblEstado);
            panelFondo.Controls.Add(txtNumeroEmpleado);
            panelFondo.Controls.Add(lblNumeroEmpleado);
            panelFondo.Controls.Add(txtMatricula);
            panelFondo.Controls.Add(lblMatricula);
            panelFondo.Controls.Add(txtPassword);
            panelFondo.Controls.Add(lblPassword);
            panelFondo.Controls.Add(cmbTipoUsuario);
            panelFondo.Controls.Add(lblTipoUsuario);
            panelFondo.Controls.Add(txtEmail);
            panelFondo.Controls.Add(lblEmail);
            panelFondo.Controls.Add(txtNombre);
            panelFondo.Controls.Add(lblNombre);
            panelFondo.Controls.Add(lblTitulo);
            panelFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            panelFondo.Location = new System.Drawing.Point(0, 0);
            panelFondo.Name = "panelFondo";
            panelFondo.Size = new System.Drawing.Size(450, 520);
            panelFondo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitulo.ForeColor = System.Drawing.Color.White;
            lblTitulo.Location = new System.Drawing.Point(20, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(167, 30);
            lblTitulo.Text = "Mantenimiento";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.ForeColor = System.Drawing.Color.Gainsboro;
            lblNombre.Location = new System.Drawing.Point(25, 70);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new System.Drawing.Size(54, 15);
            lblNombre.Text = "Nombre*";
            // 
            // txtNombre
            // 
            txtNombre.Location = new System.Drawing.Point(25, 90);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new System.Drawing.Size(395, 23);
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.ForeColor = System.Drawing.Color.Gainsboro;
            lblEmail.Location = new System.Drawing.Point(25, 125);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(41, 15);
            lblEmail.Text = "Email*";
            // 
            // txtEmail
            // 
            txtEmail.Location = new System.Drawing.Point(25, 145);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new System.Drawing.Size(395, 23);
            // 
            // lblTipoUsuario
            // 
            lblTipoUsuario.AutoSize = true;
            lblTipoUsuario.ForeColor = System.Drawing.Color.Gainsboro;
            lblTipoUsuario.Location = new System.Drawing.Point(25, 180);
            lblTipoUsuario.Name = "lblTipoUsuario";
            lblTipoUsuario.Size = new System.Drawing.Size(94, 15);
            lblTipoUsuario.Text = "Tipo de Usuario*";
            // 
            // cmbTipoUsuario
            // 
            cmbTipoUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbTipoUsuario.Location = new System.Drawing.Point(25, 200);
            cmbTipoUsuario.Name = "cmbTipoUsuario";
            cmbTipoUsuario.Size = new System.Drawing.Size(190, 23);
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.ForeColor = System.Drawing.Color.Gainsboro;
            lblPassword.Location = new System.Drawing.Point(230, 180);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(72, 15);
            lblPassword.Text = "Contraseña*";
            // 
            // txtPassword
            // 
            txtPassword.Location = new System.Drawing.Point(230, 200);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new System.Drawing.Size(190, 23);
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblMatricula
            // 
            lblMatricula.AutoSize = true;
            lblMatricula.ForeColor = System.Drawing.Color.Gainsboro;
            lblMatricula.Location = new System.Drawing.Point(25, 235);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new System.Drawing.Size(57, 15);
            lblMatricula.Text = "Matrícula";
            // 
            // txtMatricula
            // 
            txtMatricula.Location = new System.Drawing.Point(25, 255);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new System.Drawing.Size(190, 23);
            // 
            // lblNumeroEmpleado
            // 
            lblNumeroEmpleado.AutoSize = true;
            lblNumeroEmpleado.ForeColor = System.Drawing.Color.Gainsboro;
            lblNumeroEmpleado.Location = new System.Drawing.Point(230, 235);
            lblNumeroEmpleado.Name = "lblNumeroEmpleado";
            lblNumeroEmpleado.Size = new System.Drawing.Size(84, 15);
            lblNumeroEmpleado.Text = "No. Empleado";
            // 
            // txtNumeroEmpleado
            // 
            txtNumeroEmpleado.Location = new System.Drawing.Point(230, 255);
            txtNumeroEmpleado.Name = "txtNumeroEmpleado";
            txtNumeroEmpleado.Size = new System.Drawing.Size(190, 23);
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.ForeColor = System.Drawing.Color.Gainsboro;
            lblEstado.Location = new System.Drawing.Point(25, 290);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new System.Drawing.Size(42, 15);
            lblEstado.Text = "Estado";
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbEstado.Location = new System.Drawing.Point(25, 310);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new System.Drawing.Size(190, 23);
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnGuardar.ForeColor = System.Drawing.Color.White;
            btnGuardar.Location = new System.Drawing.Point(290, 450);
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
            btnCancelar.Location = new System.Drawing.Point(145, 450);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(130, 40);
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // FormUsuarioMantenimiento
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(450, 520);
            Controls.Add(panelFondo);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Name = "FormUsuarioMantenimiento";
            Text = "Mantenimiento";
            panelFondo.ResumeLayout(false);
            panelFondo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelFondo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTipoUsuario;
        private System.Windows.Forms.ComboBox cmbTipoUsuario;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label lblNumeroEmpleado;
        private System.Windows.Forms.TextBox txtNumeroEmpleado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}