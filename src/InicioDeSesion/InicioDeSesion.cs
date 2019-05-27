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

namespace FrbaCrucero.InicioDeSesion
{
    public partial class InicioDeSesion : Form
    {

        private Menu.Menu _menuForm;
        private string username;
        private string password;

        public InicioDeSesion(Menu.Menu menuForm)
        {
            InitializeComponent();
            _menuForm = menuForm; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                username = textBox1.Text;
                password = textBox2.Text;

                int resultado = new SqlUsuarios().IniciarSesion(username, password);
                switch (resultado)
                {
                    case 0:
                        MessageBox.Show("USUARIO INHABILITADO.");
                        break;
                    case 1:
                        this.habilitarSeleccionDeRoles(username);
                        this.Close();
                        break;
                    case 2:
                        MessageBox.Show("Login FALLIDO. Al tercer intento fallido se inhabilita la Cuenta!");
                        break;
                    case 3:
                        MessageBox.Show("NO EXISTE EL USUARIO");
                        break;
                }

            }
            else
            {
                MessageBox.Show("Ingrese Datos de Login");
            }

        }

        private void habilitarSeleccionDeRoles(String username)
        {
            Usuario usuario = new Usuario(username, new SqlRoles().getRolUsuario(username));
            _menuForm.agregarFuncionalidadDeRoles(usuario);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
