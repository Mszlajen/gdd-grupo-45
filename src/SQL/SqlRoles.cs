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
    class SqlRoles
    {

        public List<Rol> getRoles()
        {
            List<Rol> roles = new List<Rol>();
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();


            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT cod_rol,descripcion,habilitado,registrable FROM MLJ.Roles", conexion);
                conexion.Open();
                SqlDataReader rolesResultados = consulta.ExecuteReader();
                while (rolesResultados.Read())
                {
                    roles.Add(new Rol(rolesResultados.GetInt32(0), rolesResultados.GetBoolean(2), rolesResultados.GetBoolean(3), rolesResultados.GetString(1), funcionalidades));
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
            return roles;
        }


        public List<Funcionalidad> getFuncionesTotales()
        {
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT cod_funcionalidad, descripcion FROM MLJ.Funcionalidades", conexion);
                conexion.Open();
                SqlDataReader funcResultados = consulta.ExecuteReader();
                while (funcResultados.Read())
                {
                    funcionalidades.Add(new Funcionalidad(funcResultados.GetInt32(0), funcResultados.GetString(1)));
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
            return funcionalidades;
        }

        public void insertarNuevoRol(Rol rolNuevo)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            SqlCommand comando2 = new SqlCommand("", conexion, transaction);
            try
            {
                SqlCommand comando = new SqlCommand("INSERT INTO MLJ.Roles (descripcion,habilitado,registrable) VALUES (@desc,@estado,@registrable)", conexion, transaction);
                comando.Parameters.AddWithValue("@desc", rolNuevo.desc);
                comando.Parameters.AddWithValue("@estado", rolNuevo.estado);
                comando.Parameters.AddWithValue("@registrable", rolNuevo.registrable);
 
                int cod_rol = Convert.ToInt32(comando.ExecuteScalar());

                foreach (Funcionalidad func in rolNuevo.funcionalidades)
                {
                    comando2.CommandText = "INSERT INTO MLJ.RolesXFuncionalidades (cod_rol,cod_funcionalidad) VALUES (@codRol,@codFunc)";
                    comando2.Parameters.AddWithValue("@codRol", cod_rol);
                    comando2.Parameters.AddWithValue("@codFunc", func.idFuncion);
                    comando2.ExecuteNonQuery();
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

        public void actualizarRol(Rol rolNuevo, Rol rol)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();
            SqlCommand comando2 = new SqlCommand("", conexion, transaction);
            SqlCommand borrarFuncionalidades = new SqlCommand("DELETE FROM MLJ.RolesXFuncionalidades WHERE cod_rol = @codRol", conexion, transaction);
            borrarFuncionalidades.Parameters.AddWithValue("@codRol", rol.idRol);

            try
            {
                borrarFuncionalidades.ExecuteNonQuery();
                SqlCommand comando = new SqlCommand("UPDATE MLJ.Roles SET descripcion = @desc, habilitado = @estado, registrable = @registrable WHERE cod_rol = @codRol", conexion, transaction);
                comando.Parameters.AddWithValue("@codRol", rol.idRol);
                comando.Parameters.AddWithValue("@desc", rolNuevo.desc);
                comando.Parameters.AddWithValue("@estado", rolNuevo.estado);
                comando.Parameters.AddWithValue("@registrable", rolNuevo.registrable);
                comando.ExecuteNonQuery();
                foreach (Funcionalidad func in rolNuevo.funcionalidades)
                {
                    comando2.CommandText = "INSERT INTO MLJ.RolesXFuncionalidades (cod_rol,cod_funcionalidad) VALUES (@codRol,@codFunc)";
                    comando2.Parameters.AddWithValue("@codRol", rol.idRol);
                    comando2.Parameters.AddWithValue("@codFunc", func.idFuncion);
                    comando2.ExecuteNonQuery();
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

        public void eliminarLogico(Rol rol)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            conexion.Open();
            SqlTransaction transaction = conexion.BeginTransaction();

            SqlCommand borrarFuncionalidades = new SqlCommand("DELETE FROM MLJ.RolesXFuncionalidades WHERE cod_rol = @codRol", conexion, transaction);
            borrarFuncionalidades.Parameters.AddWithValue("@codRol", rol.idRol);

            try
            {
                borrarFuncionalidades.ExecuteNonQuery();
                SqlCommand comando = new SqlCommand("UPDATE MLJ.Roles SET habilitado = 0 WHERE cod_rol = @codRol", conexion, transaction);
                comando.Parameters.AddWithValue("@codRol", rol.idRol);
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
