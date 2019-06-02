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
    class SqlClientes
    {
        public List<Cliente> buscarClientePorDNI(decimal dni)
        {
            List<Cliente> clientes = new List<Cliente>();

            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT cod_cliente, nombre, apellido, direccion, telefono, mail, nacimiento FROM MLJ.Clientes WHERE dni = @dni", conexion);
                consulta.Parameters.AddWithValue("@dni", dni);
                conexion.Open();
                SqlDataReader result = consulta.ExecuteReader();
                while (result.Read())
                {
                    clientes.Add(new Cliente(result.GetInt32(0), result.GetString(1), result.GetString(2), dni, result.GetString(3), result.GetInt32(4), result.GetString(5), result.GetDateTime(6), result.GetValue(6) == DBNull.Value));
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
            return clientes ;
        }
    }
}
