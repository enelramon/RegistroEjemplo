using RegistroEF.BLL;
using RegistroEF.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RegistroEF.UI
{
    public partial class Consulta : Form
    {
        public Consulta()
        {
            InitializeComponent();
        }

        private void ConsultaButton_Click(object sender, EventArgs e)
        {
            var listado = new List<Personas>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0://Todo
                        listado = PersonasBll.GetList(p => true);
                        break;

                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = PersonasBll.GetList(p => p.PersonaId == id);
                        break;

                    case 2://Nombre
                        listado = PersonasBll.GetList(p => p.Nombre.Contains(CriterioTextBox.Text));
                        break;

                    case 3://Cedula
                        listado = PersonasBll.GetList(p => p.Cedula.Contains(CriterioTextBox.Text));
                        break;

                    case 4://Direccion
                        listado = PersonasBll.GetList(p => p.Direccion.Contains(CriterioTextBox.Text));
                        break;
                }

                listado = listado.Where(c => c.FechaNacimiento.Date >= DesdeDateTimePicker.Value.Date && c.FechaNacimiento.Date <= HastaDateTimePicker.Value.Date).ToList();
            }
            else
            {
                listado = PersonasBll.GetList(p => true);
            }

            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = listado;
        }
    }
}
