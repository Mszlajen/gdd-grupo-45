using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.SQL;
using FrbaCrucero.Entidades;

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class DNI : Form
    {
        List<Int32> cabinasSeleccionadas;
        public DNI(List<Int32> cabinasSeleccionadas)
        {
            InitializeComponent();
            this.cabinasSeleccionadas = cabinasSeleccionadas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Decimal dni = Convert.ToDecimal(dniBox.Text);
            List<Cliente> clientes = new SqlClientes().buscarClientePorDNI(dni);
            if (clientes.Count == 0)
            {
                Program.openNextWindow(this, new Datos_Cliente(dni));
            }
            else if (clientes.Count == 1)
            {
                Program.openNextWindow(this, new Datos_Cliente(clientes.First()));
            }
            else
            {
                Program.openNextWindow(this, new SeleccionCliente(this.cabinasSeleccionadas, clientes));
            }
        }
    }
}
