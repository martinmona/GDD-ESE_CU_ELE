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
    class compraDataAccess
    {
        public static SqlConnection conectar()
        {
            SqlConnection connection = BD.ObtenerConexion();
            connection.Open();
            return connection;
        }

        public static bool AgregarCompra(Compra laCompra, Afiliado elAfiliado)
        {

            try
            {
                laCompra.fecha = DateTime.Now;
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand("insert into ESE_CU_ELE.Compra (comp_afiliado,comp_fecha,comp_total) values(@codigoPersona,@fecha,@total)",conn);
                MiComando.Parameters.AddWithValue("@codigoPersona", elAfiliado.codigoPersona);
                MiComando.Parameters.AddWithValue("@fecha", laCompra.fecha);
                MiComando.Parameters.AddWithValue("@total", laCompra.total); 
                MiComando.ExecuteNonQuery();
                conn.Close();
                foreach (Bono elBono in laCompra.bonos)
                {
                    elBono.fechaCompra = laCompra.fecha;
                    bonoDataAccess.AgregarBono(elBono, elAfiliado);
                }
                

                return true;
            }
            catch
            {
                return false;
            }


        }
    }
}
