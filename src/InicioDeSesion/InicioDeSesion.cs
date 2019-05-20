using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.InicioDeSesion
{
    public partial class InicioDeSesion : Form
    {

        private Menu.Menu _menuForm;

        public InicioDeSesion(Menu.Menu menuForm)
        {
            InitializeComponent();
            _menuForm = menuForm; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] array = { "OPCION_ADMIN1", "OPCION_ADMIN2", "OPCION_ADMIN3" };
            _menuForm.agregarFuncionalidadDeRoles(array);
            this.Close();
        }
    }
}
