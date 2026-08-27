namespace WindowsForms
{
    partial class ActualizarIngredienteForm
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
            buttonUpdateIngrediente = new Button();
            numericUpDownStock = new NumericUpDown();
            textBoxDescripcion = new TextBox();
            textBoxNombre = new TextBox();
            buttonDeleteIngrediente = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStock).BeginInit();
            SuspendLayout();
            // 
            // buttonUpdateIngrediente
            // 
            buttonUpdateIngrediente.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            buttonUpdateIngrediente.Location = new Point(247, 444);
            buttonUpdateIngrediente.Name = "buttonUpdateIngrediente";
            buttonUpdateIngrediente.Size = new Size(195, 53);
            buttonUpdateIngrediente.TabIndex = 9;
            buttonUpdateIngrediente.Text = "ACTUALIZAR";
            buttonUpdateIngrediente.UseVisualStyleBackColor = true;
            buttonUpdateIngrediente.Click += buttonUpdateIngrediente_Click;
            // 
            // numericUpDownStock
            // 
            numericUpDownStock.Font = new Font("Segoe UI", 12F);
            numericUpDownStock.Location = new Point(30, 245);
            numericUpDownStock.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownStock.Name = "numericUpDownStock";
            numericUpDownStock.Size = new Size(259, 39);
            numericUpDownStock.TabIndex = 8;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Font = new Font("Segoe UI", 12F);
            textBoxDescripcion.Location = new Point(30, 134);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.PlaceholderText = "Descripcion...";
            textBoxDescripcion.Size = new Size(259, 39);
            textBoxDescripcion.TabIndex = 7;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Font = new Font("Segoe UI", 12F);
            textBoxNombre.Location = new Point(30, 43);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.PlaceholderText = "Nombre...";
            textBoxNombre.Size = new Size(259, 39);
            textBoxNombre.TabIndex = 6;
            // 
            // buttonDeleteIngrediente
            // 
            buttonDeleteIngrediente.BackColor = Color.Red;
            buttonDeleteIngrediente.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            buttonDeleteIngrediente.ForeColor = SystemColors.ButtonHighlight;
            buttonDeleteIngrediente.Location = new Point(30, 444);
            buttonDeleteIngrediente.Name = "buttonDeleteIngrediente";
            buttonDeleteIngrediente.Size = new Size(149, 53);
            buttonDeleteIngrediente.TabIndex = 19;
            buttonDeleteIngrediente.Text = "ELIMINAR";
            buttonDeleteIngrediente.UseVisualStyleBackColor = false;
            // 
            // ActualizarIngredienteForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 528);
            Controls.Add(buttonDeleteIngrediente);
            Controls.Add(buttonUpdateIngrediente);
            Controls.Add(numericUpDownStock);
            Controls.Add(textBoxDescripcion);
            Controls.Add(textBoxNombre);
            Name = "ActualizarIngredienteForm";
            Text = "ActualizarIngredienteForm";
            Load += ActualizarIngredienteForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonUpdateIngrediente;
        private NumericUpDown numericUpDownStock;
        private TextBox textBoxDescripcion;
        private TextBox textBoxNombre;
        private Button buttonDeleteIngrediente;
    }
}