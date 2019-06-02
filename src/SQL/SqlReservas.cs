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
    class SqlReservas
    {
        public Reserva crearReserva(Int32 cod_viaje, Int32 cod_cliente, List<Cabina> cabinas)
        {
            Reserva reserva = null;
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlTransaction transaction = null;
            try
            {
                SqlCommand consulta = new SqlCommand("MLJ.crearPasaje", conexion);
                consulta.CommandType = CommandType.StoredProcedure;
                consulta.Parameters.AddWithValue("@cod_cliente", cod_cliente);
                consulta.Parameters.AddWithValue("@cod_viaje", cod_viaje);
                consulta.Parameters.AddWithValue("@cod_pago", DBNull.Value);
                consulta.Parameters.AddWithValue("@cabinas", Cabina.formatearLista(cabinas));
                SqlParameter ret = new SqlParameter();
                ret.Direction = ParameterDirection.ReturnValue;
                consulta.Parameters.Add(ret);
                conexion.Open();

                transaction = conexion.BeginTransaction();
                consulta.Transaction = transaction;

                consulta.ExecuteNonQuery();

                Int32 cod_pasaje = Convert.ToInt32(ret.Value);

                consulta.Parameters.Clear();
                consulta.CommandText = "MLJ.crearReserva";
                consulta.Parameters.Add(ret);
                consulta.Parameters.AddWithValue("@cod_pasaje", cod_pasaje);
                consulta.Parameters.AddWithValue("@fecha", Program.ObtenerFechaActual());

                consulta.ExecuteNonQuery();

                Int32 cod_reserva = Convert.ToInt32(ret.Value);
                reserva = new Reserva(cod_reserva, cod_pasaje, Program.ObtenerFechaActual());
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
            return reserva;
        }

        
    }
}
