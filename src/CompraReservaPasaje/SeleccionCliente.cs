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
        public SeleccionCliente(List<Int32> cabinasSeleccionadas, List<Cliente> clientes)
        {
            InitializeComponent();
        }
    }
}
