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
    public partial class Datos_Cliente : Form
    {
        Cliente cliente = null;
        Viaje viaje;
        List<Cabina> cabinasSeleccionadas;
        public Datos_Cliente(Viaje viaje, List<Cabina> cabinasSeleccionadas, Decimal dni)
        {
            InitializeComponent();
            this.viaje = viaje;
            this.cabinasSeleccionadas = cabinasSeleccionadas;
            this.dni.Text = dni.ToString();
            this.nacimiento.Value = Program.ObtenerFechaActual();
            nacimiento.MaxDate = Program.ObtenerFechaActual();
        }

        public Datos_Cliente(Viaje viaje, List<Cabina> cabinasSeleccionadas, Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
            this.viaje = viaje;
            this.cabinasSeleccionadas = cabinasSeleccionadas;
            nombre.Text = cliente.nombre;
            apellido.Text = cliente.apellido;
            dni.Text = cliente.dni.ToString();
            direccion.Text = cliente.direccion;
            telefono.Text = cliente.telefono.ToString();
            nacimiento.Value = cliente.tieneNacimiento? cliente.nacimiento : Program.ObtenerFechaActual();
            nacimiento.MaxDate = Program.ObtenerFechaActual();
            mail.Text = cliente.mail;
        }

        private void pagarButton_Click(object sender, EventArgs e)
        {
            if (checkAndSaveCliente(this.cliente))
            {
                DialogResult result = Program.openPopUpWindow(this, new Pago(viaje, cabinasSeleccionadas, cliente));
                if (result == DialogResult.OK)
                    this.DialogResult = DialogResult.OK;
            }
        }

        private void reservarButton_Click(object sender, EventArgs e)
        {
            if (checkAndSaveCliente(this.cliente))
            {
                Reserva reserva = new SqlReservas().crearReserva(viaje.idViaje, cliente.idCliente, cabinasSeleccionadas);
                Program.openNextWindow(this, new PantallaFinal(viaje, cabinasSeleccionadas, reserva));
                this.DialogResult = DialogResult.OK;
            }
        }

        private Boolean checkAndSaveCliente(Cliente cliente)
        {
            Boolean valido = true;
            Decimal dniNum = 0;
            Int32 telefonoNum = 0;
            if (String.IsNullOrWhiteSpace(nombre.Text))
            {
                MessageBox.Show("El nombre no puede estar vacio");
                valido = false;
            }
            if (String.IsNullOrWhiteSpace(apellido.Text))
            {
                MessageBox.Show("El apellido no puede estar vacio");
                valido = false;
            }
            if (String.IsNullOrWhiteSpace(direccion.Text))
            {
                MessageBox.Show("La direccion no puede estar vacio");
                valido = false;
            }
            if (String.IsNullOrWhiteSpace(dni.Text) || !Decimal.TryParse(dni.Text, out dniNum))
            {
                MessageBox.Show("El DNI no puede estar vacio y debe ser un numero valido");
                valido = false;
            }
            if (String.IsNullOrWhiteSpace(telefono.Text) || !Int32.TryParse(telefono.Text, out telefonoNum))
            {
                MessageBox.Show("El numero de telefono no puede estar vacio y debe ser valido");
                valido = false;
            }
            if (valido)
            {
                if (this.cliente == null)
                    this.cliente = new SqlClientes().crearCliente(nombre.Text, apellido.Text, dniNum, direccion.Text, telefonoNum, mail.Text, nacimiento.Value);
                else
                {
                    this.cliente.nombre = nombre.Text;
                    this.cliente.apellido = apellido.Text;
                    this.cliente.dni = dniNum;
                    this.cliente.direccion = direccion.Text;
                    this.cliente.telefono = telefonoNum;
                    this.cliente.mail = mail.Text;
                    this.cliente.nacimiento = nacimiento.Value;
                    this.cliente.tieneNacimiento = true;
                    new SqlClientes().actualizarCliente(this.cliente);
                }
            }
            return valido;
        }
    }
}
