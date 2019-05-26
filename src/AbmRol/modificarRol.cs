using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Entidades;
using FrbaCrucero.SQL;

namespace FrbaCrucero.AbmRol
{
    public partial class modificarRol : Form
  {
        private Rol rol;
        private List<Funcionalidad> funcionalidades;
        private List<Funcionalidad> funcSeleccionadas;
        private AbmRol.Seleccion _seleccionForm;

        public modificarRol(AbmRol.Seleccion seleccionForm,Rol rol)
        {
            InitializeComponent();
            _seleccionForm = seleccionForm;
            this.rol = rol;
            funcionalidades = new SqlRoles().getFuncionesTotales();
            this.funcSeleccionadas = this.rol.funcionalidades;
            this.comboBoxFuncionalidades.DisplayMember = "descFuncion";
            this.comboBoxFuncionalidades.ValueMember = "this";
            this.comboBoxFuncionalidades.DataSource = funcionalidades;

            this.textBoxDesc.Text = rol.desc;
            this.comboBoxEstado.Text = rol.estado.ToString();
            this.comboBoxRegistrable.Text = rol.registrable.ToString();
            this.actualizarTextBox();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            _seleccionForm.actualizarGrilla();
            this.Close();
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                new SqlRoles().actualizarRol(new Rol(Convert.ToBoolean(this.comboBoxEstado.Text), Convert.ToBoolean(this.comboBoxRegistrable.Text), this.textBoxDesc.Text, this.funcSeleccionadas),rol);
                MessageBox.Show("Modificado con exito");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonRemover_Click(object sender, EventArgs e)
        {
            if (this.funcSeleccionadas.Any(elem => elem.descFuncion.Equals(((Funcionalidad)this.comboBoxFuncionalidades.SelectedValue).descFuncion)))
            {
                this.funcSeleccionadas.Remove(this.funcSeleccionadas.Find(elem => elem.descFuncion.Equals(((Funcionalidad)this.comboBoxFuncionalidades.SelectedValue).descFuncion)));
                this.actualizarTextBox();
            }
            else
                MessageBox.Show("No esta seleccionado esta funcionalidad");
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (!this.funcSeleccionadas.Any(elem => elem.descFuncion.Equals(((Funcionalidad)this.comboBoxFuncionalidades.SelectedValue).descFuncion)))
            {
                this.funcSeleccionadas.Add(this.comboBoxFuncionalidades.SelectedValue as Funcionalidad);
                this.actualizarTextBox();
            }
            else
                MessageBox.Show("Ya esta agregada esta funcionalidad");
        }

        private void actualizarTextBox()
        {
            this.textBoxFuncionalidades.Clear();
            String total = "";
            foreach (Funcionalidad func in this.funcSeleccionadas)
            {
                total += func.descFuncion + Environment.NewLine;
            }
            this.textBoxFuncionalidades.Text = total;
        }

        private void validar()
        {
            if (this.textBoxDesc.TextLength <= 0)
            {
                SystemException ex = new SystemException("Debes ponerle una descripcion");
                throw ex;
            }
            if (this.comboBoxEstado.SelectedIndex == -1)
            {
                SystemException ex = new SystemException("Seleccione si el rol esta habilitado");
                throw ex;
            }
            if (this.comboBoxRegistrable.SelectedIndex == -1)
            {
                SystemException ex = new SystemException("Seleccione si el rol es registrable");
                throw ex;
            }
        }
    }
}
