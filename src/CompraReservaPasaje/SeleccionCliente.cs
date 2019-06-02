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

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class SeleccionCliente : Form
    {
        List<Cliente> clientes;
        List<Cabina> cabinasSeleccionadas;
        Viaje viaje;
        public SeleccionCliente(Viaje viaje, List<Cabina> cabinasSeleccionadas, List<Cliente> clientes)
        {
            InitializeComponent();
            this.clientes = clientes;
            dniLabel.Text += clientes.First().dni.ToString();
            grilla.DataSource = clientes;
            grilla.Columns["idCliente"].Visible = false;
            this.viaje = viaje;
            this.cabinasSeleccionadas = cabinasSeleccionadas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.openNextWindow(this, new Datos_Cliente(this.viaje, this.cabinasSeleccionadas, clientes.First().dni));
        }

        private void grilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Cliente cliente = clientes[e.RowIndex];
                if (new SqlClientes().validarDisponibilidad(cliente.idCliente, this.viaje.fechaInicio, this.viaje.fechaLlegada))
                    Program.openNextWindow(this, new Datos_Cliente(this.viaje, this.cabinasSeleccionadas, cliente));
                else
                    MessageBox.Show("Usted ya posee un viaje en esa fecha");
            }
        }
    }
}
