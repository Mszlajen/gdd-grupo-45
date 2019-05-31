using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaCrucero.Entidades;
using System.Windows.Forms;

namespace FrbaCrucero.SQL
{
    class SqlCruceros
    {

        public List<CrucerosDisponibles> getCrucerosDisponibles(DateTime salida, DateTime llegada)
        {
            List<CrucerosDisponibles> cruceros = new List<CrucerosDisponibles>();

            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT cruceros.cod_crucero,cruceros.identificador,coalesce(cruceros.fecha_alta,0) FROM MLJ.Cruceros WHERE cod_crucero NOT IN (select cod_crucero FROM MLJ.Bajas_de_servicio WHERE permanente = 1) AND cod_crucero NOT IN (SELECT viajes.cod_crucero FROM MLJ.Viajes viajes WHERE (viajes.fecha_inicio BETWEEN @fechaSalida AND @fechaLlegada) AND (viajes.fecha_fin BETWEEN @fechaSalida AND @fechaLlegada))", conexion);
                consulta.Parameters.AddWithValue("@fechaSalida", salida);
                consulta.Parameters.AddWithValue("@fechaLlegada", llegada);

                conexion.Open();
                SqlDataReader crucerosResultados = consulta.ExecuteReader();
                while (crucerosResultados.Read())
                {
                    cruceros.Add(new CrucerosDisponibles(crucerosResultados.GetInt32(0), crucerosResultados.GetString(1), crucerosResultados.GetDateTime(2)));
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
            return cruceros;
        }

        public CrucerosDisponibles getCrucero(Int32 codCrucero)
        {
            CrucerosDisponibles crucero = null;

            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT cod_crucero, identificador, fecha_alta FROM MLJ.Cruceros WHERE cod_crucero = @cod", conexion);
                consulta.Parameters.Add(new SqlParameter("@cod", codCrucero));
                conexion.Open();
                SqlDataReader cruceroResult = consulta.ExecuteReader();
                while (cruceroResult.Read())
                {
                    if(cruceroResult.GetValue(2) == DBNull.Value)
                        crucero = new CrucerosDisponibles(cruceroResult.GetInt32(0), cruceroResult.GetString(1));
                    else
                        crucero = new CrucerosDisponibles(cruceroResult.GetInt32(0), cruceroResult.GetString(1), cruceroResult.GetDateTime(2));
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
            return crucero;
        }
    }
}
