namespace WindowsForms
{
    partial class IngredientesForm
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
            dataGridViewIngredientes = new DataGridView();
            textBoxBuscarIngredientes = new TextBox();
            buttonAddIngrediente = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIngredientes).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewIngredientes
            // 
            dataGridViewIngredientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewIngredientes.Location = new Point(75, 254);
            dataGridViewIngredientes.Name = "dataGridViewIngredientes";
            dataGridViewIngredientes.RowHeadersWidth = 62;
            dataGridViewIngredientes.Size = new Size(992, 441);
            dataGridViewIngredientes.TabIndex = 0;
            // 
            // textBoxBuscarIngredientes
            // 
            textBoxBuscarIngredientes.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxBuscarIngredientes.Location = new Point(75, 102);
            textBoxBuscarIngredientes.Name = "textBoxBuscarIngredientes";
            textBoxBuscarIngredientes.PlaceholderText = "Ingrediente...";
            textBoxBuscarIngredientes.Size = new Size(498, 39);
            textBoxBuscarIngredientes.TabIndex = 1;
            textBoxBuscarIngredientes.TextChanged += textBoxBuscarIngredientes_TextChanged;
            // 
            // buttonAddIngrediente
            // 
            buttonAddIngrediente.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            buttonAddIngrediente.Location = new Point(923, 88);
            buttonAddIngrediente.Name = "buttonAddIngrediente";
            buttonAddIngrediente.Size = new Size(144, 53);
            buttonAddIngrediente.TabIndex = 2;
            buttonAddIngrediente.Text = "AGREGAR";
            buttonAddIngrediente.UseVisualStyleBackColor = true;
            buttonAddIngrediente.Click += buttonAddIngrediente_Click;
            // 
            // IngredientesForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1168, 830);
            Controls.Add(buttonAddIngrediente);
            Controls.Add(textBoxBuscarIngredientes);
            Controls.Add(dataGridViewIngredientes);
            Name = "IngredientesForm";
            Text = "Ingredientes";
            Load += IngredientesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewIngredientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewIngredientes;
        private TextBox textBoxBuscarIngredientes;
        private Button buttonAddIngrediente;
    }
}