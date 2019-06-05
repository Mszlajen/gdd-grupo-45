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
    class SqlInfoCrucero
    {
        public Marca getMarca(Int32 cod)
        {
            Marca retorno = null;
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT cod_marca, nombre FROM MLJ.Marcas WHERE cod_marca = @cod", conexion);
                consulta.Parameters.Add(new SqlParameter("@cod", cod));
                conexion.Open();
                SqlDataReader result = consulta.ExecuteReader();
                while (result.Read())
                    retorno = new Marca(result.GetInt32(0), result.GetString(1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return retorno;
        }

        public Fabricante getFabricante(Int32 cod)
        {
            Fabricante retorno = null;
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT cod_fabricante, nombre FROM MLJ.Fabricantes WHERE cod_fabricante = @cod", conexion);
                consulta.Parameters.Add(new SqlParameter("@cod", cod));
                conexion.Open();
                SqlDataReader result = consulta.ExecuteReader();
                while (result.Read())
                    retorno = new Fabricante(result.GetInt32(0), result.GetString(1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return retorno;
        }

        public Servicio getServicio(Int32 cod)
        {
            Servicio retorno = null;
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT cod_servicio, nombre FROM MLJ.Servicios WHERE cod_servicios = @cod", conexion);
                consulta.Parameters.Add(new SqlParameter("@cod", cod));
                conexion.Open();
                SqlDataReader result = consulta.ExecuteReader();
                while (result.Read())
                    retorno = new Servicio(result.GetInt32(0), result.GetString(1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return retorno;
        }

        public Modelo getModelo(Int32 cod)
        {
            Modelo retorno = null;
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT cod_modelo, nombre FROM MLJ.Modelo WHERE cod_modelo = @cod", conexion);
                consulta.Parameters.Add(new SqlParameter("@cod", cod));
                conexion.Open();
                SqlDataReader result = consulta.ExecuteReader();
                while (result.Read())
                    retorno = new Modelo(result.GetInt32(0), result.GetString(1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return retorno;
        }

        public List<Marca> buscarMarcas()
        {
            List<Marca> retorno = new List<Marca>();

            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT cod_marca, nombre FROM MLJ.Marcas", conexion);

                conexion.Open();
                SqlDataReader resultados = consulta.ExecuteReader();
                while (resultados.Read())
                {
                    retorno.Add(new Marca(resultados.GetInt32(0), resultados.GetString(1)));
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
            return retorno;
        }

        public List<Fabricante> buscarFabricantes()
        {
            List<Fabricante> retorno = new List<Fabricante>();

            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT cod_fabricante, nombre FROM MLJ.Fabricantes", conexion);

                conexion.Open();
                SqlDataReader resultados = consulta.ExecuteReader();
                while (resultados.Read())
                {
                    retorno.Add(new Fabricante(resultados.GetInt32(0), resultados.GetString(1)));
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
            return retorno;
        }
        public List<Servicio> buscarServicios()
        {
            List<Servicio> retorno = new List<Servicio>();

            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT cod_servicio, nombre FROM MLJ.Servicios", conexion);

                conexion.Open();
                SqlDataReader resultados = consulta.ExecuteReader();
                while (resultados.Read())
                {
                    retorno.Add(new Servicio(resultados.GetInt32(0), resultados.GetString(1)));
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
            return retorno;
        }

        public List<Modelo> buscarModelo()
        {
            List<Modelo> retorno = new List<Modelo>();

            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT cod_modelo, nombre FROM MLJ.Modelos", conexion);

                conexion.Open();
                SqlDataReader resultados = consulta.ExecuteReader();
                while (resultados.Read())
                {
                    retorno.Add(new Modelo(resultados.GetInt32(0), resultados.GetString(1)));
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
            return retorno;
        }
    }
}
