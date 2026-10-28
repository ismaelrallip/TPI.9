namespace WindowsForms
{
    partial class PrecioDeliveryHistorico
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
            agregarButton = new Button();
            PrecioDeliveryDataGridView = new DataGridView();
            buscarButton = new Button();
            dateTimePickerDesde = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)PrecioDeliveryDataGridView).BeginInit();
            SuspendLayout();
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(995, 768);
            agregarButton.Margin = new Padding(2, 4, 2, 4);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(114, 36);
            agregarButton.TabIndex = 14;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // PrecioDeliveryDataGridView
            // 
            PrecioDeliveryDataGridView.AllowUserToAddRows = false;
            PrecioDeliveryDataGridView.AllowUserToDeleteRows = false;
            PrecioDeliveryDataGridView.AllowUserToOrderColumns = true;
            PrecioDeliveryDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PrecioDeliveryDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PrecioDeliveryDataGridView.Location = new Point(36, 176);
            PrecioDeliveryDataGridView.Margin = new Padding(2, 4, 2, 4);
            PrecioDeliveryDataGridView.MultiSelect = false;
            PrecioDeliveryDataGridView.Name = "PrecioDeliveryDataGridView";
            PrecioDeliveryDataGridView.ReadOnly = true;
            PrecioDeliveryDataGridView.RowHeadersWidth = 82;
            PrecioDeliveryDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PrecioDeliveryDataGridView.Size = new Size(1072, 545);
            PrecioDeliveryDataGridView.TabIndex = 13;
            // 
            // buscarButton
            // 
            buscarButton.Location = new Point(494, 84);
            buscarButton.Margin = new Padding(2, 4, 2, 4);
            buscarButton.Name = "buscarButton";
            buscarButton.Size = new Size(92, 30);
            buscarButton.TabIndex = 12;
            buscarButton.Text = "Buscar";
            buscarButton.UseVisualStyleBackColor = true;
            buscarButton.Click += buscarButton_Click;
            // 
            // dateTimePickerDesde
            // 
            dateTimePickerDesde.Checked = false;
            dateTimePickerDesde.Location = new Point(79, 84);
            dateTimePickerDesde.Margin = new Padding(4, 5, 4, 5);
            dateTimePickerDesde.Name = "dateTimePickerDesde";
            dateTimePickerDesde.ShowCheckBox = true;
            dateTimePickerDesde.Size = new Size(389, 31);
            dateTimePickerDesde.TabIndex = 17;
            dateTimePickerDesde.Value = new DateTime(2026, 10, 14, 18, 16, 47, 0);
            // 
            // PrecioDeliveryHistorico
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 901);
            Controls.Add(dateTimePickerDesde);
            Controls.Add(agregarButton);
            Controls.Add(PrecioDeliveryDataGridView);
            Controls.Add(buscarButton);
            Margin = new Padding(4, 5, 4, 5);
            Name = "PrecioDeliveryHistorico";
            Text = "Precio Delivery Historico";
            Load += PrecioDeliveryHistorico_Load;
            ((System.ComponentModel.ISupportInitialize)PrecioDeliveryDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button agregarButton;
        private DataGridView PrecioDeliveryDataGridView;
        private Button buscarButton;
        private DateTimePicker dateTimePickerDesde;
    }
}