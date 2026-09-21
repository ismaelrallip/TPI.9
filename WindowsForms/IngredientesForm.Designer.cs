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
            dataGridViewIngredientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewIngredientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewIngredientes.Location = new Point(60, 203);
            dataGridViewIngredientes.Margin = new Padding(2, 2, 2, 2);
            dataGridViewIngredientes.MultiSelect = false;
            dataGridViewIngredientes.Name = "dataGridViewIngredientes";
            dataGridViewIngredientes.ReadOnly = true;
            dataGridViewIngredientes.RowHeadersWidth = 62;
            dataGridViewIngredientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewIngredientes.Size = new Size(794, 415);
            dataGridViewIngredientes.TabIndex = 0;
            dataGridViewIngredientes.CellContentDoubleClick += dataGridViewIngredientes_CellContentDoubleClick;
            // 
            // textBoxBuscarIngredientes
            // 
            textBoxBuscarIngredientes.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxBuscarIngredientes.Location = new Point(60, 82);
            textBoxBuscarIngredientes.Margin = new Padding(2, 2, 2, 2);
            textBoxBuscarIngredientes.Name = "textBoxBuscarIngredientes";
            textBoxBuscarIngredientes.PlaceholderText = "Ingrediente...";
            textBoxBuscarIngredientes.Size = new Size(399, 34);
            textBoxBuscarIngredientes.TabIndex = 1;
            textBoxBuscarIngredientes.TextChanged += textBoxBuscarIngredientes_TextChanged;
            // 
            // buttonAddIngrediente
            // 
            buttonAddIngrediente.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            buttonAddIngrediente.Location = new Point(738, 70);
            buttonAddIngrediente.Margin = new Padding(2, 2, 2, 2);
            buttonAddIngrediente.Name = "buttonAddIngrediente";
            buttonAddIngrediente.Size = new Size(115, 42);
            buttonAddIngrediente.TabIndex = 2;
            buttonAddIngrediente.Text = "AGREGAR";
            buttonAddIngrediente.UseVisualStyleBackColor = true;
            buttonAddIngrediente.Click += buttonAddIngrediente_Click;
            // 
            // IngredientesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 721);
            Controls.Add(buttonAddIngrediente);
            Controls.Add(textBoxBuscarIngredientes);
            Controls.Add(dataGridViewIngredientes);
            Margin = new Padding(2, 2, 2, 2);
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