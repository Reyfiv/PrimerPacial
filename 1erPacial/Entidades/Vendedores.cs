using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1erPacial.Entidades
{
    public class Vendedores
    {
        [Key]
        public int VendedorId { get; set; }
        public string Nombres { get; set; }
        public decimal Sueldo { get; set; }
        public decimal PorcientoRetencion { get; set; }
        public decimal Retencion { get; set; }
        public DateTime Fecha { get; set; }


        public Vendedores()
        {
            VendedorId = 0;
            Nombres = string.Empty;
            Sueldo = 0;
            PorcientoRetencion = 0;
            Retencion = 0;
            Fecha = DateTime.Now;
        }

    }

}

