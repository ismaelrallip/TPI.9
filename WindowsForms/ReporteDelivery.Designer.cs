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
            desdeLabel.Location = new Point(44, 110);
            desdeLabel.Margin = new Padding(4, 0, 4, 0);
            desdeLabel.Name = "desdeLabel";
            desdeLabel.Size = new Size(62, 25);
            desdeLabel.TabIndex = 15;
            desdeLabel.Text = "Desde";
            // 
            // hastaLabel
            // 
            hastaLabel.AutoSize = true;
            hastaLabel.Location = new Point(529, 110);
            hastaLabel.Margin = new Padding(4, 0, 4, 0);
            hastaLabel.Name = "hastaLabel";
            hastaLabel.Size = new Size(57, 25);
            hastaLabel.TabIndex = 16;
            hastaLabel.Text = "Hasta";
            // 
            // downloadButton
            // 
            downloadButton.Location = new Point(1020, 110);
            downloadButton.Margin = new Padding(4, 5, 4, 5);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(143, 38);
            downloadButton.TabIndex = 17;
            downloadButton.Text = "Descargar PDF";
            downloadButton.UseVisualStyleBackColor = true;
            downloadButton.Click += downloadButton_Click;
            // 
            // desdeDatePicker
            // 
            desdeDatePicker.Location = new Point(109, 110);
            desdeDatePicker.Margin = new Padding(4, 5, 4, 5);
            desdeDatePicker.Name = "desdeDatePicker";
            desdeDatePicker.Size = new Size(327, 31);
            desdeDatePicker.TabIndex = 18;
            desdeDatePicker.ValueChanged += desdeDatePicker_ValueChanged;
            // 
            // hastaDatePicker
            // 
            hastaDatePicker.Location = new Point(590, 110);
            hastaDatePicker.Margin = new Padding(4, 5, 4, 5);
            hastaDatePicker.Name = "hastaDatePicker";
            hastaDatePicker.Size = new Size(327, 31);
            hastaDatePicker.TabIndex = 19;
            hastaDatePicker.ValueChanged += hastaDatePicker_ValueChanged;
            // 
            // deliveriesDataGridView
            // 
            deliveriesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            deliveriesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            deliveriesDataGridView.Location = new Point(44, 187);
            deliveriesDataGridView.Margin = new Padding(4, 5, 4, 5);
            deliveriesDataGridView.Name = "deliveriesDataGridView";
            deliveriesDataGridView.RowHeadersWidth = 62;
            deliveriesDataGridView.Size = new Size(1528, 890);
            deliveriesDataGridView.TabIndex = 20;
            // 
            // pedidoDTOBindingSource
            // 
            pedidoDTOBindingSource.DataSource = typeof(DTOs.PedidoDTO);
            // 
            // deliveryComboBox
            // 
            deliveryComboBox.FormattingEnabled = true;
            deliveryComboBox.Location = new Point(44, 43);
            deliveryComboBox.Margin = new Padding(4, 5, 4, 5);
            deliveryComboBox.Name = "deliveryComboBox";
            deliveryComboBox.Size = new Size(391, 33);
            deliveryComboBox.TabIndex = 21;
            deliveryComboBox.SelectedIndexChanged += deliveryComboBox_SelectedIndexChanged;
            // 
            // ReporteDelivery
            // 
            AcceptButton = downloadButton;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1746, 1102);
            Controls.Add(deliveryComboBox);
            Controls.Add(deliveriesDataGridView);
            Controls.Add(hastaDatePicker);
            Controls.Add(desdeDatePicker);
            Controls.Add(downloadButton);
            Controls.Add(hastaLabel);
            Controls.Add(desdeLabel);
            Margin = new Padding(4, 5, 4, 5);
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