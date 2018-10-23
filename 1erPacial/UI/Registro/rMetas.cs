using _1erPacial.BLL;
using _1erPacial.Entidades;
using PrimerPacial.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1erPacial.UI.Registro
{
    public partial class rMetas : Form
    {
        RepositorioBase<MetaDetalle> repositorio;
        public rMetas()
        {
            InitializeComponent();
        }

        private MetaDetalle LlenaClase()
        {
            MetaDetalle metaDetalle = new MetaDetalle();
            metaDetalle.MetaId = Convert.ToInt32(MetaIdNumericUpDown.Value);
           
            metaDetalle.Descripcion = DescripcionTextBox.Text;
            metaDetalle.Cuota = Convert.ToInt32(CuotaTextBox.Text);
            return metaDetalle;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            repositorio = new RepositorioBase<MetaDetalle>(new Contexto());
            MetaDetalle metaDetalle;
            bool paso = false;
           
            metaDetalle = LlenaClase();

            if (MetaIdNumericUpDown.Value == 0)
                paso = repositorio.Guardar(metaDetalle);
            else
            {
             
                paso = repositorio.Guardar(metaDetalle);
            }
           

            if (paso)
                MessageBox.Show("Guardado", "Con Exito!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo Guardar", "Error!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
