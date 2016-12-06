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
                    return true;
                }
            }
        }
        public static List<Bono> obtenerBonosSinUsar(Afiliado elAfiliado)
        {
            using (SqlConnection con = conectar())
            {
                
                using (SqlCommand cmd = new SqlCommand("ESE_CU_ELE.SPObtenerBonosSinUsar", con))
                {
                    List<Bono> bonos = new List<Bono>();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@afiliado", SqlDbType.Decimal).Value = elAfiliado.numeroAfiliado;
                    cmd.Parameters.Add("@plan", SqlDbType.Decimal).Value = elAfiliado.plan.codigo;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Bono unBono = new Bono();
                        unBono.codigo = (decimal)reader["bono_codigo"];
                        unBono.fechaCompra = (DateTime)reader["bono_fecha_compra"];
                        unBono.plan = elAfiliado.plan;
                        unBono.precio= (decimal)reader["bono_precio"];
                        bonos.Add(unBono);
                    }
                    reader.Close();

                    
                    con.Close();
                    return bonos;
                }
            }
        }
    }
}
