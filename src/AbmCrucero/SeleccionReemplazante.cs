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
    public partial class SeleccionReemplazante : Form
    {
        Crucero crucero;
        DateTime fecha;
        public SeleccionReemplazante(Crucero crucero, DateTime fechaBaja)
        {
            InitializeComponent();
            this.crucero = crucero;
            this.fecha = fechaBaja;
        }

        private void SeleccionReemplazante_Load(object sender, EventArgs e)
        {
            List<Crucero> cruceros = new SqlCruceros().buscarPosiblesReemplazantes(crucero.codCrucero, fecha);
            if (cruceros.Count == 0)
            {
                DialogResult respuesta = MessageBox.Show("No hay cruceros que puedan reemplazar, ¿desea crear uno nuevo? \n (En caso negativo, se cancelaran los viajes involucrados)", "", MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                    reemplazarPorNuevo();
                else
                    new SqlCruceros().cancelarCrucero(fecha, crucero.codCrucero, "Crucero fue dado de baja permanentemente");
                this.DialogResult = DialogResult.OK;
            }
            else
                grilla.DataSource = cruceros;
        }

        private void grilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                List<Crucero> cruceros = (List<Crucero>) grilla.DataSource;
                new SqlCruceros().reemplazarCrucero(fecha, crucero.codCrucero, cruceros[e.RowIndex].codCrucero);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void botonNuevo_Click(object sender, EventArgs e)
        {
            reemplazarPorNuevo();
        }

        private void reemplazarPorNuevo()
        {
            ModificacionCrucero form = new ModificacionCrucero(this.crucero, true);
            if (DialogResult.OK == Program.openPopUpWindow(this, form))
            {
                new SqlCruceros().reemplazarCrucero(fecha, crucero.codCrucero, form.crucero.codCrucero);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
