using System.ComponentModel.DataAnnotations;

namespace RegistroEF.Entidades
{
    //Colocamos Public Aqui Para que la clase se pueda encontrar en cualquier parte del proyecto
    public class TelefonosDetalle
    {
        //Esta es la llave primaria y luego de agregarla hay que agregar su libreria llamada using System.ComponentModel.DataAnnotations;
        [Key]
        // Atributos de nuestra clase 
        public int Id { get; set; }
        //colocamos una entidad para identificar el Id de la clase dueña del detalle con el mismo nombre del ID de la entidad dueña
        public int PersonaId { get; set; }
        public string TipoTelefono { get; set; }
        public string Telefono { get; set; }


        //Constructor vacio
        public TelefonosDetalle()
        {
            Id = 0;
            PersonaId = 0;
            TipoTelefono = string.Empty;
            Telefono = string.Empty;
        }

        //Constructor Con parametros sin Id
        public TelefonosDetalle(int idPersona, string tipoTelefono, string telefono)
        {
            PersonaId = idPersona;
            TipoTelefono = tipoTelefono;
            Telefono = telefono;
        }

        //Constructor Con parametros con ID
        public TelefonosDetalle(int id, int idPersona, string tipoTelefono, string telefono)
        {
            Id = id;
            PersonaId = idPersona;
            TipoTelefono = tipoTelefono;
            Telefono = telefono;
        }
    }
}
