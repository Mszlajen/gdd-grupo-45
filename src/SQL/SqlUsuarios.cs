﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.SQL
{
    class SqlUsuarios
    {
        public int IniciarSesion(String username, String password)
        {
            SqlConnection conexion = SqlGeneral.nuevaConexion();
            SqlCommand cmd = new SqlCommand("MLJ.login", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            // instancio parametro de salida
            SqlParameter VariableRetorno = new SqlParameter("@resultado", SqlDbType.Int);
            VariableRetorno.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(new SqlParameter("@usuario", username));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            cmd.Parameters.Add(VariableRetorno);

            conexion.Open();
            cmd.ExecuteNonQuery(); // aca se abre la conexion y se ejecuta el SP de login
            int resultado = (int)cmd.Parameters["@resultado"].Value;
            conexion.Close();
            return resultado;
        }
    }
}
