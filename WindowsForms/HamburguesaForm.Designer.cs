namespace WindowsForms
{
    partial class HamburguesaForm
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
            dataGridViewHamburguesas = new DataGridView();
            buttonAddHamburguesa = new Button();
            textBoxBuscarHamburguesa = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHamburguesas).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewHamburguesas
            // 
            dataGridViewHamburguesas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHamburguesas.Location = new Point(45, 186);
            dataGridViewHamburguesas.MultiSelect = false;
            dataGridViewHamburguesas.Name = "dataGridViewHamburguesas";
            dataGridViewHamburguesas.ReadOnly = true;
            dataGridViewHamburguesas.RowHeadersWidth = 62;
            dataGridViewHamburguesas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewHamburguesas.Size = new Size(992, 441);
            dataGridViewHamburguesas.TabIndex = 1;
            dataGridViewHamburguesas.CellContentDoubleClick += dataGridViewHamburguesas_CellContentDoubleClick;
            // 
            // buttonAddHamburguesa
            // 
            buttonAddHamburguesa.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            buttonAddHamburguesa.Location = new Point(893, 76);
            buttonAddHamburguesa.Name = "buttonAddHamburguesa";
            buttonAddHamburguesa.Size = new Size(144, 53);
            buttonAddHamburguesa.TabIndex = 4;
            buttonAddHamburguesa.Text = "AGREGAR";
            buttonAddHamburguesa.UseVisualStyleBackColor = true;
            buttonAddHamburguesa.Click += buttonAddHamburguesa_Click;
            // 
            // textBoxBuscarHamburguesa
            // 
            textBoxBuscarHamburguesa.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxBuscarHamburguesa.Location = new Point(45, 90);
            textBoxBuscarHamburguesa.Name = "textBoxBuscarHamburguesa";
            textBoxBuscarHamburguesa.PlaceholderText = "Hamburguesa...";
            textBoxBuscarHamburguesa.Size = new Size(498, 39);
            textBoxBuscarHamburguesa.TabIndex = 3;
            textBoxBuscarHamburguesa.TextChanged += textBoxBuscarHamburguesa_TextChanged;
            // 
            // HamburguesaForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1131, 675);
            Controls.Add(buttonAddHamburguesa);
            Controls.Add(textBoxBuscarHamburguesa);
            Controls.Add(dataGridViewHamburguesas);
            Name = "HamburguesaForm";
            Text = "HamburguesaForm";
            Load += HamburguesaForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewHamburguesas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewHamburguesas;
        private Button buttonAddHamburguesa;
        private TextBox textBoxBuscarHamburguesa;
    }
}