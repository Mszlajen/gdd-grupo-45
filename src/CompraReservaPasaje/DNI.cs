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
                new Datos_Cliente().Show();
            }
            if (clientes.Count == 1)
            {
                new Datos_Cliente().Show();
            }
            else
            {
                new SeleccionCliente(this.cabinasSeleccionadas, clientes).Show();
            }
        }
    }
}
