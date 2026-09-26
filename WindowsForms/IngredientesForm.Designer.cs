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
            buttonVerResumen = new Button();
            buttonUpdateIngrediente = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIngredientes).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewIngredientes
            // 
            dataGridViewIngredientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewIngredientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewIngredientes.Location = new Point(64, 146);
            dataGridViewIngredientes.Margin = new Padding(2);
            dataGridViewIngredientes.MultiSelect = false;
            dataGridViewIngredientes.Name = "dataGridViewIngredientes";
            dataGridViewIngredientes.ReadOnly = true;
            dataGridViewIngredientes.RowHeadersWidth = 62;
            dataGridViewIngredientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewIngredientes.Size = new Size(1072, 570);
            dataGridViewIngredientes.TabIndex = 0;
            // 
            // textBoxBuscarIngredientes
            // 
            textBoxBuscarIngredientes.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxBuscarIngredientes.Location = new Point(89, 50);
            textBoxBuscarIngredientes.Margin = new Padding(2);
            textBoxBuscarIngredientes.Name = "textBoxBuscarIngredientes";
            textBoxBuscarIngredientes.PlaceholderText = "Ingrediente...";
            textBoxBuscarIngredientes.Size = new Size(328, 31);
            textBoxBuscarIngredientes.TabIndex = 1;
            textBoxBuscarIngredientes.TextChanged += textBoxBuscarIngredientes_TextChanged;
            // 
            // buttonAddIngrediente
            // 
            buttonAddIngrediente.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold);
            buttonAddIngrediente.Location = new Point(1021, 775);
            buttonAddIngrediente.Margin = new Padding(2);
            buttonAddIngrediente.Name = "buttonAddIngrediente";
            buttonAddIngrediente.Size = new Size(115, 36);
            buttonAddIngrediente.TabIndex = 2;
            buttonAddIngrediente.Text = "AGREGAR";
            buttonAddIngrediente.UseVisualStyleBackColor = true;
            buttonAddIngrediente.Click += buttonAddIngrediente_Click;
            // 
            // buttonVerResumen
            // 
            buttonVerResumen.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold);
            buttonVerResumen.Location = new Point(702, 775);
            buttonVerResumen.Margin = new Padding(2);
            buttonVerResumen.Name = "buttonVerResumen";
            buttonVerResumen.Size = new Size(154, 36);
            buttonVerResumen.TabIndex = 8;
            buttonVerResumen.Text = "VER RESUMEN";
            buttonVerResumen.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateIngrediente
            // 
            buttonUpdateIngrediente.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold);
            buttonUpdateIngrediente.Location = new Point(877, 775);
            buttonUpdateIngrediente.Margin = new Padding(2);
            buttonUpdateIngrediente.Name = "buttonUpdateIngrediente";
            buttonUpdateIngrediente.Size = new Size(128, 36);
            buttonUpdateIngrediente.TabIndex = 7;
            buttonUpdateIngrediente.Text = "MODIFICAR";
            buttonUpdateIngrediente.UseVisualStyleBackColor = true;
            buttonUpdateIngrediente.Click += buttonUpdateHamburguesa_Click;
            // 
            // IngredientesForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 901);
            Controls.Add(buttonVerResumen);
            Controls.Add(buttonUpdateIngrediente);
            Controls.Add(buttonAddIngrediente);
            Controls.Add(textBoxBuscarIngredientes);
            Controls.Add(dataGridViewIngredientes);
            Margin = new Padding(2);
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
        private Button buttonVerResumen;
        private Button buttonUpdateIngrediente;
    }
}