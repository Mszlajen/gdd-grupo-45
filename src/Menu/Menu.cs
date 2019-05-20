using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.Menu
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

            comboBox1.Items.Add("OPCION_1");
            comboBox1.Items.Add("OPCION_2");
            comboBox1.Items.Add("OPCION_3");
            comboBox1.SelectedIndex = 0;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           InicioDeSesion.InicioDeSesion LoginForm = new InicioDeSesion.InicioDeSesion(this);
           LoginForm.Show();
        }

        public void agregarFuncionalidadDeRoles(string[] array)
        {
            comboBox1.Items.AddRange(array);
        }
    }
}
