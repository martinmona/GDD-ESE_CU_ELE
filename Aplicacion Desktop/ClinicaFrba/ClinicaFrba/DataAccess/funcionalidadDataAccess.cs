using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClinicaFrba.Config;
using ClinicaFrba.Class;

namespace ClinicaFrba.DataAccess
{
    public class funcionalidadDataAccess
    {
        public static SqlConnection conectar()
        {
            SqlConnection connection = BD.ObtenerConexion();
            connection.Open();
            return connection;
        }

        public static List<Funcionalidad> obtenerFuncionalidadesPorRol(decimal idRol)
        {
            List<Funcionalidad> listaFuncionalidades = new List<Funcionalidad>();
            SqlConnection conn = conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.CommandText = "select func.* from ESE_CU_ELE.RolXFuncionalidad rolxfunc join ESE_CU_ELE.Funcionalidad func on rolxfunc.rolxf_func_codigo=func.func_codigo where rolxfunc.rolxf_rol_codigo=" + idRol;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                Funcionalidad funcionalidad = new Funcionalidad();
                funcionalidad.id = (decimal)reader["func_codigo"];
                funcionalidad.descripcion = (string)reader["func_descripcion"];
                listaFuncionalidades.Add(funcionalidad);
            }
            reader.Close();
            conn.Close();
            return listaFuncionalidades;
        }


        public static List<Funcionalidad> obtenerFuncionalidadesFiltradas(string where )
        {
            List<Funcionalidad> listaFuncionalidades = new List<Funcionalidad>();
            SqlConnection conn = conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.CommandText = "select * from ESE_CU_ELE.Funcionalidad "+ where;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                Funcionalidad funcionalidad = new Funcionalidad();
                funcionalidad.id = (decimal)reader["func_codigo"];
                funcionalidad.descripcion = (string)reader["func_descripcion"];
                listaFuncionalidades.Add(funcionalidad);
            }
            reader.Close();
            conn.Close();
            return listaFuncionalidades;
        }
    }

}
