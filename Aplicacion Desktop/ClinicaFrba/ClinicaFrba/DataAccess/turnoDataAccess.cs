using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Config;
using ClinicaFrba.Class;
using System.Data.SqlClient;
using ClinicaFrba.DataAccess;
using System.Data;
using System.Windows.Forms;

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
        public static List<Turno> obtenerTurnosxAfiliado(decimal codigoAfiliado, string where)
        {
            List<Turno> listaTurnos = new List<Turno>();
            SqlConnection conn = conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.CommandText = "select turn_codigo,turn_fecha,turn_codigo_afiliado, turn_estado from ESE_CU_ELE.Turno where turn_codigo_afiliado "+where;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                Turno unTurno = new Turno();
                Afiliado unAfil = new Afiliado();
                unTurno.codigo = (decimal)reader["turn_codigo"];
                unTurno.fecha = (DateTime)reader["turn_fecha"];
                decimal codigoAfil = (decimal)reader["turn_codigo_afiliado"];
                unAfil = afiliadoDataAccess.ObtenerAfiliados("where afil_codigo_persona =" + codigoAfil.ToString())[0];
                unTurno.afiliado = unAfil;
                unTurno.estado = (string)reader["turn_estado"];
                listaTurnos.Add(unTurno);
            }
            reader.Close();
            conn.Close();
            return listaTurnos;
        }

        public static List<Turno> obtenerTurnosxFecha(DateTime laFecha, decimal codigoEspecialidad, decimal codigoProfesional, string where)
        {
            return obtenerTurnosxFecha(laFecha, laFecha, codigoEspecialidad, codigoProfesional, where);
        }

        public static List<Turno> obtenerTurnosxFecha(DateTime fechaDesde,DateTime fechaHasta, decimal codigoEspecialidad, decimal codigoProfesional,string where)
        {
                
            List<Turno> listaTurnos = new List<Turno>();
            SqlConnection conn = conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.CommandText = "select turn_codigo,turn_fecha,turn_codigo_afiliado, turn_estado from ESE_CU_ELE.Turno where CONVERT(date, turn_hora) >= CONVERT(date, '" + fechaDesde+ "') and CONVERT(date, turn_hora) <= CONVERT(date, '" + fechaHasta + "') and turn_especialidad =" + codigoEspecialidad+" and turn_profesional ="+ codigoProfesional+" "+where;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                Turno unTurno = new Turno();
                Afiliado unAfil = new Afiliado();
                unTurno.codigo = (decimal)reader["turn_codigo"];
                unTurno.fecha = (DateTime)reader["turn_fecha"];
                decimal codigoAfil = (decimal)reader["turn_codigo_afiliado"];
                unAfil = afiliadoDataAccess.ObtenerAfiliados("where afil_codigo_persona =" + codigoAfil.ToString())[0];
                unTurno.afiliado = unAfil;
                unTurno.estado= (string)reader["turn_estado"];
                listaTurnos.Add(unTurno);
            }
            reader.Close();
            conn.Close();
            return listaTurnos;
        }

        public static bool registrarLlegada(decimal codigoAfiliado,decimal codigoBono, decimal codigoTurno)
        {
            try
            {
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand("ESE_CU_ELE.SPRegistrarLlegada", conn);
                MiComando.Connection = conn;
                MiComando.CommandType = CommandType.StoredProcedure;
                MiComando.Parameters.Add("@afiliado", SqlDbType.Decimal).Value = codigoAfiliado;
                MiComando.Parameters.Add("@bono", SqlDbType.Decimal).Value = codigoBono;
                MiComando.Parameters.Add("@turno", SqlDbType.Decimal).Value = codigoTurno;
                MiComando.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "MENSAJE DE LA BASE DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



        }
        public static bool actualizarEstado(string estado, decimal codigoTurno)
        {
            try
            {
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.CommandText = "update from ESE_CU_ELE.Turno turn_estado = '"+estado+"' where turn_codigo ="+codigoTurno;
                MiComando.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }



        }
        public static bool CancelarTurnoAfiliado(decimal turno, decimal tipo, string motivo)
        {
            try
            {
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand("ESE_CU_ELE.SPCancelarTurnoAfiliado", conn);
                MiComando.Connection = conn;
                MiComando.CommandType = CommandType.StoredProcedure;
                MiComando.Parameters.Add("@turno", SqlDbType.Decimal).Value = turno;
                MiComando.Parameters.Add("@tipo", SqlDbType.Decimal).Value = tipo;
                MiComando.Parameters.Add("@motivo", SqlDbType.VarChar).Value = motivo;
                MiComando.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "MENSAJE DE LA BASE DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }            
        }
        public static bool CancelarTurnoProfesional(decimal codigoProfesional,DateTime fechaDesde, DateTime fechaHasta, decimal tipo, string motivo)
        {
            try
            {
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand("ESE_CU_ELE.SPCancelarTurnoProfesional", conn);
                MiComando.Connection = conn;
                MiComando.CommandType = CommandType.StoredProcedure;
                MiComando.Parameters.Add("@profesional", SqlDbType.Decimal).Value = codigoProfesional;
                MiComando.Parameters.Add("@fechaDesde", SqlDbType.DateTime).Value = fechaDesde.Date;
                MiComando.Parameters.Add("@fechaHasta", SqlDbType.DateTime).Value = fechaHasta.Date;
                MiComando.Parameters.Add("@tipo", SqlDbType.Decimal).Value = tipo;
                MiComando.Parameters.Add("@motivo", SqlDbType.VarChar).Value = motivo;
                MiComando.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "MENSAJE DE LA BASE DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



        }


        public static void reservarTurno(Afiliado afiliado, string horaI, string horaF, decimal idProfesional, DateTime fecha)
        {

            SqlConnection conn = conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.Parameters.AddWithValue("@afiliado", afiliado);
            MiComando.Parameters.AddWithValue("@horaI", horaI);
            MiComando.Parameters.AddWithValue("@horaF", horaF);
            MiComando.Parameters.AddWithValue("@idProfesional", idProfesional);
            MiComando.Parameters.AddWithValue("@fecha", fecha);
            MiComando.CommandText = "INSERT INTO Turnos(turn_fecha, turn_afiliado, turn_horaI, turn_horaF, turn_idProfesional) VALUES(@fecha, @afiliado, @horaI, @horaF, @idProfesional)";
            MiComando.ExecuteNonQuery();
            conn.Close();
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
