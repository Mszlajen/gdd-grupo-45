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

        public Crucero crearCrucero(String identificador, Int32 codServicio, Int32 codMarca, Int32 codFabricante, Int32 codModelo, Nullable<DateTime> fechaAlta, IList<Cabina> cabinas)
        {
            Crucero crucero = null;
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlTransaction transaction = null;
            try
            {
                SqlCommand consulta = new SqlCommand("MLJ.crearCrucero", conexion);
                consulta.CommandType = CommandType.StoredProcedure;
                consulta.Parameters.AddWithValue("@identificador", identificador);
                consulta.Parameters.AddWithValue("@codServicio", codServicio);
                consulta.Parameters.AddWithValue("@codMarca", codMarca);
                consulta.Parameters.AddWithValue("@codFabricante", codFabricante);
                consulta.Parameters.AddWithValue("@codModelo", codModelo);
                if(fechaAlta.HasValue)
                    consulta.Parameters.AddWithValue("@fechaAlta", fechaAlta);
                else
                    consulta.Parameters.AddWithValue("@fechaAlta", DBNull.Value);
                SqlParameter ret = new SqlParameter();
                ret.Direction = ParameterDirection.ReturnValue;
                consulta.Parameters.Add(ret);
                conexion.Open();

                transaction = conexion.BeginTransaction();
                consulta.Transaction = transaction;

                consulta.ExecuteNonQuery();

                Int32 cod_crucero = Convert.ToInt32(ret.Value);
                crucero = new Crucero(cod_crucero, identificador, fechaAlta, codMarca, codModelo, codFabricante, codServicio);

                consulta.CommandText = "MLJ.crearCabina";
                foreach(Cabina cabina in cabinas)
                {
                    consulta.Parameters.Clear();
                    consulta.Parameters.Add(ret);
                    consulta.Parameters.AddWithValue("@codCrucero", cod_crucero);
                    consulta.Parameters.AddWithValue("@piso", cabina.piso);
                    consulta.Parameters.AddWithValue("@numero", cabina.numero);
                    consulta.Parameters.AddWithValue("@codTipo", cabina.codTipo);

                    consulta.ExecuteNonQuery();
                }
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
            return crucero;
        }

        public List<Crucero> getCrucerosDisponibles(DateTime salida, DateTime llegada)
        {
            List<Crucero> cruceros = new List<Crucero>();

            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT cruceros.cod_crucero,cruceros.identificador,coalesce(cruceros.fecha_alta,0) FROM MLJ.Cruceros WHERE cod_crucero NOT IN (select cod_crucero FROM MLJ.Bajas_de_servicio WHERE (permanente = 1 OR fecha_alta >= @fechaSalida)) AND cod_crucero NOT IN (SELECT viajes.cod_crucero FROM MLJ.Viajes viajes WHERE (viajes.fecha_inicio BETWEEN @fechaSalida AND @fechaLlegada) OR (viajes.fecha_fin BETWEEN @fechaSalida AND @fechaLlegada))", conexion);
                consulta.Parameters.AddWithValue("@fechaSalida", salida);
                consulta.Parameters.AddWithValue("@fechaLlegada", llegada);

                conexion.Open();
                SqlDataReader crucerosResultados = consulta.ExecuteReader();
                while (crucerosResultados.Read())
                {
                    cruceros.Add(new Crucero(crucerosResultados.GetInt32(0), crucerosResultados.GetString(1), crucerosResultados.GetDateTime(2)));
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

        public Crucero getCrucero(Int32 codCrucero)
        {
            Crucero crucero = null;

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
                        crucero = new Crucero(cruceroResult.GetInt32(0), cruceroResult.GetString(1));
                    else
                        crucero = new Crucero(cruceroResult.GetInt32(0), cruceroResult.GetString(1), cruceroResult.GetDateTime(2));
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

        public List<Crucero> buscarCruceros()
        {
            List<Crucero> cruceros = new List<Crucero>();

            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT cod_crucero, identificador, fecha_alta, cod_marca, cod_fabricante, cod_servicio, cod_modelo FROM MLJ.Cruceros", conexion);

                conexion.Open();
                SqlDataReader crucerosResultados = consulta.ExecuteReader();
                while (crucerosResultados.Read())
                {
                    if(crucerosResultados.GetValue(2) == DBNull.Value)
                        cruceros.Add(new Crucero(crucerosResultados.GetInt32(0), crucerosResultados.GetString(1), null, crucerosResultados.GetInt32(3), crucerosResultados.GetInt32(6), crucerosResultados.GetInt32(4), crucerosResultados.GetInt32(5)));
                    else
                        cruceros.Add(new Crucero(crucerosResultados.GetInt32(0), crucerosResultados.GetString(1), crucerosResultados.GetDateTime(2), crucerosResultados.GetInt32(3), crucerosResultados.GetInt32(6), crucerosResultados.GetInt32(4), crucerosResultados.GetInt32(5)));
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

        public List<Cabina> buscarCabinas(Int32 codCrucero)
        {
            List<Cabina> cabinas = new List<Cabina>();

            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT cod_cabina, nro, cod_tipo, piso FROM MLJ.Cabinas WHERE cod_crucero = @cod", conexion);
                consulta.Parameters.AddWithValue("@cod", codCrucero);
                conexion.Open();
                SqlDataReader result = consulta.ExecuteReader();
                while (result.Read())
                {
                    cabinas.Add(new Cabina(result.GetInt32(0), codCrucero, result.GetDecimal(1), result.GetInt32(2), result.GetDecimal(3)));
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
            return cabinas;
        }
    }
}
