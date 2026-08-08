namespace SIGEBI.AppEscritorio.Forms.Perfil
{
    partial class FormPerfil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlDatosPersonales = new System.Windows.Forms.Panel();
            this.txtRol = new System.Windows.Forms.TextBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.txtNumeroEmpleado = new System.Windows.Forms.TextBox();
            this.lblNumeroEmpleado = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDatosPersonales = new System.Windows.Forms.Label();
            this.pnlSeguridad = new System.Windows.Forms.Panel();
            this.btnActualizarPassword = new System.Windows.Forms.Button();
            this.txtConfirmarPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmarPassword = new System.Windows.Forms.Label();
            this.txtNuevaPassword = new System.Windows.Forms.TextBox();
            this.lblNuevaPassword = new System.Windows.Forms.Label();
            this.txtPasswordActual = new System.Windows.Forms.TextBox();
            this.lblPasswordActual = new System.Windows.Forms.Label();
            this.lblSeguridad = new System.Windows.Forms.Label();
            this.pnlDatosPersonales.SuspendLayout();
            this.pnlSeguridad.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(24, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(111, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Mi Perfil";
            // 
            // pnlDatosPersonales
            // 
            this.pnlDatosPersonales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.pnlDatosPersonales.Controls.Add(this.txtRol);
            this.pnlDatosPersonales.Controls.Add(this.lblRol);
            this.pnlDatosPersonales.Controls.Add(this.txtNumeroEmpleado);
            this.pnlDatosPersonales.Controls.Add(this.lblNumeroEmpleado);
            this.pnlDatosPersonales.Controls.Add(this.txtEmail);
            this.pnlDatosPersonales.Controls.Add(this.lblEmail);
            this.pnlDatosPersonales.Controls.Add(this.txtNombre);
            this.pnlDatosPersonales.Controls.Add(this.lblNombre);
            this.pnlDatosPersonales.Controls.Add(this.lblDatosPersonales);
            this.pnlDatosPersonales.Location = new System.Drawing.Point(30, 80);
            this.pnlDatosPersonales.Name = "pnlDatosPersonales";
            this.pnlDatosPersonales.Size = new System.Drawing.Size(350, 360);
            this.pnlDatosPersonales.TabIndex = 1;
            // 
            // txtRol
            // 
            this.txtRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.txtRol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRol.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtRol.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtRol.Location = new System.Drawing.Point(25, 305);
            this.txtRol.Name = "txtRol";
            this.txtRol.ReadOnly = true;
            this.txtRol.Size = new System.Drawing.Size(300, 27);
            this.txtRol.TabIndex = 8;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblRol.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblRol.Location = new System.Drawing.Point(22, 285);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(96, 17);
            this.lblRol.TabIndex = 7;
            this.lblRol.Text = "Rol en Sistema";
            // 
            // txtNumeroEmpleado
            // 
            this.txtNumeroEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.txtNumeroEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroEmpleado.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNumeroEmpleado.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtNumeroEmpleado.Location = new System.Drawing.Point(25, 235);
            this.txtNumeroEmpleado.Name = "txtNumeroEmpleado";
            this.txtNumeroEmpleado.ReadOnly = true;
            this.txtNumeroEmpleado.Size = new System.Drawing.Size(300, 27);
            this.txtNumeroEmpleado.TabIndex = 6;
            // 
            // lblNumeroEmpleado
            // 
            this.lblNumeroEmpleado.AutoSize = true;
            this.lblNumeroEmpleado.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNumeroEmpleado.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblNumeroEmpleado.Location = new System.Drawing.Point(22, 215);
            this.lblNumeroEmpleado.Name = "lblNumeroEmpleado";
            this.lblNumeroEmpleado.Size = new System.Drawing.Size(129, 17);
            this.lblNumeroEmpleado.TabIndex = 5;
            this.lblNumeroEmpleado.Text = "Número de Empleado";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtEmail.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtEmail.Location = new System.Drawing.Point(25, 165);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(300, 27);
            this.txtEmail.TabIndex = 4;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblEmail.Location = new System.Drawing.Point(22, 145);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(120, 17);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Correo Electrónico";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNombre.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtNombre.Location = new System.Drawing.Point(25, 95);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(300, 27);
            this.txtNombre.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblNombre.Location = new System.Drawing.Point(22, 75);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(122, 17);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre Completo";
            // 
            // lblDatosPersonales
            // 
            this.lblDatosPersonales.AutoSize = true;
            this.lblDatosPersonales.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosPersonales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblDatosPersonales.Location = new System.Drawing.Point(20, 20);
            this.lblDatosPersonales.Name = "lblDatosPersonales";
            this.lblDatosPersonales.Size = new System.Drawing.Size(142, 21);
            this.lblDatosPersonales.TabIndex = 0;
            this.lblDatosPersonales.Text = "Datos Personales";
            // 
            // pnlSeguridad
            // 
            this.pnlSeguridad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.pnlSeguridad.Controls.Add(this.btnActualizarPassword);
            this.pnlSeguridad.Controls.Add(this.txtConfirmarPassword);
            this.pnlSeguridad.Controls.Add(this.lblConfirmarPassword);
            this.pnlSeguridad.Controls.Add(this.txtNuevaPassword);
            this.pnlSeguridad.Controls.Add(this.lblNuevaPassword);
            this.pnlSeguridad.Controls.Add(this.txtPasswordActual);
            this.pnlSeguridad.Controls.Add(this.lblPasswordActual);
            this.pnlSeguridad.Controls.Add(this.lblSeguridad);
            this.pnlSeguridad.Location = new System.Drawing.Point(410, 80);
            this.pnlSeguridad.Name = "pnlSeguridad";
            this.pnlSeguridad.Size = new System.Drawing.Size(350, 360);
            this.pnlSeguridad.TabIndex = 2;
            // 
            // btnActualizarPassword
            // 
            this.btnActualizarPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(200)))));
            this.btnActualizarPassword.FlatAppearance.BorderSize = 0;
            this.btnActualizarPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarPassword.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarPassword.ForeColor = System.Drawing.Color.White;
            this.btnActualizarPassword.Location = new System.Drawing.Point(25, 300);
            this.btnActualizarPassword.Name = "btnActualizarPassword";
            this.btnActualizarPassword.Size = new System.Drawing.Size(300, 35);
            this.btnActualizarPassword.TabIndex = 7;
            this.btnActualizarPassword.Text = "Actualizar Contraseña";
            this.btnActualizarPassword.UseVisualStyleBackColor = false;
            // 
            // txtConfirmarPassword
            // 
            this.txtConfirmarPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.txtConfirmarPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmarPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtConfirmarPassword.ForeColor = System.Drawing.Color.White;
            this.txtConfirmarPassword.Location = new System.Drawing.Point(25, 240);
            this.txtConfirmarPassword.Name = "txtConfirmarPassword";
            this.txtConfirmarPassword.Size = new System.Drawing.Size(300, 27);
            this.txtConfirmarPassword.TabIndex = 6;
            this.txtConfirmarPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmarPassword
            // 
            this.lblConfirmarPassword.AutoSize = true;
            this.lblConfirmarPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblConfirmarPassword.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblConfirmarPassword.Location = new System.Drawing.Point(22, 220);
            this.lblConfirmarPassword.Name = "lblConfirmarPassword";
            this.lblConfirmarPassword.Size = new System.Drawing.Size(183, 17);
            this.lblConfirmarPassword.TabIndex = 5;
            this.lblConfirmarPassword.Text = "Confirmar Nueva Contraseña *";
            // 
            // txtNuevaPassword
            // 
            this.txtNuevaPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.txtNuevaPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNuevaPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNuevaPassword.ForeColor = System.Drawing.Color.White;
            this.txtNuevaPassword.Location = new System.Drawing.Point(25, 165);
            this.txtNuevaPassword.Name = "txtNuevaPassword";
            this.txtNuevaPassword.Size = new System.Drawing.Size(300, 27);
            this.txtNuevaPassword.TabIndex = 4;
            this.txtNuevaPassword.UseSystemPasswordChar = true;
            // 
            // lblNuevaPassword
            // 
            this.lblNuevaPassword.AutoSize = true;
            this.lblNuevaPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNuevaPassword.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblNuevaPassword.Location = new System.Drawing.Point(22, 145);
            this.lblNuevaPassword.Name = "lblNuevaPassword";
            this.lblNuevaPassword.Size = new System.Drawing.Size(126, 17);
            this.lblNuevaPassword.TabIndex = 3;
            this.lblNuevaPassword.Text = "Nueva Contraseña *";
            // 
            // txtPasswordActual
            // 
            this.txtPasswordActual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.txtPasswordActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswordActual.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPasswordActual.ForeColor = System.Drawing.Color.White;
            this.txtPasswordActual.Location = new System.Drawing.Point(25, 95);
            this.txtPasswordActual.Name = "txtPasswordActual";
            this.txtPasswordActual.Size = new System.Drawing.Size(300, 27);
            this.txtPasswordActual.TabIndex = 2;
            this.txtPasswordActual.UseSystemPasswordChar = true;
            // 
            // lblPasswordActual
            // 
            this.lblPasswordActual.AutoSize = true;
            this.lblPasswordActual.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPasswordActual.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPasswordActual.Location = new System.Drawing.Point(22, 75);
            this.lblPasswordActual.Name = "lblPasswordActual";
            this.lblPasswordActual.Size = new System.Drawing.Size(127, 17);
            this.lblPasswordActual.TabIndex = 1;
            this.lblPasswordActual.Text = "Contraseña Actual *";
            // 
            // lblSeguridad
            // 
            this.lblSeguridad.AutoSize = true;
            this.lblSeguridad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeguridad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblSeguridad.Location = new System.Drawing.Point(20, 20);
            this.lblSeguridad.Name = "lblSeguridad";
            this.lblSeguridad.Size = new System.Drawing.Size(161, 21);
            this.lblSeguridad.TabIndex = 0;
            this.lblSeguridad.Text = "Seguridad y Acceso";
            // 
            // FormPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(800, 460);
            this.Controls.Add(this.pnlSeguridad);
            this.Controls.Add(this.pnlDatosPersonales);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPerfil";
            this.Text = "FormPerfil";
            this.pnlDatosPersonales.ResumeLayout(false);
            this.pnlDatosPersonales.PerformLayout();
            this.pnlSeguridad.ResumeLayout(false);
            this.pnlSeguridad.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlDatosPersonales;
        private System.Windows.Forms.Label lblDatosPersonales;
        private System.Windows.Forms.TextBox txtRol;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNumeroEmpleado;
        private System.Windows.Forms.Label lblNumeroEmpleado;
        private System.Windows.Forms.Panel pnlSeguridad;
        private System.Windows.Forms.Label lblSeguridad;
        private System.Windows.Forms.Button btnActualizarPassword;
        private System.Windows.Forms.TextBox txtConfirmarPassword;
        private System.Windows.Forms.Label lblConfirmarPassword;
        private System.Windows.Forms.TextBox txtNuevaPassword;
        private System.Windows.Forms.Label lblNuevaPassword;
        private System.Windows.Forms.TextBox txtPasswordActual;
        private System.Windows.Forms.Label lblPasswordActual;
    }
}