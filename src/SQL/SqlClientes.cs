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

        public Boolean validarDisponibilidad(Int32 cod_cliente, DateTime fecha_inicio, DateTime fecha_fin)
        {
            Boolean resultado = false;
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("MLJ.clienteViajaDurante", conexion);
                consulta.Parameters.AddWithValue("@cod_cliente", cod_cliente);
                consulta.Parameters.AddWithValue("@inicio", fecha_inicio);
                consulta.Parameters.AddWithValue("@fin", fecha_fin);
                conexion.Open();
                SqlDataReader result = consulta.ExecuteReader();
                resultado = result.Read();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return resultado;
        }

        public void actualizarCliente(Cliente cliente)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("UPDATE MLJ.Cliente SET nombre = @nombre, apellido = @apellido, direccion = @direccion, telefono = @telefono, dni = @dni, mail = @mail, nacimiento = @nacimiento WHERE cod_cliente = @cod", conexion);
                consulta.Parameters.AddWithValue("@nombre", cliente.nombre);
                consulta.Parameters.AddWithValue("@apellido", cliente.apellido);
                consulta.Parameters.AddWithValue("@direccion", cliente.direccion);
                consulta.Parameters.AddWithValue("@telefono", cliente.telefono);
                consulta.Parameters.AddWithValue("@dni", cliente.dni);
                consulta.Parameters.AddWithValue("@mail", cliente.mail);
                consulta.Parameters.AddWithValue("@nacimiento", cliente.nacimiento);
                consulta.Parameters.AddWithValue("@cod", cliente.idCliente);
                conexion.Open();
                consulta.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public Cliente crearCliente(String nombre, String apellido, Decimal dni, String direccion, Int32 telefono, String mail, DateTime fechaNacimiento)
        {
            SqlParameter ret = new SqlParameter("@ret", SqlDbType.Int);
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("", conexion);
                consulta.Parameters.AddWithValue("@nombre", nombre);
                consulta.Parameters.AddWithValue("@apellido", apellido);
                consulta.Parameters.AddWithValue("@direccion", direccion);
                consulta.Parameters.AddWithValue("@telefono", telefono);
                consulta.Parameters.AddWithValue("@dni", dni);
                consulta.Parameters.AddWithValue("@mail", mail);
                consulta.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                ret.Direction = ParameterDirection.ReturnValue;
                consulta.Parameters.Add(ret);
                conexion.Open();
                consulta.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            Int32 cod = Convert.ToInt32(ret.Value);

            return new Cliente(cod, nombre, apellido, dni, direccion, telefono, mail, fechaNacimiento, true);
        }
    }
}
