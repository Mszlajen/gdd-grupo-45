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
    public partial class altaRol : Form
    {
        private List<Funcionalidad> funcionalidades;
        private List<Funcionalidad> funcSeleccionadas;

        private AbmRol.Seleccion _seleccionForm;

        public altaRol(AbmRol.Seleccion seleccionForm)
        {
            InitializeComponent();
            _seleccionForm = seleccionForm; 
            funcionalidades = new SqlRoles().getFuncionesTotales();
            funcSeleccionadas = new List<Funcionalidad>();
            this.comboBoxFuncionalidades.DisplayMember = "descFuncion";
            this.comboBoxFuncionalidades.ValueMember = "this";
            this.comboBoxFuncionalidades.DataSource = funcionalidades;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            _seleccionForm.actualizarGrilla();
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                new SqlRoles().insertarNuevoRol(new Rol(Convert.ToBoolean(this.comboBoxEstado.Text), Convert.ToBoolean(this.comboBoxRegistrable.Text), this.textBoxDesc.Text, this.funcSeleccionadas));
                MessageBox.Show("Rol guardado con exito");
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

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxDesc.Clear();
            this.comboBoxEstado.SelectedIndex = -1;
            this.comboBoxRegistrable.SelectedIndex = -1;
            this.funcSeleccionadas.Clear();
            this.actualizarTextBox();
        }

        private void ButtonRemover_Click(object sender, EventArgs e)
        {
            if (this.funcSeleccionadas.Contains(this.comboBoxFuncionalidades.SelectedValue as Funcionalidad))
            {
                this.funcSeleccionadas.Remove(this.comboBoxFuncionalidades.SelectedValue as Funcionalidad);
                this.actualizarTextBox();
            }
            else
                MessageBox.Show("No esta seleccionado esta funcionalidad");
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (!this.funcSeleccionadas.Contains(this.comboBoxFuncionalidades.SelectedValue as Funcionalidad))
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
