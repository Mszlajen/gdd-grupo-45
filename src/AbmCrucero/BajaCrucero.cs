using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmCrucero
{
    public partial class BajaCrucero : Form
    {
        public BajaCrucero()
        {
            InitializeComponent();
            fechaBaja.MinDate = Program.ObtenerFechaActual();
            fechaRegreso.MinDate = fechaBaja.Value;
        }

        private void baja_CheckedChanged(object sender, EventArgs e)
        {
            fechaBaja.Enabled = baja.Checked;
            permanente.Enabled = baja.Checked;
            regresa.Enabled = baja.Checked;
            fechaRegreso.Enabled = baja.Checked && !permanente.Checked && regresa.Checked;
        }

        private void permanente_CheckedChanged(object sender, EventArgs e)
        {
            regresa.Enabled = !permanente.Checked;
            fechaRegreso.Enabled = !permanente.Checked && regresa.Checked;
        }

        private void fechaBaja_ValueChanged(object sender, EventArgs e)
        {
            fechaRegreso.MinDate = fechaBaja.Value;
        }
    }
}
