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
    class personaDataAccess
    {
        public static SqlConnection conectar()
        {
            SqlConnection connection = BD.ObtenerConexion();
            connection.Open();
            return connection;
        }

        public static string ObtenerTipoPersona(decimal idPersona )
        {
            SqlConnection conn = conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.CommandText = " select pers_tipo from ESE_CU_ELE.Persona pers_codigo=" + idPersona;
            SqlDataReader reader = MiComando.ExecuteReader();
            string tipo = (string)reader["pers_tipo"];
            reader.Close();
            conn.Close();
            return tipo;
        }
    }
}

