using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Data;

namespace ClinicaFrba.Config
{
    public static class BD
    {
        private static DateTime _fechaActual;
        public static SqlConnection conectar()
        {
            SqlConnection connection = BD.ObtenerConexion();
            connection.Open();
            return connection;
        }
        public static SqlConnection ObtenerConexion()
        {
            string datosConexion = ConfigurationManager.AppSettings["connection-string"];
            SqlConnection con = new SqlConnection(datosConexion);
            return con;
        }
        public static DateTime obtenerFecha()
        {

            DateTime fecha = new DateTime();
            try
            {
                fecha = DateTime.Parse(ConfigurationManager.AppSettings["fecha"]);
                if (!_fechaActual.Equals(fecha))
                {
                    //ACTUALIZO LA FECHA EN LA BASE DE DATOS
                    SqlConnection conn = conectar();
                    SqlCommand MiComando = new SqlCommand("ESE_CU_ELE.AsignarFecha", conn);
                    MiComando.Connection = conn;
                    MiComando.CommandType = CommandType.StoredProcedure;
                    MiComando.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;
                    MiComando.ExecuteNonQuery();
                    conn.Close();
                    _fechaActual = fecha;
                }
            }
            catch 
            {
                MessageBox.Show("Error al intentar leer fecha desde archivo de configuracion");
            }

            return fecha;
        }

    }
}
