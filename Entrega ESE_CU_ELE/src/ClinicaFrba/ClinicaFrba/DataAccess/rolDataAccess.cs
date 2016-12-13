using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClinicaFrba.Config;
using ClinicaFrba.Class;

namespace ClinicaFrba.Class
{

    public class rolDataAccess
    {


        public static List<Rol> ObtenerRolesPorUsuario(decimal idUser)
        {
            List<Rol> listaRoles = new List<Rol>();
            SqlConnection conn = BD.conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.CommandText = "select rol.* from ESE_CU_ELE.RolXUsuario rolxusu join ESE_CU_ELE.Rol rol on rolxusu.rolxu_rol_codigo=rol.rol_codigo where rolxusu.rolxu_usua_codigo="+idUser+" and rol.rol_habilitado = 1";
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                Rol rol = new Rol();
                rol.codigo = (decimal)reader["rol_codigo"];
                rol.nombre= (string)reader["rol_nombre"];
                listaRoles.Add(rol);
            }
            reader.Close();
            conn.Close();
            return listaRoles;
        }

        public static List<Rol> ObtenerRoles(string where)
        {
            List<Rol> listaRoles = new List<Rol>();
            SqlConnection conn = BD.conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.CommandText = "select * from ESE_CU_ELE.Rol "+ where;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                Rol rol = new Rol();
                rol.codigo = (decimal)reader["rol_codigo"];
                rol.nombre = (string)reader["rol_nombre"];
                rol.habilitado = (bool)reader["rol_habilitado"];
                listaRoles.Add(rol);
            }
            reader.Close();
            conn.Close();
            return listaRoles;
        }

        public static bool AgregarRol(string nombre,List<Funcionalidad> listaFuncionalidades)
        {
            try
            {
                decimal codigoRol = obtenerUltimoCodigo() +1;
                SqlConnection conn = BD.conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.CommandText = "INSERT INTO ESE_CU_ELE.Rol(rol_nombre,rol_habilitado) VALUES('" + nombre + "',1)";
                MiComando.ExecuteNonQuery();

                foreach (Funcionalidad func in listaFuncionalidades)
                {
                    MiComando.CommandText = "INSERT INTO ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) VALUES("+func.codigo+", "+ codigoRol+")";
                    MiComando.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        private static decimal obtenerUltimoCodigo()
        {
            decimal codigo = 1;
            try
            {
                SqlConnection conn = BD.conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.CommandText = "SELECT TOP 1 rol_codigo from ESE_CU_ELE.Rol order by rol_codigo DESC";
                codigo = (decimal)MiComando.ExecuteScalar();
                conn.Close();
            }
            catch
            {
            }
            return codigo;
        }
        public static bool EliminarRol(decimal codigo)
        {
            try
            {
                SqlConnection conn = BD.conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.CommandText = "DELETE FROM ESE_CU_ELE.RolXFuncionalidad where rolxf_rol_codigo = " + codigo;
                MiComando.ExecuteNonQuery();
                MiComando.CommandText = "UPDATE ESE_CU_ELE.Rol set rol_habilitado=0 where rol_codigo = " + codigo;
                MiComando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static bool ModificarRol(decimal codigo, string nombre, List<Funcionalidad> listaFuncionalidades, int habilitado)
        {
            try
            {
                SqlConnection conn = BD.conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.CommandText = "DELETE FROM ESE_CU_ELE.RolXFuncionalidad where rolxf_rol_codigo = " + codigo;
                MiComando.ExecuteNonQuery();
                foreach (Funcionalidad func in listaFuncionalidades)
                {
                    MiComando.CommandText = "INSERT INTO ESE_CU_ELE.RolXFuncionalidad(rolxf_func_codigo,rolxf_rol_codigo) VALUES("+func.codigo+", "+ codigo+")";
                    MiComando.ExecuteNonQuery();
                }
                MiComando.CommandText = "UPDATE ESE_CU_ELE.Rol set rol_habilitado="+habilitado+", rol_nombre = '"+nombre+"' where rol_codigo = " + codigo;
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
