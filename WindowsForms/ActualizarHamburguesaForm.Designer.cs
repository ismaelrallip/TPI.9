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
            buttonUpdateHamburguesa.Location = new Point(495, 390);
            buttonUpdateHamburguesa.Margin = new Padding(2, 2, 2, 2);
            buttonUpdateHamburguesa.Name = "buttonUpdateHamburguesa";
            buttonUpdateHamburguesa.Size = new Size(156, 42);
            buttonUpdateHamburguesa.TabIndex = 13;
            buttonUpdateHamburguesa.Text = "ACTUALIZAR";
            buttonUpdateHamburguesa.UseVisualStyleBackColor = true;
            buttonUpdateHamburguesa.Click += buttonUpdateHamburguesa_Click;
            // 
            // checkedListBoxIngredientes
            // 
            checkedListBoxIngredientes.FormattingEnabled = true;
            checkedListBoxIngredientes.Location = new Point(30, 228);
            checkedListBoxIngredientes.Margin = new Padding(2, 2, 2, 2);
            checkedListBoxIngredientes.Name = "checkedListBoxIngredientes";
            checkedListBoxIngredientes.Size = new Size(333, 158);
            checkedListBoxIngredientes.TabIndex = 17;
            // 
            // textBoxPrecio
            // 
            textBoxPrecio.Font = new Font("Segoe UI", 12F);
            textBoxPrecio.Location = new Point(30, 158);
            textBoxPrecio.Margin = new Padding(2, 2, 2, 2);
            textBoxPrecio.Name = "textBoxPrecio";
            textBoxPrecio.PlaceholderText = "Precio...";
            textBoxPrecio.Size = new Size(208, 34);
            textBoxPrecio.TabIndex = 16;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Font = new Font("Segoe UI", 12F);
            textBoxDescripcion.Location = new Point(30, 92);
            textBoxDescripcion.Margin = new Padding(2, 2, 2, 2);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.PlaceholderText = "Descripcion...";
            textBoxDescripcion.Size = new Size(208, 34);
            textBoxDescripcion.TabIndex = 15;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Font = new Font("Segoe UI", 12F);
            textBoxNombre.Location = new Point(30, 19);
            textBoxNombre.Margin = new Padding(2, 2, 2, 2);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.PlaceholderText = "Nombre...";
            textBoxNombre.Size = new Size(208, 34);
            textBoxNombre.TabIndex = 14;
            // 
            // buttonDeleteHamburguesa
            // 
            buttonDeleteHamburguesa.BackColor = Color.Red;
            buttonDeleteHamburguesa.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            buttonDeleteHamburguesa.ForeColor = SystemColors.ButtonHighlight;
            buttonDeleteHamburguesa.Location = new Point(30, 390);
            buttonDeleteHamburguesa.Margin = new Padding(2, 2, 2, 2);
            buttonDeleteHamburguesa.Name = "buttonDeleteHamburguesa";
            buttonDeleteHamburguesa.Size = new Size(119, 42);
            buttonDeleteHamburguesa.TabIndex = 18;
            buttonDeleteHamburguesa.Text = "ELIMINAR";
            buttonDeleteHamburguesa.UseVisualStyleBackColor = false;
            buttonDeleteHamburguesa.Click += buttonDeleteHamburguesa_Click;
            // 
            // ActualizarHamburguesaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 433);
            Controls.Add(buttonDeleteHamburguesa);
            Controls.Add(checkedListBoxIngredientes);
            Controls.Add(textBoxPrecio);
            Controls.Add(textBoxDescripcion);
            Controls.Add(textBoxNombre);
            Controls.Add(buttonUpdateHamburguesa);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2, 2, 2, 2);
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