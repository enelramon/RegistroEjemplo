using RegistroEjemplo.BLL;
using RegistroEjemplo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroEjemplo.UI
{
    public partial class Registro : Form
    {
        //Esta es la clase donde va la programacion del formulario del registro
        //Aqui llamamos la logica creada en la BLL
        public Registro()
        {
            InitializeComponent();
        }

        //Metodo para limpiar los componentes del registro
        private void Limpiar()
        {
            IDNumericUpDown.Value = 0;
            NombeTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            FechaNacimientoDateTimePicker.Value = DateTime.Now;
            SuperErrorProvider.Clear();
        }

        //evento del boton nuevo en el que limpiamos los componentes del registro
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Personas LlenaClase()
        {
            Personas persona = new Personas();
            persona.PersonaID = Convert.ToInt32(IDNumericUpDown.Value);
            persona.Nombre = NombeTextBox.Text;
            persona.Cedula = CedulaTextBox.Text;
            persona.Telefono = TelefonoTextBox.Text;
            persona.Direccion = DireccionTextBox.Text;
            persona.FechaNacimiento = FechaNacimientoDateTimePicker.Value;
            return persona;
        }

        private void LlenaCampo(Personas persona)
        {
            IDNumericUpDown.Value = persona.PersonaID;
            NombeTextBox.Text = persona.Nombre;
            TelefonoTextBox.Text = persona.Telefono;
            CedulaTextBox.Text = persona.Cedula;
            DireccionTextBox.Text = persona.Direccion;
            FechaNacimientoDateTimePicker.Value = persona.FechaNacimiento;
        }
        
        private bool Validar()
        {
            //var controles = this.Controls.OfType<TextBox>();

            //foreach (var item in controles)
            //{
            //    if (String.IsNullOrWhiteSpace(item.Text))
            //        SuperErrorProvider.SetError(item, "campo obligatorio");
            //}

            bool paso = true;

            if (NombeTextBox.Text == string.Empty || CedulaTextBox.Text == string.Empty || TelefonoTextBox.Text == string.Empty || DireccionTextBox.Text == string.Empty)
            {
                if (DireccionTextBox.Text == string.Empty)
                {
                    SuperErrorProvider.SetError(DireccionTextBox, "No puede dejar este campo vacio");
                    DireccionTextBox.Focus();
                }
                if (CedulaTextBox.Text == string.Empty)
                {
                    SuperErrorProvider.SetError(CedulaTextBox, "No puede dejar este campo vacio");
                    CedulaTextBox.Focus();
                }
                if (TelefonoTextBox.Text == string.Empty)
                {
                    SuperErrorProvider.SetError(TelefonoTextBox, "No puede dejar este campo vacio");
                    TelefonoTextBox.Focus();
                }
                if (NombeTextBox.Text == string.Empty)
                {
                    SuperErrorProvider.SetError(NombeTextBox, "No puede dejar este campo vacio");
                    NombeTextBox.Focus();
                }
                paso = false;
            }

            return paso;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            
            Personas persona;
            bool paso = false;
            
            if(!Validar())
                return;

            persona = LlenaClase();
            Limpiar();

            //Determinar si es guardar o modificar
            if (IDNumericUpDown.Value == 0)
                paso = PersonasBll.Guardar(persona);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una persona que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = PersonasBll.Modificar(persona);
            }
            
            //Informar el resultado
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private bool ExisteEnLaBaseDeDatos()
        {
            Personas persona = PersonasBll.Buscar((int)IDNumericUpDown.Value);

            return (persona != null);
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            
            int id;
            Personas persona = new Personas();
            int.TryParse(IDNumericUpDown.Text, out id);

            Limpiar();

            persona = PersonasBll.Buscar(id);

            if (persona != null)
            {
                MessageBox.Show("Persona Encontrada");
                LlenaCampo(persona);
            }
            else
            {
                MessageBox.Show("Persona no Encontada");
            }
        }
        
        private void EliminarButton_Click(object sender, EventArgs e)
        {
            SuperErrorProvider.Clear();
            int id;
            int.TryParse(IDNumericUpDown.Text, out id);
            Limpiar();
            if (PersonasBll.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                SuperErrorProvider.SetError(IDNumericUpDown, "No se puede eliminar una persona que no existe");
        }
    }
}
