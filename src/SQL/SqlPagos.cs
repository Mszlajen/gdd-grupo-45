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
    class SqlPagos
    {
        public List<MedioDePago> mediosDePagos()
        {
            List<MedioDePago> medios = new List<MedioDePago>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand consulta = new SqlCommand("SELECT cod_medio, nombre FROM MLJ.Medios_de_Pago", conexion);
            conexion.Open();
            SqlDataReader resultados = consulta.ExecuteReader();
            while (resultados.Read())
                medios.Add(new MedioDePago(resultados.GetInt32(0), resultados.GetString(1)));
            conexion.Close();
            return medios;
        }

        public Int32 crearPago(Int32 cod_viaje, Int32 cod_cliente, List<Cabina> cabinas, String numTarjeta, String security_code, DateTime fecha, Int32 cod_medio)
        {
            Int32 cod_pago = 0;
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlTransaction transaction = null;
            try
            {
                SqlCommand consulta = new SqlCommand("MLJ.crearPasaje", conexion);
                consulta.CommandType = CommandType.StoredProcedure;
                consulta.Parameters.AddWithValue("@cod_cliente", cod_cliente);
                consulta.Parameters.AddWithValue("@cod_viaje", cod_viaje);
                consulta.Parameters.AddWithValue("@cabinas", Cabina.formatearLista(cabinas));
                SqlParameter ret = new SqlParameter();
                ret.Direction = ParameterDirection.ReturnValue;
                consulta.Parameters.Add(ret);
                conexion.Open();

                transaction = conexion.BeginTransaction();
                consulta.Transaction = transaction;

                consulta.ExecuteNonQuery();

                Int32 cod_pasaje = Convert.ToInt32(ret.Value);

                consulta.Parameters.Clear();
                consulta.CommandText = "MLJ.crearPago";
                consulta.Parameters.Add(ret);
                consulta.Parameters.AddWithValue("@cod_pasaje", cod_pasaje);
                consulta.Parameters.AddWithValue("@fecha", Program.ObtenerFechaActual());
                consulta.Parameters.AddWithValue("@numTarjeta", numTarjeta);
                consulta.Parameters.AddWithValue("@pin", security_code);
                consulta.Parameters.AddWithValue("@cod_medio", cod_medio);

                consulta.ExecuteNonQuery();

                cod_pago = Convert.ToInt32(ret.Value);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return cod_pago;
        }

        public Pago buscarPago(Int32 cod_pago)
        {
            Pago pago = null;
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand consulta = new SqlCommand("SELECT cod_medio, fecha, hash_nro_tarjeta, ultimos_digitos, cod_seguridad, cod_pasaje FROM MLJ.Pagos WHERE cod_pago = @cod", conexion);
            consulta.Parameters.AddWithValue("cod", cod_pago);
            conexion.Open();
            SqlDataReader restl = consulta.ExecuteReader();
            while (restl.Read())
                pago = new Pago(cod_pago, restl.GetString(2), restl.GetString(3), restl.GetString(4), restl.GetDateTime(1), restl.GetInt32(5), restl.GetInt32(0));
            conexion.Close();
            return pago;
        }
    }
}
