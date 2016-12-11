using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Config;
using ClinicaFrba.Class;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

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
                MiComando.CommandText = "INSERT INTO ESE_CU_ELE.Agenda(agen_dia,agen_profesional,agen_especialidad,agen_fecha_inicio,agen_fecha_fin,agen_hora_fin,agen_hora_inicio) VALUES('" + nuevaAgenda.dia + "', " + profesional.codigoPersona + "," + nuevaAgenda.especialidad.codigo + ", '" + nuevaAgenda.fechaInicio.Date + "','" + nuevaAgenda.fechaFin.Date + "', '" + nuevaAgenda.horaFin + "', '" + nuevaAgenda.horaInicio + "')";
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
        public static List<Agenda> ObtenerAgendas(decimal codigoProfesional, decimal codigoEspecialidad, DateTime fecha)
        {
            List<Agenda> listaAgendas = new List<Agenda>();
            SqlConnection conn = conectar();
            SqlCommand MiComando = new SqlCommand("ESE_CU_ELE.SPObtenerAgendas",conn);
            MiComando.Connection = conn;
            
            MiComando.CommandType = CommandType.StoredProcedure;
            MiComando.Parameters.Add("@profesional", SqlDbType.Decimal).Value = codigoProfesional;
            MiComando.Parameters.Add("@especialidad", SqlDbType.Decimal).Value = codigoEspecialidad;
            MiComando.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha.Date;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                Agenda agenda = new Agenda();
                //agenda.codigo= (decimal)reader["agen_codigo"];
                agenda.dia = (byte)reader["agen_dia"];
                //agenda.fechaInicio = (DateTime)reader["agen_fecha_inicio"];
                //agenda.fechaFin = (DateTime)reader["agen_fecha_fin"];
                agenda.horaInicio= (TimeSpan)reader["agen_hora_inicio"]; 
                agenda.horaFin = (TimeSpan)reader["agen_hora_fin"];
                listaAgendas.Add(agenda);
            }
            reader.Close();
            conn.Close();
            return listaAgendas;
        }
    }
}