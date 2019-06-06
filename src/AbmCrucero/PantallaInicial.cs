using FrbaCrucero.Entidades;
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
    public partial class PantallaInicial : Form
    {
        public PantallaInicial()
        {
            InitializeComponent();
        }

        private void PantallaInicial_Load(object sender, EventArgs e)
        {
            grilla.DataSource = new SQL.SqlCruceros().buscarCruceros();
            grilla.Columns["codCrucero"].Visible = false;
            grilla.Columns["codMarca"].Visible = false;
            grilla.Columns["codFabricante"].Visible = false;
            grilla.Columns["codServicio"].Visible = false;
            grilla.Columns["codModelo"].Visible = false;
        }

        private void grilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<Crucero> cruceros = (List<Crucero>)grilla.DataSource;
            if (e.ColumnIndex == 0)
            {
                Program.openPopUpWindow(this, new ModificacionCrucero(cruceros[e.RowIndex]));
            }
            else if (e.ColumnIndex == 1)
            {
                Program.openPopUpWindow(this, new BajaCrucero());
            }
        }

        private void nuevo_Click(object sender, EventArgs e)
        {
            Program.openPopUpWindow(this, new ModificacionCrucero());
        }
    }
}
