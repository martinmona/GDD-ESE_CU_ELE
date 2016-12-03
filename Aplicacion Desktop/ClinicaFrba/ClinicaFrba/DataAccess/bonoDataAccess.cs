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
    class bonoDataAccess
    {
        public static SqlConnection conectar()
        {
            SqlConnection connection = BD.ObtenerConexion();
            connection.Open();
            return connection;
        }

        public static bool AgregarBono(Bono nuevoBono, Afiliado elAfiliado)
        {
            //try
            //{
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand("insert into ESE_CU_ELE.Bono (bono_afiliado,bono_plan,bono_precio,bono_fecha_compra) values(@afiliado,@plan,@precio,@fecha)",conn);
                MiComando.Parameters.AddWithValue("@afiliado", elAfiliado.codigoPersona);
                MiComando.Parameters.AddWithValue("@plan", elAfiliado.plan.codigo);
                MiComando.Parameters.AddWithValue("@precio", nuevoBono.precio);
                MiComando.Parameters.AddWithValue("@fecha", nuevoBono.fechaCompra);
                MiComando.ExecuteNonQuery();
                conn.Close();
                return true;
            //}
            //catch
            //{
            //    return false;
            //}


        }
    }
}
