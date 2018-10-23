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
    public partial class rVendedores : Form
    {
        RepositorioBase<Vendedores> repositorio;

        public List<MetaDetalle> Detalle { get; set; }

        public rVendedores()
        {
            InitializeComponent();
            this.Detalle = new List<MetaDetalle>();
            LlenaCombo();
        }


        private void CargarGrid()
        {
            CuotaDataGridView.DataSource = null;
            CuotaDataGridView.DataSource = this.Detalle;
        }


        private void Limpiar()
        {
            errorProvider1.Clear();

            VendedorIdNumericUpDown.Value = 0;
            NombresTextBox.Clear();
            SueldoNumericUpDown.Value = 0;
            PorcientoRetencionNumericUpDown.Value = 0;
            RetencionTextBox.Clear();
            FechaDateTimePicker.Value = DateTime.Now;

            this.Detalle = new List<MetaDetalle>();
            CargarGrid();
        }


        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void LlenaCampo(Vendedores vendedores)
        {
            VendedorIdNumericUpDown.Value = vendedores.VendedorId;
            NombresTextBox.Text = vendedores.Nombres;
            SueldoNumericUpDown.Value = vendedores.Sueldo;
            PorcientoRetencionNumericUpDown.Value = vendedores.PorcientoRetencion;
            RetencionTextBox.Text = Convert.ToString(vendedores.Retencion);
            FechaDateTimePicker.Value = vendedores.Fecha;

            this.Detalle = vendedores.Cuota;
            CargarGrid();
           
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

            vendedor.Cuota = this.Detalle; 
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

        private bool ValidarDetalle()
        {
            bool validarDetalle = false;
            errorProvider1.Clear();

            if (String.IsNullOrWhiteSpace(CuotaTextBox.Text))
            {
                errorProvider1.SetError(CuotaTextBox, "La Cuota esta vacia");
                validarDetalle = true;
            }

            return validarDetalle;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            repositorio = new RepositorioBase<Vendedores>(new Contexto());
            Vendedores vendedor = repositorio.Buscar((int)VendedorIdNumericUpDown.Value);
            return (vendedor != null);
        }

        private void LlenaCombo()
        {

            var MetaRepositorio = new RepositorioBase<MetaDetalle>(new Contexto());
            var lista = MetaRepositorio.GetList(c => true);
            MetasComboBox.DataSource = lista;
            MetasComboBox.ValueMember = "MetaId";
            MetasComboBox.DisplayMember = "Descripcion";
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            repositorio = new RepositorioBase<Vendedores>(new Contexto());
            Vendedores vendedor;
            bool paso = false;
            if (Validar())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            vendedor = LlenaClase();

            if (VendedorIdNumericUpDown.Value == 0)
                paso = repositorio.Guardar(vendedor);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("El Vendedor no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = repositorio.Modificar(vendedor);
            }
            Limpiar();

            if (paso)
                MessageBox.Show("Guardado", "Con Exito!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo Guardar", "Error!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            repositorio = new RepositorioBase<Vendedores>(new Contexto());
            int id = Convert.ToInt32(VendedorIdNumericUpDown.Value);
            if (repositorio.Eliminar(id))
            {
                MessageBox.Show("Eliminado", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            repositorio = new RepositorioBase<Vendedores>(new Contexto());
            int id = Convert.ToInt32(VendedorIdNumericUpDown.Value);
            Vendedores vendedor = repositorio.Buscar(id);
            if (vendedor != null)
            {
                NombresTextBox.Text = vendedor.Nombres;
                SueldoNumericUpDown.Value = vendedor.Sueldo;
                PorcientoRetencionNumericUpDown.Value = vendedor.PorcientoRetencion;
                RetencionTextBox.Text = vendedor.Retencion.ToString();
                FechaDateTimePicker.Value = vendedor.Fecha;
                CuotaDataGridView.DataSource = vendedor.Cuota;
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

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            if (CuotaDataGridView.DataSource != null)
                this.Detalle = (List<MetaDetalle>)CuotaDataGridView.DataSource;

            if (ValidarDetalle())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Detalle.Add(
                new MetaDetalle(
                    metaId: 0,
                    vendedorId: 0,
                    descripcion: MetasComboBox.Text,
                    cuota: Convert.ToDecimal(CuotaTextBox.Text)
                    ));
            CargarGrid();
            CuotaTextBox.Focus();
            CuotaTextBox.Clear();
        }

        private void RemoverFilaButton_Click(object sender, EventArgs e)
        {
            if (CuotaDataGridView.Rows.Count > 0 && CuotaDataGridView.CurrentRow != null)
            {
                Detalle.RemoveAt(CuotaDataGridView.CurrentRow.Index);

                CargarGrid();
            }
        }

        private void MasMetasButton_Click(object sender, EventArgs e)
        {
            rMetas rMetas = new rMetas();
            rMetas.ShowDialog();
            LlenaCombo();
        }
    }
}
