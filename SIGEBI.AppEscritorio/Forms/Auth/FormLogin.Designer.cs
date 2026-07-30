namespace SIGEBI.AppEscritorio.Forms.Auth
{
    partial class FormLogin
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
            lblTitulo = new Label();
            lblIdentificador = new Label();
            txtIdentificador = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            lblError = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitulo.Location = new Point(65, 64);
            lblTitulo.Margin = new Padding(6, 0, 6, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(346, 59);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Acceso a SIGEBI";
            // 
            // lblIdentificador
            // 
            lblIdentificador.AutoSize = true;
            lblIdentificador.Font = new Font("Segoe UI", 9F);
            lblIdentificador.Location = new Point(65, 192);
            lblIdentificador.Margin = new Padding(6, 0, 6, 0);
            lblIdentificador.Name = "lblIdentificador";
            lblIdentificador.Size = new Size(204, 32);
            lblIdentificador.TabIndex = 1;
            lblIdentificador.Text = "Correo Eletrónico:";
            // 
            // txtIdentificador
            // 
            txtIdentificador.Font = new Font("Segoe UI", 10F);
            txtIdentificador.Location = new Point(65, 235);
            txtIdentificador.Margin = new Padding(6, 6, 6, 6);
            txtIdentificador.Name = "txtIdentificador";
            txtIdentificador.Size = new Size(572, 43);
            txtIdentificador.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F);
            lblPassword.Location = new Point(65, 341);
            lblPassword.Margin = new Padding(6, 0, 6, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(139, 32);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Contraseña:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(65, 384);
            txtPassword.Margin = new Padding(6, 6, 6, 6);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(572, 43);
            txtPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(13, 110, 253);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(65, 555);
            btnLogin.Margin = new Padding(6, 6, 6, 6);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(576, 96);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // lblError
            // 
            lblError.Font = new Font("Segoe UI", 9F);
            lblError.ForeColor = Color.Crimson;
            lblError.Location = new Point(65, 459);
            lblError.Margin = new Padding(6, 0, 6, 0);
            lblError.Name = "lblError";
            lblError.Size = new Size(576, 85);
            lblError.TabIndex = 5;
            lblError.Text = "Mensaje de error aquí";
            lblError.Visible = false;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(713, 727);
            Controls.Add(btnLogin);
            Controls.Add(lblError);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtIdentificador);
            Controls.Add(lblIdentificador);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(6, 6, 6, 6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SIGEBI - Autenticación";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblIdentificador;
        public System.Windows.Forms.TextBox txtIdentificador;
        private System.Windows.Forms.Label lblPassword;
        public System.Windows.Forms.TextBox txtPassword;
        public System.Windows.Forms.Button btnLogin;
        public System.Windows.Forms.Label lblError;
    }
}