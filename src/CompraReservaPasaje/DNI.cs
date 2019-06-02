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
        List<Cabina> cabinasSeleccionadas;
        Viaje viaje;
        public DNI(Viaje viaje, List<Cabina> cabinasSeleccionadas)
        {
            InitializeComponent();
            this.cabinasSeleccionadas = cabinasSeleccionadas;
            this.viaje = viaje;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Decimal dni = 0;
            if (String.IsNullOrWhiteSpace(dniBox.Text))
            {
                MessageBox.Show("Ingrese un DNI por favor");
                return;
            }
            else if (!Decimal.TryParse(dniBox.Text, out dni))
            {
                MessageBox.Show("El DNI ingresado no es valido");
                return;
            }
            List<Cliente> clientes = new SqlClientes().buscarClientePorDNI(dni);
            if (clientes.Count == 0)
            {
                Program.openNextWindow(this, new Datos_Cliente(this.viaje, this.cabinasSeleccionadas, dni));
            }
            else if (clientes.Count == 1)
            {
                Cliente cliente = clientes.First();
                if (new SqlClientes().validarDisponibilidad(cliente.idCliente, this.viaje.fechaInicio, this.viaje.fechaLlegada))
                    Program.openNextWindow(this, new Datos_Cliente(this.viaje, this.cabinasSeleccionadas, cliente));
                else
                    MessageBox.Show("Usted ya posee un viaje en esa fecha");
            }
            else
            {
                Program.openNextWindow(this, new SeleccionCliente(this.viaje, this.cabinasSeleccionadas, clientes));
            }
        }
    }
}
