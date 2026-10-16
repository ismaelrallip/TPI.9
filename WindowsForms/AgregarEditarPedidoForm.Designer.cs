namespace WindowsForms
{
    partial class AgregarEditarPedidoForm
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
            label1 = new Label();
            cmbCliente = new ComboBox();
            label2 = new Label();
            cmbModalidad = new ComboBox();
            label3 = new Label();
            lblFechaValor = new Label();
            label4 = new Label();
            txtDireccion = new TextBox();
            groupBox1 = new GroupBox();
            btnModificarLinea = new Button();
            btnEliminarLinea = new Button();
            dgvDetalles = new DataGridView();
            btnAgregarLinea = new Button();
            numCantidad = new NumericUpDown();
            label6 = new Label();
            cmbHamburguesa = new ComboBox();
            label5 = new Label();
            label7 = new Label();
            txtComentario = new TextBox();
            label8 = new Label();
            lblTotalValor = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            lblCostoDelivery = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 22);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 0;
            label1.Text = "Cliente:";
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(134, 19);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(444, 28);
            cmbCliente.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 76);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 2;
            label2.Text = "Modalidad:";
            // 
            // cmbModalidad
            // 
            cmbModalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModalidad.FormattingEnabled = true;
            cmbModalidad.Location = new Point(134, 73);
            cmbModalidad.Name = "cmbModalidad";
            cmbModalidad.Size = new Size(228, 28);
            cmbModalidad.TabIndex = 3;
            cmbModalidad.SelectedIndexChanged += cmbModalidad_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(396, 81);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 4;
            label3.Text = "Fecha:";
            // 
            // lblFechaValor
            // 
            lblFechaValor.AutoSize = true;
            lblFechaValor.Location = new Point(493, 81);
            lblFechaValor.Name = "lblFechaValor";
            lblFechaValor.Size = new Size(85, 20);
            lblFechaValor.TabIndex = 5;
            lblFechaValor.Text = "15/10/2026";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 134);
            label4.Name = "label4";
            label4.Size = new Size(136, 20);
            label4.TabIndex = 6;
            label4.Text = "Dirección de Envío:";
            // 
            // txtDireccion
            // 
            txtDireccion.Enabled = false;
            txtDireccion.Location = new Point(195, 135);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(383, 27);
            txtDireccion.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnModificarLinea);
            groupBox1.Controls.Add(btnEliminarLinea);
            groupBox1.Controls.Add(dgvDetalles);
            groupBox1.Controls.Add(btnAgregarLinea);
            groupBox1.Controls.Add(numCantidad);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(cmbHamburguesa);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(49, 280);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(546, 344);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Agregar Hamburguesas";
            // 
            // btnModificarLinea
            // 
            btnModificarLinea.Location = new Point(22, 300);
            btnModificarLinea.Name = "btnModificarLinea";
            btnModificarLinea.Size = new Size(176, 29);
            btnModificarLinea.TabIndex = 16;
            btnModificarLinea.Text = "Modificar Cantidad";
            btnModificarLinea.UseVisualStyleBackColor = true;
            btnModificarLinea.Click += btnModificarLinea_Click;
            // 
            // btnEliminarLinea
            // 
            btnEliminarLinea.Location = new Point(347, 300);
            btnEliminarLinea.Name = "btnEliminarLinea";
            btnEliminarLinea.Size = new Size(173, 29);
            btnEliminarLinea.TabIndex = 15;
            btnEliminarLinea.Text = "Quitar Selección";
            btnEliminarLinea.UseVisualStyleBackColor = true;
            btnEliminarLinea.Click += btnEliminarLinea_Click;
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.AllowUserToDeleteRows = false;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(22, 140);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.RowHeadersWidth = 51;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(502, 154);
            dgvDetalles.TabIndex = 14;
            // 
            // btnAgregarLinea
            // 
            btnAgregarLinea.Location = new Point(379, 93);
            btnAgregarLinea.Name = "btnAgregarLinea";
            btnAgregarLinea.Size = new Size(145, 29);
            btnAgregarLinea.TabIndex = 13;
            btnAgregarLinea.Text = "Agregar al pedido";
            btnAgregarLinea.UseVisualStyleBackColor = true;
            btnAgregarLinea.Click += btnAgregarLinea_Click;
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(407, 50);
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(117, 27);
            numCantidad.TabIndex = 12;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(354, 50);
            label6.Name = "label6";
            label6.Size = new Size(42, 20);
            label6.TabIndex = 11;
            label6.Text = "Cant:";
            // 
            // cmbHamburguesa
            // 
            cmbHamburguesa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHamburguesa.FormattingEnabled = true;
            cmbHamburguesa.Location = new Point(125, 47);
            cmbHamburguesa.Name = "cmbHamburguesa";
            cmbHamburguesa.Size = new Size(223, 28);
            cmbHamburguesa.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 47);
            label5.Name = "label5";
            label5.Size = new Size(105, 20);
            label5.TabIndex = 9;
            label5.Text = "Hamburguesa:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(49, 187);
            label7.Name = "label7";
            label7.Size = new Size(164, 20);
            label7.TabIndex = 9;
            label7.Text = "Comentario (Opcional):";
            // 
            // txtComentario
            // 
            txtComentario.Location = new Point(232, 187);
            txtComentario.Multiline = true;
            txtComentario.Name = "txtComentario";
            txtComentario.Size = new Size(337, 67);
            txtComentario.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(444, 645);
            label8.Name = "label8";
            label8.Size = new Size(45, 20);
            label8.TabIndex = 11;
            label8.Text = "Total:";
            // 
            // lblTotalValor
            // 
            lblTotalValor.AutoSize = true;
            lblTotalValor.Location = new Point(505, 645);
            lblTotalValor.Name = "lblTotalValor";
            lblTotalValor.Size = new Size(48, 20);
            lblTotalValor.TabIndex = 12;
            lblTotalValor.Text = "$ 0,00";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(456, 676);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(139, 32);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "Guardar Pedido";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(340, 679);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblCostoDelivery
            // 
            lblCostoDelivery.AutoSize = true;
            lblCostoDelivery.Location = new Point(53, 645);
            lblCostoDelivery.Name = "lblCostoDelivery";
            lblCostoDelivery.Size = new Size(147, 20);
            lblCostoDelivery.TabIndex = 15;
            lblCostoDelivery.Text = "Costo Delivery: $0.00";
            lblCostoDelivery.Visible = false;
            // 
            // AgregarEditarPedidoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 720);
            Controls.Add(lblCostoDelivery);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(lblTotalValor);
            Controls.Add(label8);
            Controls.Add(txtComentario);
            Controls.Add(label7);
            Controls.Add(groupBox1);
            Controls.Add(txtDireccion);
            Controls.Add(label4);
            Controls.Add(lblFechaValor);
            Controls.Add(label3);
            Controls.Add(cmbModalidad);
            Controls.Add(label2);
            Controls.Add(cmbCliente);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AgregarEditarPedidoForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "AgregarEditarPedidoForm";
            Load += AgregarEditarPedidoForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbCliente;
        private Label label2;
        private ComboBox cmbModalidad;
        private Label label3;
        private Label lblFechaValor;
        private Label label4;
        private TextBox txtDireccion;
        private GroupBox groupBox1;
        private Label label6;
        private ComboBox cmbHamburguesa;
        private Label label5;
        private Button btnAgregarLinea;
        private NumericUpDown numCantidad;
        private DataGridView dgvDetalles;
        private Button btnEliminarLinea;
        private Label label7;
        private TextBox txtComentario;
        private Button btnModificarLinea;
        private Label label8;
        private Label lblTotalValor;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label lblCostoDelivery;
    }
}