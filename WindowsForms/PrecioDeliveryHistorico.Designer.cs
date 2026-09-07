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
            actualizarButton.Location = new Point(602, 381);
            actualizarButton.Margin = new Padding(2);
            actualizarButton.Name = "actualizarButton";
            actualizarButton.Size = new Size(80, 22);
            actualizarButton.TabIndex = 16;
            actualizarButton.Text = "Actualizar";
            actualizarButton.UseVisualStyleBackColor = true;
            // 
            // eliminarButton
            // 
            eliminarButton.Enabled = false;
            eliminarButton.Location = new Point(509, 381);
            eliminarButton.Margin = new Padding(2);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(80, 22);
            eliminarButton.TabIndex = 15;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(695, 381);
            agregarButton.Margin = new Padding(2);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(80, 22);
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
            PrecioDeliveryDataGridView.Location = new Point(25, 106);
            PrecioDeliveryDataGridView.Margin = new Padding(2);
            PrecioDeliveryDataGridView.MultiSelect = false;
            PrecioDeliveryDataGridView.Name = "PrecioDeliveryDataGridView";
            PrecioDeliveryDataGridView.ReadOnly = true;
            PrecioDeliveryDataGridView.RowHeadersWidth = 82;
            PrecioDeliveryDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PrecioDeliveryDataGridView.Size = new Size(751, 244);
            PrecioDeliveryDataGridView.TabIndex = 13;
            PrecioDeliveryDataGridView.SelectionChanged += PrecioDeliveryDataGridView_SelectionChanged;
            // 
            // buscarButton
            // 
            buscarButton.Location = new Point(285, 50);
            buscarButton.Margin = new Padding(2);
            buscarButton.Name = "buscarButton";
            buscarButton.Size = new Size(65, 18);
            buscarButton.TabIndex = 12;
            buscarButton.Text = "Buscar";
            buscarButton.UseVisualStyleBackColor = true;
            buscarButton.Click += buscarButton_Click;
            // 
            // dateTimePickerDesde
            // 
            dateTimePickerDesde.Location = new Point(55, 50);
            dateTimePickerDesde.Name = "dateTimePickerDesde";
            dateTimePickerDesde.Size = new Size(200, 23);
            dateTimePickerDesde.TabIndex = 17;
            dateTimePickerDesde.Value = new DateTime(2026, 9, 6, 0, 0, 0, 0);
            // 
            // PrecioDeliveryHistorico
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dateTimePickerDesde);
            Controls.Add(actualizarButton);
            Controls.Add(eliminarButton);
            Controls.Add(agregarButton);
            Controls.Add(PrecioDeliveryDataGridView);
            Controls.Add(buscarButton);
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