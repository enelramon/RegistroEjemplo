using System;
using RegistroEjemplo.Entidades;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using RegistroEjemplo.BLL;

namespace RegistroEjemplo.DAL
{
    public class Contexto: DbContext
    {
        public DbSet<Persona> Personas { get; set; }

        public Contexto(): base("ConStr")
        {

        }
    }
}
