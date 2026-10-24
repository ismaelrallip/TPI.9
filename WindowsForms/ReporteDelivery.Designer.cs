namespace WindowsForms
{
    partial class ReporteDelivery
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
            desdeLabel = new Label();
            hastaLabel = new Label();
            downloadButton = new Button();
            desdeDatePicker = new DateTimePicker();
            hastaDatePicker = new DateTimePicker();
            deliveriesDataGridView = new DataGridView();
            pedidoDTOBindingSource = new BindingSource(components);
            deliveryComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)deliveriesDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pedidoDTOBindingSource).BeginInit();
            SuspendLayout();
            // 
            // desdeLabel
            // 
            desdeLabel.AutoSize = true;
            desdeLabel.Location = new Point(31, 66);
            desdeLabel.Name = "desdeLabel";
            desdeLabel.Size = new Size(39, 15);
            desdeLabel.TabIndex = 15;
            desdeLabel.Text = "Desde";
            // 
            // hastaLabel
            // 
            hastaLabel.AutoSize = true;
            hastaLabel.Location = new Point(370, 66);
            hastaLabel.Name = "hastaLabel";
            hastaLabel.Size = new Size(37, 15);
            hastaLabel.TabIndex = 16;
            hastaLabel.Text = "Hasta";
            // 
            // downloadButton
            // 
            downloadButton.Location = new Point(714, 66);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(100, 23);
            downloadButton.TabIndex = 17;
            downloadButton.Text = "Descargar PDF";
            downloadButton.UseVisualStyleBackColor = true;
            downloadButton.Click += downloadButton_Click;
            // 
            // desdeDatePicker
            // 
            desdeDatePicker.Location = new Point(76, 66);
            desdeDatePicker.Name = "desdeDatePicker";
            desdeDatePicker.Size = new Size(230, 23);
            desdeDatePicker.TabIndex = 18;
            desdeDatePicker.ValueChanged += desdeDatePicker_ValueChanged;
            // 
            // hastaDatePicker
            // 
            hastaDatePicker.Location = new Point(413, 66);
            hastaDatePicker.Name = "hastaDatePicker";
            hastaDatePicker.Size = new Size(230, 23);
            hastaDatePicker.TabIndex = 19;
            hastaDatePicker.ValueChanged += hastaDatePicker_ValueChanged;
            // 
            // deliveriesDataGridView
            // 
            deliveriesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            deliveriesDataGridView.Location = new Point(31, 112);
            deliveriesDataGridView.Name = "deliveriesDataGridView";
            deliveriesDataGridView.Size = new Size(920, 437);
            deliveriesDataGridView.TabIndex = 20;
            // 
            // pedidoDTOBindingSource
            // 
            pedidoDTOBindingSource.DataSource = typeof(DTOs.PedidoDTO);
            // 
            // deliveryComboBox
            // 
            deliveryComboBox.FormattingEnabled = true;
            deliveryComboBox.Location = new Point(31, 26);
            deliveryComboBox.Name = "deliveryComboBox";
            deliveryComboBox.Size = new Size(275, 23);
            deliveryComboBox.TabIndex = 21;
            deliveryComboBox.SelectedIndexChanged += deliveryComboBox_SelectedIndexChanged;
            // 
            // ReporteDelivery
            // 
            AcceptButton = downloadButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1222, 583);
            Controls.Add(deliveryComboBox);
            Controls.Add(deliveriesDataGridView);
            Controls.Add(hastaDatePicker);
            Controls.Add(desdeDatePicker);
            Controls.Add(downloadButton);
            Controls.Add(hastaLabel);
            Controls.Add(desdeLabel);
            Name = "ReporteDelivery";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reporte de Delivery";
            ((System.ComponentModel.ISupportInitialize)deliveriesDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pedidoDTOBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label desdeLabel;
        private Label hastaLabel;
        private Button downloadButton;
        private DateTimePicker desdeDatePicker;
        private DateTimePicker hastaDatePicker;
        private DataGridView deliveriesDataGridView;
        private BindingSource pedidoDTOBindingSource;
        private ComboBox deliveryComboBox;
    }
}