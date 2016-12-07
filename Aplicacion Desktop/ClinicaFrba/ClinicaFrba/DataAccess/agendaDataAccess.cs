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
    class agendaDataAccess
    {
        public static SqlConnection conectar()
        {
            SqlConnection connection = BD.ObtenerConexion();
            connection.Open();
            return connection;
        }


        public static bool AgregarAgenda(Agenda nuevaAgenda, Profesional profesional)
        {
            try
            {
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.CommandText = "INSERT INTO ESE_CU_ELE.Agenda(agen_dia,agen_profesional,agen_especialidad,agen_fecha_inicio,agen_fecha_fin,agen_hora_fin,agen_hora_inicio) VALUES('" + nuevaAgenda.dia + "', " + profesional.codigoPersona + "," + nuevaAgenda.especialidad.codigo + ", '" + nuevaAgenda.fechaInicio.Date + "','" + nuevaAgenda.fechaFin.Date + "', '" + nuevaAgenda.horaFin.TimeOfDay + "', '" + nuevaAgenda.horaInicio.TimeOfDay + "')";
                MiComando.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }

            
            
        }
    }
}