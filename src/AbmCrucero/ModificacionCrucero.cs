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

namespace FrbaCrucero.AbmCrucero
{
    public partial class ModificacionCrucero : Form
    {
        Crucero crucero;
        public ModificacionCrucero(Crucero crucero)
        {
            InitializeComponent();
            this.crucero = crucero;
        }
        public ModificacionCrucero()
        {
            InitializeComponent();
        }

        private void ModificacionCrucero_Load(object sender, EventArgs e)
        {
            SQL.SqlInfoCrucero queries = new SQL.SqlInfoCrucero();
            List<Servicio> servicios = queries.buscarServicios();
            servicio.DataSource = servicios;
            List<Fabricante> fabricantes = queries.buscarFabricantes();
            fabricante.DataSource = fabricantes;
            List<Modelo> modelos = queries.buscarModelo();
            modelo.DataSource = modelos;
            List<Marca> marcas = queries.buscarMarcas();
            marca.DataSource = marcas;
            if (crucero != null)
            {
                this.identificador.Text = crucero.identificador;
                BindingList<Cabina> listaCabinas = new BindingList<Cabina>(new SQL.SqlCruceros().buscarCabinas(crucero.codCrucero));
                foreach (Cabina cabina in listaCabinas)
                    cabina.setTipoCabina();
                cabinas.DataSource = listaCabinas;
                modelo.SelectedItem = modelos.Find(t => crucero.codModelo == t.cod);
                marca.SelectedItem = marcas.Find(t => crucero.codMarca == t.cod);
                fabricante.SelectedItem = fabricantes.Find(t => crucero.codFabricante == t.cod);
                servicio.SelectedItem = servicios.Find(t => crucero.codServicio == t.cod);
                fechaAlta.Value = crucero.fechaAlta.HasValue? crucero.fechaAlta.Value : Program.ObtenerFechaActual();
            }
            else
            {
                cabinas.DataSource = new BindingList<Cabina>();
            }
            cabinas.Columns["codCabina"].Visible = false;
            cabinas.Columns["codCrucero"].Visible = false;
            cabinas.Columns["codTipo"].Visible = false;
        }

        private void cabinas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BindingList<Cabina> listaCabinas = (BindingList<Cabina>)cabinas.DataSource;
            if (e.ColumnIndex == 1)
            {
                DialogResult result = Program.openPopUpWindow(this, new AltaCabina(listaCabinas[e.RowIndex]));
                if (result == DialogResult.OK)
                {
                }
            }
            if (e.ColumnIndex == 0)
            {
                if (listaCabinas[e.RowIndex].codCabina == 0)
                {
                    listaCabinas.RemoveAt(e.RowIndex);
                }
            }
        }

        private void agregarCabina_Click(object sender, EventArgs e)
        {
            AltaCabina altaCabina = new AltaCabina();
            DialogResult result = Program.openPopUpWindow(this, altaCabina);
            if (result == DialogResult.OK)
            {
                BindingList<Cabina> listaCabinas = (BindingList<Cabina>)cabinas.DataSource;
                listaCabinas.Add(altaCabina.cabina);
            }
        }

        private void checkFechaAlta_CheckedChanged(object sender, EventArgs e)
        {
            fechaAlta.Enabled = !checkFechaAlta.Checked;
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            Boolean valido = true;
            if (String.IsNullOrWhiteSpace(identificador.Text) || identificador.Text.Length > 50)
            {
                valido = false;
                MessageBox.Show("El identificador no es valido");
            }

            if (valido)
            {
                if (crucero == null)
                {
                    Marca marcaValue = (Marca)marca.SelectedItem;
                    Modelo modeloValue = (Modelo)modelo.SelectedItem;
                    Fabricante fabricanteValue = (Fabricante)fabricante.SelectedItem;
                    Servicio servicioValue = (Servicio)servicio.SelectedItem;
                    BindingList<Cabina> cabs = (BindingList<Cabina>)cabinas.DataSource;
                    new SQL.SqlCruceros().crearCrucero(identificador.Text, servicioValue.cod, marcaValue.cod, fabricanteValue.cod, modeloValue.cod, getFechaAlta(), cabs);
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private Nullable<DateTime> getFechaAlta()
        {
            Nullable<DateTime> var = fechaAlta.Value;
            return !checkFechaAlta.Checked ? var : null;
        }
    }
}
