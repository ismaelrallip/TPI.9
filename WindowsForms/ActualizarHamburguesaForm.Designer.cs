namespace WindowsForms
{
    partial class ActualizarHamburguesaForm
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
            buttonUpdateHamburguesa = new Button();
            checkedListBoxIngredientes = new CheckedListBox();
            textBoxPrecio = new TextBox();
            textBoxDescripcion = new TextBox();
            textBoxNombre = new TextBox();
            buttonDeleteHamburguesa = new Button();
            SuspendLayout();
            // 
            // buttonUpdateHamburguesa
            // 
            buttonUpdateHamburguesa.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            buttonUpdateHamburguesa.Location = new Point(258, 478);
            buttonUpdateHamburguesa.Margin = new Padding(2);
            buttonUpdateHamburguesa.Name = "buttonUpdateHamburguesa";
            buttonUpdateHamburguesa.Size = new Size(195, 52);
            buttonUpdateHamburguesa.TabIndex = 13;
            buttonUpdateHamburguesa.Text = "ACTUALIZAR";
            buttonUpdateHamburguesa.UseVisualStyleBackColor = true;
            buttonUpdateHamburguesa.Click += buttonUpdateHamburguesa_Click;
            // 
            // checkedListBoxIngredientes
            // 
            checkedListBoxIngredientes.FormattingEnabled = true;
            checkedListBoxIngredientes.Location = new Point(38, 285);
            checkedListBoxIngredientes.Margin = new Padding(2);
            checkedListBoxIngredientes.Name = "checkedListBoxIngredientes";
            checkedListBoxIngredientes.Size = new Size(415, 172);
            checkedListBoxIngredientes.TabIndex = 17;
            // 
            // textBoxPrecio
            // 
            textBoxPrecio.Font = new Font("Segoe UI", 12F);
            textBoxPrecio.Location = new Point(38, 198);
            textBoxPrecio.Margin = new Padding(2);
            textBoxPrecio.Name = "textBoxPrecio";
            textBoxPrecio.PlaceholderText = "Precio...";
            textBoxPrecio.Size = new Size(259, 39);
            textBoxPrecio.TabIndex = 16;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Font = new Font("Segoe UI", 12F);
            textBoxDescripcion.Location = new Point(38, 115);
            textBoxDescripcion.Margin = new Padding(2);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.PlaceholderText = "Descripcion...";
            textBoxDescripcion.Size = new Size(259, 39);
            textBoxDescripcion.TabIndex = 15;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Font = new Font("Segoe UI", 12F);
            textBoxNombre.Location = new Point(38, 24);
            textBoxNombre.Margin = new Padding(2);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.PlaceholderText = "Nombre...";
            textBoxNombre.Size = new Size(259, 39);
            textBoxNombre.TabIndex = 14;
            // 
            // buttonDeleteHamburguesa
            // 
            buttonDeleteHamburguesa.BackColor = Color.Red;
            buttonDeleteHamburguesa.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            buttonDeleteHamburguesa.ForeColor = SystemColors.ButtonHighlight;
            buttonDeleteHamburguesa.Location = new Point(27, 478);
            buttonDeleteHamburguesa.Margin = new Padding(2);
            buttonDeleteHamburguesa.Name = "buttonDeleteHamburguesa";
            buttonDeleteHamburguesa.Size = new Size(149, 52);
            buttonDeleteHamburguesa.TabIndex = 18;
            buttonDeleteHamburguesa.Text = "ELIMINAR";
            buttonDeleteHamburguesa.UseVisualStyleBackColor = false;
            buttonDeleteHamburguesa.Click += buttonDeleteHamburguesa_Click;
            // 
            // ActualizarHamburguesaForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 541);
            Controls.Add(buttonDeleteHamburguesa);
            Controls.Add(checkedListBoxIngredientes);
            Controls.Add(textBoxPrecio);
            Controls.Add(textBoxDescripcion);
            Controls.Add(textBoxNombre);
            Controls.Add(buttonUpdateHamburguesa);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2);
            Name = "ActualizarHamburguesaForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ActualizarHamburguesaForm";
            Load += ActualizarHamburguesaForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonUpdateHamburguesa;
        private CheckedListBox checkedListBoxIngredientes;
        private TextBox textBoxPrecio;
        private TextBox textBoxDescripcion;
        private TextBox textBoxNombre;
        private Button buttonDeleteHamburguesa;
    }
}