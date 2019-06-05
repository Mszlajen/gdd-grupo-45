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
    public partial class SeleccionCrucero : Form
    {
        GenerarViaje formulario;

        public SeleccionCrucero(GenerarViaje formulario)
        {
            InitializeComponent();
            this.formulario = formulario;
            actualizarGrilla();
        }

        public void actualizarGrilla()
        {
            BindingList<Crucero> cruceros = new BindingList<Crucero>(new SqlCruceros().getCrucerosDisponibles(this.formulario.fecha_salida, this.formulario.fecha_llegada));
            this.dataGridView1.DataSource = new BindingSource(cruceros, null);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.Seleccionar.Index)
            {
                formulario.CruceroDisponible(this.dataGridView1.Rows[e.RowIndex].DataBoundItem as Crucero);
                this.Close();
            }
        }
    }
}
