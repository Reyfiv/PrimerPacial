using _1erPacial.BLL;
using _1erPacial.Entidades;
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
    public partial class rVendedores : Form
    {
        public rVendedores()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            VendedorIdNumericUpDown.Value = 0;
            NombresTextBox.Clear();
            SueldoNumericUpDown.Value = 0;
            PorcientoRetencionNumericUpDown.Value = 0;
            RetencionTextBox.Clear();
            FechaDateTimePicker.Value = DateTime.Now;
        }


        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Vendedores LlenaClase()
        {
            Vendedores vendedor = new Vendedores();
            vendedor.VendedorId = Convert.ToInt32(VendedorIdNumericUpDown.Value);
            vendedor.Nombres = NombresTextBox.Text;
            vendedor.Sueldo = Convert.ToDecimal(SueldoNumericUpDown.Value);
            vendedor.PorcientoRetencion = Convert.ToDecimal(PorcientoRetencionNumericUpDown.Value);
            vendedor.Retencion = Convert.ToDecimal(RetencionTextBox.Text);
            vendedor.Fecha = FechaDateTimePicker.Value;
            return vendedor;
        }

        public bool Validar()
        {
            bool validar = false;
            if (String.IsNullOrEmpty(NombresTextBox.Text))
            {
                errorProvider1.SetError(NombresTextBox, "Nombres esta vacios");
                validar = true;
            }
            return validar;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Vendedores vendedor = BLL.VendedoresBLL.Buscar((int)VendedorIdNumericUpDown.Value);
            return (vendedor != null);
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Vendedores vendedor;
            bool paso = false;
            if (Validar())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            vendedor = LlenaClase();

            if (VendedorIdNumericUpDown.Value == 0)
                paso = VendedoresBLL.Guardar(vendedor);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("El Vendedor no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = VendedoresBLL.Guardar(vendedor);
            }
            Limpiar();

            if (paso)
                MessageBox.Show("Guardado", "Con Exito!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo Guardar", "Error!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(VendedorIdNumericUpDown.Value);
            if (BLL.VendedoresBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(VendedorIdNumericUpDown.Value);
            Vendedores vendedor = BLL.VendedoresBLL.Buscar(id);
            if (vendedor != null)
            {
                NombresTextBox.Text = vendedor.Nombres;
                SueldoNumericUpDown.Value = vendedor.Sueldo;
                PorcientoRetencionNumericUpDown.Value = vendedor.PorcientoRetencion;
                RetencionTextBox.Text = vendedor.Retencion.ToString();
                FechaDateTimePicker.Value = vendedor.Fecha;
            }
        }

        private void SaldoNumericUpDownTextBox_ValueChanged(object sender, EventArgs e)
        {
            if(SueldoNumericUpDown.Value != 0 && PorcientoRetencionNumericUpDown.Value != 0)
            {
                decimal calculo;
                calculo = SueldoNumericUpDown.Value / PorcientoRetencionNumericUpDown.Value * 100;
                RetencionTextBox.Text = calculo.ToString();
            } 
        }

        private void PorcientoRetencionNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (SueldoNumericUpDown.Value != 0 && PorcientoRetencionNumericUpDown.Value != 0)
            {
                decimal calculo;
                calculo = SueldoNumericUpDown.Value / PorcientoRetencionNumericUpDown.Value * 100;
                RetencionTextBox.Text = calculo.ToString();
            }
        }
    }
}
