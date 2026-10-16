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
            confirmarPasswordTextBox = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(157, 53);
            idLabel.Margin = new Padding(2, 0, 2, 0);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(17, 15);
            idLabel.TabIndex = 26;
            idLabel.Text = "Id";
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(264, 53);
            idTextBox.Margin = new Padding(2);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(110, 23);
            idTextBox.TabIndex = 14;
            idTextBox.TabStop = false;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(157, 156);
            emailLabel.Margin = new Padding(2, 0, 2, 0);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(36, 15);
            emailLabel.TabIndex = 24;
            emailLabel.Text = "Email";
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(264, 156);
            emailTextBox.Margin = new Padding(2);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(206, 23);
            emailTextBox.TabIndex = 19;
            // 
            // apellidoLabel
            // 
            apellidoLabel.AutoSize = true;
            apellidoLabel.Location = new Point(157, 120);
            apellidoLabel.Margin = new Padding(2, 0, 2, 0);
            apellidoLabel.Name = "apellidoLabel";
            apellidoLabel.Size = new Size(51, 15);
            apellidoLabel.TabIndex = 23;
            apellidoLabel.Text = "Apellido";
            // 
            // apellidoTextBox
            // 
            apellidoTextBox.Location = new Point(264, 120);
            apellidoTextBox.Margin = new Padding(2);
            apellidoTextBox.Name = "apellidoTextBox";
            apellidoTextBox.Size = new Size(110, 23);
            apellidoTextBox.TabIndex = 17;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(466, 287);
            cancelarButton.Margin = new Padding(2);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(80, 22);
            cancelarButton.TabIndex = 22;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(374, 287);
            aceptarButton.Margin = new Padding(2);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(80, 22);
            aceptarButton.TabIndex = 20;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(157, 88);
            nombreLabel.Margin = new Padding(2, 0, 2, 0);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(51, 15);
            nombreLabel.TabIndex = 18;
            nombreLabel.Text = "Nombre";
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(264, 88);
            nombreTextBox.Margin = new Padding(2);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(110, 23);
            nombreTextBox.TabIndex = 16;
            // 
            // telefonoLabel
            // 
            telefonoLabel.AutoSize = true;
            telefonoLabel.Location = new Point(157, 188);
            telefonoLabel.Margin = new Padding(2, 0, 2, 0);
            telefonoLabel.Name = "telefonoLabel";
            telefonoLabel.Size = new Size(53, 15);
            telefonoLabel.TabIndex = 27;
            telefonoLabel.Text = "Teléfono";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(157, 217);
            passwordLabel.Margin = new Padding(2, 0, 2, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(67, 15);
            passwordLabel.TabIndex = 28;
            passwordLabel.Text = "Contraseña";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // telefonoTextBox
            // 
            telefonoTextBox.Location = new Point(264, 188);
            telefonoTextBox.Margin = new Padding(2);
            telefonoTextBox.Name = "telefonoTextBox";
            telefonoTextBox.Size = new Size(206, 23);
            telefonoTextBox.TabIndex = 29;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(264, 217);
            passwordTextBox.Margin = new Padding(2);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(206, 23);
            passwordTextBox.TabIndex = 30;
            // 
            // confirmarPasswordTextBox
            // 
            confirmarPasswordTextBox.Location = new Point(264, 249);
            confirmarPasswordTextBox.Margin = new Padding(2);
            confirmarPasswordTextBox.Name = "confirmarPasswordTextBox";
            confirmarPasswordTextBox.PasswordChar = '*';
            confirmarPasswordTextBox.Size = new Size(206, 23);
            confirmarPasswordTextBox.TabIndex = 32;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(129, 249);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 31;
            label1.Text = "Confirmar contraseña";
            // 
            // ClienteDetalle
            // 
            AcceptButton = aceptarButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelarButton;
            ClientSize = new Size(614, 325);
            Controls.Add(confirmarPasswordTextBox);
            Controls.Add(label1);
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
            Margin = new Padding(3, 2, 3, 2);
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
        private TextBox confirmarPasswordTextBox;
        private Label label1;
    }
}