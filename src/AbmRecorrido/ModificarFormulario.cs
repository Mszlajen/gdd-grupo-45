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
    public partial class ModificarFormulario : Form, FormTramos
    {

        Selector selector;
        Recorridos recorrido;
        List<Tramos> tramos;

        public ModificarFormulario(Selector selector,Recorridos recorrido)
        {
            InitializeComponent();
            this.selector = selector;
            this.recorrido = recorrido;
            this.tramos = recorrido.tramos;
            this.checkBox1.Checked = recorrido.estado;

            this.dataGridView1.DataSource = tramos;
            this.dataGridView1.Columns["codRecorrido"].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.quitar.Index)
            {
                tramos.RemoveAt(e.RowIndex);

                int i = 1;
                foreach (Tramos tramo in tramos)
                {
                    tramo.nroTramo = (Byte)i;
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

        public List<Tramos> getTramos()
        {
            return this.tramos;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AbmRecorrido.AgregarTramo(this).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tramos.Any())
            {
                try
                {
                    recorrido.tramos = tramos;
                    recorrido.estado = this.checkBox1.Checked;
                    new SqlRecorridos().actualizarRecorrido(this.recorrido);
                    MessageBox.Show("Recorrido modificado con exito");
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
