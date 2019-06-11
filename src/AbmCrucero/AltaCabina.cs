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
        public Cabina cabina { get; private set; }
        public Boolean paraReemplazar { get; private set; }
        public AltaCabina()
        {
            InitializeComponent();
            paraReemplazar = false;
        }

        public AltaCabina(Cabina cabina, Boolean paraReemplazar)
        {
            this.cabina = cabina;
            this.paraReemplazar = paraReemplazar;
            InitializeComponent();
        }

        private void AltaCabina_Load(object sender, EventArgs e)
        {
            List<TipoCabina> tipos = new SqlCabinas().getTiposCabina();
            this.tipoCabina.DataSource = tipos;
            this.tipoCabina.Enabled = !this.paraReemplazar;
            if (cabina != null)
            {
                this.tipoCabina.SelectedItem = tipos.Find(cab => cab.codTipo == cabina.codTipo);
                this.piso.Text = cabina.piso.ToString();
                this.numero.Text = cabina.numero.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Boolean valido = true;
            if (String.IsNullOrWhiteSpace(piso.Text) || !checkDecimal18(piso.Text))
            {
                valido = false;
                MessageBox.Show("El piso no es valido");
            }
            if (String.IsNullOrWhiteSpace(numero.Text) || !checkDecimal18(numero.Text))
            {
                valido = false;
                MessageBox.Show("El numero no es valido");
            }

            if (valido)
            {
                Decimal pisoValue = Convert.ToDecimal(piso.Text), numeroValue = Convert.ToDecimal(numero.Text);
                TipoCabina tipo = (TipoCabina)tipoCabina.SelectedItem;
                if (cabina == null)
                {
                    cabina = new Cabina(numeroValue, tipo.codTipo, pisoValue);
                    cabina.tipo = (TipoCabina)tipoCabina.SelectedItem;
                }
                else
                {
                    cabina.piso = pisoValue;
                    cabina.numero = numeroValue;
                    cabina.codTipo = tipo.codTipo;
                    cabina.tipo = tipo;
                }
                this.DialogResult = DialogResult.OK;
            }
        }
        private Boolean checkDecimal18(String text)
        {
            return text.All(c => '0' <= c && c <= '9') && text.Length <= 18;
        }
    }
}
