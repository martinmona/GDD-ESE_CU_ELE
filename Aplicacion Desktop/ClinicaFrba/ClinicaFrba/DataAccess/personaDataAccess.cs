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


        public static string ObtenerTipoPersona(decimal idPersona )
        {
            string tipo="";
            SqlConnection conn = BD.conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.CommandText = "select pers_tipo from ESE_CU_ELE.Persona where pers_codigo = " + idPersona;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                tipo = (string)reader["pers_tipo"];
            }
            
            reader.Close();
            conn.Close();
            return tipo;
        }
    }
}

