using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Entidades;

namespace FrbaCrucero.GeneracionViaje
{
    public partial class VerRecorrido : Form
    {
        public VerRecorrido(Recorridos recorridos)
        {
            InitializeComponent();

            this.dataGridView1.DataSource = recorridos.tramos;
            this.dataGridView1.Columns["codRecorrido"].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
