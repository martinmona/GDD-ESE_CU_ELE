using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ClinicaFrba.Config
{
    static class BD
    {
        public static SqlConnection ObtenerConexion()
        {
            string datosConexion = "Data Source = localhost\\SQLSERVER2012;"
            + "Initial Catalog = GD2C2016 ; Integrated Security = true; user id=gd; password=gd2016";
            SqlConnection con = new SqlConnection(datosConexion);
            con.Open();
            return con;
        }
             

    }
}
