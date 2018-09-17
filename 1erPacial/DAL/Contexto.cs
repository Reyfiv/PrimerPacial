using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerPacial.DAL
{
    class contexto : DbContext
    {
        public DbSet<>  { get; set; }

        public contexto() : base("ConStr")
        { }
    {
    }
}
