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

namespace FrbaCrucero.AbmRol
{
    public partial class Seleccion : Form
    {

        Rol rol;

        public Seleccion()
        {
            InitializeComponent();
            actualizarGrilla();
        }

        public void actualizarGrilla()
        {
            BindingList<Rol> roles = new BindingList<Rol>(new SqlRoles().getRoles());
            this.dataGridView1.DataSource = new BindingSource(roles, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbmRol.altaRol altaRol = new AbmRol.altaRol(this);
            altaRol.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.Deshabilitar.Index)
            {
                new SqlRoles().eliminarLogico(this.dataGridView1.Rows[e.RowIndex].DataBoundItem as Rol);
                actualizarGrilla();
            }
        }

    }
}
