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
            labelFondoRadioButtons = new Label();
            comboBoxFiltro = new ComboBox();
            labelFiltroPedidos = new Label();
            dataGridViewDetalle = new DataGridView();
            btnAvanzarEstado = new Button();
            btnAsignarDelivery = new Button();
            btnCancelarPedido = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetalle).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewPedidos
            // 
            dataGridViewPedidos.AllowUserToAddRows = false;
            dataGridViewPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPedidos.Location = new Point(26, 61);
            dataGridViewPedidos.Margin = new Padding(2);
            dataGridViewPedidos.MultiSelect = false;
            dataGridViewPedidos.Name = "dataGridViewPedidos";
            dataGridViewPedidos.ReadOnly = true;
            dataGridViewPedidos.RowHeadersWidth = 62;
            dataGridViewPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPedidos.Size = new Size(863, 428);
            dataGridViewPedidos.TabIndex = 7;
            dataGridViewPedidos.SelectionChanged += dataGridViewPedidos_SelectionChanged;
            // 
            // dateTimePickerFiltro
            // 
            dateTimePickerFiltro.Location = new Point(949, 119);
            dateTimePickerFiltro.Margin = new Padding(2);
            dateTimePickerFiltro.Name = "dateTimePickerFiltro";
            dateTimePickerFiltro.Size = new Size(282, 27);
            dateTimePickerFiltro.TabIndex = 12;
            // 
            // labelFondoRadioButtons
            // 
            labelFondoRadioButtons.BackColor = SystemColors.ControlDark;
            labelFondoRadioButtons.BorderStyle = BorderStyle.FixedSingle;
            labelFondoRadioButtons.Location = new Point(912, 61);
            labelFondoRadioButtons.Margin = new Padding(2, 0, 2, 0);
            labelFondoRadioButtons.Name = "labelFondoRadioButtons";
            labelFondoRadioButtons.Size = new Size(377, 174);
            labelFondoRadioButtons.TabIndex = 16;
            // 
            // comboBoxFiltro
            // 
            comboBoxFiltro.FormattingEnabled = true;
            comboBoxFiltro.Location = new Point(949, 182);
            comboBoxFiltro.Margin = new Padding(2);
            comboBoxFiltro.Name = "comboBoxFiltro";
            comboBoxFiltro.Size = new Size(206, 28);
            comboBoxFiltro.TabIndex = 17;
            // 
            // labelFiltroPedidos
            // 
            labelFiltroPedidos.AutoSize = true;
            labelFiltroPedidos.BackColor = SystemColors.ControlDark;
            labelFiltroPedidos.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFiltroPedidos.Location = new Point(1014, 75);
            labelFiltroPedidos.Margin = new Padding(2, 0, 2, 0);
            labelFiltroPedidos.Name = "labelFiltroPedidos";
            labelFiltroPedidos.Size = new Size(157, 28);
            labelFiltroPedidos.TabIndex = 18;
            labelFiltroPedidos.Text = "Filtrar Pedidos";
            // 
            // dataGridViewDetalle
            // 
            dataGridViewDetalle.AllowUserToAddRows = false;
            dataGridViewDetalle.AllowUserToDeleteRows = false;
            dataGridViewDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDetalle.Location = new Point(912, 248);
            dataGridViewDetalle.Name = "dataGridViewDetalle";
            dataGridViewDetalle.ReadOnly = true;
            dataGridViewDetalle.RowHeadersWidth = 51;
            dataGridViewDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDetalle.Size = new Size(377, 241);
            dataGridViewDetalle.TabIndex = 19;
            // 
            // btnAvanzarEstado
            // 
            btnAvanzarEstado.Location = new Point(26, 507);
            btnAvanzarEstado.Name = "btnAvanzarEstado";
            btnAvanzarEstado.Size = new Size(187, 29);
            btnAvanzarEstado.TabIndex = 20;
            btnAvanzarEstado.Text = "Avanzar Estado";
            btnAvanzarEstado.UseVisualStyleBackColor = true;
            btnAvanzarEstado.Click += btnAvanzarEstado_Click;
            // 
            // btnAsignarDelivery
            // 
            btnAsignarDelivery.Location = new Point(365, 507);
            btnAsignarDelivery.Name = "btnAsignarDelivery";
            btnAsignarDelivery.Size = new Size(186, 30);
            btnAsignarDelivery.TabIndex = 21;
            btnAsignarDelivery.Text = "Asignar Delivery";
            btnAsignarDelivery.UseVisualStyleBackColor = true;
            btnAsignarDelivery.Click += btnAsignarDelivery_Click;
            // 
            // btnCancelarPedido
            // 
            btnCancelarPedido.Location = new Point(733, 506);
            btnCancelarPedido.Name = "btnCancelarPedido";
            btnCancelarPedido.Size = new Size(156, 29);
            btnCancelarPedido.TabIndex = 22;
            btnCancelarPedido.Text = "Cancelar Pedido";
            btnCancelarPedido.UseVisualStyleBackColor = true;
            btnCancelarPedido.Click += btnCancelarPedido_Click;
            // 
            // PedidosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1309, 557);
            Controls.Add(btnCancelarPedido);
            Controls.Add(btnAsignarDelivery);
            Controls.Add(btnAvanzarEstado);
            Controls.Add(dataGridViewDetalle);
            Controls.Add(labelFiltroPedidos);
            Controls.Add(comboBoxFiltro);
            Controls.Add(dateTimePickerFiltro);
            Controls.Add(dataGridViewPedidos);
            Controls.Add(labelFondoRadioButtons);
            Margin = new Padding(2);
            Name = "PedidosForm";
            Text = "PedidosForm";
            Load += PedidosForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridViewPedidos;
        private DateTimePicker dateTimePickerFiltro;
        private Label labelFondoRadioButtons;
        private ComboBox comboBoxFiltro;
        private Label labelFiltroPedidos;
        private DataGridView dataGridViewDetalle;
        private Button btnAvanzarEstado;
        private Button btnAsignarDelivery;
        private Button btnCancelarPedido;
    }
}