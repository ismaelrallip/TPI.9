namespace WindowsForms
{
    partial class ClienteDetalle
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
            idLabel = new Label();
            idTextBox = new TextBox();
            emailLabel = new Label();
            emailTextBox = new TextBox();
            apellidoLabel = new Label();
            apellidoTextBox = new TextBox();
            cancelarButton = new Button();
            aceptarButton = new Button();
            nombreLabel = new Label();
            nombreTextBox = new TextBox();
            telefonoLabel = new Label();
            passwordLabel = new Label();
            errorProvider = new ErrorProvider(components);
            telefonoTextBox = new TextBox();
            passwordTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(179, 71);
            idLabel.Margin = new Padding(2, 0, 2, 0);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(22, 20);
            idLabel.TabIndex = 26;
            idLabel.Text = "Id";
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(302, 71);
            idTextBox.Margin = new Padding(2);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(125, 27);
            idTextBox.TabIndex = 14;
            idTextBox.TabStop = false;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(179, 208);
            emailLabel.Margin = new Padding(2, 0, 2, 0);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(46, 20);
            emailLabel.TabIndex = 24;
            emailLabel.Text = "Email";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(302, 208);
            emailTextBox.Margin = new Padding(2);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(235, 27);
            emailTextBox.TabIndex = 19;
            // 
            // apellidoLabel
            // 
            apellidoLabel.AutoSize = true;
            apellidoLabel.Location = new Point(179, 160);
            apellidoLabel.Margin = new Padding(2, 0, 2, 0);
            apellidoLabel.Name = "apellidoLabel";
            apellidoLabel.Size = new Size(66, 20);
            apellidoLabel.TabIndex = 23;
            apellidoLabel.Text = "Apellido";
            // 
            // apellidoTextBox
            // 
            apellidoTextBox.Location = new Point(302, 160);
            apellidoTextBox.Margin = new Padding(2);
            apellidoTextBox.Name = "apellidoTextBox";
            apellidoTextBox.Size = new Size(125, 27);
            apellidoTextBox.TabIndex = 17;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(530, 350);
            cancelarButton.Margin = new Padding(2);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(92, 29);
            cancelarButton.TabIndex = 22;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(425, 350);
            aceptarButton.Margin = new Padding(2);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(92, 29);
            aceptarButton.TabIndex = 20;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(179, 118);
            nombreLabel.Margin = new Padding(2, 0, 2, 0);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(64, 20);
            nombreLabel.TabIndex = 18;
            nombreLabel.Text = "Nombre";
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(302, 118);
            nombreTextBox.Margin = new Padding(2);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(125, 27);
            nombreTextBox.TabIndex = 16;
            // 
            // telefonoLabel
            // 
            telefonoLabel.AutoSize = true;
            telefonoLabel.Location = new Point(179, 251);
            telefonoLabel.Margin = new Padding(2, 0, 2, 0);
            telefonoLabel.Name = "telefonoLabel";
            telefonoLabel.Size = new Size(67, 20);
            telefonoLabel.TabIndex = 27;
            telefonoLabel.Text = "Teléfono";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(179, 289);
            passwordLabel.Margin = new Padding(2, 0, 2, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(83, 20);
            passwordLabel.TabIndex = 28;
            passwordLabel.Text = "Contraseña";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // telefonoTextBox
            // 
            telefonoTextBox.Location = new Point(302, 251);
            telefonoTextBox.Margin = new Padding(2);
            telefonoTextBox.Name = "telefonoTextBox";
            telefonoTextBox.Size = new Size(235, 27);
            telefonoTextBox.TabIndex = 29;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(302, 289);
            passwordTextBox.Margin = new Padding(2);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(235, 27);
            passwordTextBox.TabIndex = 30;
            passwordTextBox.TextChanged += passwordTextBox_TextChanged;
            passwordTextBox.Enter += passwordTextBox_Enter;
            passwordTextBox.Leave += passwordTextBox_Leave;
            // 
            // ClienteDetalle
            // 
            AcceptButton = aceptarButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelarButton;
            ClientSize = new Size(800, 450);
            Controls.Add(passwordTextBox);
            Controls.Add(telefonoTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(telefonoLabel);
            Controls.Add(idLabel);
            Controls.Add(idTextBox);
            Controls.Add(emailLabel);
            Controls.Add(emailTextBox);
            Controls.Add(apellidoLabel);
            Controls.Add(apellidoTextBox);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(nombreLabel);
            Controls.Add(nombreTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ClienteDetalle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cliente";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label idLabel;
        private TextBox idTextBox;
        private Label emailLabel;
        private TextBox emailTextBox;
        private Label apellidoLabel;
        private TextBox apellidoTextBox;
        private Button cancelarButton;
        private Button aceptarButton;
        private Label nombreLabel;
        private TextBox nombreTextBox;
        private Label telefonoLabel;
        private Label passwordLabel;
        private ErrorProvider errorProvider;
        private TextBox passwordTextBox;
        private TextBox telefonoTextBox;
    }
}