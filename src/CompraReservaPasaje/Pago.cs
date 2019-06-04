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
    public partial class Pago : Form
    {
        Viaje viaje;
        List<Cabina> cabinas;
        Cliente cliente;
        List<MedioDePago> medios = new SqlPagos().mediosDePagos();
        public Pago(Viaje viaje, List<Cabina> cabinasSeleccionadas, Cliente cliente)
        {
            InitializeComponent();
            this.viaje = viaje;
            this.cabinas = cabinasSeleccionadas;
            this.cliente = cliente;
            
            vencAnio.Minimum = Program.ObtenerFechaActual().Year;
            vencAnio.Maximum = vencAnio.Minimum + 10;
            vencAnio.Value = vencAnio.Minimum;
            vencMes.Value = Program.ObtenerFechaActual().Month;

            formas.DataSource = medios;
            formas.SelectedIndex = -1;
        }

        private void pagarButton_Click(object sender, EventArgs e)
        {
            Boolean valido = true;
            DateTime fecha = Program.ObtenerFechaActual();
            int mes = fecha.Month, anio = fecha.Year;
            if (formas.SelectedIndex == -1)
            {
                valido = false;
                MessageBox.Show("Debe seleccionar un medio de pago");
            }
            if (String.IsNullOrWhiteSpace(numTarjeta.Text) || !checkStringIsNumber(numTarjeta.Text) || !validateCreditCardNumber((MedioDePago) formas.SelectedItem, numTarjeta.Text))
            {
                valido = false;
                MessageBox.Show("El numero de tarjeta no es valido");
            }
            if (String.IsNullOrWhiteSpace(codSeguridad.Text) || !checkStringIsNumber(codSeguridad.Text) || codSeguridad.Text.Length >= 4)
            {
                MessageBox.Show("El codigo de seguridad no es valido");
                valido = false;
            }
            if (vencAnio.Value == anio && mes > vencMes.Value)
            {
                valido = false;
                MessageBox.Show("La tarjeta ya se encuentra vencida");
            }

            if (valido)
            {
                SqlPagos queries = new SqlPagos();
                Int32 cod_pago = queries.crearPago(viaje.idViaje, cliente.idCliente, cabinas, numTarjeta.Text, codSeguridad.Text, Program.ObtenerFechaActual(), ((MedioDePago)formas.SelectedItem).id);
                Entidades.Pago pago = queries.buscarPago(cod_pago);
                Program.openNextWindow(this, new PantallaFinal(viaje, cabinas, pago));
            }
            
        }

        private Boolean checkStringIsNumber(String text)
        {
            return text.All((char c) => c >= '0' || '9' >= c);
        }

        /*Como existe un formato al numero de tarjeta y su tipo de tarjeta, en este metodo
         * escribirias dicha validación
         */
        private Boolean validateCreditCardNumber(MedioDePago medio, String numero)
        {
            return true;
        }
    }
}
