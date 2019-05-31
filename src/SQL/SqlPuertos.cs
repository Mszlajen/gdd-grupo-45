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
    class SqlPuertos
    {
        public List<Puertos> getPuertos()
        {
            List<Puertos> puertos = new List<Puertos>();

            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT cod_puerto, nombre, habilitado FROM MLJ.Puertos", conexion);
                conexion.Open();
                SqlDataReader rolesResultados = consulta.ExecuteReader();
                while (rolesResultados.Read())
                {
                    puertos.Add(new Puertos(rolesResultados.GetInt32(0), rolesResultados.GetString(1), rolesResultados.GetBoolean(2)));
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
            return puertos;
        }

        public List<Puertos> getPuertosHabilitados()
        {
            List<Puertos> puertos = new List<Puertos>();

            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT cod_puerto, nombre FROM MLJ.Puertos WHERE habilitado = 1", conexion);
                conexion.Open();
                SqlDataReader puertosResultados = consulta.ExecuteReader();
                while (puertosResultados.Read())
                    puertos.Add(new Puertos(puertosResultados.GetInt32(0), puertosResultados.GetString(1), true));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return puertos;
        }

        public List<Puertos> getPuertos(String nombrePuerto)
        {
            List<Puertos> puertos = new List<Puertos>();

            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT cod_puerto, nombre, habilitado FROM MLJ.Puertos WHERE nombre LIKE '%' + @nombrePuerto + '%'", conexion);
                consulta.Parameters.AddWithValue("@nombrePuerto", nombrePuerto);
                conexion.Open();
                SqlDataReader rolesResultados = consulta.ExecuteReader();
                while (rolesResultados.Read())
                {
                    puertos.Add(new Puertos(rolesResultados.GetInt32(0), rolesResultados.GetString(1), rolesResultados.GetBoolean(2)));
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
            return puertos;
        }


    }
}
