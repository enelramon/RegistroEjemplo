using RegistroEF.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroEF
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro rg = new Registro();
            rg.MdiParent = this;
            rg.Show();
        }

        private void personasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Consulta cs = new Consulta();
            cs.MdiParent = this;
            cs.Show();
        }
    }
}
