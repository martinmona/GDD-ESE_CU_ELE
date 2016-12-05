using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ClinicaFrba.Config;
using ClinicaFrba.Class;

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

        /*public static List<Turno> ObtenerTurnos(DateTime fecha, int idmedico)
        {

            SqlConnection conn = conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            List<Turno> listaturnos = new List<Turno>();
            MiComando.Parameters.AddWithValue("@Fecha", fecha);
            MiComando.Parameters.AddWithValue("@IdMedico", idmedico);
            MiComando.CommandText = "SELECT t.id, t.HoraI, t.HoraT, p.Nombre AS NombreP, p.Apellido AS ApellidoP, m.Nombre AS NombreM, m.Apellido AS ApellidoM FROM Turnos t INNER JOIN Pacientes p ON p.Id = t.IdPaciente INNER JOIN Medicos m ON m.Id = t.IdMedico WHERE t.Fecha = @Fecha And t.IdMedico = @IdMedico";
            SqlDataReader reader = MiComando.ExecuteReader();

            while (reader.Read())
            {
                Turno miturno = new Turno();
                miturno.Id = (int)reader["Id"];
                miturno.HoraI = (string)reader["HoraI"];
                miturno.HoraT = (string)reader["HoraT"];
                miturno.NombreP = (string)reader["NombreP"];
                miturno.ApellidoP = (string)reader["ApellidoP"];
                miturno.NombreM = (string)reader["NombreM"];
                miturno.ApellidoM = (string)reader["ApellidoM"];


                listaturnos.Add(miturno);
            }
            reader.Close();
            conn.Close();
            return listaturnos;
        }*/
    }
}
