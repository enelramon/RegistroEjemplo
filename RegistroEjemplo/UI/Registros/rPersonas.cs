using RegistroEF.BLL;
using RegistroEF.Entidades;
using System;
using System.Windows.Forms;

namespace RegistroEF.UI
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
            NombreTextBox.Text = string.Empty;
            CedulamaskedTextBox.Text = string.Empty;
            TelefonomaskedTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            FechaNacimientoDateTimePicker.Value = DateTime.Now;
            MyErrorProvider.Clear();
        }

        //evento del boton nuevo en el que limpiamos los componentes del registro
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Personas LlenaClase()
        {
            Personas persona = new Personas();
            persona.PersonaId = Convert.ToInt32(IDNumericUpDown.Value);
            persona.Nombre = NombreTextBox.Text;
            persona.Cedula = CedulamaskedTextBox.Text;
            persona.Telefono = TelefonomaskedTextBox.Text;
            persona.Direccion = DireccionTextBox.Text;
            persona.FechaNacimiento = FechaNacimientoDateTimePicker.Value;
            return persona;
        }

        private void LlenaCampo(Personas persona)
        {
            IDNumericUpDown.Value = persona.PersonaId;
            NombreTextBox.Text = persona.Nombre;
            TelefonomaskedTextBox.Text = persona.Telefono;
            CedulamaskedTextBox.Text = persona.Cedula;
            DireccionTextBox.Text = persona.Direccion;
            FechaNacimientoDateTimePicker.Value = persona.FechaNacimiento;
        }

        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (NombreTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(NombreTextBox, "El campo Nombre no puede estar vacio");
                NombreTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                MyErrorProvider.SetError(DireccionTextBox, "El campo Direccion no puede estar vacio");
                DireccionTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CedulamaskedTextBox.Text.Replace("-", "")))
            {
                MyErrorProvider.SetError(CedulamaskedTextBox, "El campo Cedula no puede estar vacio");
                CedulamaskedTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(TelefonomaskedTextBox.Text.Replace("-", "")))
            {
                MyErrorProvider.SetError(TelefonomaskedTextBox, "El campo Telefono no puede estar vacio");
                TelefonomaskedTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {

            Personas persona;
            bool paso = false;

            if (!Validar())
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
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            MyErrorProvider.Clear();
            int id;
            int.TryParse(IDNumericUpDown.Text, out id);
            Limpiar();
            if (PersonasBll.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                MyErrorProvider.SetError(IDNumericUpDown, "No se puede eliminar una persona que no existe");
        }
    }
}
