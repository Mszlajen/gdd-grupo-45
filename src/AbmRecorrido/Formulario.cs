using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Entidades;
using FrbaCrucero.SQL;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class Formulario : Form
    {

        public List<Tramos> tramos = new List<Tramos>();
        Selector selector;

        public Formulario(Selector selector)
        {
            InitializeComponent();
            this.selector = selector;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
                new AbmRecorrido.AgregarTramo(this).Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.quitar.Index)
            {
                tramos.RemoveAt(e.RowIndex);

                int i = 1;
                foreach(Tramos tramo in tramos)
                {
                    tramo.nroTramo = (Byte) i;
                    i++;
                }


                this.actualizarGrilla();
            }
        }

        public void actualizarGrilla()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tramos;
            this.dataGridView1.Columns["codRecorrido"].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tramos.Any())
            {
                try
                {
                    new SqlRecorridos().insertarRecorrido(this.tramos);
                    MessageBox.Show("Recorrido guardado con exito");
                    selector.actualizarGrilla();
                    this.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Complete Informacion del Recorrido");
            }
        }
    }
}
