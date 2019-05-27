using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Entidades;

namespace FrbaCrucero.SQL
{
    class SqlRecorridos
    {
        public List<Recorridos> getRecorridos()
        {
            List<Recorridos> recorridos = new List<Recorridos>();

            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT cod_recorrido, habilitado FROM MLJ.Recorridos", conexion);
                conexion.Open();
                SqlDataReader recorridosResult = consulta.ExecuteReader();
                while (recorridosResult.Read())
                {
                    recorridos.Add(new Recorridos(recorridosResult.GetInt32(0), recorridosResult.GetBoolean(1), getTramosRecorrido(recorridosResult.GetInt32(0))));
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
            return recorridos;
        }

        public List<Tramos> getTramosRecorrido(Int32 codRecorrido)
        {
            List<Tramos> tramos = new List<Tramos>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT cod_recorrido,nro_tramo,cod_puerto_salida,cod_puerto_llegada,costo FROM MLJ.Tramos WHERE cod_recorrido = @codRecorrido", conexion);
                consulta.Parameters.AddWithValue("@codRecorrido", codRecorrido);
                conexion.Open();
                SqlDataReader tramosResultados = consulta.ExecuteReader();
                while (tramosResultados.Read())
                {
                    tramos.Add(new Tramos(tramosResultados.GetInt32(0), tramosResultados.GetByte(1), getPuerto(tramosResultados.GetInt32(2)), getPuerto(tramosResultados.GetInt32(3)), tramosResultados.GetDecimal(4)));
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
            return tramos;
        }

        public Puertos getPuerto(Int32 codPuerto)
        {
            Puertos puerto = null;
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {

                conexion.Open();
                SqlCommand consulta2 = new SqlCommand("SELECT cod_puerto,nombre,habilitado FROM MLJ.Puertos WHERE cod_puerto=@codPuerto", conexion);
                consulta2.Parameters.AddWithValue("@codPuerto", codPuerto);
                SqlDataReader puertosResultados = consulta2.ExecuteReader();

                while (puertosResultados.Read())
                {
                    puerto = new Puertos(puertosResultados.GetInt32(0), puertosResultados.GetString(1), puertosResultados.GetBoolean(2));
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
            return puerto;
        }

        public void insertarRecorrido(List<Tramos> tramos)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            SqlCommand comando2 = new SqlCommand("", conexion, transaction);
            try
            {
                SqlCommand comando = new SqlCommand("INSERT INTO MLJ.Recorridos OUTPUT INSERTED.cod_recorrido DEFAULT VALUES", conexion, transaction);
                Int32 cod_recorrido = Convert.ToInt32(comando.ExecuteScalar());
                comando2.Parameters.AddWithValue("@codRecorrido", cod_recorrido);

                int i = 0;
                foreach (Tramos tramo in tramos)
                {
                    comando2.CommandText = "INSERT INTO MLJ.Tramos (cod_recorrido,nro_tramo,cod_puerto_salida,cod_puerto_llegada,costo) VALUES (@codRecorrido,@nroTramo" + i + ",@codPuertoSalida" + i + ",@codPuertoLlegada" + i + ",@costo" + i + ")";
                    comando2.Parameters.AddWithValue("@nroTramo" + i, tramo.nroTramo);
                    comando2.Parameters.AddWithValue("@codPuertoSalida" + i, tramo.puertoSalida.codPuerto);
                    comando2.Parameters.AddWithValue("@codPuertoLlegada" + i, tramo.puertoLlegada.codPuerto);
                    comando2.Parameters.AddWithValue("@costo" + i, tramo.costoTramo);
                    comando2.ExecuteNonQuery();
                    i++;
                }
                transaction.Commit();
                conexion.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                conexion.Close();
                throw ex;
            }
        }

        public void actualizarRecorrido(Recorridos recorrido)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            SqlCommand comando2 = new SqlCommand("", conexion, transaction);
            SqlCommand actualizarHabilitado = new SqlCommand("UPDATE MLJ.Recorridos SET habilitado = @habilitado WHERE cod_recorrido = @codRecorrido", conexion, transaction);
            actualizarHabilitado.Parameters.AddWithValue("@codRecorrido", recorrido.idRol);
            actualizarHabilitado.Parameters.AddWithValue("@habilitado", recorrido.estado);
            SqlCommand borrarTramos = new SqlCommand("DELETE FROM MLJ.Tramos WHERE cod_recorrido = @codRecorrido", conexion, transaction);
            borrarTramos.Parameters.AddWithValue("@codRecorrido", recorrido.idRol);

            try
            {
                actualizarHabilitado.ExecuteNonQuery();
                borrarTramos.ExecuteNonQuery();
                comando2.Parameters.AddWithValue("@codRecorrido", recorrido.idRol);

                int i = 0;
                foreach (Tramos tramo in recorrido.tramos)
                {
                    comando2.CommandText = "INSERT INTO MLJ.Tramos (cod_recorrido,nro_tramo,cod_puerto_salida,cod_puerto_llegada,costo) VALUES (@codRecorrido,@nroTramo" + i + ",@codPuertoSalida" + i + ",@codPuertoLlegada" + i + ",@costo" + i + ")";
                    comando2.Parameters.AddWithValue("@nroTramo" + i, tramo.nroTramo);
                    comando2.Parameters.AddWithValue("@codPuertoSalida" + i, tramo.puertoSalida.codPuerto);
                    comando2.Parameters.AddWithValue("@codPuertoLlegada" + i, tramo.puertoLlegada.codPuerto);
                    comando2.Parameters.AddWithValue("@costo" + i, tramo.costoTramo);
                    comando2.ExecuteNonQuery();
                    i++;
                }
                transaction.Commit();
                conexion.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                conexion.Close();
                throw ex;
            }
        }

        public void eliminarLogico(Recorridos recorrido)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();

            try
            {
                SqlCommand comando = new SqlCommand("UPDATE MLJ.Recorridos SET habilitado = 0 WHERE cod_recorrido = @codRecorrido", conexion, transaction);
                comando.Parameters.AddWithValue("@codRecorrido", recorrido.idRol);
                comando.ExecuteNonQuery();
                transaction.Commit();
                conexion.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                conexion.Close();
                throw ex;
            }
        }

    }
}
