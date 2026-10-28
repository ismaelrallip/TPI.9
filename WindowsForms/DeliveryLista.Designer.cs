namespace WindowsForms
{
    partial class DeliveryLista
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
            deliveriesDataGridView = new DataGridView();
            buscarButton = new Button();
            buscarTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)deliveriesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // actualizarButton
            // 
            actualizarButton.Enabled = false;
            actualizarButton.Location = new Point(866, 771);
            actualizarButton.Margin = new Padding(2, 4, 2, 4);
            actualizarButton.Name = "actualizarButton";
            actualizarButton.Size = new Size(114, 36);
            actualizarButton.TabIndex = 16;
            actualizarButton.Text = "Actualizar";
            actualizarButton.UseVisualStyleBackColor = true;
            actualizarButton.Click += actualizarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Enabled = false;
            eliminarButton.Location = new Point(791, 1029);
            eliminarButton.Margin = new Padding(2, 4, 2, 4);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(179, 49);
            eliminarButton.TabIndex = 15;
            eliminarButton.Text = "Dar de Baja";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(1004, 771);
            agregarButton.Margin = new Padding(2, 4, 2, 4);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(114, 36);
            agregarButton.TabIndex = 14;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // deliveriesDataGridView
            // 
            deliveriesDataGridView.AllowUserToAddRows = false;
            deliveriesDataGridView.AllowUserToDeleteRows = false;
            deliveriesDataGridView.AllowUserToOrderColumns = true;
            deliveriesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            deliveriesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            deliveriesDataGridView.Location = new Point(46, 116);
            deliveriesDataGridView.Margin = new Padding(2, 4, 2, 4);
            deliveriesDataGridView.MultiSelect = false;
            deliveriesDataGridView.Name = "deliveriesDataGridView";
            deliveriesDataGridView.ReadOnly = true;
            deliveriesDataGridView.RowHeadersWidth = 82;
            deliveriesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            deliveriesDataGridView.Size = new Size(1072, 599);
            deliveriesDataGridView.TabIndex = 13;
            deliveriesDataGridView.SelectionChanged += deliveriesDataGridView_SelectionChanged;
            // 
            // buscarButton
            // 
            buscarButton.Location = new Point(486, 26);
            buscarButton.Margin = new Padding(2, 4, 2, 4);
            buscarButton.Name = "buscarButton";
            buscarButton.Size = new Size(92, 35);
            buscarButton.TabIndex = 12;
            buscarButton.Text = "Buscar";
            buscarButton.UseVisualStyleBackColor = true;
            buscarButton.Click += buscarButton_Click;
            // 
            // buscarTextBox
            // 
            buscarTextBox.Location = new Point(71, 24);
            buscarTextBox.Margin = new Padding(2, 4, 2, 4);
            buscarTextBox.Name = "buscarTextBox";
            buscarTextBox.PlaceholderText = "Buscar por nombre, apellido, teléfono o DNI...";
            buscarTextBox.Size = new Size(392, 31);
            buscarTextBox.TabIndex = 11;
            // 
            // DeliveryLista
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 901);
            Controls.Add(actualizarButton);
            Controls.Add(eliminarButton);
            Controls.Add(agregarButton);
            Controls.Add(deliveriesDataGridView);
            Controls.Add(buscarButton);
            Controls.Add(buscarTextBox);
            Margin = new Padding(4, 4, 4, 4);
            Name = "DeliveryLista";
            Text = "Deliveries";
            ((System.ComponentModel.ISupportInitialize)deliveriesDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button actualizarButton;
        private Button eliminarButton;
        private Button agregarButton;
        private DataGridView deliveriesDataGridView;
        private Button buscarButton;
        private TextBox buscarTextBox;
    }
}