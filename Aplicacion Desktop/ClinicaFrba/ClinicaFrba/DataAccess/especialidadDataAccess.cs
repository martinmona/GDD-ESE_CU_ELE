using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Config;
using ClinicaFrba.Class;
using System.Data.SqlClient;

namespace ClinicaFrba.DataAccess
{
    class especialidadDataAccess
    {
        public static SqlConnection conectar()
        {
            SqlConnection connection = BD.ObtenerConexion();
            connection.Open();
            return connection;
        }

        public static List<Especialidad> ObtenerEspecialidades(string where)
        {
            List<Especialidad> listaEspecialidades = new List<Especialidad>();
            SqlConnection conn = conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.CommandText = " Select espe_codigo,espe_descripcion from ESE_CU_ELE.Especialidad" + where;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                Especialidad especialidad = new Especialidad();
                especialidad.codigo = (decimal)reader["espe_codigo"];
                especialidad.descripcion = (string)reader["espe_descripcion"];
                listaEspecialidades.Add(especialidad);
            }
            reader.Close();
            conn.Close();
            return listaEspecialidades;
        }
        public static List<Especialidad> ObtenerEspecialidadesXProfesional(decimal codigoProfesional)
        {
            List<Especialidad> listaEspecialidades = new List<Especialidad>();
            SqlConnection conn = conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.CommandText = " Select espe_codigo,espe_descripcion from ESE_CU_ELE.Especialidad, ESE_CU_ELE.EspecialidadXProfesional where espexp_codigo_profesional = " + codigoProfesional+ " and espexp_codigo_especialidad=espe_codigo" ;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                Especialidad especialidad = new Especialidad();
                especialidad.codigo = (decimal)reader["espe_codigo"];
                especialidad.descripcion = (string)reader["espe_descripcion"];
                listaEspecialidades.Add(especialidad);
            }
            reader.Close();
            conn.Close();
            return listaEspecialidades;
        }

    }
}

