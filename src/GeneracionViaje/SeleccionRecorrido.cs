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

namespace FrbaCrucero.GeneracionViaje
{
    public partial class SeleccionRecorrido : Form
    {

        GenerarViaje formulario;

        public SeleccionRecorrido(GenerarViaje formulario)
        {
            InitializeComponent();
            this.formulario = formulario;
            actualizarGrilla();
        }

        public void actualizarGrilla()
        {
            BindingList<Recorridos> recorridos = new BindingList<Recorridos>(new SqlRecorridos().getRecorridosHabilitados());
            this.dataGridView1.DataSource = new BindingSource(recorridos, null);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.Seleccionar.Index)
            {
                formulario.Recorrido(this.dataGridView1.Rows[e.RowIndex].DataBoundItem as Recorridos);
                this.Close();
            }
            if (e.ColumnIndex == this.VerRecorrido.Index)
            {
                new VerRecorrido(this.dataGridView1.Rows[e.RowIndex].DataBoundItem as Recorridos).Show();
            }
        }
    }
}
