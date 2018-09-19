using _1erPacial.BLL;
using _1erPacial.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1erPacial.UI.Consulta
{
    public partial class cVendedores : Form
    {
        public cVendedores()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Expression<Func<Vendedores, bool>> Filtro = a => true;

            var listado = new List<Vendedores>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0://Todo
                        listado = VendedoresBLL.GetList(p => true);
                        break;
                    case 1://VendedorID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = VendedoresBLL.GetList(p => p.VendedorId == id);
                        break;
                    case 2: //Nombres
                        listado = VendedoresBLL.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                        break;
                    case 3: //Sueldo
                        listado = VendedoresBLL.GetList(p => p.Sueldo.Equals(CriterioTextBox.Text));
                        break;
                    case 4: //%Retencion
                        listado = VendedoresBLL.GetList(p => p.PorcientoRetencion.Equals(CriterioTextBox.Text));
                        break;
                    case 5: //Retencion
                        listado = VendedoresBLL.GetList(p => p.Retencion.Equals(CriterioTextBox.Text));
                        break;
                    case 6: //Fecha
                        listado = VendedoresBLL.GetList(p => p.Fecha.Equals(CriterioTextBox.Text));
                        break;
                }

            }
            else
                listado = VendedoresBLL.GetList(p => true);

            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = listado;
        }
    }
    
}
