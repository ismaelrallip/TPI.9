namespace WindowsForms
{
    partial class ClienteLista
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
            buscarTextBox = new TextBox();
            buscarButton = new Button();
            clientesDataGridView = new DataGridView();
            actualizarButton = new Button();
            eliminarButton = new Button();
            agregarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)clientesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // buscarTextBox
            // 
            buscarTextBox.Location = new Point(71, 40);
            buscarTextBox.Margin = new Padding(2);
            buscarTextBox.Name = "buscarTextBox";
            buscarTextBox.PlaceholderText = "Buscar por nombre, apellido o email...";
            buscarTextBox.Size = new Size(263, 27);
            buscarTextBox.TabIndex = 5;
            // 
            // buscarButton
            // 
            buscarButton.Location = new Point(349, 43);
            buscarButton.Margin = new Padding(2);
            buscarButton.Name = "buscarButton";
            buscarButton.Size = new Size(74, 24);
            buscarButton.TabIndex = 6;
            buscarButton.Text = "Buscar";
            buscarButton.UseVisualStyleBackColor = true;
            buscarButton.Click += buscarButton_Click;
            // 
            // clientesDataGridView
            // 
            clientesDataGridView.AllowUserToAddRows = false;
            clientesDataGridView.AllowUserToDeleteRows = false;
            clientesDataGridView.AllowUserToOrderColumns = true;
            clientesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientesDataGridView.Location = new Point(51, 117);
            clientesDataGridView.Margin = new Padding(2);
            clientesDataGridView.MultiSelect = false;
            clientesDataGridView.Name = "clientesDataGridView";
            clientesDataGridView.ReadOnly = true;
            clientesDataGridView.RowHeadersWidth = 82;
            clientesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            clientesDataGridView.Size = new Size(858, 325);
            clientesDataGridView.TabIndex = 7;
            clientesDataGridView.SelectionChanged += clientesDataGridView_SelectionChanged;
            // 
            // actualizarButton
            // 
            actualizarButton.Enabled = false;
            actualizarButton.Location = new Point(711, 484);
            actualizarButton.Margin = new Padding(2);
            actualizarButton.Name = "actualizarButton";
            actualizarButton.Size = new Size(92, 29);
            actualizarButton.TabIndex = 10;
            actualizarButton.Text = "Actualizar";
            actualizarButton.UseVisualStyleBackColor = true;
            actualizarButton.Click += actualizarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Enabled = false;
            eliminarButton.Location = new Point(605, 484);
            eliminarButton.Margin = new Padding(2);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(92, 29);
            eliminarButton.TabIndex = 9;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(817, 484);
            agregarButton.Margin = new Padding(2);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(92, 29);
            agregarButton.TabIndex = 8;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // ClienteLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 573);
            Controls.Add(actualizarButton);
            Controls.Add(eliminarButton);
            Controls.Add(agregarButton);
            Controls.Add(clientesDataGridView);
            Controls.Add(buscarButton);
            Controls.Add(buscarTextBox);
            Name = "ClienteLista";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Clientes";
            Load += ClienteLista_Load;
            ((System.ComponentModel.ISupportInitialize)clientesDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox buscarTextBox;
        private Button buscarButton;
        private DataGridView clientesDataGridView;
        private Button actualizarButton;
        private Button eliminarButton;
        private Button agregarButton;
    }
}