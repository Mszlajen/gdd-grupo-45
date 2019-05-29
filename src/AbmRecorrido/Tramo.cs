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

namespace FrbaCrucero.AbmRecorrido
{
    public partial class Tramo : Form
    {

        Puertos puertosalida;
        Puertos puertollegada;

        Tramos tramo = null;

        FormTramos _formulario;

        public Tramo(FormTramos formulario)
        {
            InitializeComponent();
            this._formulario = formulario;
        }

        public Tramo(FormTramos formulario,Tramos tramo)
        {
            InitializeComponent();
            this._formulario = formulario;
            this.tramo = tramo;
            this.puertosale(tramo.puertoSalida);
            this.puertollega(tramo.puertoLlegada);
            this.textBox3.Text = tramo.costoTramo.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AbmRecorrido.SeleccionPuerto(this,1).Show();
        }

        public void puertollega(Puertos puerto)
        {
            this.puertollegada = puerto;
            this.textBox2.Text = puerto.nombrePuerto;
        }

        public void puertosale(Puertos puerto)
        {
            this.puertosalida = puerto;
            this.textBox1.Text = puerto.nombrePuerto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            if (tramo != null)
            {
                    this.validar();
                    tramo.puertoSalida = this.puertosalida;
                    tramo.puertoLlegada = this.puertollegada;
                    tramo.costoTramo = Convert.ToDecimal(this.textBox3.Text);
                    _formulario.actualizarGrilla();
                    this.Close();
            }
            else
            {
                    this.validar();
                    _formulario.getTramos().Add(new Tramos((Byte)(_formulario.getTramos().Count), puertosalida, puertollegada, Convert.ToDecimal(textBox3.Text)));
                    _formulario.actualizarGrilla();
                    this.Close();
            }
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox3.Clear();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            new AbmRecorrido.SeleccionPuerto(this,0).Show();
        }

                private void validar()
        {
                if (textBox3.Text == "")
                {
                    SystemException ex = new SystemException("Ingresa Costo del Tramo");
		            throw ex;
                }

                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    SystemException ex = new SystemException("Ingrese Puertos de Llegada|Salida");
		            throw ex;
                }
        }
    }
}
