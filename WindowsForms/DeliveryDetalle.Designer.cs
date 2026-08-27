namespace WindowsForms
{
    partial class DeliveryDetalle
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
            dniTextBox = new TextBox();
            telefonoTextBox = new TextBox();
            dniLabel = new Label();
            telefonoLabel = new Label();
            idLabel = new Label();
            idTextBox = new TextBox();
            apellidoLabel = new Label();
            apellidoTextBox = new TextBox();
            cancelarButton = new Button();
            aceptarButton = new Button();
            nombreLabel = new Label();
            nombreTextBox = new TextBox();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // dniTextBox
            // 
            dniTextBox.Location = new Point(302, 252);
            dniTextBox.Margin = new Padding(2);
            dniTextBox.Name = "dniTextBox";
            dniTextBox.Size = new Size(235, 27);
            dniTextBox.TabIndex = 44;
            // 
            // telefonoTextBox
            // 
            telefonoTextBox.Location = new Point(302, 204);
            telefonoTextBox.Margin = new Padding(2);
            telefonoTextBox.Name = "telefonoTextBox";
            telefonoTextBox.Size = new Size(235, 27);
            telefonoTextBox.TabIndex = 43;
            // 
            // dniLabel
            // 
            dniLabel.AutoSize = true;
            dniLabel.Location = new Point(179, 252);
            dniLabel.Margin = new Padding(2, 0, 2, 0);
            dniLabel.Name = "dniLabel";
            dniLabel.Size = new Size(35, 20);
            dniLabel.TabIndex = 42;
            dniLabel.Text = "DNI";
            // 
            // telefonoLabel
            // 
            telefonoLabel.AutoSize = true;
            telefonoLabel.Location = new Point(179, 204);
            telefonoLabel.Margin = new Padding(2, 0, 2, 0);
            telefonoLabel.Name = "telefonoLabel";
            telefonoLabel.Size = new Size(67, 20);
            telefonoLabel.TabIndex = 41;
            telefonoLabel.Text = "Teléfono";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(179, 71);
            idLabel.Margin = new Padding(2, 0, 2, 0);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(22, 20);
            idLabel.TabIndex = 40;
            idLabel.Text = "Id";
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(302, 71);
            idTextBox.Margin = new Padding(2);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(125, 27);
            idTextBox.TabIndex = 31;
            idTextBox.TabStop = false;
            // 
            // apellidoLabel
            // 
            apellidoLabel.AutoSize = true;
            apellidoLabel.Location = new Point(179, 160);
            apellidoLabel.Margin = new Padding(2, 0, 2, 0);
            apellidoLabel.Name = "apellidoLabel";
            apellidoLabel.Size = new Size(66, 20);
            apellidoLabel.TabIndex = 38;
            apellidoLabel.Text = "Apellido";
            // 
            // apellidoTextBox
            // 
            apellidoTextBox.Location = new Point(302, 160);
            apellidoTextBox.Margin = new Padding(2);
            apellidoTextBox.Name = "apellidoTextBox";
            apellidoTextBox.Size = new Size(125, 27);
            apellidoTextBox.TabIndex = 33;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(530, 350);
            cancelarButton.Margin = new Padding(2);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(92, 29);
            cancelarButton.TabIndex = 37;
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
            aceptarButton.TabIndex = 36;
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
            nombreLabel.TabIndex = 34;
            nombreLabel.Text = "Nombre";
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(302, 118);
            nombreTextBox.Margin = new Padding(2);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(125, 27);
            nombreTextBox.TabIndex = 32;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // DeliveryDetalle
            // 
            AcceptButton = aceptarButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelarButton;
            ClientSize = new Size(800, 450);
            Controls.Add(dniTextBox);
            Controls.Add(telefonoTextBox);
            Controls.Add(dniLabel);
            Controls.Add(telefonoLabel);
            Controls.Add(idLabel);
            Controls.Add(idTextBox);
            Controls.Add(apellidoLabel);
            Controls.Add(apellidoTextBox);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(nombreLabel);
            Controls.Add(nombreTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DeliveryDetalle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Delivery";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox dniTextBox;
        private TextBox telefonoTextBox;
        private Label dniLabel;
        private Label telefonoLabel;
        private Label idLabel;
        private TextBox idTextBox;
        private Label apellidoLabel;
        private TextBox apellidoTextBox;
        private Button cancelarButton;
        private Button aceptarButton;
        private Label nombreLabel;
        private TextBox nombreTextBox;
        private ErrorProvider errorProvider;
    }
}