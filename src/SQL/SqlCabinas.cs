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
    class SqlCabinas
    {
        public TipoCabina getTipoCabina(Int32 codCabina)
        {
            TipoCabina tipo = null;
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand consulta = new SqlCommand("SELECT cod_tipo, valor, nombre FROM MLJ.Tipo_Cabinas WHERE cod_tipo IN (SELECT cod_tipo FROM MLJ.Cabinas WHERE cod_cabina = @cod)", conexion);
            consulta.Parameters.AddWithValue("@cod", codCabina);
            conexion.Open();
            SqlDataReader resultados = consulta.ExecuteReader();
            while (resultados.Read())
                tipo = new TipoCabina(resultados.GetInt32(0), resultados.GetDecimal(1), resultados.GetString(2));
            conexion.Close();
            return tipo;
        }

        public List<Cabina> buscarCabinasReservadas(Int32 cod_pasaje)
        {
            List<Cabina> cabinas = new List<Cabina>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand consulta = new SqlCommand("MLJ.buscarCabinasDePasaje", conexion);
            consulta.CommandType = CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@cod_pasaje", cod_pasaje);
            conexion.Open();
            SqlDataReader resultados = consulta.ExecuteReader();
            while (resultados.Read())
                cabinas.Add(new Cabina(resultados.GetInt32(0), resultados.GetInt32(1), resultados.GetDecimal(3), resultados.GetInt32(2), resultados.GetDecimal(4)));
            conexion.Close();
            return cabinas;
        }

        public List<TipoCabina> getTiposCabina()
        {
            List<TipoCabina> tipos = new List<TipoCabina>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand consulta = new SqlCommand("SELECT cod_tipo, valor, nombre FROM MLJ.Tipo_cabinas", conexion);
            conexion.Open();
            SqlDataReader resultados = consulta.ExecuteReader();
            while (resultados.Read())
                tipos.Add(new TipoCabina(resultados.GetInt32(0), resultados.GetDecimal(1), resultados.GetString(2)));
            conexion.Close();
            return tipos;
        }
    }
}
