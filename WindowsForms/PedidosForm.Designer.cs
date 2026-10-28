namespace WindowsForms
{
    partial class PedidosForm
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
            dataGridViewPedidos = new DataGridView();
            dateTimePickerFiltro = new DateTimePicker();
            labelFondoFiltros = new Label();
            comboBoxFiltro = new ComboBox();
            labelFiltroPedidos = new Label();
            dataGridViewDetalle = new DataGridView();
            btnAvanzarEstado = new Button();
            btnAsignarDelivery = new Button();
            btnCancelarPedido = new Button();
            btnNuevoPedido = new Button();
            btnModificarPedido = new Button();
            btnCalificarPedido = new Button();
            labelDetalleAmpliado = new Label();
            labelFondoDetalle = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetalle).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewPedidos
            // 
            dataGridViewPedidos.AllowUserToAddRows = false;
            dataGridViewPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPedidos.Location = new Point(33, 76);
            dataGridViewPedidos.Margin = new Padding(2);
            dataGridViewPedidos.MultiSelect = false;
            dataGridViewPedidos.Name = "dataGridViewPedidos";
            dataGridViewPedidos.ReadOnly = true;
            dataGridViewPedidos.RowHeadersWidth = 62;
            dataGridViewPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPedidos.Size = new Size(1625, 1039);
            dataGridViewPedidos.TabIndex = 7;
            dataGridViewPedidos.SelectionChanged += dataGridViewPedidos_SelectionChanged;
            // 
            // dateTimePickerFiltro
            // 
            dateTimePickerFiltro.Checked = false;
            dateTimePickerFiltro.Location = new Point(1723, 148);
            dateTimePickerFiltro.Margin = new Padding(2);
            dateTimePickerFiltro.Name = "dateTimePickerFiltro";
            dateTimePickerFiltro.ShowCheckBox = true;
            dateTimePickerFiltro.Size = new Size(405, 31);
            dateTimePickerFiltro.TabIndex = 12;
            // 
            // labelFondoFiltros
            // 
            labelFondoFiltros.BackColor = SystemColors.ControlDark;
            labelFondoFiltros.BorderStyle = BorderStyle.FixedSingle;
            labelFondoFiltros.Location = new Point(1677, 76);
            labelFondoFiltros.Margin = new Padding(2, 0, 2, 0);
            labelFondoFiltros.Name = "labelFondoFiltros";
            labelFondoFiltros.Size = new Size(536, 217);
            labelFondoFiltros.TabIndex = 16;
            // 
            // comboBoxFiltro
            // 
            comboBoxFiltro.FormattingEnabled = true;
            comboBoxFiltro.Location = new Point(1723, 227);
            comboBoxFiltro.Margin = new Padding(2);
            comboBoxFiltro.Name = "comboBoxFiltro";
            comboBoxFiltro.Size = new Size(256, 33);
            comboBoxFiltro.TabIndex = 17;
            // 
            // labelFiltroPedidos
            // 
            labelFiltroPedidos.AutoSize = true;
            labelFiltroPedidos.BackColor = SystemColors.ControlDark;
            labelFiltroPedidos.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFiltroPedidos.Location = new Point(1858, 93);
            labelFiltroPedidos.Margin = new Padding(2, 0, 2, 0);
            labelFiltroPedidos.Name = "labelFiltroPedidos";
            labelFiltroPedidos.Size = new Size(184, 32);
            labelFiltroPedidos.TabIndex = 18;
            labelFiltroPedidos.Text = "Filtrar Pedidos";
            // 
            // dataGridViewDetalle
            // 
            dataGridViewDetalle.AllowUserToAddRows = false;
            dataGridViewDetalle.AllowUserToDeleteRows = false;
            dataGridViewDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDetalle.Location = new Point(1677, 361);
            dataGridViewDetalle.Margin = new Padding(4);
            dataGridViewDetalle.Name = "dataGridViewDetalle";
            dataGridViewDetalle.ReadOnly = true;
            dataGridViewDetalle.RowHeadersWidth = 51;
            dataGridViewDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDetalle.Size = new Size(728, 399);
            dataGridViewDetalle.TabIndex = 19;
            // 
            // btnAvanzarEstado
            // 
            btnAvanzarEstado.Location = new Point(33, 1155);
            btnAvanzarEstado.Margin = new Padding(4);
            btnAvanzarEstado.Name = "btnAvanzarEstado";
            btnAvanzarEstado.Size = new Size(234, 36);
            btnAvanzarEstado.TabIndex = 20;
            btnAvanzarEstado.Text = "Avanzar Estado";
            btnAvanzarEstado.UseVisualStyleBackColor = true;
            btnAvanzarEstado.Click += btnAvanzarEstado_Click;
            // 
            // btnAsignarDelivery
            // 
            btnAsignarDelivery.Location = new Point(342, 1155);
            btnAsignarDelivery.Margin = new Padding(4);
            btnAsignarDelivery.Name = "btnAsignarDelivery";
            btnAsignarDelivery.Size = new Size(232, 38);
            btnAsignarDelivery.TabIndex = 21;
            btnAsignarDelivery.Text = "Asignar Delivery";
            btnAsignarDelivery.UseVisualStyleBackColor = true;
            btnAsignarDelivery.Click += btnAsignarDelivery_Click;
            // 
            // btnCancelarPedido
            // 
            btnCancelarPedido.Location = new Point(672, 1153);
            btnCancelarPedido.Margin = new Padding(4);
            btnCancelarPedido.Name = "btnCancelarPedido";
            btnCancelarPedido.Size = new Size(195, 36);
            btnCancelarPedido.TabIndex = 22;
            btnCancelarPedido.Text = "Cancelar Pedido";
            btnCancelarPedido.UseVisualStyleBackColor = true;
            btnCancelarPedido.Click += btnCancelarPedido_Click;
            // 
            // btnNuevoPedido
            // 
            btnNuevoPedido.Location = new Point(1167, 1155);
            btnNuevoPedido.Margin = new Padding(4);
            btnNuevoPedido.Name = "btnNuevoPedido";
            btnNuevoPedido.Size = new Size(181, 36);
            btnNuevoPedido.TabIndex = 23;
            btnNuevoPedido.Text = "Nuevo Pedido";
            btnNuevoPedido.UseVisualStyleBackColor = true;
            btnNuevoPedido.Click += btnNuevoPedido_Click;
            // 
            // btnModificarPedido
            // 
            btnModificarPedido.Enabled = false;
            btnModificarPedido.Location = new Point(1427, 1155);
            btnModificarPedido.Margin = new Padding(4);
            btnModificarPedido.Name = "btnModificarPedido";
            btnModificarPedido.Size = new Size(185, 36);
            btnModificarPedido.TabIndex = 24;
            btnModificarPedido.Text = "Modificar Pedido";
            btnModificarPedido.UseVisualStyleBackColor = true;
            btnModificarPedido.Click += btnModificarPedido_Click;
            // 
            // btnCalificarPedido
            // 
            btnCalificarPedido.Enabled = false;
            btnCalificarPedido.Location = new Point(931, 1153);
            btnCalificarPedido.Margin = new Padding(4);
            btnCalificarPedido.Name = "btnCalificarPedido";
            btnCalificarPedido.Size = new Size(181, 36);
            btnCalificarPedido.TabIndex = 25;
            btnCalificarPedido.Text = "Comentar/Calificar";
            btnCalificarPedido.UseVisualStyleBackColor = true;
            btnCalificarPedido.Visible = false;
            btnCalificarPedido.Click += btnCalificarPedido_Click;
            // 
            // labelDetalleAmpliado
            // 
            labelDetalleAmpliado.AutoSize = true;
            labelDetalleAmpliado.BackColor = SystemColors.ControlDark;
            labelDetalleAmpliado.Font = new Font("Segoe UI Black", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDetalleAmpliado.Location = new Point(1684, 326);
            labelDetalleAmpliado.Name = "labelDetalleAmpliado";
            labelDetalleAmpliado.Size = new Size(222, 28);
            labelDetalleAmpliado.TabIndex = 26;
            labelDetalleAmpliado.Text = "DETALLE AMPLIADO:";
            // 
            // labelFondoDetalle
            // 
            labelFondoDetalle.BackColor = SystemColors.ControlDark;
            labelFondoDetalle.BorderStyle = BorderStyle.FixedSingle;
            labelFondoDetalle.Location = new Point(1677, 315);
            labelFondoDetalle.Margin = new Padding(2, 0, 2, 0);
            labelFondoDetalle.Name = "labelFondoDetalle";
            labelFondoDetalle.Size = new Size(728, 445);
            labelFondoDetalle.TabIndex = 27;
            // 
            // PedidosForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2435, 1222);
            Controls.Add(labelDetalleAmpliado);
            Controls.Add(btnCalificarPedido);
            Controls.Add(btnModificarPedido);
            Controls.Add(btnNuevoPedido);
            Controls.Add(btnCancelarPedido);
            Controls.Add(btnAsignarDelivery);
            Controls.Add(btnAvanzarEstado);
            Controls.Add(dataGridViewDetalle);
            Controls.Add(labelFiltroPedidos);
            Controls.Add(comboBoxFiltro);
            Controls.Add(dateTimePickerFiltro);
            Controls.Add(dataGridViewPedidos);
            Controls.Add(labelFondoFiltros);
            Controls.Add(labelFondoDetalle);
            Margin = new Padding(2);
            Name = "PedidosForm";
            Text = "Pedidos";
            Load += PedidosForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridViewPedidos;
        private DateTimePicker dateTimePickerFiltro;
        private Label labelFondoFiltros;
        private ComboBox comboBoxFiltro;
        private Label labelFiltroPedidos;
        private DataGridView dataGridViewDetalle;
        private Button btnAvanzarEstado;
        private Button btnAsignarDelivery;
        private Button btnCancelarPedido;
        private Button btnNuevoPedido;
        private Button btnModificarPedido;
        private Button btnCalificarPedido;
        private Label labelDetalleAmpliado;
        private Label labelFondoDetalle;
    }
}