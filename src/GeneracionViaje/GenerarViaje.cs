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

namespace FrbaCrucero.GeneracionViaje
{
    public partial class GenerarViaje : Form
    {
        Recorridos recorrido=null;
        Crucero crucero = null;
        public DateTime fecha_salida;
        public DateTime fecha_llegada;


        public GenerarViaje()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new SeleccionRecorrido(this).Show();
        }

        public void Recorrido(Recorridos recorrido)
        {
            this.recorrido = recorrido;
            textBox1.Text = recorrido.idRecorrido.ToString();
        }

        public void CruceroDisponible(Crucero crucero)
        {
            this.crucero = crucero;
            textBox3.Text = crucero.identificador;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
            this.ValidarFechas();
            this.fecha_salida = this.dateTimePicker1.Value.Date;
            this.fecha_llegada = this.dateTimePicker2.Value.Date;
            new SeleccionCrucero(this).Show();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                    this.validar();
                    this.fecha_salida = this.dateTimePicker1.Value.Date;
                    this.fecha_llegada = this.dateTimePicker2.Value.Date;
                    int retorno = new SqlViaje().viaje(recorrido.idRecorrido, crucero.codCrucero, this.fecha_salida, this.fecha_llegada,this.Retorna());
                    switch (retorno)
                    {
                        case -1:
                            MessageBox.Show("Fecha Salida Invalida");
                            break;
                        case -2:
                            MessageBox.Show("No hay Cruceros Disponibles");
                            break;
                        case -3:
                            MessageBox.Show("Crucero NO DISPONIBLE");
                            break;
                        case -4:
                            MessageBox.Show("Recorrido Deshabilitado");
                            break;
                        case 1:
                            MessageBox.Show("Se Creo El Viaje. OKEY");
                            break;
                    }
                    this.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Boolean Retorna()
        {
            return this.recorrido.tramos.ElementAt(0).puertoSalida.codPuerto == this.recorrido.tramos.ElementAt(this.recorrido.tramos.Count-1).puertoLlegada.codPuerto;
        }

        private void validar()
        {
            ValidarFechas();

            if ((recorrido == null) || (crucero == null))
            {
                SystemException ex = new SystemException("Ingrese Crucero|Recorrido");
                throw ex;
            }
        }

        private void ValidarFechas()
        {
            if (Program.dia >= this.dateTimePicker1.Value.Date || Program.dia >= this.dateTimePicker2.Value.Date)
             {
                 SystemException ex = new SystemException("Las Fechas NO son mayores a la actual");
                 throw ex;
            }
        }
    }
}
