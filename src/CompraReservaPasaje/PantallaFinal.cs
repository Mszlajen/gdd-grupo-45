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
    public partial class PantallaFinal : Form
    {
        public PantallaFinal(Viaje viaje, List<Cabina> cabinas, TipoPasaje tipoPasaje)
        {
            InitializeComponent();
            voucher.Text = tipoPasaje.id.ToString();
            tipo.Text = tipoPasaje.tipo;
            salida.Text = viaje.fechaInicio.ToString();
            llegada.Text = viaje.fechaLlegada.ToString();
            crucero.Text = viaje.crucero().identificador;
            costo.Text = tipoPasaje.pasaje().costo.ToString();
            this.cabinas.DataSource = cabinas;
            this.cabinas.Columns["codCabina"].Visible = false;
            this.cabinas.Columns["codCrucero"].Visible = false;
            this.cabinas.Columns["codTipo"].Visible = false;
            //Agregar que impirma el nombre del Tipo de cabina
            List<Tramos> tramos = viaje.recorrido().tramos;
            this.puertos.Rows.Add(new Object[] { tramos.First().puertoSalida.nombrePuerto });
            foreach (Tramos tramo in tramos)
            {
                this.puertos.Rows.Add(new Object[] { tramo.puertoLlegada.nombrePuerto });
            }
        }
    }
}
