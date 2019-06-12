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
using FrbaCrucero.SQL;
using FrbaCrucero.Entidades;
namespace FrbaCrucero.ListadoEstadistico
{
    public partial class ListadoTop5 : Form
    {

        List<TopCruceros> cruceros;
        List<TopRecorridos> recorridos;
        List<TopRecorridosLibres> recorridosLibres;
        Int32 anio;
        Int32 semestre;

        public ListadoTop5()
        {
            InitializeComponent();
            comboBox1.Items.Add("Recorridos con más pasajes comprados");
            comboBox1.Items.Add("Recorridos con más cabinas libres en cada uno de los viajes realizados");
            comboBox1.Items.Add("Cruceros con mayor cantidad de días fuera de servicio");
            comboBox2.Items.Add("PRIMER SEMESTRE");
            comboBox2.Items.Add("SEGUNDO SEMESTRE");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();

                anio = Int32.Parse(textBox1.Text);
                Semestre();
                if (comboBox1.Text.Equals("Recorridos con más pasajes comprados"))
                {
                    recorridos = new SqlTops().Top5Recorridos(anio, semestre);
                    dataGridView1.DataSource = recorridos;
                }
                if (comboBox1.Text.Equals("Recorridos con más cabinas libres en cada uno de los viajes realizados"))
                {
                    recorridosLibres = new SqlTops().Top5RecorridosLibres(anio, semestre);
                    dataGridView1.DataSource = recorridosLibres;
                }
                if (comboBox1.Text.Equals("Cruceros con mayor cantidad de días fuera de servicio"))
                {
                    cruceros = new SqlTops().Top5Cruceros(anio, semestre);
                    dataGridView1.DataSource = cruceros;
                }
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

        private void Semestre()
        {
            if (comboBox2.Text.Equals("PRIMER SEMESTRE"))
            {
                semestre = 1;
            }
            else
            {
                semestre = 2;
            }
        }

        private void validar()
        {
            if (this.comboBox1.SelectedIndex == -1)
            {
                SystemException ex = new SystemException("Eliga Tipo Listado");
                throw ex;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Año en numeros.");
                textBox1.Clear();
            }
            if (this.comboBox2.SelectedIndex == -1)
            {
                SystemException ex = new SystemException("Seleccione el semestre");
                throw ex;
            }
        }
    }
}
