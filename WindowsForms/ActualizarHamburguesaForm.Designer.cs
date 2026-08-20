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
            SuspendLayout();
            // 
            // buttonUpdateHamburguesa
            // 
            buttonUpdateHamburguesa.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            buttonUpdateHamburguesa.Location = new Point(294, 532);
            buttonUpdateHamburguesa.Name = "buttonUpdateHamburguesa";
            buttonUpdateHamburguesa.Size = new Size(195, 53);
            buttonUpdateHamburguesa.TabIndex = 13;
            buttonUpdateHamburguesa.Text = "ACTUALIZAR";
            buttonUpdateHamburguesa.UseVisualStyleBackColor = true;
            buttonUpdateHamburguesa.Click += buttonUpdateHamburguesa_Click;
            // 
            // checkedListBoxIngredientes
            // 
            checkedListBoxIngredientes.FormattingEnabled = true;
            checkedListBoxIngredientes.Location = new Point(37, 285);
            checkedListBoxIngredientes.Name = "checkedListBoxIngredientes";
            checkedListBoxIngredientes.Size = new Size(259, 200);
            checkedListBoxIngredientes.TabIndex = 17;
            // 
            // textBoxPrecio
            // 
            textBoxPrecio.Font = new Font("Segoe UI", 12F);
            textBoxPrecio.Location = new Point(37, 198);
            textBoxPrecio.Name = "textBoxPrecio";
            textBoxPrecio.PlaceholderText = "Precio...";
            textBoxPrecio.Size = new Size(259, 39);
            textBoxPrecio.TabIndex = 16;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Font = new Font("Segoe UI", 12F);
            textBoxDescripcion.Location = new Point(37, 115);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.PlaceholderText = "Descripcion...";
            textBoxDescripcion.Size = new Size(259, 39);
            textBoxDescripcion.TabIndex = 15;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Font = new Font("Segoe UI", 12F);
            textBoxNombre.Location = new Point(37, 24);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.PlaceholderText = "Nombre...";
            textBoxNombre.Size = new Size(259, 39);
            textBoxNombre.TabIndex = 14;
            // 
            // ActualizarHamburguesaForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 608);
            Controls.Add(checkedListBoxIngredientes);
            Controls.Add(textBoxPrecio);
            Controls.Add(textBoxDescripcion);
            Controls.Add(textBoxNombre);
            Controls.Add(buttonUpdateHamburguesa);
            Name = "ActualizarHamburguesaForm";
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
    }
}