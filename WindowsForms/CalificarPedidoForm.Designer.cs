namespace WindowsForms
{
    partial class CalificarPedidoForm
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
            label1 = new Label();
            numCalifPedido = new NumericUpDown();
            lblCalifDelivery = new Label();
            labelComentario = new Label();
            txtComentarioFinal = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            numCalifDelivery = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numCalifPedido).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCalifDelivery).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 33);
            label1.Name = "label1";
            label1.Size = new Size(207, 20);
            label1.TabIndex = 0;
            label1.Text = "Calificación del Pedido (1 a 5)";
            // 
            // numCalifPedido
            // 
            numCalifPedido.Location = new Point(261, 33);
            numCalifPedido.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numCalifPedido.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCalifPedido.Name = "numCalifPedido";
            numCalifPedido.Size = new Size(43, 27);
            numCalifPedido.TabIndex = 1;
            numCalifPedido.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lblCalifDelivery
            // 
            lblCalifDelivery.AutoSize = true;
            lblCalifDelivery.Location = new Point(24, 90);
            lblCalifDelivery.Name = "lblCalifDelivery";
            lblCalifDelivery.Size = new Size(215, 20);
            lblCalifDelivery.TabIndex = 2;
            lblCalifDelivery.Text = "Calificación del Delivery (1 a 5)";
            // 
            // labelComentario
            // 
            labelComentario.AutoSize = true;
            labelComentario.Location = new Point(24, 145);
            labelComentario.Name = "labelComentario";
            labelComentario.Size = new Size(190, 20);
            labelComentario.TabIndex = 4;
            labelComentario.Text = "Comentarios o sugerencias:";
            // 
            // txtComentarioFinal
            // 
            txtComentarioFinal.Location = new Point(24, 177);
            txtComentarioFinal.Multiline = true;
            txtComentarioFinal.Name = "txtComentarioFinal";
            txtComentarioFinal.ScrollBars = ScrollBars.Vertical;
            txtComentarioFinal.Size = new Size(417, 198);
            txtComentarioFinal.TabIndex = 5;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(319, 413);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(50, 413);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // numCalifDelivery
            // 
            numCalifDelivery.Location = new Point(261, 88);
            numCalifDelivery.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numCalifDelivery.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCalifDelivery.Name = "numCalifDelivery";
            numCalifDelivery.Size = new Size(43, 27);
            numCalifDelivery.TabIndex = 8;
            numCalifDelivery.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // CalificarPedidoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 479);
            Controls.Add(numCalifDelivery);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtComentarioFinal);
            Controls.Add(labelComentario);
            Controls.Add(lblCalifDelivery);
            Controls.Add(numCalifPedido);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CalificarPedidoForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Calificar Pedido";
            ((System.ComponentModel.ISupportInitialize)numCalifPedido).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCalifDelivery).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown numCalifPedido;
        private Label lblCalifDelivery;
        private Label labelComentario;
        private TextBox txtComentarioFinal;
        private Button btnGuardar;
        private Button btnCancelar;
        private NumericUpDown numCalifDelivery;
    }
}