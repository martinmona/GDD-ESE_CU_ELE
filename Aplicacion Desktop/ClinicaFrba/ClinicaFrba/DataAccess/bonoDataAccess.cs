using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Config;
using ClinicaFrba.Class;
using System.Data.SqlClient;
using System.Data;

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
            using (SqlConnection con = conectar())
            {
                using (SqlCommand cmd = new SqlCommand("ESE_CU_ELE.SPAgregarBono", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@afiliado", SqlDbType.Decimal).Value = elAfiliado.codigoPersona;
                    cmd.Parameters.Add("@plan", SqlDbType.Decimal).Value = elAfiliado.plan.codigo;
                    cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = nuevoBono.precio;
                    cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = nuevoBono.fechaCompra;

                    
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }

            /*try
            {
            SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand("insert into ESE_CU_ELE.Bono (bono_afiliado,bono_plan,bono_precio,bono_fecha_compra) values(@afiliado,@plan,@precio,@fecha)",conn);
                MiComando.Parameters.AddWithValue("@afiliado", elAfiliado.codigoPersona);
                MiComando.Parameters.AddWithValue("@plan", elAfiliado.plan.codigo);
                MiComando.Parameters.AddWithValue("@precio", nuevoBono.precio);
                MiComando.Parameters.AddWithValue("@fecha", nuevoBono.fechaCompra);
                MiComando.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
            */

        }
    }
}
