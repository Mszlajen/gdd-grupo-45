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
    public partial class Selector : Form
    {
        public Selector()
        {
            InitializeComponent();
            actualizarGrilla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AbmRecorrido.Formulario(this).Show();
        }

        public void actualizarGrilla()
        {
            BindingList<Recorridos> recorridos = new BindingList<Recorridos>(new SqlRecorridos().getRecorridos());
            this.dataGridView1.DataSource = new BindingSource(recorridos, null);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.Deshabilitar.Index)
            {
                new SqlRecorridos().eliminarLogico(this.dataGridView1.Rows[e.RowIndex].DataBoundItem as Recorridos);
                actualizarGrilla();
            }
            if (e.ColumnIndex == this.Editar.Index)
            {
                new ModificarFormulario(this, this.dataGridView1.Rows[e.RowIndex].DataBoundItem as Recorridos).Show();
            }
        }
    }
}
