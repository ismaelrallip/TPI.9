namespace WindowsForms
{
    partial class HomeAdministrador
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
            menuStrip1 = new MenuStrip();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            deliveriesToolStripMenuItem = new ToolStripMenuItem();
            hamburguesasToolStripMenuItem = new ToolStripMenuItem();
            ingredientesToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { clientesToolStripMenuItem, deliveriesToolStripMenuItem, hamburguesasToolStripMenuItem, ingredientesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 1, 0, 1);
            menuStrip1.Size = new Size(1000, 31);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(89, 29);
            clientesToolStripMenuItem.Text = "Clientes";
            clientesToolStripMenuItem.Click += clientesToolStripMenuItem_Click;
            // 
            // deliveriesToolStripMenuItem
            // 
            deliveriesToolStripMenuItem.Name = "deliveriesToolStripMenuItem";
            deliveriesToolStripMenuItem.Size = new Size(103, 29);
            deliveriesToolStripMenuItem.Text = "Deliveries";
            deliveriesToolStripMenuItem.Click += deliveriesToolStripMenuItem_Click;
            // 
            // hamburguesasToolStripMenuItem
            // 
            hamburguesasToolStripMenuItem.Name = "hamburguesasToolStripMenuItem";
            hamburguesasToolStripMenuItem.Size = new Size(148, 29);
            hamburguesasToolStripMenuItem.Text = "Hamburguesas";
            hamburguesasToolStripMenuItem.Click += hamburguesasToolStripMenuItem_Click;
            // 
            // ingredientesToolStripMenuItem
            // 
            ingredientesToolStripMenuItem.Name = "ingredientesToolStripMenuItem";
            ingredientesToolStripMenuItem.Size = new Size(126, 29);
            ingredientesToolStripMenuItem.Text = "Ingredientes";
            ingredientesToolStripMenuItem.Click += ingredientesToolStripMenuItem_Click;
            // 
            // HomeAdministrador
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 562);
            Controls.Add(menuStrip1);
            Margin = new Padding(4);
            Name = "HomeAdministrador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de gestión";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem deliveriesToolStripMenuItem;
        private ToolStripMenuItem hamburguesasToolStripMenuItem;
        private ToolStripMenuItem ingredientesToolStripMenuItem;
    }
}