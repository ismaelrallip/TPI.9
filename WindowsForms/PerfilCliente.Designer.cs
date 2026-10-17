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
            editarPerfilButton = new Button();
            SuspendLayout();
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(55, 36);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(64, 20);
            nombreLabel.TabIndex = 0;
            nombreLabel.Text = "Nombre";
            // 
            // nombreTextBox
            // 
            nombreTextBox.Enabled = false;
            nombreTextBox.Location = new Point(203, 36);
            nombreTextBox.Margin = new Padding(3, 4, 3, 4);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(249, 27);
            nombreTextBox.TabIndex = 1;
            // 
            // apellidoLabel
            // 
            apellidoLabel.AutoSize = true;
            apellidoLabel.Location = new Point(55, 85);
            apellidoLabel.Name = "apellidoLabel";
            apellidoLabel.Size = new Size(66, 20);
            apellidoLabel.TabIndex = 2;
            apellidoLabel.Text = "Apellido";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(55, 143);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(46, 20);
            emailLabel.TabIndex = 3;
            emailLabel.Text = "Email";
            // 
            // telefonoLabel
            // 
            telefonoLabel.AutoSize = true;
            telefonoLabel.Location = new Point(55, 195);
            telefonoLabel.Name = "telefonoLabel";
            telefonoLabel.Size = new Size(67, 20);
            telefonoLabel.TabIndex = 4;
            telefonoLabel.Text = "Teléfono";
            // 
            // ApellidoTextBox
            // 
            ApellidoTextBox.Enabled = false;
            ApellidoTextBox.Location = new Point(203, 85);
            ApellidoTextBox.Margin = new Padding(3, 4, 3, 4);
            ApellidoTextBox.Name = "ApellidoTextBox";
            ApellidoTextBox.Size = new Size(249, 27);
            ApellidoTextBox.TabIndex = 5;
            // 
            // emailTextBox
            // 
            emailTextBox.Enabled = false;
            emailTextBox.Location = new Point(203, 143);
            emailTextBox.Margin = new Padding(3, 4, 3, 4);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(249, 27);
            emailTextBox.TabIndex = 6;
            // 
            // telefonoTextBox
            // 
            telefonoTextBox.Enabled = false;
            telefonoTextBox.Location = new Point(203, 195);
            telefonoTextBox.Margin = new Padding(3, 4, 3, 4);
            telefonoTextBox.Name = "telefonoTextBox";
            telefonoTextBox.Size = new Size(249, 27);
            telefonoTextBox.TabIndex = 7;
            // 
            // cambiarContraseñaButton
            // 
            cambiarContraseñaButton.Location = new Point(237, 453);
            cambiarContraseñaButton.Margin = new Padding(3, 4, 3, 4);
            cambiarContraseñaButton.Name = "cambiarContraseñaButton";
            cambiarContraseñaButton.Size = new Size(157, 31);
            cambiarContraseñaButton.TabIndex = 9;
            cambiarContraseñaButton.Text = "Cambiar Contraseña";
            cambiarContraseñaButton.UseVisualStyleBackColor = true;
            cambiarContraseñaButton.Click += cambiarContraseñaButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.BackColor = Color.Red;
            eliminarButton.ForeColor = SystemColors.ControlLightLight;
            eliminarButton.Location = new Point(456, 453);
            eliminarButton.Margin = new Padding(3, 4, 3, 4);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(117, 31);
            eliminarButton.TabIndex = 10;
            eliminarButton.Text = "Eliminar Perfil";
            eliminarButton.UseVisualStyleBackColor = false;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // contraseñaActualLabel
            // 
            contraseñaActualLabel.AutoSize = true;
            contraseñaActualLabel.Location = new Point(55, 251);
            contraseñaActualLabel.Name = "contraseñaActualLabel";
            contraseñaActualLabel.Size = new Size(127, 20);
            contraseñaActualLabel.TabIndex = 11;
            contraseñaActualLabel.Text = "Contraseña actual";
            contraseñaActualLabel.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 307);
            label1.Name = "label1";
            label1.Size = new Size(129, 20);
            label1.TabIndex = 12;
            label1.Text = "Nueva Contraseña";
            label1.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(203, 251);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(249, 27);
            textBox1.TabIndex = 13;
            textBox1.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(203, 307);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(249, 27);
            textBox2.TabIndex = 14;
            textBox2.Visible = false;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(203, 364);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(249, 27);
            textBox3.TabIndex = 15;
            textBox3.Visible = false;
            // 
            // ConfirmarContraseñaLabel
            // 
            ConfirmarContraseñaLabel.AutoSize = true;
            ConfirmarContraseñaLabel.Location = new Point(53, 364);
            ConfirmarContraseñaLabel.Name = "ConfirmarContraseñaLabel";
            ConfirmarContraseñaLabel.Size = new Size(153, 20);
            ConfirmarContraseñaLabel.TabIndex = 16;
            ConfirmarContraseñaLabel.Text = "Confirmar Contraseña";
            ConfirmarContraseñaLabel.Visible = false;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(203, 403);
            aceptarButton.Margin = new Padding(3, 4, 3, 4);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(107, 31);
            aceptarButton.TabIndex = 17;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Visible = false;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(355, 403);
            cancelButton.Margin = new Padding(3, 4, 3, 4);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(97, 31);
            cancelButton.TabIndex = 18;
            cancelButton.Text = "Cancelar";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Visible = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // editarPerfilButton
            // 
            editarPerfilButton.Location = new Point(25, 453);
            editarPerfilButton.Margin = new Padding(3, 4, 3, 4);
            editarPerfilButton.Name = "editarPerfilButton";
            editarPerfilButton.Size = new Size(157, 31);
            editarPerfilButton.TabIndex = 19;
            editarPerfilButton.Text = "Editar Datos";
            editarPerfilButton.UseVisualStyleBackColor = true;
            editarPerfilButton.Click += editarPerfilButton_Click;
            // 
            // PerfilCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(610, 500);
            Controls.Add(editarPerfilButton);
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
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PerfilCliente";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PerfilCliente";
            Load += PerfilCliente_Load;
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
        private Button editarPerfilButton;
    }
}