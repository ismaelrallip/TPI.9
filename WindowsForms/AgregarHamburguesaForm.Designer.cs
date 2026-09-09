namespace WindowsForms
{
    partial class AgregarHamburguesaForm
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
            buttonAddHamburguesa = new Button();
            textBoxDescripcion = new TextBox();
            textBoxNombre = new TextBox();
            textBoxPrecio = new TextBox();
            checkedListBoxIngredientes = new CheckedListBox();
            SuspendLayout();
            // 
            // buttonAddHamburguesa
            // 
            buttonAddHamburguesa.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            buttonAddHamburguesa.Location = new Point(337, 530);
            buttonAddHamburguesa.Name = "buttonAddHamburguesa";
            buttonAddHamburguesa.Size = new Size(144, 53);
            buttonAddHamburguesa.TabIndex = 8;
            buttonAddHamburguesa.Text = "AGREGAR";
            buttonAddHamburguesa.UseVisualStyleBackColor = true;
            buttonAddHamburguesa.Click += buttonAddHamburguesa_Click;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Font = new Font("Segoe UI", 12F);
            textBoxDescripcion.Location = new Point(38, 147);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.PlaceholderText = "Descripcion...";
            textBoxDescripcion.Size = new Size(259, 39);
            textBoxDescripcion.TabIndex = 7;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Font = new Font("Segoe UI", 12F);
            textBoxNombre.Location = new Point(38, 56);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.PlaceholderText = "Nombre...";
            textBoxNombre.Size = new Size(259, 39);
            textBoxNombre.TabIndex = 6;
            // 
            // textBoxPrecio
            // 
            textBoxPrecio.Font = new Font("Segoe UI", 12F);
            textBoxPrecio.Location = new Point(38, 230);
            textBoxPrecio.Name = "textBoxPrecio";
            textBoxPrecio.PlaceholderText = "Precio...";
            textBoxPrecio.Size = new Size(259, 39);
            textBoxPrecio.TabIndex = 9;
            // 
            // checkedListBoxIngredientes
            // 
            checkedListBoxIngredientes.FormattingEnabled = true;
            checkedListBoxIngredientes.Location = new Point(38, 317);
            checkedListBoxIngredientes.Name = "checkedListBoxIngredientes";
            checkedListBoxIngredientes.Size = new Size(259, 200);
            checkedListBoxIngredientes.TabIndex = 10;
            // 
            // AgregarHamburguesaForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(553, 646);
            Controls.Add(checkedListBoxIngredientes);
            Controls.Add(textBoxPrecio);
            Controls.Add(buttonAddHamburguesa);
            Controls.Add(textBoxDescripcion);
            Controls.Add(textBoxNombre);
            Name = "AgregarHamburguesaForm";
            Text = "AgregarHamburguesaForm";
            Load += AgregarHamburguesaForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAddHamburguesa;
        private TextBox textBoxDescripcion;
        private TextBox textBoxNombre;
        private TextBox textBoxPrecio;
        private CheckedListBox checkedListBoxIngredientes;
    }
}