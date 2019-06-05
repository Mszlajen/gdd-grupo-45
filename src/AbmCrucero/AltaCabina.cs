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

namespace FrbaCrucero.AbmCrucero
{
    public partial class AltaCabina : Form
    {
        Cabina cabina;
        public AltaCabina()
        {
            InitializeComponent();
        }

        public AltaCabina(Cabina cabina)
        {
            this.cabina = cabina;
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AltaCabina_Load(object sender, EventArgs e)
        {
            List<TipoCabina> tipos = new SqlCabinas().getTiposCabina();
            this.tipoCabina.DataSource = tipos;
            if (cabina != null)
            {
                this.tipoCabina.SelectedItem = tipos.Find(cab => cab.codTipo == cabina.codTipo);
                this.piso.Text = cabina.piso.ToString();
                this.numero.Text = cabina.numero.ToString();
            }
        }
    }
}
