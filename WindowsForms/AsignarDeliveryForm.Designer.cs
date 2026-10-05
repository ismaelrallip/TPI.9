namespace WindowsForms
{
    partial class AsignarDeliveryForm
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
            labelDelivery = new Label();
            comboRepartidores = new ComboBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // labelDelivery
            // 
            labelDelivery.AutoSize = true;
            labelDelivery.Location = new Point(95, 143);
            labelDelivery.Name = "labelDelivery";
            labelDelivery.Size = new Size(63, 20);
            labelDelivery.TabIndex = 0;
            labelDelivery.Text = "Delivery";
            // 
            // comboRepartidores
            // 
            comboRepartidores.FormattingEnabled = true;
            comboRepartidores.Location = new Point(176, 143);
            comboRepartidores.Name = "comboRepartidores";
            comboRepartidores.Size = new Size(357, 28);
            comboRepartidores.TabIndex = 1;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(176, 234);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 2;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(363, 234);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // AsignarDeliveryForm
            // 
            AcceptButton = btnAceptar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(comboRepartidores);
            Controls.Add(labelDelivery);
            Name = "AsignarDeliveryForm";
            Text = "Asignar Delivery";
            Load += AsignarDeliveryForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelDelivery;
        private ComboBox comboRepartidores;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}