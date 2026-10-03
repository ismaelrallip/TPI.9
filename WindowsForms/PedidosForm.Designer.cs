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
            buttonVerPedido = new Button();
            buttonUpdatePedido = new Button();
            dataGridViewPedidos = new DataGridView();
            dateTimePickerFiltro = new DateTimePicker();
            labelFondoRadioButtons = new Label();
            comboBoxFiltro = new ComboBox();
            labelFiltroPedidos = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).BeginInit();
            SuspendLayout();
            // 
            // buttonVerPedido
            // 
            buttonVerPedido.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold);
            buttonVerPedido.Location = new Point(1252, 610);
            buttonVerPedido.Margin = new Padding(2);
            buttonVerPedido.Name = "buttonVerPedido";
            buttonVerPedido.Size = new Size(154, 36);
            buttonVerPedido.TabIndex = 11;
            buttonVerPedido.Text = "VER PEDIDO";
            buttonVerPedido.UseVisualStyleBackColor = true;
            // 
            // buttonUpdatePedido
            // 
            buttonUpdatePedido.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold);
            buttonUpdatePedido.Location = new Point(1427, 610);
            buttonUpdatePedido.Margin = new Padding(2);
            buttonUpdatePedido.Name = "buttonUpdatePedido";
            buttonUpdatePedido.Size = new Size(128, 36);
            buttonUpdatePedido.TabIndex = 10;
            buttonUpdatePedido.Text = "MODIFICAR";
            buttonUpdatePedido.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPedidos
            // 
            dataGridViewPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPedidos.Location = new Point(62, 76);
            dataGridViewPedidos.Margin = new Padding(2);
            dataGridViewPedidos.MultiSelect = false;
            dataGridViewPedidos.Name = "dataGridViewPedidos";
            dataGridViewPedidos.ReadOnly = true;
            dataGridViewPedidos.RowHeadersWidth = 62;
            dataGridViewPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPedidos.Size = new Size(1072, 570);
            dataGridViewPedidos.TabIndex = 7;
            // 
            // dateTimePickerFiltro
            // 
            dateTimePickerFiltro.Location = new Point(1186, 149);
            dateTimePickerFiltro.Name = "dateTimePickerFiltro";
            dateTimePickerFiltro.Size = new Size(352, 31);
            dateTimePickerFiltro.TabIndex = 12;
            // 
            // labelFondoRadioButtons
            // 
            labelFondoRadioButtons.BackColor = SystemColors.ControlDark;
            labelFondoRadioButtons.BorderStyle = BorderStyle.FixedSingle;
            labelFondoRadioButtons.Location = new Point(1167, 76);
            labelFondoRadioButtons.Name = "labelFondoRadioButtons";
            labelFondoRadioButtons.Size = new Size(388, 261);
            labelFondoRadioButtons.TabIndex = 16;
            // 
            // comboBoxFiltro
            // 
            comboBoxFiltro.FormattingEnabled = true;
            comboBoxFiltro.Location = new Point(1186, 228);
            comboBoxFiltro.Name = "comboBoxFiltro";
            comboBoxFiltro.Size = new Size(256, 33);
            comboBoxFiltro.TabIndex = 17;
            // 
            // labelFiltroPedidos
            // 
            labelFiltroPedidos.AutoSize = true;
            labelFiltroPedidos.BackColor = SystemColors.ControlDark;
            labelFiltroPedidos.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFiltroPedidos.Location = new Point(1267, 94);
            labelFiltroPedidos.Name = "labelFiltroPedidos";
            labelFiltroPedidos.Size = new Size(184, 32);
            labelFiltroPedidos.TabIndex = 18;
            labelFiltroPedidos.Text = "Filtrar Pedidos";
            // 
            // PedidosForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1636, 696);
            Controls.Add(labelFiltroPedidos);
            Controls.Add(comboBoxFiltro);
            Controls.Add(dateTimePickerFiltro);
            Controls.Add(buttonVerPedido);
            Controls.Add(buttonUpdatePedido);
            Controls.Add(dataGridViewPedidos);
            Controls.Add(labelFondoRadioButtons);
            Name = "PedidosForm";
            Text = "PedidosForm";
            Load += PedidosForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonVerPedido;
        private Button buttonUpdatePedido;
        private DataGridView dataGridViewPedidos;
        private DateTimePicker dateTimePickerFiltro;
        private Label labelFondoRadioButtons;
        private ComboBox comboBoxFiltro;
        private Label labelFiltroPedidos;
    }
}