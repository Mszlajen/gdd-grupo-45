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

                int i = 0;
                foreach (Tramos tramo in tramos)
                {
                    tramo.nroTramo = (Byte)i;
                    i++;
                }


                this.actualizarGrilla();
            }

            if (e.ColumnIndex == this.Modificar.Index)
            {
                new Tramo(this, this.dataGridView1.Rows[e.RowIndex].DataBoundItem as Tramos).Show();
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
            new AbmRecorrido.Tramo(this).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tramos.Any())
            {
                try
                {
                    this.validarTramos();
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

        private void validarTramos()
        {
            Puertos salida;

            int i = 0;
            foreach (Tramos tramo in tramos)
            {
                salida = tramo.puertoSalida;

                if (i > 0)
                {
                    if (!(salida.codPuerto == tramos.ElementAt(i - 1).puertoLlegada.codPuerto))
                    {
                        SystemException ex = new SystemException("Los Tramos No Son Validos");
                        throw ex;
                    }
                }
                i++;
            }

        }
    }
}
