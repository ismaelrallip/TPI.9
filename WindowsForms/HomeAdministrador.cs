using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class HomeAdministrador : Form
    {
        public HomeAdministrador()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClienteLista clientesForm = new ClienteLista();
            clientesForm.ShowDialog();
        }

        private void deliveriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeliveryLista deliveriesForm = new DeliveryLista();
            deliveriesForm.ShowDialog();
        }
    }
}