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
    public partial class BajaCrucero : Form
    {
        Crucero crucero;
        Nullable<DateTime> bajaPermanente;
        public BajaCrucero(Crucero crucero)
        {
            InitializeComponent();
            fechaBaja.MinDate = Program.ObtenerFechaActual();
            fechaRegreso.MinDate = fechaBaja.Value;
            this.crucero = crucero;
            bajaPermanente = new SqlCruceros().fechaDeBajaPermanente(crucero.codCrucero);
            if (bajaPermanente.HasValue)
            {
                fechaBaja.MaxDate = bajaPermanente.Value;
                fechaRegreso.MaxDate = bajaPermanente.Value;
            }
        }

        private void permanente_CheckedChanged(object sender, EventArgs e)
        {
            fechaRegreso.Enabled = !permanente.Checked;
            corrimiento.Enabled = !permanente.Checked;
            fechaBaja.Enabled = !(permanente.Checked && bajaPermanente.HasValue);
            fechaBaja.Value = bajaPermanente.HasValue ? bajaPermanente.Value : fechaBaja.Value;
            if (!fechaBaja.Enabled)
                MessageBox.Show("Este crucero ya tiene una fecha de baja permanente");
        }

        private void fechaBaja_ValueChanged(object sender, EventArgs e)
        {
            fechaRegreso.MinDate = fechaBaja.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (permanente.Checked)
            {
                if (DialogResult.Yes == MessageBox.Show("¿Desea reemplazar el crucero en sus viajes? \n(En caso negativo se suspenderan)", "", MessageBoxButtons.YesNo))
                    Program.openPopUpWindow(this, new SeleccionReemplazante(crucero, fechaBaja.Value));
                else
                    new SqlCruceros().cancelarCrucero(fechaBaja.Value, crucero.codCrucero, "Crucero fue dado de baja permanentemente");
            }
            else
            {
                Int32 diasCorrimientos = 0;
                if (Int32.TryParse(corrimiento.Text, out diasCorrimientos))
                    new SqlCruceros().bajarTemporalmenteCrucero(fechaBaja.Value, fechaRegreso.Value, crucero.codCrucero, diasCorrimientos);
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
