namespace WindowsForms
{
    partial class HomeCliente
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
            perfilToolStripMenuItem = new ToolStripMenuItem();
            crearPedidoToolStripMenuItem = new ToolStripMenuItem();
            misPedidosToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesionToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { perfilToolStripMenuItem, crearPedidoToolStripMenuItem, misPedidosToolStripMenuItem, cerrarSesionToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // perfilToolStripMenuItem
            // 
            perfilToolStripMenuItem.Name = "perfilToolStripMenuItem";
            perfilToolStripMenuItem.Size = new Size(46, 20);
            perfilToolStripMenuItem.Text = "Perfil";
            perfilToolStripMenuItem.Click += perfilToolStripMenuItem_Click;
            // 
            // crearPedidoToolStripMenuItem
            // 
            crearPedidoToolStripMenuItem.Name = "crearPedidoToolStripMenuItem";
            crearPedidoToolStripMenuItem.Size = new Size(87, 20);
            crearPedidoToolStripMenuItem.Text = "Crear Pedido";
            // 
            // misPedidosToolStripMenuItem
            // 
            misPedidosToolStripMenuItem.Name = "misPedidosToolStripMenuItem";
            misPedidosToolStripMenuItem.Size = new Size(83, 20);
            misPedidosToolStripMenuItem.Text = "Mis Pedidos";
            // 
            // cerrarSesionToolStripMenuItem
            // 
            cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            cerrarSesionToolStripMenuItem.Size = new Size(87, 20);
            cerrarSesionToolStripMenuItem.Text = "Cerrar sesion";
            cerrarSesionToolStripMenuItem.Click += cerrarSesionToolStripMenuItem_Click;
            // 
            // HomeCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "HomeCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HomeCliente";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem perfilToolStripMenuItem;
        private ToolStripMenuItem crearPedidoToolStripMenuItem;
        private ToolStripMenuItem misPedidosToolStripMenuItem;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
    }
}