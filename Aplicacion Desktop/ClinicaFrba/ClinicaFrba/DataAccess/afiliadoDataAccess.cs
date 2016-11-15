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
    class afiliadoDataAccess
    {
        public static SqlConnection conectar()
        {
            SqlConnection connection = BD.ObtenerConexion();
            connection.Open();
            return connection;
        }

        public static List<Afiliado> ObtenerAfiliados(string where)
        {
            List<Afiliado> listaAfiliados = new List<Afiliado>();
            SqlConnection conn = conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.CommandText = " SELECT CONCAT(pers_nombre, ' ',pers_apellido) as nombre, CONCAT(pers_tipo_documento, ' ',pers_numero_documento) as documento,pers_direccion, pers_telefono, pers_mail, pers_fecha_nacimiento, pers_sexo,  afi.afil_numero,afi.afil_numero_familiar,afi.afil_estado_civil,(SELECT COUNT(familiar.afil_codigo_persona) FROM ESE_CU_ELE.Afiliado familiar WHERE familiar.afil_numero = afi.afil_numero AND NOT(familiar.afil_numero_familiar = 01) AND NOT(afi.afil_codigo_persona = familiar.afil_codigo_persona)) as cantidadFamiliares, planes.plan_descripcion from ESE_CU_ELE.Persona pers join ESE_CU_ELE.Afiliado afi on pers.pers_codigo = afi.afil_codigo_persona join ESE_CU_ELE.Planes planes on afi.afil_codigo_plan = planes.plan_codigo " + where;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                Afiliado afiliado = new Afiliado();
                listaAfiliados.Add(afiliado);
            }
            reader.Close();
            conn.Close();
            return listaAfiliados;
        }
    }
}
