using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

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
    }
}
