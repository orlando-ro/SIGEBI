namespace SIGEBI.AppEscritorio.Forms.Auth
{
    partial class FormLogin
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
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(65, 54);
            lblTitulo.Margin = new Padding(6, 0, 6, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(346, 59);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Acceso a SIGEBI";
            // 
            // lblIdentificador
            // 
            lblIdentificador.AutoSize = true;
            lblIdentificador.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIdentificador.ForeColor = Color.Gainsboro; 
            lblIdentificador.Location = new Point(65, 182);
            lblIdentificador.Margin = new Padding(6, 0, 6, 0);
            lblIdentificador.Name = "lblIdentificador";
            lblIdentificador.Size = new Size(204, 32);
            lblIdentificador.TabIndex = 1;
            lblIdentificador.Text = "Correo Electrónico:";
            // 
            // txtIdentificador
            // 
            txtIdentificador.BackColor = Color.FromArgb(20, 24, 38); 
            txtIdentificador.BorderStyle = BorderStyle.FixedSingle;
            txtIdentificador.Font = new Font("Segoe UI", 11F);
            txtIdentificador.ForeColor = Color.White;
            txtIdentificador.Location = new Point(65, 225);
            txtIdentificador.Margin = new Padding(6);
            txtIdentificador.Name = "txtIdentificador";
            txtIdentificador.Size = new Size(572, 39);
            txtIdentificador.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPassword.ForeColor = Color.Gainsboro;
            lblPassword.Location = new Point(65, 331);
            lblPassword.Margin = new Padding(6, 0, 6, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(139, 32);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Contraseña:";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(20, 24, 38);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(65, 374);
            txtPassword.Margin = new Padding(6);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(572, 39);
            txtPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(13, 110, 253);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(65, 545);
            btnLogin.Margin = new Padding(6);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(576, 85);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // lblError
            // 
            lblError.Font = new Font("Segoe UI", 9.5F);
            lblError.ForeColor = Color.FromArgb(220, 53, 69);
            lblError.Location = new Point(65, 449);
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
            BackColor = Color.FromArgb(30, 30, 45);
            ClientSize = new Size(713, 727);
            Controls.Add(btnLogin);
            Controls.Add(lblError);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtIdentificador);
            Controls.Add(lblIdentificador);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(6);
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