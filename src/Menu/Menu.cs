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

namespace FrbaCrucero.Menu
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

            comboBox1.Items.Add("Compra y/o Reserva de Viaje");
            comboBox1.Items.Add("Pago Reserva");
            comboBox1.SelectedIndex = 0;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           InicioDeSesion.InicioDeSesion LoginForm = new InicioDeSesion.InicioDeSesion(this);
           LoginForm.Show();
        }

        public void agregarFuncionalidadDeRoles(Usuario usuario)
        {
            this.comboBox1.DisplayMember = "descFuncion";
            this.comboBox1.ValueMember = "this";
            if (usuario.userrol != null)
            {
                this.comboBox1.DataSource = usuario.userrol.funcionalidades;
            }
            else
            {
                this.comboBox1.DataSource = null;

                if (comboBox1.Items.Count == 0)
                {
                    comboBox1.Items.Add("Compra y/o Reserva de Viaje");
                    comboBox1.Items.Add("Pago Reserva");
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Ak comparar el textbox text selecccionado con un switch e ir poniendo 
 * las ventanas correspondientes a cada nombre*/
            if (comboBox1.Text.ToLower().Equals("compra y/o reserva de viaje"))
            {
                new CompraReservaPasaje.Busqueda().Show();
            }
            else if (comboBox1.Text.ToLower().Equals("pago reserva"))
            {
                new PagoReserva.Busqueda().Show();
            }
            else if (comboBox1.Text.ToLower().Equals("abm puertos"))
            {
                MessageBox.Show("ABM Puertos...");
            }
            else if (comboBox1.Text.ToLower().Equals("abm rol"))
            {
                new AbmRol.Seleccion().Show();
            }
            else if (comboBox1.Text.ToLower().Equals("abm usuarios"))
            {
                MessageBox.Show("ABM Usuarios...");
            }
            else if (comboBox1.Text.ToLower().Equals("abm recorridos"))
            {
                new AbmRecorrido.Selector().Show();
            }
            else if (comboBox1.Text.ToLower().Equals("abm cruceros"))
            {
                new AbmCrucero.Form1().Show();
            }
            else if (comboBox1.Text.ToLower().Equals("generar viaje"))
            {
                new GeneracionViaje.GenerarViaje().Show();
            }
            else if (comboBox1.Text.ToLower().Equals("listadostop"))
            {
                new ListadoEstadistico.ListadoTop5().Show();
            }
        }
    }
}
