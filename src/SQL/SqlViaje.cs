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
    class SqlViaje
    {
        public int viaje(Int32 codigo_recorrido, Int32 cod_crucero, DateTime fechaSalida , DateTime fechaLlegada, Boolean retorno)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand cmd = new SqlCommand("MLJ.verificar_viaje", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            // instancio parametro de salida
            SqlParameter VariableRetorno = new SqlParameter("@resultado", SqlDbType.Int);
            VariableRetorno.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new SqlParameter("@codigo_recorrido", codigo_recorrido));
            cmd.Parameters.Add(new SqlParameter("@cod_crucero", cod_crucero));
            cmd.Parameters.Add(new SqlParameter("@fechaSalida", fechaSalida));
            cmd.Parameters.Add(new SqlParameter("@fechaLlegada", fechaLlegada));
            cmd.Parameters.Add(new SqlParameter("@fechaActual", Program.ObtenerFechaActual()));
            cmd.Parameters.Add(new SqlParameter("@retorno", retorno));
            cmd.Parameters.Add(VariableRetorno);

            conexion.Open();
            cmd.ExecuteNonQuery(); // aca se abre la conexion y se ejecuta el SP de login
            int resultado = (int)cmd.Parameters["@resultado"].Value;
            conexion.Close();
            return resultado;
        }

        public List<Entidades.Viaje> buscarViajes(DateTime fecha, Puertos origen, Puertos destino)
        {
            List<Viaje> viajes = new List<Viaje>();

            SqlConnection conexion = SqlGeneral.nuevaConexion(); 
            SqlCommand consulta = new SqlCommand("MLJ.buscarViajes", conexion);
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@fecha", fecha);
            if(origen == null)
                consulta.Parameters.AddWithValue("@cod_origen", DBNull.Value);
            else
                consulta.Parameters.AddWithValue("@cod_origen", origen.codPuerto);
            if(destino == null)
                consulta.Parameters.AddWithValue("@cod_destino", DBNull.Value);
            else
                consulta.Parameters.AddWithValue("@cod_destino", destino.codPuerto);
            conexion.Open();
            SqlDataReader resultados = consulta.ExecuteReader();
            while (resultados.Read())
                if(resultados.GetValue(6) == DBNull.Value)
                    viajes.Add(new Viaje(resultados.GetInt32(0), resultados.GetDateTime(1), resultados.GetDateTime(2), resultados.GetInt32(3), resultados.GetInt32(4), resultados.GetBoolean(5)));
                else
                    viajes.Add(new Viaje(resultados.GetInt32(0), resultados.GetDateTime(1), resultados.GetDateTime(2), resultados.GetInt32(3), resultados.GetInt32(4), resultados.GetBoolean(5), resultados.GetString(6)));
            conexion.Close();
            return viajes;
        }

        public Viaje getViaje(Int32 idViaje)
        {
            Viaje viaje = null;
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {

                conexion.Open();
                SqlCommand consulta2 = new SqlCommand("SELECT cod_viaje, fecha_inicio, fecha_fin, cod_recorrido, cod_crucero, retorna, razon_de_cancelacion FROM MLJ.Viajes WHERE cod_viaje = @id", conexion);
                consulta2.Parameters.AddWithValue("@id", idViaje);
                SqlDataReader resultados = consulta2.ExecuteReader();

                while (resultados.Read())
                {
                    if(resultados.GetValue(6) == DBNull.Value)
                        viaje = new Viaje(idViaje, resultados.GetDateTime(1), resultados.GetDateTime(2), resultados.GetInt32(3), resultados.GetInt32(4), resultados.GetBoolean(5));
                    else
                        viaje = new Viaje(idViaje, resultados.GetDateTime(1), resultados.GetDateTime(2), resultados.GetInt32(3), resultados.GetInt32(4), resultados.GetBoolean(5), resultados.GetString(6));
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
            return viaje;
        }

        public List<Cabina> buscarCabinasDisponibles(Int32 codViaje)
        {
            List<Cabina> cabinas = new List<Cabina>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand consulta = new SqlCommand("MLJ.buscarCabinasDisponibles", conexion);
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@codViaje", codViaje);
            conexion.Open();
            SqlDataReader resultados = consulta.ExecuteReader();
            while (resultados.Read())
                cabinas.Add(new Cabina(resultados.GetInt32(0), resultados.GetInt32(1), resultados.GetDecimal(2), resultados.GetInt32(3), resultados.GetDecimal(4)));
            conexion.Close();
            return cabinas;
        }
    }
}
