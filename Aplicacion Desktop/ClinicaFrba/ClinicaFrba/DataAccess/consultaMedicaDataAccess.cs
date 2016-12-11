using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Class;
using System.Data.SqlClient;
using ClinicaFrba.Config;
using System.Data;
using System.Windows.Forms;

namespace ClinicaFrba.DataAccess
{
    class consultaMedicaDataAccess
    {
        public static SqlConnection conectar()
        {
            SqlConnection connection = BD.ObtenerConexion();
            connection.Open();
            return connection;
        }

        public static ConsultaMedica ObtenerConsulta(decimal turnoCodigo)
        {
            ConsultaMedica consulta = new ConsultaMedica();
            SqlConnection conn = conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.CommandText = "select cons_turno,cons_sintomas,cons_hora_llegada,cons_enfermedades from ESE_CU_ELE.Consulta_Medica where cons_turno="+turnoCodigo;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                
                consulta.codigo = (decimal)reader["cons_turno"];
                consulta.horaLlegada = (DateTime)reader["cons_hora_llegada"];
                try
                {
                    consulta.enfermedades = (string)reader["cons_enfermedades"];
                    consulta.sintomas = (string)reader["cons_sintomas"];
                }
                catch { }

            }
            reader.Close();
            conn.Close();
            return consulta;
        }
        public static bool registrarLlegada(decimal codigoConsulta, DateTime fecha, string sintomas,string enfermedades)
        {
            try
            {
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand("ESE_CU_ELE.SPRegistrarResultado", conn);
                MiComando.Connection = conn;
                MiComando.CommandType = CommandType.StoredProcedure;
                MiComando.Parameters.Add("@consulta", SqlDbType.Decimal).Value = codigoConsulta;
                MiComando.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;
                MiComando.Parameters.Add("@sintomas", SqlDbType.VarChar).Value = sintomas;
                MiComando.Parameters.Add("@enfermedades", SqlDbType.VarChar).Value = enfermedades;
                MiComando.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message,"MENSAJE DE LA BASE DE DATOS",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }



        }
        
    }
    
}
