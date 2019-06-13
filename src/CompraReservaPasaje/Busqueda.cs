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

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class Busqueda : Form
    {
        List<Entidades.Puertos> puertos = new SQL.SqlPuertos().getPuertosHabilitados();
        DataTable viajesTable = new DataTable();
        public Busqueda()
        {
            
            InitializeComponent();
            foreach(Entidades.Puertos puerto in puertos)
            {
                origen.Items.Add(puerto.nombrePuerto);
                destino.Items.Add(puerto.nombrePuerto);
            }
            fecha.MinDate = Program.ObtenerFechaActual();
            fecha.Value = Program.ObtenerFechaActual();
            viajesTable.Columns.Add("idViaje");
            viajesTable.Columns.Add("fecha inicio");
            viajesTable.Columns.Add("fecha llegada");
            viajesTable.Columns.Add("retona");
            viajesTable.Columns.Add("puerto salida");
            viajesTable.Columns.Add("puerto llegada");
            viajesTable.Columns.Add("identificador crucero");
            grilla.DataSource = viajesTable;
            grilla.Columns["idViaje"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viajesTable.Rows.Clear();
            Entidades.Puertos puertoOrigen = origen.SelectedIndex != -1? puertos[origen.SelectedIndex] : null,
                              puertoDestino = destino.SelectedIndex != -1? puertos[destino.SelectedIndex] : null;
            List<Entidades.Viaje> viajes = new SQL.SqlViaje().buscarViajes(fecha.Value, puertoOrigen, puertoDestino);

            foreach (Entidades.Viaje viaje in viajes)
            {
                Entidades.Crucero crucero = viaje.crucero();
                List<Entidades.Tramos> paradas = (new SQL.SqlRecorridos()).getTramosRecorrido(viaje.codRecorrido);
                viajesTable.Rows.Add(new Object[] {
                    viaje.idViaje,
                    viaje.fechaInicio, 
                    viaje.fechaLlegada, 
                    viaje.retorna? "Sí" : "No", 
                    paradas.First().puertoSalida.nombrePuerto, 
                    paradas.Last().puertoLlegada.nombrePuerto, 
                    crucero.identificador
                });
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void grilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Int32 codViaje = Convert.ToInt32(grilla.Rows[e.RowIndex].Cells["idViaje"].Value.ToString());
                DialogResult result = Program.openNextWindow(this, new CompraReservaPasaje.Cabinas(codViaje));
                if (result == DialogResult.OK)
                    viajesTable.Clear();
            }
        }
    }
}
