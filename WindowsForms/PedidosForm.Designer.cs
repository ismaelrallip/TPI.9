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
            dataGridViewPedidos.AllowUserToDeleteRows = false;
            dataGridViewPedidos.AllowUserToResizeColumns = false;
            dataGridViewPedidos.AllowUserToResizeRows = false;
            dataGridViewPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPedidos.Location = new Point(23, 46);
            dataGridViewPedidos.Margin = new Padding(1, 1, 1, 1);
            dataGridViewPedidos.MultiSelect = false;
            dataGridViewPedidos.Name = "dataGridViewPedidos";
            dataGridViewPedidos.ReadOnly = true;
            dataGridViewPedidos.RowHeadersWidth = 62;
            dataGridViewPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPedidos.Size = new Size(1138, 623);
            dataGridViewPedidos.TabIndex = 7;
            dataGridViewPedidos.SelectionChanged += dataGridViewPedidos_SelectionChanged;
            // 
            // dateTimePickerFiltro
            // 
            dateTimePickerFiltro.Checked = false;
            dateTimePickerFiltro.Location = new Point(1206, 89);
            dateTimePickerFiltro.Margin = new Padding(1, 1, 1, 1);
            dateTimePickerFiltro.Name = "dateTimePickerFiltro";
            dateTimePickerFiltro.ShowCheckBox = true;
            dateTimePickerFiltro.Size = new Size(285, 23);
            dateTimePickerFiltro.TabIndex = 12;
            // 
            // labelFondoFiltros
            // 
            labelFondoFiltros.BackColor = SystemColors.ControlDark;
            labelFondoFiltros.BorderStyle = BorderStyle.FixedSingle;
            labelFondoFiltros.Location = new Point(1174, 46);
            labelFondoFiltros.Margin = new Padding(1, 0, 1, 0);
            labelFondoFiltros.Name = "labelFondoFiltros";
            labelFondoFiltros.Size = new Size(376, 131);
            labelFondoFiltros.TabIndex = 16;
            // 
            // comboBoxFiltro
            // 
            comboBoxFiltro.FormattingEnabled = true;
            comboBoxFiltro.Location = new Point(1206, 136);
            comboBoxFiltro.Margin = new Padding(1, 1, 1, 1);
            comboBoxFiltro.Name = "comboBoxFiltro";
            comboBoxFiltro.Size = new Size(180, 23);
            comboBoxFiltro.TabIndex = 17;
            // 
            // labelFiltroPedidos
            // 
            labelFiltroPedidos.AutoSize = true;
            labelFiltroPedidos.BackColor = SystemColors.ControlDark;
            labelFiltroPedidos.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFiltroPedidos.Location = new Point(1301, 56);
            labelFiltroPedidos.Margin = new Padding(1, 0, 1, 0);
            labelFiltroPedidos.Name = "labelFiltroPedidos";
            labelFiltroPedidos.Size = new Size(125, 21);
            labelFiltroPedidos.TabIndex = 18;
            labelFiltroPedidos.Text = "Filtrar Pedidos";
            // 
            // dataGridViewDetalle
            // 
            dataGridViewDetalle.AllowUserToAddRows = false;
            dataGridViewDetalle.AllowUserToDeleteRows = false;
            dataGridViewDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDetalle.Location = new Point(1174, 217);
            dataGridViewDetalle.Margin = new Padding(3, 2, 3, 2);
            dataGridViewDetalle.Name = "dataGridViewDetalle";
            dataGridViewDetalle.ReadOnly = true;
            dataGridViewDetalle.RowHeadersWidth = 51;
            dataGridViewDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDetalle.Size = new Size(510, 239);
            dataGridViewDetalle.TabIndex = 19;
            // 
            // btnAvanzarEstado
            // 
            btnAvanzarEstado.Location = new Point(23, 693);
            btnAvanzarEstado.Margin = new Padding(3, 2, 3, 2);
            btnAvanzarEstado.Name = "btnAvanzarEstado";
            btnAvanzarEstado.Size = new Size(164, 22);
            btnAvanzarEstado.TabIndex = 20;
            btnAvanzarEstado.Text = "Avanzar Estado";
            btnAvanzarEstado.UseVisualStyleBackColor = true;
            btnAvanzarEstado.Click += btnAvanzarEstado_Click;
            // 
            // btnAsignarDelivery
            // 
            btnAsignarDelivery.Location = new Point(239, 693);
            btnAsignarDelivery.Margin = new Padding(3, 2, 3, 2);
            btnAsignarDelivery.Name = "btnAsignarDelivery";
            btnAsignarDelivery.Size = new Size(162, 23);
            btnAsignarDelivery.TabIndex = 21;
            btnAsignarDelivery.Text = "Asignar Delivery";
            btnAsignarDelivery.UseVisualStyleBackColor = true;
            btnAsignarDelivery.Click += btnAsignarDelivery_Click;
            // 
            // btnCancelarPedido
            // 
            btnCancelarPedido.Location = new Point(470, 692);
            btnCancelarPedido.Margin = new Padding(3, 2, 3, 2);
            btnCancelarPedido.Name = "btnCancelarPedido";
            btnCancelarPedido.Size = new Size(136, 22);
            btnCancelarPedido.TabIndex = 22;
            btnCancelarPedido.Text = "Cancelar Pedido";
            btnCancelarPedido.UseVisualStyleBackColor = true;
            btnCancelarPedido.Click += btnCancelarPedido_Click;
            // 
            // btnNuevoPedido
            // 
            btnNuevoPedido.Location = new Point(817, 693);
            btnNuevoPedido.Margin = new Padding(3, 2, 3, 2);
            btnNuevoPedido.Name = "btnNuevoPedido";
            btnNuevoPedido.Size = new Size(127, 22);
            btnNuevoPedido.TabIndex = 23;
            btnNuevoPedido.Text = "Nuevo Pedido";
            btnNuevoPedido.UseVisualStyleBackColor = true;
            btnNuevoPedido.Click += btnNuevoPedido_Click;
            // 
            // btnModificarPedido
            // 
            btnModificarPedido.Enabled = false;
            btnModificarPedido.Location = new Point(999, 693);
            btnModificarPedido.Margin = new Padding(3, 2, 3, 2);
            btnModificarPedido.Name = "btnModificarPedido";
            btnModificarPedido.Size = new Size(130, 22);
            btnModificarPedido.TabIndex = 24;
            btnModificarPedido.Text = "Modificar Pedido";
            btnModificarPedido.UseVisualStyleBackColor = true;
            btnModificarPedido.Click += btnModificarPedido_Click;
            // 
            // btnCalificarPedido
            // 
            btnCalificarPedido.Enabled = false;
            btnCalificarPedido.Location = new Point(652, 692);
            btnCalificarPedido.Margin = new Padding(3, 2, 3, 2);
            btnCalificarPedido.Name = "btnCalificarPedido";
            btnCalificarPedido.Size = new Size(127, 22);
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
            labelDetalleAmpliado.Location = new Point(1179, 196);
            labelDetalleAmpliado.Margin = new Padding(2, 0, 2, 0);
            labelDetalleAmpliado.Name = "labelDetalleAmpliado";
            labelDetalleAmpliado.Size = new Size(160, 19);
            labelDetalleAmpliado.TabIndex = 26;
            labelDetalleAmpliado.Text = "DETALLE AMPLIADO:";
            // 
            // labelFondoDetalle
            // 
            labelFondoDetalle.BackColor = SystemColors.ControlDark;
            labelFondoDetalle.BorderStyle = BorderStyle.FixedSingle;
            labelFondoDetalle.Location = new Point(1174, 189);
            labelFondoDetalle.Margin = new Padding(1, 0, 1, 0);
            labelFondoDetalle.Name = "labelFondoDetalle";
            labelFondoDetalle.Size = new Size(510, 268);
            labelFondoDetalle.TabIndex = 27;
            // 
            // PedidosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1704, 637);
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
            Margin = new Padding(1, 1, 1, 1);
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