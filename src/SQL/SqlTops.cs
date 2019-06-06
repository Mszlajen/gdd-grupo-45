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
    class SqlTops
    {
        public List<TopCruceros> Top5Cruceros(Int32 anio, Int32 semestre)
        {
            List<TopCruceros> cruceros = new List<TopCruceros>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand consulta = new SqlCommand("MLJ.top5_cruceros", conexion);
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@anio", anio);
            consulta.Parameters.AddWithValue("@semestre", semestre);
            conexion.Open();
            SqlDataReader resultados = consulta.ExecuteReader();
            while (resultados.Read())
                cruceros.Add(new TopCruceros(resultados.GetInt32(0), resultados.GetString(1), resultados.GetString(2), resultados.GetString(3), resultados.GetInt32(4)));
            conexion.Close();
            return cruceros;
        }
    }
}
