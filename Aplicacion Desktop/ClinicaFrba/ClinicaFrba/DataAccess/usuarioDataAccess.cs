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
            connection.Open();
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
                    myuser.id = (decimal)reader["usua_codigo"];
                    myuser.user = (string)reader["usua_username"];
                }

                if (!( myuser.id > 0))
                {
                    myuser.id = -1;
                }


            reader.Close();
            conn.Close();
            }
            catch 
            {
                myuser.id = -1;
            }
            return myuser;
        }
    }
}
