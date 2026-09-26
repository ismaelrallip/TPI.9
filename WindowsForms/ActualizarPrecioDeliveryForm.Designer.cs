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
            dateTimePicker1.Location = new Point(14, 81);
            dateTimePicker1.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(342, 34);
            dateTimePicker1.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(14, 179);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Precio...";
            textBox1.Size = new Size(171, 34);
            textBox1.TabIndex = 4;
            // 
            // buttonDeletePrecioDelivery
            // 
            buttonDeletePrecioDelivery.BackColor = Color.Red;
            buttonDeletePrecioDelivery.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            buttonDeletePrecioDelivery.ForeColor = SystemColors.ButtonHighlight;
            buttonDeletePrecioDelivery.Location = new Point(14, 357);
            buttonDeletePrecioDelivery.Margin = new Padding(2, 3, 2, 3);
            buttonDeletePrecioDelivery.Name = "buttonDeletePrecioDelivery";
            buttonDeletePrecioDelivery.Size = new Size(119, 43);
            buttonDeletePrecioDelivery.TabIndex = 21;
            buttonDeletePrecioDelivery.Text = "ELIMINAR";
            buttonDeletePrecioDelivery.UseVisualStyleBackColor = false;
            buttonDeletePrecioDelivery.Click += buttonDeletePrecioDelivery_Click;
            // 
            // buttonUpdatePrecioDelivery
            // 
            buttonUpdatePrecioDelivery.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            buttonUpdatePrecioDelivery.Location = new Point(499, 357);
            buttonUpdatePrecioDelivery.Margin = new Padding(2, 3, 2, 3);
            buttonUpdatePrecioDelivery.Name = "buttonUpdatePrecioDelivery";
            buttonUpdatePrecioDelivery.Size = new Size(155, 43);
            buttonUpdatePrecioDelivery.TabIndex = 20;
            buttonUpdatePrecioDelivery.Text = "ACTUALIZAR";
            buttonUpdatePrecioDelivery.UseVisualStyleBackColor = true;
            buttonUpdatePrecioDelivery.Click += buttonUpdatePrecioDelivery_Click;
            // 
            // ActualizarPrecioDeliveryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 433);
            Controls.Add(buttonDeletePrecioDelivery);
            Controls.Add(buttonUpdatePrecioDelivery);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ActualizarPrecioDeliveryForm";
            StartPosition = FormStartPosition.CenterParent;
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