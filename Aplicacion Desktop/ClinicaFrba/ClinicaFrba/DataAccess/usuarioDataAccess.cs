using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClinicaFrba.Config;
using ClinicaFrba.Class;

namespace ClinicaFrba.Class{

    public class usuarioDataAccess
    {
        public static SqlConnection conectar()
        {
            SqlConnection connection = BD.ObtenerConexion();
            try
            {
                connection.Open();
            }
            catch (SqlException e)
            {
                if (e.Number == 18487 || e.Number == 18488)
                {
                    SqlConnection.ChangePassword(connection.ConnectionString, "gd2016");
                }
            }
            finally
            {
                //connection.Close();
            }


            return connection;
        }

        public static Usuario login(string user, string pass) 
        {
            Usuario myuser = new Usuario();
            try
            {
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.CommandText = "Select * From ESE_CU_ELE.Usuario Where usua_username = '" + user + "' AND usua_contrasena = HASHBYTES('SHA2_256', '"+ pass+"')";
                SqlDataReader reader = MiComando.ExecuteReader();

                while(reader.Read()) {
                    myuser.codigo = (decimal)reader["usua_codigo"];
                    myuser.username = (string)reader["usua_username"];
                    myuser.intentos = (int)reader["usua_intentos"];
                    myuser.habilitado = (bool)reader["usua_habilitado"];
                }

                if (!( myuser.codigo > 0))
                {
                    myuser.codigo = -1;
                }
            reader.Close();
            conn.Close();
            }
            catch 
            {
                myuser.codigo = -1;
            }
            return myuser;
        }

        public static decimal verificarUsuario(string user) 
        {
            decimal id = -1;
            try
            {
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.CommandText = "Select usua_codigo From ESE_CU_ELE.Usuario Where usua_username = '" + user + "' AND usua_habilitado = 1";
                id = (decimal)MiComando.ExecuteScalar();
                conn.Close();
            }
            catch 
            {
            }
            return id;
        }
        public static decimal verificarUsuarioPorCodigo(decimal codigo)
        {
            decimal id = -1;
            try
            {
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.CommandText = "Select usua_codigo From ESE_CU_ELE.Usuario Where usua_codigo = '" + codigo + "' AND usua_habilitado = 1";
                id = (decimal)MiComando.ExecuteScalar();
                conn.Close();
            }
            catch
            {
            }
            return id;
        }
        public static int sumarIntentoFallido(decimal idUser)
        {
            try
            {
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.CommandText = "UPDATE ESE_CU_ELE.Usuario SET usua_intentos = (usua_intentos + 1)  Where usua_codigo = " + idUser;
                MiComando.ExecuteNonQuery();

                MiComando.CommandText = "Select usua_intentos From ESE_CU_ELE.Usuario Where usua_codigo = " + idUser;
                int intentos = (int)MiComando.ExecuteScalar();

                conn.Close();
                return intentos;
            }
            catch
            {
                return -1;
            }
        }

        public static bool resetIntentos(decimal idUser)
        {
            try
            {
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.CommandText = "UPDATE ESE_CU_ELE.Usuario SET usua_intentos = 0  Where usua_codigo = " + idUser;
                MiComando.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool deshabilitar(decimal idUser)
        {
            try
            {
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.CommandText = "UPDATE ESE_CU_ELE.Usuario SET usua_habilitado = 0, usua_fecha_inhabilitado = GETDATE()  Where usua_codigo = " + idUser;
                MiComando.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool habilitar(decimal idUser)
        {
            try
            {
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.CommandText = "UPDATE ESE_CU_ELE.Usuario SET usua_habilitado = 1, usua_fecha_inhabilitado = NULL  Where usua_codigo = " + idUser;
                MiComando.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool agregarUsuario(decimal codigoPers)
        {
            try
            {
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.CommandText = "insert into ESE_CU_ELE.Usuario (usua_codigo,usua_username,usua_contrasena,usua_habilitado,usua_intentos) select pers_codigo,CONCAT(pers_nombre,pers_codigo),HASHBYTES('SHA2_256', pers_apellido),1,0 from ESE_CU_ELE.Persona where pers_codigo ="+codigoPers.ToString();
                MiComando.ExecuteNonQuery();
                MiComando.CommandText = "insert into ESE_CU_ELE.RolXUsuario (rolxu_rol_codigo,rolxu_usua_codigo)  VALUES(1,"+codigoPers.ToString()+")";
                MiComando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }



    }
}
