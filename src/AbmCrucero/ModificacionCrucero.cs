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

namespace FrbaCrucero.AbmCrucero
{
    public partial class ModificacionCrucero : Form
    {
        Crucero crucero;
        public ModificacionCrucero(Crucero crucero)
        {
            InitializeComponent();
            this.crucero = crucero;
        }

        private void ModificacionCrucero_Load(object sender, EventArgs e)
        {
            this.identificador.Text = crucero.identificador;
            SQL.SqlInfoCrucero queries = new SQL.SqlInfoCrucero();
            servicio.DataSource = queries.buscarServicios();
            fabricante.DataSource = queries.buscarFabricantes();
            modelo.DataSource = queries.buscarModelo();
            marca.DataSource = queries.buscarMarcas();
            cabinas.DataSource = new SQL.SqlCruceros().buscarCabinas(crucero.codCrucero);
        }

        private void cabinas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<Cabina> listaCabinas = (List<Cabina>)cabinas.DataSource;
            if (e.ColumnIndex == 1)
            {
                DialogResult result = Program.openPopUpWindow(this, new AltaCabina(listaCabinas[e.RowIndex]));
                if (result == DialogResult.OK)
                {
                }
            }
        }
    }
}
