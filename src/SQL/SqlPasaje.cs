using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using FrbaCrucero.Entidades;
using System.Windows.Forms;

namespace FrbaCrucero.SQL
{
    class SqlPasaje
    {
        public Pasaje buscarPasaje(Int32 cod_pasaje)
        {
            Pasaje pasaje = null;
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                conexion.Open();
                SqlCommand consulta = new SqlCommand("SELECT cod_cliente, cod_viaje, cantidad FROM MLJ.Pasajes WHERE cod_pasaje = @cod", conexion);
                consulta.Parameters.AddWithValue("@cod", cod_pasaje);
                SqlDataReader resultados = consulta.ExecuteReader();

                if (resultados.Read())
                {
                    pasaje = new Pasaje(cod_pasaje, resultados.GetInt32(0), resultados.GetInt32(1), resultados.GetDecimal(2));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return pasaje;
        }
    }
}
