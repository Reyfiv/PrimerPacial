using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1erPacial.Entidades
{
    public class MetaDetalle
    {
        [Key]
        public int MetaId { get; set; }
        public int VendedorId { get; set; }
        public string Descripcion { get; set; }
        public decimal Cuota { get; set; }

        public MetaDetalle(int metaId, int vendedorId, string descripcion, decimal cuota)
        {
            MetaId = metaId;
            VendedorId = vendedorId;
            Descripcion = descripcion;
            Cuota = cuota;
        }

        public MetaDetalle()
        {
            MetaId = 0;
            VendedorId = 0;
            Descripcion = string.Empty;
            Cuota = 0;
        }
    }
}
