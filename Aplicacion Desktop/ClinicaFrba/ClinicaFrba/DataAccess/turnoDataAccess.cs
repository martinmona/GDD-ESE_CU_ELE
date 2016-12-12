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

        public static List<Turno> obtenerTurnosxAfiliado(decimal codigoAfiliado, string where)
        {
            List<Turno> listaTurnos = new List<Turno>();
            SqlConnection conn = BD.conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.CommandText = "select turn_codigo,turn_fecha,turn_codigo_afiliado, turn_especialidad,turn_estado from ESE_CU_ELE.Turno where turn_codigo_afiliado =" + codigoAfiliado+" "+where;
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
                decimal codigoEspe = (decimal)reader["turn_especialidad"];
                unTurno.especialidad = especialidadDataAccess.ObtenerEspecialidades("where espe_codigo ="+ codigoEspe.ToString())[0];
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
            SqlConnection conn = BD.conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.CommandText = "select turn_codigo,turn_fecha,turn_codigo_afiliado,turn_especialidad, turn_estado from ESE_CU_ELE.Turno where CONVERT(date, turn_fecha) >= CONVERT(date, '" + fechaDesde+ "') and CONVERT(date, turn_fecha) <= CONVERT(date, '" + fechaHasta + "') and turn_especialidad =" + codigoEspecialidad+" and turn_profesional ="+ codigoProfesional+" "+where;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                Turno unTurno = new Turno();
                Afiliado unAfil = new Afiliado();
                unTurno.codigo = (decimal)reader["turn_codigo"];
                unTurno.fecha = (DateTime)reader["turn_fecha"];
                decimal codigoAfil = (decimal)reader["turn_codigo_afiliado"];
                unAfil = afiliadoDataAccess.ObtenerAfiliados("where afil_codigo_persona =" + codigoAfil.ToString())[0];
                decimal codigoEspe = (decimal)reader["turn_especialidad"];
                unTurno.especialidad = especialidadDataAccess.ObtenerEspecialidades("where espe_codigo =" + codigoEspe.ToString())[0];
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
                BD.obtenerFecha();
                SqlConnection conn = BD.conectar();
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
                SqlConnection conn = BD.conectar();
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
                BD.obtenerFecha();
                SqlConnection conn = BD.conectar();
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
                BD.obtenerFecha();
                SqlConnection conn = BD.conectar();
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


        public static bool reservarTurno(Turno nuevoTurno)
        {
            try
            {
                SqlConnection conn = BD.conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.Parameters.AddWithValue("@afiliado", nuevoTurno.afiliado.codigoPersona);
                MiComando.Parameters.AddWithValue("@especialidad", nuevoTurno.especialidad.codigo);
                MiComando.Parameters.AddWithValue("@idProfesional", nuevoTurno.profesional.codigoPersona);
                MiComando.Parameters.AddWithValue("@fecha", nuevoTurno.fecha);
                MiComando.Parameters.AddWithValue("@estado", nuevoTurno.estado);
                MiComando.CommandText = "INSERT INTO ESE_CU_ELE.Turno(turn_fecha,turn_codigo_afiliado, turn_especialidad,turn_estado,turn_profesional) VALUES(@fecha, @afiliado,@especialidad,@estado, @idProfesional)";
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

    }
}
