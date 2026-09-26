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
            buttonUpdateHamburguesa = new Button();
            buttonVerResumen = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHamburguesas).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewHamburguesas
            // 
            dataGridViewHamburguesas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewHamburguesas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHamburguesas.Location = new Point(64, 146);
            dataGridViewHamburguesas.Margin = new Padding(2);
            dataGridViewHamburguesas.MultiSelect = false;
            dataGridViewHamburguesas.Name = "dataGridViewHamburguesas";
            dataGridViewHamburguesas.ReadOnly = true;
            dataGridViewHamburguesas.RowHeadersWidth = 62;
            dataGridViewHamburguesas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewHamburguesas.Size = new Size(1072, 570);
            dataGridViewHamburguesas.TabIndex = 1;
            // 
            // buttonAddHamburguesa
            // 
            buttonAddHamburguesa.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold);
            buttonAddHamburguesa.Location = new Point(1021, 775);
            buttonAddHamburguesa.Margin = new Padding(2);
            buttonAddHamburguesa.Name = "buttonAddHamburguesa";
            buttonAddHamburguesa.Size = new Size(115, 36);
            buttonAddHamburguesa.TabIndex = 4;
            buttonAddHamburguesa.Text = "AGREGAR";
            buttonAddHamburguesa.UseVisualStyleBackColor = true;
            buttonAddHamburguesa.Click += buttonAddHamburguesa_Click;
            // 
            // textBoxBuscarHamburguesa
            // 
            textBoxBuscarHamburguesa.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxBuscarHamburguesa.Location = new Point(89, 50);
            textBoxBuscarHamburguesa.Margin = new Padding(2);
            textBoxBuscarHamburguesa.Name = "textBoxBuscarHamburguesa";
            textBoxBuscarHamburguesa.PlaceholderText = "Hamburguesa...";
            textBoxBuscarHamburguesa.Size = new Size(328, 31);
            textBoxBuscarHamburguesa.TabIndex = 3;
            textBoxBuscarHamburguesa.TextChanged += textBoxBuscarHamburguesa_TextChanged;
            // 
            // buttonUpdateHamburguesa
            // 
            buttonUpdateHamburguesa.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold);
            buttonUpdateHamburguesa.Location = new Point(877, 775);
            buttonUpdateHamburguesa.Margin = new Padding(2);
            buttonUpdateHamburguesa.Name = "buttonUpdateHamburguesa";
            buttonUpdateHamburguesa.Size = new Size(128, 36);
            buttonUpdateHamburguesa.TabIndex = 5;
            buttonUpdateHamburguesa.Text = "MODIFICAR";
            buttonUpdateHamburguesa.UseVisualStyleBackColor = true;
            buttonUpdateHamburguesa.Click += buttonUpdateHamburguesa_Click;
            // 
            // buttonVerResumen
            // 
            buttonVerResumen.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold);
            buttonVerResumen.Location = new Point(702, 775);
            buttonVerResumen.Margin = new Padding(2);
            buttonVerResumen.Name = "buttonVerResumen";
            buttonVerResumen.Size = new Size(154, 36);
            buttonVerResumen.TabIndex = 6;
            buttonVerResumen.Text = "VER RESUMEN";
            buttonVerResumen.UseVisualStyleBackColor = true;
            buttonVerResumen.Click += buttonVerResumen_Click;
            // 
            // HamburguesaForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 901);
            Controls.Add(buttonVerResumen);
            Controls.Add(buttonUpdateHamburguesa);
            Controls.Add(buttonAddHamburguesa);
            Controls.Add(textBoxBuscarHamburguesa);
            Controls.Add(dataGridViewHamburguesas);
            Margin = new Padding(2);
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
        private Button buttonUpdateHamburguesa;
        private Button buttonVerResumen;
    }
}