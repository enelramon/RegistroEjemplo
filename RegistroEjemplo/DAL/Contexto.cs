using System;
using RegistroEF.Entidades;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using RegistroEF.BLL;

namespace RegistroEF.DAL
{
    public class Contexto: DbContext
    {
        public DbSet<Personas> Personas { get; set; }

        public Contexto(): base("ConStr")
        {        }
    }
}
