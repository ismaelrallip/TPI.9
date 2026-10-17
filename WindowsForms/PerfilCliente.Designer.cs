namespace WindowsForms
{
    partial class PerfilCliente
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
            nombreLabel = new Label();
            nombreTextBox = new TextBox();
            apellidoLabel = new Label();
            emailLabel = new Label();
            telefonoLabel = new Label();
            ApellidoTextBox = new TextBox();
            emailTextBox = new TextBox();
            telefonoTextBox = new TextBox();
            cambiarContraseñaButton = new Button();
            eliminarButton = new Button();
            contraseñaActualLabel = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            ConfirmarContraseñaLabel = new Label();
            aceptarButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(48, 27);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(51, 15);
            nombreLabel.TabIndex = 0;
            nombreLabel.Text = "Nombre";
            // 
            // nombreTextBox
            // 
            nombreTextBox.Enabled = false;
            nombreTextBox.Location = new Point(178, 27);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(218, 23);
            nombreTextBox.TabIndex = 1;
            // 
            // apellidoLabel
            // 
            apellidoLabel.AutoSize = true;
            apellidoLabel.Location = new Point(48, 64);
            apellidoLabel.Name = "apellidoLabel";
            apellidoLabel.Size = new Size(51, 15);
            apellidoLabel.TabIndex = 2;
            apellidoLabel.Text = "Apellido";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(48, 107);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(36, 15);
            emailLabel.TabIndex = 3;
            emailLabel.Text = "Email";
            // 
            // telefonoLabel
            // 
            telefonoLabel.AutoSize = true;
            telefonoLabel.Location = new Point(48, 146);
            telefonoLabel.Name = "telefonoLabel";
            telefonoLabel.Size = new Size(53, 15);
            telefonoLabel.TabIndex = 4;
            telefonoLabel.Text = "Teléfono";
            // 
            // ApellidoTextBox
            // 
            ApellidoTextBox.Enabled = false;
            ApellidoTextBox.Location = new Point(178, 64);
            ApellidoTextBox.Name = "ApellidoTextBox";
            ApellidoTextBox.Size = new Size(218, 23);
            ApellidoTextBox.TabIndex = 5;
            // 
            // emailTextBox
            // 
            emailTextBox.Enabled = false;
            emailTextBox.Location = new Point(178, 107);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(218, 23);
            emailTextBox.TabIndex = 6;
            // 
            // telefonoTextBox
            // 
            telefonoTextBox.Enabled = false;
            telefonoTextBox.Location = new Point(178, 146);
            telefonoTextBox.Name = "telefonoTextBox";
            telefonoTextBox.Size = new Size(218, 23);
            telefonoTextBox.TabIndex = 7;
            // 
            // cambiarContraseñaButton
            // 
            cambiarContraseñaButton.Location = new Point(402, 340);
            cambiarContraseñaButton.Name = "cambiarContraseñaButton";
            cambiarContraseñaButton.Size = new Size(137, 23);
            cambiarContraseñaButton.TabIndex = 9;
            cambiarContraseñaButton.Text = "Cambiar Contraseña";
            cambiarContraseñaButton.UseVisualStyleBackColor = true;
            cambiarContraseñaButton.Click += cambiarContraseñaButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.BackColor = Color.Red;
            eliminarButton.ForeColor = SystemColors.ControlLightLight;
            eliminarButton.Location = new Point(545, 340);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(102, 23);
            eliminarButton.TabIndex = 10;
            eliminarButton.Text = "Eliminar Perfil";
            eliminarButton.UseVisualStyleBackColor = false;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // contraseñaActualLabel
            // 
            contraseñaActualLabel.AutoSize = true;
            contraseñaActualLabel.Location = new Point(48, 188);
            contraseñaActualLabel.Name = "contraseñaActualLabel";
            contraseñaActualLabel.Size = new Size(102, 15);
            contraseñaActualLabel.TabIndex = 11;
            contraseñaActualLabel.Text = "Contraseña actual";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 230);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 12;
            label1.Text = "Nueva Contraseña";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(178, 188);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(218, 23);
            textBox1.TabIndex = 13;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(178, 230);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(218, 23);
            textBox2.TabIndex = 14;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(178, 273);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(218, 23);
            textBox3.TabIndex = 15;
            // 
            // ConfirmarContraseñaLabel
            // 
            ConfirmarContraseñaLabel.AutoSize = true;
            ConfirmarContraseñaLabel.Location = new Point(46, 273);
            ConfirmarContraseñaLabel.Name = "ConfirmarContraseñaLabel";
            ConfirmarContraseñaLabel.Size = new Size(124, 15);
            ConfirmarContraseñaLabel.TabIndex = 16;
            ConfirmarContraseñaLabel.Text = "Confirmar Contraseña";
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(178, 302);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(94, 23);
            aceptarButton.TabIndex = 17;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(311, 302);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(85, 23);
            cancelButton.TabIndex = 18;
            cancelButton.Text = "Cancelar";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // PerfilCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(659, 375);
            Controls.Add(cancelButton);
            Controls.Add(aceptarButton);
            Controls.Add(ConfirmarContraseñaLabel);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(contraseñaActualLabel);
            Controls.Add(eliminarButton);
            Controls.Add(cambiarContraseñaButton);
            Controls.Add(telefonoTextBox);
            Controls.Add(emailTextBox);
            Controls.Add(ApellidoTextBox);
            Controls.Add(telefonoLabel);
            Controls.Add(emailLabel);
            Controls.Add(apellidoLabel);
            Controls.Add(nombreTextBox);
            Controls.Add(nombreLabel);
            // Ocultar controles de contraseña por defecto
            contraseñaActualLabel.Visible = false;
            label1.Visible = false;
            ConfirmarContraseñaLabel.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            aceptarButton.Visible = false;
            cancelButton.Visible = false;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PerfilCliente";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PerfilCliente";
            this.Load += PerfilCliente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nombreLabel;
        private TextBox nombreTextBox;
        private Label apellidoLabel;
        private Label emailLabel;
        private Label telefonoLabel;
        private TextBox ApellidoTextBox;
        private TextBox emailTextBox;
        private TextBox telefonoTextBox;
        private Button cambiarContraseñaButton;
        private Button eliminarButton;
        private Label contraseñaActualLabel;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label ConfirmarContraseñaLabel;
        private Button aceptarButton;
        private Button cancelButton;
    }
}