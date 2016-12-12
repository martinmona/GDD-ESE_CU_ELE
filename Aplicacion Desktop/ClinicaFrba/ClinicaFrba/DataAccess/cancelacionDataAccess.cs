using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Class;
using System.Data.SqlClient;
using ClinicaFrba.Config;

namespace ClinicaFrba.DataAccess
{
    class cancelacionDataAccess
    {



        public static List<TipoCancelacion> ObtenerTipoCancelacion()
        {
            List<TipoCancelacion> listaTipos = new List<TipoCancelacion>();
            SqlConnection conn = BD.conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.CommandText = "SELECT tipoc_codigo,tipoc_descripcion from ESE_CU_ELE.TipoCancelacion";
            MiComando.ExecuteNonQuery();
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                TipoCancelacion unTipo = new TipoCancelacion();
                unTipo.codigo= (decimal)reader["tipoc_codigo"];
                
                unTipo.descripcion = (string)reader["tipoc_descripcion"];
                listaTipos.Add(unTipo);
            }
            reader.Close();
            conn.Close();
            return listaTipos;



        }
    }
}
