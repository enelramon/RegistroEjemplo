using RegistroEF.Entidades;
using System.Data.Entity;

namespace RegistroEF.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> Personas { get; set; }

        public Contexto() : base("ConStr")
        { }
    }
}
