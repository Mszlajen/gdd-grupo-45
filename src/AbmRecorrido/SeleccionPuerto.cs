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
using FrbaCrucero.SQL;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class SeleccionPuerto : Form
    {

        private AgregarTramo formulario;
        private int tipo_puerto;

        public SeleccionPuerto(AgregarTramo formulario, int tipo_puerto)
        {
            InitializeComponent();

            this.formulario = formulario;
            this.tipo_puerto = tipo_puerto;
            BindingList<Puertos> puertos = new BindingList<Puertos>(new SqlPuertos().getPuertos());
            this.dataGridView1.DataSource = new BindingSource(puertos, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindingList<Puertos> puertos = new BindingList<Puertos>(new SqlPuertos().getPuertos(this.textBox1.Text));
            this.dataGridView1.DataSource = new BindingSource(puertos, null);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.seleccionado.Index)
            {
                if (tipo_puerto == 0)
                {
                    formulario.puertosale(this.dataGridView1.Rows[e.RowIndex].DataBoundItem as Puertos);
                }
                else
                {
                    formulario.puertollega(this.dataGridView1.Rows[e.RowIndex].DataBoundItem as Puertos);
                }
                this.Close();
            }
        }

    }
}
