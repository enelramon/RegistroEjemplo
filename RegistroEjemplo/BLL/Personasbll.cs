using RegistroEjemplo.BLL;
using RegistroEjemplo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroEjemplo.Entidades
{
    public class Personasbll
    {




        //Este es el metodo para eliminar en la base de datos
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Personas.Find(id);
                db.Entry(eliminar).State = System.Data.Entity.EntityState.Deleted;

                paso = (db.SaveChanges() > 0);
                db.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        //Este es el metodo para modificar en la base de datos
        public static bool Modificar(Persona persona)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(persona).State = System.Data.Entity.EntityState.Modified;
                paso = (db.SaveChanges() > 0);
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }



        //Este es el metodo para buscar en la base de datos
        public static Persona Buscar(int id)
        {
            Contexto db = new Contexto();
            Persona persona = new Persona();
            try
            {
                persona = db.Personas.Find(id);
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return persona;
        }

        internal static bool Guardar(Persona persona)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Personas.Add(persona) != null)
                {
                    db.SaveChanges();
                    paso = true;
                }

                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        //Este es el metodo para listar o consultar lo que tenemos en la base de datos
        public static List<Persona> GetList(Expression<Func<Persona, bool>> persona)
        {
            List<Persona> people = new List<Persona>();
            Contexto db = new Contexto();
            try
            {
                people = db.Personas.Where(persona).ToList();
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return people;
        }




    }
}
