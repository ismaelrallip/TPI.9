namespace WindowsForms
{
    partial class ResumenHamburguesaForm
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
            dataGridViewPrecios = new DataGridView();
            labelNombreHamburguesa = new Label();
            labelPrecioActual = new Label();
            labelMostrarNombre = new Label();
            labelMostrarPrecio = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIngredientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPrecios).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewIngredientes
            // 
            dataGridViewIngredientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewIngredientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewIngredientes.Location = new Point(52, 102);
            dataGridViewIngredientes.Name = "dataGridViewIngredientes";
            dataGridViewIngredientes.ReadOnly = true;
            dataGridViewIngredientes.RowHeadersWidth = 62;
            dataGridViewIngredientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewIngredientes.Size = new Size(394, 424);
            dataGridViewIngredientes.TabIndex = 0;
            // 
            // dataGridViewPrecios
            // 
            dataGridViewPrecios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPrecios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPrecios.Location = new Point(523, 102);
            dataGridViewPrecios.Name = "dataGridViewPrecios";
            dataGridViewPrecios.ReadOnly = true;
            dataGridViewPrecios.RowHeadersWidth = 62;
            dataGridViewPrecios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPrecios.Size = new Size(394, 424);
            dataGridViewPrecios.TabIndex = 1;
            // 
            // labelNombreHamburguesa
            // 
            labelNombreHamburguesa.AutoSize = true;
            labelNombreHamburguesa.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNombreHamburguesa.Location = new Point(52, 34);
            labelNombreHamburguesa.Name = "labelNombreHamburguesa";
            labelNombreHamburguesa.Size = new Size(99, 25);
            labelNombreHamburguesa.TabIndex = 2;
            labelNombreHamburguesa.Text = "NOMBRE:";
            // 
            // labelPrecioActual
            // 
            labelPrecioActual.AutoSize = true;
            labelPrecioActual.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPrecioActual.Location = new Point(523, 34);
            labelPrecioActual.Name = "labelPrecioActual";
            labelPrecioActual.Size = new Size(161, 25);
            labelPrecioActual.TabIndex = 3;
            labelPrecioActual.Text = "PRECIO ACTUAL:";
            // 
            // labelMostrarNombre
            // 
            labelMostrarNombre.BackColor = SystemColors.ButtonShadow;
            labelMostrarNombre.Font = new Font("Segoe UI", 9F);
            labelMostrarNombre.Location = new Point(157, 34);
            labelMostrarNombre.Name = "labelMostrarNombre";
            labelMostrarNombre.Size = new Size(245, 25);
            labelMostrarNombre.TabIndex = 4;
            labelMostrarNombre.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelMostrarPrecio
            // 
            labelMostrarPrecio.BackColor = SystemColors.ButtonShadow;
            labelMostrarPrecio.Font = new Font("Segoe UI", 9F);
            labelMostrarPrecio.Location = new Point(690, 34);
            labelMostrarPrecio.Name = "labelMostrarPrecio";
            labelMostrarPrecio.Size = new Size(187, 25);
            labelMostrarPrecio.TabIndex = 5;
            labelMostrarPrecio.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ResumenHamburguesaForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(986, 562);
            Controls.Add(labelMostrarPrecio);
            Controls.Add(labelMostrarNombre);
            Controls.Add(labelPrecioActual);
            Controls.Add(labelNombreHamburguesa);
            Controls.Add(dataGridViewPrecios);
            Controls.Add(dataGridViewIngredientes);
            Name = "ResumenHamburguesaForm";
            Text = "ResumenHamburguesaForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewIngredientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPrecios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewIngredientes;
        private DataGridView dataGridViewPrecios;
        private Label labelNombreHamburguesa;
        private Label labelPrecioActual;
        private Label labelMostrarNombre;
        private Label labelMostrarPrecio;
    }
}