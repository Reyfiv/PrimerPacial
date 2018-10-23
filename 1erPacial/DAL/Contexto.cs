using _1erPacial.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerPacial.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Vendedores> Vendedores { get; set; }


        public Contexto() : base("ConStr")
        { }
    }

}

