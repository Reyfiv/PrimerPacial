using _1erPacial.UI.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1erPacial
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void vendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rVendedores rVendedores = new rVendedores();
            rVendedores.Show();
        }
    }
}
