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
            actualizarButton = new Button();
            eliminarButton = new Button();
            agregarButton = new Button();
            PrecioDeliveryDataGridView = new DataGridView();
            buscarButton = new Button();
            dateTimePickerDesde = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)PrecioDeliveryDataGridView).BeginInit();
            SuspendLayout();
            // 
            // actualizarButton
            // 
            actualizarButton.Enabled = false;
            actualizarButton.Location = new Point(687, 614);
            actualizarButton.Margin = new Padding(2, 3, 2, 3);
            actualizarButton.Name = "actualizarButton";
            actualizarButton.Size = new Size(91, 29);
            actualizarButton.TabIndex = 16;
            actualizarButton.Text = "Actualizar";
            actualizarButton.UseVisualStyleBackColor = true;
            // 
            // eliminarButton
            // 
            eliminarButton.Enabled = false;
            eliminarButton.Location = new Point(580, 614);
            eliminarButton.Margin = new Padding(2, 3, 2, 3);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(91, 29);
            eliminarButton.TabIndex = 15;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(796, 614);
            agregarButton.Margin = new Padding(2, 3, 2, 3);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(91, 29);
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
            PrecioDeliveryDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PrecioDeliveryDataGridView.Location = new Point(29, 141);
            PrecioDeliveryDataGridView.Margin = new Padding(2, 3, 2, 3);
            PrecioDeliveryDataGridView.MultiSelect = false;
            PrecioDeliveryDataGridView.Name = "PrecioDeliveryDataGridView";
            PrecioDeliveryDataGridView.ReadOnly = true;
            PrecioDeliveryDataGridView.RowHeadersWidth = 82;
            PrecioDeliveryDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PrecioDeliveryDataGridView.Size = new Size(858, 436);
            PrecioDeliveryDataGridView.TabIndex = 13;
            PrecioDeliveryDataGridView.SelectionChanged += PrecioDeliveryDataGridView_SelectionChanged;
            // 
            // buscarButton
            // 
            buscarButton.Location = new Point(326, 67);
            buscarButton.Margin = new Padding(2, 3, 2, 3);
            buscarButton.Name = "buscarButton";
            buscarButton.Size = new Size(74, 24);
            buscarButton.TabIndex = 12;
            buscarButton.Text = "Buscar";
            buscarButton.UseVisualStyleBackColor = true;
            buscarButton.Click += buscarButton_Click;
            // 
            // dateTimePickerDesde
            // 
            dateTimePickerDesde.Location = new Point(63, 67);
            dateTimePickerDesde.Margin = new Padding(3, 4, 3, 4);
            dateTimePickerDesde.Name = "dateTimePickerDesde";
            dateTimePickerDesde.Size = new Size(228, 27);
            dateTimePickerDesde.TabIndex = 17;
            dateTimePickerDesde.Value = new DateTime(2026, 9, 6, 0, 0, 0, 0);
            // 
            // PrecioDeliveryHistorico
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 721);
            Controls.Add(dateTimePickerDesde);
            Controls.Add(actualizarButton);
            Controls.Add(eliminarButton);
            Controls.Add(agregarButton);
            Controls.Add(PrecioDeliveryDataGridView);
            Controls.Add(buscarButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PrecioDeliveryHistorico";
            Text = "PrecioDeliveryHistorico";
            Load += PrecioDeliveryHistorico_Load;
            ((System.ComponentModel.ISupportInitialize)PrecioDeliveryDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button actualizarButton;
        private Button eliminarButton;
        private Button agregarButton;
        private DataGridView PrecioDeliveryDataGridView;
        private Button buscarButton;
        private DateTimePicker dateTimePickerDesde;
    }
}