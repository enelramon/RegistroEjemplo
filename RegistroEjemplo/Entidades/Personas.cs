using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RegistroEF.Entidades
{
    public class Personas
    {
        [Key]
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }

        //Lista tipo TelefonoDetalle 
        // Al colocarle virtual estamos llamando al LazyLoading 
        /* LazyLoading  consiste en retrasar la carga o inicialización de un objeto hasta el mismo momento de su utilización. 
         * ... El opuesto de la carga diferida es la carga previa, precarga o eager loading.*/

        public virtual List<TelefonosDetalle> Telefonos { get; set; }

        public Personas()
        {
            PersonaId = 0;
            Nombre = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            FechaNacimiento = DateTime.Now;

            Telefonos = new List<TelefonosDetalle>();
        }

        public Personas(int personaid, string nombre, string cedula, string direccion, DateTime fechanacimiento)
        {
            PersonaId = personaid;
            Nombre = nombre;
            Cedula = cedula;
            Direccion = direccion;
            FechaNacimiento = fechanacimiento;
            Telefonos = new List<TelefonosDetalle>();
        }
    }
}
