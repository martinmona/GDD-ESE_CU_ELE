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
            string passSha = sha256(pass);
            try
            {
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.CommandText = "Select * From ESE_CU_ELE.Usuario Where usua_username = '" + user + "' AND usua_contrasena = '" + passSha + "'";
                SqlDataReader reader = MiComando.ExecuteReader();

                while(reader.Read()) {
                    myuser.id = (int)reader["usua_codigo"];
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

        static string sha256(string password)
        {
            System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
            System.Text.StringBuilder hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
