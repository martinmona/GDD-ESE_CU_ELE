﻿using System;
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

        public static List<Funcionalidad> obtenerFuncionalidadesPorRol(decimal idRol)
        {
            List<Class.Funcionalidad> listaFuncionalidades = new List<Class.Funcionalidad>();
            SqlConnection conn = BD.conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.CommandText = "select func.* from ESE_CU_ELE.RolXFuncionalidad rolxfunc join ESE_CU_ELE.Funcionalidad func on rolxfunc.rolxf_func_codigo=func.func_codigo where rolxfunc.rolxf_rol_codigo=" + idRol;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                Funcionalidad funcionalidad = new Funcionalidad();
                funcionalidad.codigo = (decimal)reader["func_codigo"];
                funcionalidad.descripcion = (string)reader["func_descripcion"];
                listaFuncionalidades.Add(funcionalidad);
            }
            reader.Close();
            conn.Close();
            return listaFuncionalidades;
        }


        public static List<Funcionalidad> obtenerFuncionalidadesFiltradas(string where)
        {
            List<Class.Funcionalidad> listaFuncionalidades = new List<Class.Funcionalidad>();
            SqlConnection conn = BD.conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.CommandText = "select * from ESE_CU_ELE.Funcionalidad "+ where;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                Funcionalidad funcionalidad = new Funcionalidad();
                funcionalidad.codigo = (decimal)reader["func_codigo"];
                funcionalidad.descripcion = (string)reader["func_descripcion"];
                listaFuncionalidades.Add(funcionalidad);
            }
            reader.Close();
            conn.Close();
            return listaFuncionalidades;
        }
    }

}
