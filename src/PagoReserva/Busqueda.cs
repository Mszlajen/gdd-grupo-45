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

namespace FrbaCrucero.PagoReserva
{
    public partial class Busqueda : Form
    {
        public Busqueda()
        {
            InitializeComponent();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            Int32 cod_reserva = 0;
            if (!String.IsNullOrWhiteSpace(codigo.Text) && Int32.TryParse(codigo.Text, out cod_reserva))
            {
                Reserva reserva = new SqlReservas().buscarReserva(cod_reserva);
                DialogResult result = Program.openNextWindow(this, new CompraReservaPasaje.Pago(reserva));
                if (result == DialogResult.OK)
                    this.DialogResult = DialogResult.OK;
            }
        }
    }
}
