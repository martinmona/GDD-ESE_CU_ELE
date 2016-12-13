using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaFrba.Class;
using ClinicaFrba.Config;
using System.Data.SqlClient;
using System.Data;

namespace ClinicaFrba.DataAccess
{
    class listadosDataAccess
    {
        public static List<listadoCancelaciones> listadoCancelaciones(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<listadoCancelaciones> listaCancelaciones = new List<listadoCancelaciones>();
            SqlConnection conn = BD.conectar();
            SqlCommand MiComando = new SqlCommand("ESE_CU_ELE.SPListadoCancelaciones", conn);
            MiComando.Connection = conn;

            MiComando.CommandType = CommandType.StoredProcedure;
            MiComando.Parameters.Add("@fechaDesde", SqlDbType.DateTime).Value = fechaDesde.Date;
            MiComando.Parameters.Add("@fechaHasta", SqlDbType.DateTime).Value = fechaHasta.Date;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                listadoCancelaciones cancelacion = new listadoCancelaciones();
                cancelacion.Especialidad= (string)reader["espe_descripcion"];

                cancelacion.CantidadCancelaciones = (int)reader["cantidadCancelaciones"];

                listaCancelaciones.Add(cancelacion);
            }
            reader.Close();
            conn.Close();
            return listaCancelaciones;
        }
        public static List<listadoProfesionalesPorPlan> listadoProfesionalesPorPlan(DateTime fechaDesde, DateTime fechaHasta,decimal plan)
        {
            List<listadoProfesionalesPorPlan> listaProfesionalesPorPlan = new List<listadoProfesionalesPorPlan>();
            SqlConnection conn = BD.conectar();
            SqlCommand MiComando = new SqlCommand("ESE_CU_ELE.SPListadoProfesionalesPorPlan", conn);
            MiComando.Connection = conn;
            MiComando.CommandType = CommandType.StoredProcedure;
            MiComando.Parameters.Add("@fechaDesde", SqlDbType.DateTime).Value = fechaDesde.Date;
            MiComando.Parameters.Add("@fechaHasta", SqlDbType.DateTime).Value = fechaHasta.Date;
            MiComando.Parameters.Add("@plan", SqlDbType.Decimal).Value = plan;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                listadoProfesionalesPorPlan profPorPlan = new listadoProfesionalesPorPlan();
                profPorPlan.Nombre= (string)reader["pers_nombre"];
                profPorPlan.Apellido=(string)reader["pers_apellido"];
                profPorPlan.Matricula= (decimal)reader["prof_codigo_matricula"]; ;
                profPorPlan.Especialidad = (string)reader["espe_descripcion"];
                profPorPlan.CantidadConsultas = (int)reader["cantidadConsultas"];
                listaProfesionalesPorPlan.Add(profPorPlan);
            }
            reader.Close();
            conn.Close();
            return listaProfesionalesPorPlan;
        }
        public static List<listadoProfesionalesMenosHoras> listadoProfesionalesMenosHoras(DateTime fechaDesde, DateTime fechaHasta, decimal especialidad)
        {
            List<listadoProfesionalesMenosHoras> listaProfesionalesMenosHoras = new List<listadoProfesionalesMenosHoras>();
            SqlConnection conn = BD.conectar();
            SqlCommand MiComando = new SqlCommand("ESE_CU_ELE.ListadoProfesionalesMenosHoras", conn);
            MiComando.Connection = conn;
            MiComando.CommandType = CommandType.StoredProcedure;
            MiComando.Parameters.Add("@fechaDesde", SqlDbType.DateTime).Value = fechaDesde.Date;
            MiComando.Parameters.Add("@fechaHasta", SqlDbType.DateTime).Value = fechaHasta.Date;
            MiComando.Parameters.Add("@especialidad", SqlDbType.Decimal).Value = especialidad;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                listadoProfesionalesMenosHoras profMenosHoras = new listadoProfesionalesMenosHoras();
                profMenosHoras.Nombre = (string)reader["pers_nombre"];
                profMenosHoras.Apellido = (string)reader["pers_apellido"];
                profMenosHoras.Matricula = (decimal)reader["prof_codigo_matricula"]; ;
                profMenosHoras.CantidadHoras = (int)reader["cantidadHoras"];
                listaProfesionalesMenosHoras.Add(profMenosHoras);
            }
            reader.Close();
            conn.Close();
            return listaProfesionalesMenosHoras;
        }
        public static List<listadoAfiliadosBonos> listadoAfiliadosBonos(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<listadoAfiliadosBonos> listaAfiliadosBonos = new List<listadoAfiliadosBonos>();
            SqlConnection conn = BD.conectar();
            SqlCommand MiComando = new SqlCommand("ESE_CU_ELE.ListadoAfiliadosBonos", conn);
            MiComando.Connection = conn;
            MiComando.CommandType = CommandType.StoredProcedure;
            MiComando.Parameters.Add("@fechaDesde", SqlDbType.DateTime).Value = fechaDesde.Date;
            MiComando.Parameters.Add("@fechaHasta", SqlDbType.DateTime).Value = fechaHasta.Date;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                listadoAfiliadosBonos afilBonos = new listadoAfiliadosBonos();
                afilBonos.Nombre = (string)reader["pers_nombre"];
                afilBonos.Apellido = (string)reader["pers_apellido"];
                afilBonos.NumeroAfiliado = (decimal)reader["afil_numero"];
                afilBonos.NumeroFamiliar = (decimal)reader["afil_numero_familiar"];
                afilBonos.CantidadBonos = (int)reader["cantidadBonos"]; 
                afilBonos.perteneceGrupoFamiliar = (string)reader["perteneceGrupoFamiliar"];
                listaAfiliadosBonos.Add(afilBonos);
            }
            reader.Close();
            conn.Close();
            return listaAfiliadosBonos;
        }
        public static List<listadoEspecialidadesBonos> listadoEspecialidadesBonos(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<listadoEspecialidadesBonos> listaEspecialidadesBonos = new List<listadoEspecialidadesBonos>();
            SqlConnection conn = BD.conectar();
            SqlCommand MiComando = new SqlCommand("ESE_CU_ELE.ListadoEspecialidadesBonos", conn);
            MiComando.Connection = conn;
            MiComando.CommandType = CommandType.StoredProcedure;
            MiComando.Parameters.Add("@fechaDesde", SqlDbType.DateTime).Value = fechaDesde.Date;
            MiComando.Parameters.Add("@fechaHasta", SqlDbType.DateTime).Value = fechaHasta.Date;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                listadoEspecialidadesBonos espeBonos = new listadoEspecialidadesBonos();
                espeBonos.Especialidad = (string)reader["espe_descripcion"];
                espeBonos.CantidadBonos = (int)reader["cantidadBonos"];

                listaEspecialidadesBonos.Add(espeBonos);
            }
            reader.Close();
            conn.Close();
            return listaEspecialidadesBonos;
        }
    }
}
