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

        private Persona LlenaClase()
        {
            Persona persona = new Persona();
            persona.PersonaID = Convert.ToInt32(IDNumericUpDown.Value);
            persona.Nombre = NombeTextBox.Text;
            persona.Cedula = CedulaTextBox.Text;
            persona.Telefono = TelefonoTextBox.Text;
            persona.Direccion = DireccionTextBox.Text;
            persona.FechaNacimiento = FechaNacimientoDateTimePicker.Value;
            return persona;
        }

        private void LlenaCampo(Persona persona)
        {
            IDNumericUpDown.Value = persona.PersonaID;
            NombeTextBox.Text = persona.Nombre;
            TelefonoTextBox.Text = persona.Telefono;
            CedulaTextBox.Text = persona.Cedula;
            DireccionTextBox.Text = persona.Direccion;
            FechaNacimientoDateTimePicker.Value = persona.FechaNacimiento;
        }
        
        private bool GuardarValidar()
        {
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
                if(TelefonoTextBox.Text == string.Empty)
                {
                    SuperErrorProvider.SetError(TelefonoTextBox, "No puede dejar este campo vacio");
                    TelefonoTextBox.Focus();
                }
                if(NombeTextBox.Text == string.Empty)
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
            SuperErrorProvider.Clear();
            int id;
            int.TryParse(IDNumericUpDown.Text, out id);
            Persona persona = Personasbll.Buscar(id);
            Persona persona_guardar = LlenaClase();

            if (persona == null)
            {
                if (GuardarValidar())
                {
                    if (Personasbll.Guardar(persona_guardar))
                        MessageBox.Show("Persona guardada");
                    else
                        MessageBox.Show("Persona no guardada");
                }
            }
            else
            {
                if (GuardarValidar())
                {
                    if (Personasbll.Modificar(persona_guardar))
                        MessageBox.Show("Persona modificada");
                    else
                        MessageBox.Show("Persona no modificada");
                }
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            SuperErrorProvider.Clear();
            int id;
            Persona persona = new Persona();
            int.TryParse(IDNumericUpDown.Text, out id);

            persona = Personasbll.Buscar(id);

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

            if (Personasbll.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                SuperErrorProvider.SetError(IDNumericUpDown, "No se puede eliminar una persona que no existe");
        }
    }
}
