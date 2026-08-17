using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace WindowsForms
{
    public partial class Home : Form
    {
        private MenuStrip menuStrip;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem deliveriesToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;

        public Home()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Sistema de Gestión - Hamburguesería (Entrega 2)";
            this.Width = 800;
            this.Height = 600;
            this.StartPosition = FormStartPosition.CenterScreen;

            menuStrip = new MenuStrip();
            clientesToolStripMenuItem = new ToolStripMenuItem("Clientes");
            deliveriesToolStripMenuItem = new ToolStripMenuItem("Deliveries");
            salirToolStripMenuItem = new ToolStripMenuItem("Salir");

            clientesToolStripMenuItem.Click += (s, e) => {
                var form = Program.ServiceProvider?.GetRequiredService<ClienteForm>();
                form?.ShowDialog();
            };

            deliveriesToolStripMenuItem.Click += (s, e) => {
                var form = Program.ServiceProvider?.GetRequiredService<DeliveryForm>();
                form?.ShowDialog();
            };

            salirToolStripMenuItem.Click += (s, e) => { this.Close(); };

            menuStrip.Items.Add(clientesToolStripMenuItem);
            menuStrip.Items.Add(deliveriesToolStripMenuItem);
            menuStrip.Items.Add(salirToolStripMenuItem);

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }
    }
}
