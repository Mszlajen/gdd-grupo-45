using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using FrbaCrucero.Entidades;

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

        public List<Entidades.Viaje> getViajes(DateTime fecha, Puertos origen, Puertos destino)
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
    }
}
