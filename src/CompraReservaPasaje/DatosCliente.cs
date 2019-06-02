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
    public partial class Datos_Cliente : Form
    {
        Cliente cliente = null;
        Viaje viaje;
        List<Int32> cabinasSeleccionadas;
        public Datos_Cliente(Viaje viaje, List<Int32> cabinasSeleccionadas, Decimal dni)
        {
            InitializeComponent();
            this.dni.Text = dni.ToString();
            this.nacimiento.Value = Program.ObtenerFechaActual();
        }

        public Datos_Cliente(Viaje viaje, List<Int32> cabinasSeleccionadas, Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
            nombre.Text = cliente.nombre;
            apellido.Text = cliente.apellido;
            dni.Text = cliente.dni.ToString();
            direccion.Text = cliente.direccion;
            telefono.Text = cliente.telefono.ToString();
            nacimiento.Value = cliente.tieneNacimiento? cliente.nacimiento : Program.ObtenerFechaActual();
        }
    }
}
