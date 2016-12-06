using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Config;
using ClinicaFrba.Class;
using System.Data.SqlClient;
using ClinicaFrba.DataAccess;

namespace ClinicaFrba.DataAccess
{
    class turnoDataAccess
    {
        public static SqlConnection conectar()
        {
            SqlConnection connection = BD.ObtenerConexion();
            connection.Open();
            return connection;
        }

        public static List<Turno> obtenerTurnosxFecha(DateTime laFecha, decimal codigoEspecialidad, decimal codigoProfesional)
        {
                
            List<Turno> listaTurnos = new List<Turno>();
            SqlConnection conn = conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.CommandText = "select turn_codigo,turn_hora,turn_codigo_afiliado from ESE_CU_ELE.Turno where CONVERT(date, turn_hora) = CONVERT(date, '"+laFecha+"') and turn_especialidad ="+codigoEspecialidad+" and turn_profesional ="+ codigoProfesional;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                Turno unTurno = new Turno();
                Afiliado unAfil = new Afiliado();
                unTurno.codigo = (decimal)reader["turn_codigo"];
                unTurno.fecha = (DateTime)reader["turn_hora"];
                decimal codigoAfil = (decimal)reader["turn_codigo_afiliado"];
                unAfil= afiliadoDataAccess.ObtenerAfiliados("where afil_codigo_persona ="+codigoAfil.ToString())[0];
                unTurno.afiliado = unAfil;
                listaTurnos.Add(unTurno);
            }
            reader.Close();
            conn.Close();
            return listaTurnos;
        }
    }
}
