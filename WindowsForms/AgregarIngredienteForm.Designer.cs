namespace WindowsForms
{
    partial class AgregarIngredienteForm
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
            textBoxNombre = new TextBox();
            textBoxDescripcion = new TextBox();
            numericUpDownStock = new NumericUpDown();
            labelStock = new Label();
            buttonAddIngrediente = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStock).BeginInit();
            SuspendLayout();
            // 
            // textBoxNombre
            // 
            textBoxNombre.Font = new Font("Segoe UI", 12F);
            textBoxNombre.Location = new Point(29, 37);
            textBoxNombre.Margin = new Padding(2, 2, 2, 2);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.PlaceholderText = "Nombre...";
            textBoxNombre.Size = new Size(208, 34);
            textBoxNombre.TabIndex = 0;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Font = new Font("Segoe UI", 12F);
            textBoxDescripcion.Location = new Point(29, 110);
            textBoxDescripcion.Margin = new Padding(2, 2, 2, 2);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.PlaceholderText = "Descripcion...";
            textBoxDescripcion.Size = new Size(208, 34);
            textBoxDescripcion.TabIndex = 1;
            // 
            // numericUpDownStock
            // 
            numericUpDownStock.Font = new Font("Segoe UI", 12F);
            numericUpDownStock.Location = new Point(29, 198);
            numericUpDownStock.Margin = new Padding(2, 2, 2, 2);
            numericUpDownStock.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownStock.Name = "numericUpDownStock";
            numericUpDownStock.Size = new Size(207, 34);
            numericUpDownStock.TabIndex = 3;
            // 
            // labelStock
            // 
            labelStock.AutoSize = true;
            labelStock.Font = new Font("Segoe UI", 12F);
            labelStock.Location = new Point(25, 170);
            labelStock.Margin = new Padding(2, 0, 2, 0);
            labelStock.Name = "labelStock";
            labelStock.Size = new Size(64, 28);
            labelStock.TabIndex = 4;
            labelStock.Text = "Stock:";
            // 
            // buttonAddIngrediente
            // 
            buttonAddIngrediente.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            buttonAddIngrediente.Location = new Point(539, 328);
            buttonAddIngrediente.Margin = new Padding(2, 2, 2, 2);
            buttonAddIngrediente.Name = "buttonAddIngrediente";
            buttonAddIngrediente.Size = new Size(115, 42);
            buttonAddIngrediente.TabIndex = 5;
            buttonAddIngrediente.Text = "AGREGAR";
            buttonAddIngrediente.UseVisualStyleBackColor = true;
            buttonAddIngrediente.Click += buttonAddIngrediente_Click;
            // 
            // AgregarIngredienteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 433);
            Controls.Add(buttonAddIngrediente);
            Controls.Add(labelStock);
            Controls.Add(numericUpDownStock);
            Controls.Add(textBoxDescripcion);
            Controls.Add(textBoxNombre);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2, 2, 2, 2);
            Name = "AgregarIngredienteForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AgregarIngredienteForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDownStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxNombre;
        private TextBox textBoxDescripcion;
        private NumericUpDown numericUpDownStock;
        private Label labelStock;
        private Button buttonAddIngrediente;
    }
}