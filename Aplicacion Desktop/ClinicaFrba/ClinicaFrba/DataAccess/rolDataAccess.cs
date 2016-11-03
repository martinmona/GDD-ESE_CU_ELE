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
        public static SqlConnection conectar()
        {
            SqlConnection connection = BD.ObtenerConexion();
            connection.Open();
            return connection;
        }

        public static List<IlanRol> ObtenerRolesPorUsuario(decimal idUser)
        {
            List<IlanRol> listaRoles = new List<IlanRol>();
            SqlConnection conn = conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.CommandText = "select rol.* from ESE_CU_ELE.RolXUsuario rolxusu join ESE_CU_ELE.Rol rol on rolxusu.rolxu_rol_codigo=rol.rol_codigo where rolxusu.rolxu_usua_codigo="+idUser+" and rol.rol_habilitado = 1";
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                IlanRol rol = new IlanRol();
                rol.id = (decimal)reader["rol_codigo"];
                rol.nombre= (string)reader["rol_nombre"];
                listaRoles.Add(rol);
            }
            reader.Close();
            conn.Close();
            return listaRoles;
        }

        public static List<IlanRol> ObtenerRoles(string where)
        {
            List<IlanRol> listaRoles = new List<IlanRol>();
            SqlConnection conn = conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.CommandText = "select * from ESE_CU_ELE.Rol "+ where;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                IlanRol rol = new IlanRol();
                rol.id = (decimal)reader["rol_codigo"];
                rol.nombre = (string)reader["rol_nombre"];
                rol.habilitado = (bool)reader["rol_habilitado"];
                listaRoles.Add(rol);
            }
            reader.Close();
            conn.Close();
            return listaRoles;
        }
    }
}
