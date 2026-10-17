namespace WindowsForms
{
    partial class LoginForm
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
            components = new System.ComponentModel.Container();
            titleLabel = new Label();
            usernameLabel = new Label();
            usernameTextBox = new TextBox();
            passwordLabel = new Label();
            loginButton = new Button();
            passwordTextBox = new TextBox();
            cancelButton = new Button();
            errorProvider = new ErrorProvider(components);
            registerButton = new Button();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(59, 12);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(136, 28);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Iniciar sesión";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(48, 52);
            usernameLabel.Margin = new Padding(1, 0, 1, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(62, 20);
            usernameLabel.TabIndex = 8;
            usernameLabel.Text = "Usuario:";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(51, 73);
            usernameTextBox.Margin = new Padding(1);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(133, 27);
            usernameTextBox.TabIndex = 3;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(48, 121);
            passwordLabel.Margin = new Padding(1, 0, 1, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(86, 20);
            passwordLabel.TabIndex = 7;
            passwordLabel.Text = "Contraseña:";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(32, 181);
            loginButton.Margin = new Padding(1);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(73, 28);
            loginButton.TabIndex = 5;
            loginButton.Text = "Iniciar Sesión";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(51, 143);
            passwordTextBox.Margin = new Padding(1);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(133, 27);
            passwordTextBox.TabIndex = 4;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(155, 215);
            cancelButton.Margin = new Padding(1);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(84, 36);
            cancelButton.TabIndex = 6;
            cancelButton.Text = "Cancelar";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // registerButton
            // 
            registerButton.Location = new Point(140, 179);
            registerButton.Margin = new Padding(3, 4, 3, 4);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(99, 31);
            registerButton.TabIndex = 9;
            registerButton.Text = "Registrarse";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click;
            // 
            // LoginForm
            // 
            AcceptButton = loginButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(253, 264);
            Controls.Add(registerButton);
            Controls.Add(cancelButton);
            Controls.Add(passwordTextBox);
            Controls.Add(loginButton);
            Controls.Add(passwordLabel);
            Controls.Add(usernameTextBox);
            Controls.Add(usernameLabel);
            Controls.Add(titleLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TPI - Login";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label usernameLabel;
        private TextBox usernameTextBox;
        private Label passwordLabel;
        private Button loginButton;
        private TextBox passwordTextBox;
        private Button cancelButton;
        private ErrorProvider errorProvider;
        private Button registerButton;
    }
}