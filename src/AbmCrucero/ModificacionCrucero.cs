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
        public Crucero crucero { get; private set; }
        List<Cabina> cabinasBorradas = new List<Cabina>();
        Boolean paraReemplazar;
        public ModificacionCrucero(Crucero crucero, Boolean paraReemplazar = false)
        {
            InitializeComponent();
            this.crucero = crucero;
            this.paraReemplazar = paraReemplazar;
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
                modelo.Enabled = !this.paraReemplazar;
                marca.SelectedItem = marcas.Find(t => crucero.codMarca == t.cod);
                fabricante.SelectedItem = fabricantes.Find(t => crucero.codFabricante == t.cod);
                servicio.SelectedItem = servicios.Find(t => crucero.codServicio == t.cod);
                servicio.Enabled = !this.paraReemplazar;
                if(crucero.fechaAlta.HasValue) 
                {
                    fechaAlta.Value = crucero.fechaAlta.Value;
                    checkFechaAlta.Checked = false;
                }
                else
                {
                    checkFechaAlta.Checked = true;
                    fechaAlta.Value = Program.ObtenerFechaActual();
                    fechaAlta.Enabled = false;
                }
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
                Program.openPopUpWindow(this, new AltaCabina(listaCabinas[e.RowIndex], this.paraReemplazar && listaCabinas[e.RowIndex].codCabina != 0));
            }
            if (e.ColumnIndex == 0)
            {
                DialogResult resp = MessageBox.Show("¿Está seguro que desea borrarla?", "", MessageBoxButtons.YesNo);
                if (resp == DialogResult.Yes)
                {
                    if (listaCabinas[e.RowIndex].codCabina != 0)
                    {
                        if (this.paraReemplazar)
                            MessageBox.Show("Esta cabina no puede borrarse ya que es necesaria para reemplazar al crucero.");
                        else
                            cabinasBorradas.Add(listaCabinas[e.RowIndex]);
                    }
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
                Marca marcaValue = (Marca)marca.SelectedItem;
                Modelo modeloValue = (Modelo)modelo.SelectedItem;
                Fabricante fabricanteValue = (Fabricante)fabricante.SelectedItem;
                Servicio servicioValue = (Servicio)servicio.SelectedItem;
                BindingList<Cabina> cabs = (BindingList<Cabina>)cabinas.DataSource;
                if (crucero == null || paraReemplazar)
                {
                    this.crucero = new SQL.SqlCruceros().crearCrucero(identificador.Text, servicioValue.cod, marcaValue.cod, fabricanteValue.cod, modeloValue.cod, getFechaAlta(), cabs);
                }
                else
                {
                    crucero = new Crucero(crucero.codCrucero, identificador.Text, this.getFechaAlta(), marcaValue.cod, modeloValue.cod, fabricanteValue.cod, servicioValue.cod);
                    new SQL.SqlCruceros().actualizarCrucero(crucero, cabs, cabinasBorradas);
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
