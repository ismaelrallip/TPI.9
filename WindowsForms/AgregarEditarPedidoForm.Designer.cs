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
            label1.Location = new Point(56, 28);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(69, 25);
            label1.TabIndex = 0;
            label1.Text = "Cliente:";
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(168, 24);
            cmbCliente.Margin = new Padding(4, 4, 4, 4);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(554, 33);
            cmbCliente.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 95);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 2;
            label2.Text = "Modalidad:";
            // 
            // cmbModalidad
            // 
            cmbModalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModalidad.FormattingEnabled = true;
            cmbModalidad.Location = new Point(168, 91);
            cmbModalidad.Margin = new Padding(4, 4, 4, 4);
            cmbModalidad.Name = "cmbModalidad";
            cmbModalidad.Size = new Size(284, 33);
            cmbModalidad.TabIndex = 3;
            cmbModalidad.SelectedIndexChanged += cmbModalidad_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(480, 101);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(61, 25);
            label3.TabIndex = 4;
            label3.Text = "Fecha:";
            // 
            // lblFechaValor
            // 
            lblFechaValor.AutoSize = true;
            lblFechaValor.Location = new Point(555, 101);
            lblFechaValor.Margin = new Padding(4, 0, 4, 0);
            lblFechaValor.Name = "lblFechaValor";
            lblFechaValor.Size = new Size(106, 25);
            lblFechaValor.TabIndex = 5;
            lblFechaValor.Text = "15/10/2026";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(58, 168);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(162, 25);
            label4.TabIndex = 6;
            label4.Text = "Dirección de Envío:";
            // 
            // txtDireccion
            // 
            txtDireccion.Enabled = false;
            txtDireccion.Location = new Point(244, 169);
            txtDireccion.Margin = new Padding(4, 4, 4, 4);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(478, 31);
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
            groupBox1.Location = new Point(61, 350);
            groupBox1.Margin = new Padding(4, 4, 4, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 4, 4, 4);
            groupBox1.Size = new Size(682, 430);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Agregar Hamburguesas";
            // 
            // btnModificarLinea
            // 
            btnModificarLinea.Location = new Point(28, 375);
            btnModificarLinea.Margin = new Padding(4, 4, 4, 4);
            btnModificarLinea.Name = "btnModificarLinea";
            btnModificarLinea.Size = new Size(220, 36);
            btnModificarLinea.TabIndex = 16;
            btnModificarLinea.Text = "Modificar Cantidad";
            btnModificarLinea.UseVisualStyleBackColor = true;
            btnModificarLinea.Click += btnModificarLinea_Click;
            // 
            // btnEliminarLinea
            // 
            btnEliminarLinea.Location = new Point(434, 375);
            btnEliminarLinea.Margin = new Padding(4, 4, 4, 4);
            btnEliminarLinea.Name = "btnEliminarLinea";
            btnEliminarLinea.Size = new Size(216, 36);
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
            dgvDetalles.Location = new Point(28, 175);
            dgvDetalles.Margin = new Padding(4, 4, 4, 4);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.RowHeadersWidth = 51;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.Size = new Size(628, 192);
            dgvDetalles.TabIndex = 14;
            // 
            // btnAgregarLinea
            // 
            btnAgregarLinea.Location = new Point(474, 116);
            btnAgregarLinea.Margin = new Padding(4, 4, 4, 4);
            btnAgregarLinea.Name = "btnAgregarLinea";
            btnAgregarLinea.Size = new Size(181, 36);
            btnAgregarLinea.TabIndex = 13;
            btnAgregarLinea.Text = "Agregar al pedido";
            btnAgregarLinea.UseVisualStyleBackColor = true;
            btnAgregarLinea.Click += btnAgregarLinea_Click;
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(509, 62);
            numCantidad.Margin = new Padding(4, 4, 4, 4);
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(146, 31);
            numCantidad.TabIndex = 12;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(442, 62);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(52, 25);
            label6.TabIndex = 11;
            label6.Text = "Cant:";
            // 
            // cmbHamburguesa
            // 
            cmbHamburguesa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHamburguesa.FormattingEnabled = true;
            cmbHamburguesa.Location = new Point(156, 59);
            cmbHamburguesa.Margin = new Padding(4, 4, 4, 4);
            cmbHamburguesa.Name = "cmbHamburguesa";
            cmbHamburguesa.Size = new Size(278, 33);
            cmbHamburguesa.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 59);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(128, 25);
            label5.TabIndex = 9;
            label5.Text = "Hamburguesa:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(61, 234);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(195, 25);
            label7.TabIndex = 9;
            label7.Text = "Comentario (Opcional):";
            // 
            // txtComentario
            // 
            txtComentario.Location = new Point(290, 234);
            txtComentario.Margin = new Padding(4, 4, 4, 4);
            txtComentario.Multiline = true;
            txtComentario.Name = "txtComentario";
            txtComentario.Size = new Size(420, 83);
            txtComentario.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(555, 806);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(53, 25);
            label8.TabIndex = 11;
            label8.Text = "Total:";
            // 
            // lblTotalValor
            // 
            lblTotalValor.AutoSize = true;
            lblTotalValor.Location = new Point(631, 806);
            lblTotalValor.Margin = new Padding(4, 0, 4, 0);
            lblTotalValor.Name = "lblTotalValor";
            lblTotalValor.Size = new Size(61, 25);
            lblTotalValor.TabIndex = 12;
            lblTotalValor.Text = "$ 0,00";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(570, 845);
            btnGuardar.Margin = new Padding(4, 4, 4, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(174, 40);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "Guardar Pedido";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(425, 849);
            btnCancelar.Margin = new Padding(4, 4, 4, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(118, 36);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblCostoDelivery
            // 
            lblCostoDelivery.AutoSize = true;
            lblCostoDelivery.Location = new Point(66, 806);
            lblCostoDelivery.Margin = new Padding(4, 0, 4, 0);
            lblCostoDelivery.Name = "lblCostoDelivery";
            lblCostoDelivery.Size = new Size(180, 25);
            lblCostoDelivery.TabIndex = 15;
            lblCostoDelivery.Text = "Costo Delivery: $0.00";
            lblCostoDelivery.Visible = false;
            // 
            // AgregarEditarPedidoForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(790, 900);
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
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AgregarEditarPedidoForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Agregar o Editar Pedido";
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