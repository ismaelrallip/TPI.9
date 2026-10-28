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
            titleLabel.Location = new Point(87, 18);
            titleLabel.Margin = new Padding(4, 0, 4, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(165, 32);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Iniciar sesión";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(10, 63);
            usernameLabel.Margin = new Padding(1, 0, 1, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(76, 25);
            usernameLabel.TabIndex = 8;
            usernameLabel.Text = "Usuario:";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(10, 89);
            usernameTextBox.Margin = new Padding(1);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(319, 31);
            usernameTextBox.TabIndex = 3;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(10, 149);
            passwordLabel.Margin = new Padding(1, 0, 1, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(105, 25);
            passwordLabel.TabIndex = 7;
            passwordLabel.Text = "Contraseña:";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(14, 224);
            loginButton.Margin = new Padding(1);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(175, 35);
            loginButton.TabIndex = 5;
            loginButton.Text = "Iniciar Sesión";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(14, 175);
            passwordTextBox.Margin = new Padding(1);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(315, 31);
            passwordTextBox.TabIndex = 4;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(224, 265);
            cancelButton.Margin = new Padding(1);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(105, 45);
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
            registerButton.Location = new Point(205, 220);
            registerButton.Margin = new Padding(4, 5, 4, 5);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(124, 39);
            registerButton.TabIndex = 9;
            registerButton.Text = "Registrarse";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click;
            // 
            // LoginForm
            // 
            AcceptButton = loginButton;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(342, 330);
            Controls.Add(registerButton);
            Controls.Add(cancelButton);
            Controls.Add(passwordTextBox);
            Controls.Add(loginButton);
            Controls.Add(passwordLabel);
            Controls.Add(usernameTextBox);
            Controls.Add(usernameLabel);
            Controls.Add(titleLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
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