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
            precioDeliveryToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesionToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { clientesToolStripMenuItem, deliveriesToolStripMenuItem, hamburguesasToolStripMenuItem, ingredientesToolStripMenuItem, precioDeliveryToolStripMenuItem, cerrarSesionToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 1, 0, 1);
            menuStrip1.Size = new Size(800, 26);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(75, 24);
            clientesToolStripMenuItem.Text = "Clientes";
            clientesToolStripMenuItem.Click += clientesToolStripMenuItem_Click;
            // 
            // deliveriesToolStripMenuItem
            // 
            deliveriesToolStripMenuItem.Name = "deliveriesToolStripMenuItem";
            deliveriesToolStripMenuItem.Size = new Size(88, 24);
            deliveriesToolStripMenuItem.Text = "Deliveries";
            deliveriesToolStripMenuItem.Click += deliveriesToolStripMenuItem_Click;
            // 
            // hamburguesasToolStripMenuItem
            // 
            hamburguesasToolStripMenuItem.Name = "hamburguesasToolStripMenuItem";
            hamburguesasToolStripMenuItem.Size = new Size(122, 24);
            hamburguesasToolStripMenuItem.Text = "Hamburguesas";
            hamburguesasToolStripMenuItem.Click += hamburguesasToolStripMenuItem_Click;
            // 
            // ingredientesToolStripMenuItem
            // 
            ingredientesToolStripMenuItem.Name = "ingredientesToolStripMenuItem";
            ingredientesToolStripMenuItem.Size = new Size(105, 24);
            ingredientesToolStripMenuItem.Text = "Ingredientes";
            ingredientesToolStripMenuItem.Click += ingredientesToolStripMenuItem_Click;
            // 
            // precioDeliveryToolStripMenuItem
            // 
            precioDeliveryToolStripMenuItem.Name = "precioDeliveryToolStripMenuItem";
            precioDeliveryToolStripMenuItem.Size = new Size(122, 24);
            precioDeliveryToolStripMenuItem.Text = "Precio Delivery";
            precioDeliveryToolStripMenuItem.Click += precioDeliveryToolStripMenuItem_Click;
            // 
            // cerrarSesionToolStripMenuItem
            // 
            cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            cerrarSesionToolStripMenuItem.Size = new Size(108, 24);
            cerrarSesionToolStripMenuItem.Text = "Cerrar sesion";
            cerrarSesionToolStripMenuItem.Click += cerrarSesionToolStripMenuItem_Click;
            // 
            // HomeAdministrador
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 449);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
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
        private ToolStripMenuItem precioDeliveryToolStripMenuItem;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
    }
}