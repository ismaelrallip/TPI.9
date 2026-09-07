namespace WindowsForms
{
    partial class ActualizarPrecioDeliveryForm
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
            dateTimePicker1 = new DateTimePicker();
            textBox1 = new TextBox();
            buttonDeletePrecioDelivery = new Button();
            buttonUpdatePrecioDelivery = new Button();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Segoe UI", 12F);
            dateTimePicker1.Location = new Point(12, 61);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 29);
            dateTimePicker1.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(12, 134);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Precio...";
            textBox1.Size = new Size(150, 29);
            textBox1.TabIndex = 4;
            // 
            // buttonDeletePrecioDelivery
            // 
            buttonDeletePrecioDelivery.BackColor = Color.Red;
            buttonDeletePrecioDelivery.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            buttonDeletePrecioDelivery.ForeColor = SystemColors.ButtonHighlight;
            buttonDeletePrecioDelivery.Location = new Point(12, 317);
            buttonDeletePrecioDelivery.Margin = new Padding(2);
            buttonDeletePrecioDelivery.Name = "buttonDeletePrecioDelivery";
            buttonDeletePrecioDelivery.Size = new Size(104, 32);
            buttonDeletePrecioDelivery.TabIndex = 21;
            buttonDeletePrecioDelivery.Text = "ELIMINAR";
            buttonDeletePrecioDelivery.UseVisualStyleBackColor = false;
            buttonDeletePrecioDelivery.Click += buttonDeletePrecioDelivery_Click;
            // 
            // buttonUpdatePrecioDelivery
            // 
            buttonUpdatePrecioDelivery.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            buttonUpdatePrecioDelivery.Location = new Point(164, 317);
            buttonUpdatePrecioDelivery.Margin = new Padding(2);
            buttonUpdatePrecioDelivery.Name = "buttonUpdatePrecioDelivery";
            buttonUpdatePrecioDelivery.Size = new Size(136, 32);
            buttonUpdatePrecioDelivery.TabIndex = 20;
            buttonUpdatePrecioDelivery.Text = "ACTUALIZAR";
            buttonUpdatePrecioDelivery.UseVisualStyleBackColor = true;
            buttonUpdatePrecioDelivery.Click += buttonUpdatePrecioDelivery_Click;
            // 
            // ActualizarPrecioDeliveryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(328, 360);
            Controls.Add(buttonDeletePrecioDelivery);
            Controls.Add(buttonUpdatePrecioDelivery);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox1);
            Name = "ActualizarPrecioDeliveryForm";
            Text = "ActualizarPrecioDeliveryForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private TextBox textBox1;
        private Button buttonDeletePrecioDelivery;
        private Button buttonUpdatePrecioDelivery;
    }
}