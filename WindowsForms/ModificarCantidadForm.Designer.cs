namespace WindowsForms
{
    partial class ModificarCantidadForm
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
            lblHamburguesa = new Label();
            lblPrecio = new Label();
            label1 = new Label();
            btnAceptar = new Button();
            btnCancelar = new Button();
            numNuevaCantidad = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numNuevaCantidad).BeginInit();
            SuspendLayout();
            // 
            // lblHamburguesa
            // 
            lblHamburguesa.AutoSize = true;
            lblHamburguesa.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHamburguesa.Location = new Point(22, 18);
            lblHamburguesa.Name = "lblHamburguesa";
            lblHamburguesa.Size = new Size(139, 23);
            lblHamburguesa.TabIndex = 0;
            lblHamburguesa.Text = "Hamburguesa: -";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(22, 52);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(149, 20);
            lblPrecio.TabIndex = 1;
            lblPrecio.Text = "Precio Unitario: $0.00";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 87);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 2;
            label1.Text = "Nueva cantidad:";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(206, 146);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 3;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(33, 146);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(99, 29);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // numNuevaCantidad
            // 
            numNuevaCantidad.Location = new Point(165, 91);
            numNuevaCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numNuevaCantidad.Name = "numNuevaCantidad";
            numNuevaCantidad.Size = new Size(135, 27);
            numNuevaCantidad.TabIndex = 5;
            numNuevaCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // ModificarCantidadForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 203);
            Controls.Add(numNuevaCantidad);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(label1);
            Controls.Add(lblPrecio);
            Controls.Add(lblHamburguesa);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ModificarCantidadForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Modificar Cantidad";
            ((System.ComponentModel.ISupportInitialize)numNuevaCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHamburguesa;
        private Label lblPrecio;
        private Label label1;
        private Button btnAceptar;
        private Button btnCancelar;
        private NumericUpDown numNuevaCantidad;
    }
}