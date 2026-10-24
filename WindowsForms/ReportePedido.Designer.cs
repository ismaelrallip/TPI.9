namespace WindowsForms
{
    partial class ReportePedido
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            desdeLabel = new Label();
            hastaLabel = new Label();
            modalidadLabel = new Label();
            desdeDatePicker = new DateTimePicker();
            hastaDatePicker = new DateTimePicker();
            modalidadComboBox = new ComboBox();
            estadoComboBox = new ComboBox();
            estadoLabel = new Label();
            DownloadButton = new Button();
            dataGridViewPedidos = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            comentarioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            direccionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            modalidadDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            calificacionPedidoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            calificacionDeliveryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            comentarioFinalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            precioTotalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            clienteIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            clienteNombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            clienteActivoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            deliveryIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            deliveryNombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pedidoDTOBindingSource = new BindingSource(components);
            detallesPedidoBindingSource = new BindingSource(components);
            traerTodosButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pedidoDTOBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detallesPedidoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(271, 20);
            label1.Name = "label1";
            label1.Size = new Size(279, 15);
            label1.TabIndex = 0;
            label1.Text = "Si no selecciona un filtro, se traen todos los pedidos";
            // 
            // desdeLabel
            // 
            desdeLabel.AutoSize = true;
            desdeLabel.Location = new Point(58, 49);
            desdeLabel.Name = "desdeLabel";
            desdeLabel.Size = new Size(39, 15);
            desdeLabel.TabIndex = 1;
            desdeLabel.Text = "Desde";
            // 
            // hastaLabel
            // 
            hastaLabel.AutoSize = true;
            hastaLabel.Location = new Point(58, 96);
            hastaLabel.Name = "hastaLabel";
            hastaLabel.Size = new Size(37, 15);
            hastaLabel.TabIndex = 2;
            hastaLabel.Text = "Hasta";
            // 
            // modalidadLabel
            // 
            modalidadLabel.AutoSize = true;
            modalidadLabel.Location = new Point(430, 49);
            modalidadLabel.Name = "modalidadLabel";
            modalidadLabel.Size = new Size(64, 15);
            modalidadLabel.TabIndex = 3;
            modalidadLabel.Text = "Modalidad";
            // 
            // desdeDatePicker
            // 
            desdeDatePicker.Location = new Point(128, 49);
            desdeDatePicker.Name = "desdeDatePicker";
            desdeDatePicker.Size = new Size(233, 23);
            desdeDatePicker.TabIndex = 4;
            desdeDatePicker.ValueChanged += desdeDatePicker_ValueChanged;
            // 
            // hastaDatePicker
            // 
            hastaDatePicker.Location = new Point(128, 96);
            hastaDatePicker.Name = "hastaDatePicker";
            hastaDatePicker.Size = new Size(233, 23);
            hastaDatePicker.TabIndex = 5;
            hastaDatePicker.ValueChanged += hastaDatePicker_ValueChanged;
            // 
            // modalidadComboBox
            // 
            modalidadComboBox.FormattingEnabled = true;
            modalidadComboBox.Items.AddRange(new object[] { "Delivery", "Take Away" });
            modalidadComboBox.Location = new Point(526, 49);
            modalidadComboBox.Name = "modalidadComboBox";
            modalidadComboBox.Size = new Size(121, 23);
            modalidadComboBox.TabIndex = 6;
            modalidadComboBox.SelectedIndexChanged += modalidadComboBox_SelectedIndexChanged;
            // 
            // estadoComboBox
            // 
            estadoComboBox.FormattingEnabled = true;
            estadoComboBox.Items.AddRange(new object[] { "Pendiente", "EnProceso", "Listo", "Asignado", "EnCamino", "Entregado", "Cancelado" });
            estadoComboBox.Location = new Point(526, 96);
            estadoComboBox.Name = "estadoComboBox";
            estadoComboBox.Size = new Size(121, 23);
            estadoComboBox.TabIndex = 7;
            estadoComboBox.SelectedIndexChanged += estadoComboBox_SelectedIndexChanged;
            // 
            // estadoLabel
            // 
            estadoLabel.AutoSize = true;
            estadoLabel.Location = new Point(430, 96);
            estadoLabel.Name = "estadoLabel";
            estadoLabel.Size = new Size(42, 15);
            estadoLabel.TabIndex = 8;
            estadoLabel.Text = "Estado";
            // 
            // DownloadButton
            // 
            DownloadButton.Location = new Point(681, 96);
            DownloadButton.Name = "DownloadButton";
            DownloadButton.Size = new Size(117, 23);
            DownloadButton.TabIndex = 9;
            DownloadButton.Text = "Descargar PDF";
            DownloadButton.UseVisualStyleBackColor = true;
            DownloadButton.Click += DownloadButton_Click;
            // 
            // dataGridViewPedidos
            // 
            dataGridViewPedidos.AutoGenerateColumns = false;
            dataGridViewPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPedidos.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, fechaDataGridViewTextBoxColumn, comentarioDataGridViewTextBoxColumn, direccionDataGridViewTextBoxColumn, modalidadDataGridViewTextBoxColumn, calificacionPedidoDataGridViewTextBoxColumn, calificacionDeliveryDataGridViewTextBoxColumn, estadoDataGridViewTextBoxColumn, comentarioFinalDataGridViewTextBoxColumn, precioTotalDataGridViewTextBoxColumn, clienteIdDataGridViewTextBoxColumn, clienteNombreDataGridViewTextBoxColumn, clienteActivoDataGridViewCheckBoxColumn, deliveryIdDataGridViewTextBoxColumn, deliveryNombreDataGridViewTextBoxColumn });
            dataGridViewPedidos.DataSource = pedidoDTOBindingSource;
            dataGridViewPedidos.Location = new Point(28, 152);
            dataGridViewPedidos.Name = "dataGridViewPedidos";
            dataGridViewPedidos.Size = new Size(1244, 351);
            dataGridViewPedidos.TabIndex = 10;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            // 
            // comentarioDataGridViewTextBoxColumn
            // 
            comentarioDataGridViewTextBoxColumn.DataPropertyName = "Comentario";
            comentarioDataGridViewTextBoxColumn.HeaderText = "Comentario";
            comentarioDataGridViewTextBoxColumn.Name = "comentarioDataGridViewTextBoxColumn";
            // 
            // direccionDataGridViewTextBoxColumn
            // 
            direccionDataGridViewTextBoxColumn.DataPropertyName = "Direccion";
            direccionDataGridViewTextBoxColumn.HeaderText = "Direccion";
            direccionDataGridViewTextBoxColumn.Name = "direccionDataGridViewTextBoxColumn";
            // 
            // modalidadDataGridViewTextBoxColumn
            // 
            modalidadDataGridViewTextBoxColumn.DataPropertyName = "Modalidad";
            modalidadDataGridViewTextBoxColumn.HeaderText = "Modalidad";
            modalidadDataGridViewTextBoxColumn.Name = "modalidadDataGridViewTextBoxColumn";
            // 
            // calificacionPedidoDataGridViewTextBoxColumn
            // 
            calificacionPedidoDataGridViewTextBoxColumn.DataPropertyName = "CalificacionPedido";
            calificacionPedidoDataGridViewTextBoxColumn.HeaderText = "CalificacionPedido";
            calificacionPedidoDataGridViewTextBoxColumn.Name = "calificacionPedidoDataGridViewTextBoxColumn";
            // 
            // calificacionDeliveryDataGridViewTextBoxColumn
            // 
            calificacionDeliveryDataGridViewTextBoxColumn.DataPropertyName = "CalificacionDelivery";
            calificacionDeliveryDataGridViewTextBoxColumn.HeaderText = "CalificacionDelivery";
            calificacionDeliveryDataGridViewTextBoxColumn.Name = "calificacionDeliveryDataGridViewTextBoxColumn";
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            // 
            // comentarioFinalDataGridViewTextBoxColumn
            // 
            comentarioFinalDataGridViewTextBoxColumn.DataPropertyName = "ComentarioFinal";
            comentarioFinalDataGridViewTextBoxColumn.HeaderText = "ComentarioFinal";
            comentarioFinalDataGridViewTextBoxColumn.Name = "comentarioFinalDataGridViewTextBoxColumn";
            // 
            // precioTotalDataGridViewTextBoxColumn
            // 
            precioTotalDataGridViewTextBoxColumn.DataPropertyName = "PrecioTotal";
            precioTotalDataGridViewTextBoxColumn.HeaderText = "PrecioTotal";
            precioTotalDataGridViewTextBoxColumn.Name = "precioTotalDataGridViewTextBoxColumn";
            // 
            // clienteIdDataGridViewTextBoxColumn
            // 
            clienteIdDataGridViewTextBoxColumn.DataPropertyName = "ClienteId";
            clienteIdDataGridViewTextBoxColumn.HeaderText = "ClienteId";
            clienteIdDataGridViewTextBoxColumn.Name = "clienteIdDataGridViewTextBoxColumn";
            clienteIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // clienteNombreDataGridViewTextBoxColumn
            // 
            clienteNombreDataGridViewTextBoxColumn.DataPropertyName = "ClienteNombre";
            clienteNombreDataGridViewTextBoxColumn.HeaderText = "ClienteNombre";
            clienteNombreDataGridViewTextBoxColumn.Name = "clienteNombreDataGridViewTextBoxColumn";
            // 
            // clienteActivoDataGridViewCheckBoxColumn
            // 
            clienteActivoDataGridViewCheckBoxColumn.DataPropertyName = "ClienteActivo";
            clienteActivoDataGridViewCheckBoxColumn.HeaderText = "ClienteActivo";
            clienteActivoDataGridViewCheckBoxColumn.Name = "clienteActivoDataGridViewCheckBoxColumn";
            // 
            // deliveryIdDataGridViewTextBoxColumn
            // 
            deliveryIdDataGridViewTextBoxColumn.DataPropertyName = "DeliveryId";
            deliveryIdDataGridViewTextBoxColumn.HeaderText = "DeliveryId";
            deliveryIdDataGridViewTextBoxColumn.Name = "deliveryIdDataGridViewTextBoxColumn";
            deliveryIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // deliveryNombreDataGridViewTextBoxColumn
            // 
            deliveryNombreDataGridViewTextBoxColumn.DataPropertyName = "DeliveryNombre";
            deliveryNombreDataGridViewTextBoxColumn.HeaderText = "DeliveryNombre";
            deliveryNombreDataGridViewTextBoxColumn.Name = "deliveryNombreDataGridViewTextBoxColumn";
            // 
            // pedidoDTOBindingSource
            // 
            pedidoDTOBindingSource.DataSource = typeof(DTOs.PedidoDTO);
            // 
            // detallesPedidoBindingSource
            // 
            detallesPedidoBindingSource.DataMember = "DetallesPedido";
            detallesPedidoBindingSource.DataSource = pedidoDTOBindingSource;
            // 
            // traerTodosButton
            // 
            traerTodosButton.Location = new Point(681, 45);
            traerTodosButton.Name = "traerTodosButton";
            traerTodosButton.Size = new Size(157, 23);
            traerTodosButton.TabIndex = 11;
            traerTodosButton.Text = "Traer todos los pedidos";
            traerTodosButton.UseVisualStyleBackColor = true;
            traerTodosButton.Click += traerTodosButton_Click;
            // 
            // ReportePedido
            // 
            AcceptButton = DownloadButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1313, 570);
            Controls.Add(traerTodosButton);
            Controls.Add(dataGridViewPedidos);
            Controls.Add(DownloadButton);
            Controls.Add(estadoLabel);
            Controls.Add(estadoComboBox);
            Controls.Add(modalidadComboBox);
            Controls.Add(hastaDatePicker);
            Controls.Add(desdeDatePicker);
            Controls.Add(modalidadLabel);
            Controls.Add(hastaLabel);
            Controls.Add(desdeLabel);
            Controls.Add(label1);
            Name = "ReportePedido";
            Text = "Reporte de Pedidos";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).EndInit();
            ((System.ComponentModel.ISupportInitialize)pedidoDTOBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)detallesPedidoBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label desdeLabel;
        private Label hastaLabel;
        private Label modalidadLabel;
        private DateTimePicker desdeDatePicker;
        private DateTimePicker hastaDatePicker;
        private ComboBox modalidadComboBox;
        private ComboBox estadoComboBox;
        private Label estadoLabel;
        private Button DownloadButton;
        private DataGridView dataGridViewPedidos;
        private BindingSource pedidoDTOBindingSource;
        private BindingSource detallesPedidoBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn comentarioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn direccionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn modalidadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn calificacionPedidoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn calificacionDeliveryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn comentarioFinalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioTotalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn clienteIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn clienteNombreDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn clienteActivoDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn deliveryIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn deliveryNombreDataGridViewTextBoxColumn;
        private Button traerTodosButton;
    }
}