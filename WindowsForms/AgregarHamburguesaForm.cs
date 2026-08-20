using Application.Services;
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
    public partial class AgregarHamburguesaForm : Form
    {
        private readonly HamburguesaService _hamburguesaService;
        public AgregarHamburguesaForm(HamburguesaService hamburguesaService)
        {
            this._hamburguesaService = hamburguesaService;
            InitializeComponent();
        }

        private void AgregarHamburguesaForm_Load(object sender, EventArgs e)
        {

        }
    }
}
