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

        private void PersonasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            rPersonas rPersonas = new rPersonas();
            rPersonas.MdiParent = this;
            rPersonas.Show();
        }

        private void PersonasToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            cPersonas cPersonas = new cPersonas();
            cPersonas.MdiParent = this;
            cPersonas.Show();
        }
    }
}
