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

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class SeleccionCliente : Form
    {
        List<Cliente> clientes;
        public SeleccionCliente(List<Int32> cabinasSeleccionadas, List<Cliente> clientes)
        {
            InitializeComponent();
            this.clientes = clientes;
            dniLabel.Text += clientes.First().dni.ToString();
            grilla.DataSource = clientes;
            grilla.Columns["idCliente"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.openNextWindow(this, new Datos_Cliente(clientes.First().dni));
        }

        private void grilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Program.openNextWindow(this, new Datos_Cliente(clientes[e.RowIndex]));
            }
        }
    }
}
