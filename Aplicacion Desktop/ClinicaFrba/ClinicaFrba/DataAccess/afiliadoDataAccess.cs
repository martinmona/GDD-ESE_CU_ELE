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
            MiComando.CommandText = " SELECT CONCAT(pers_nombre, ' ',pers_apellido) as nombre, CONCAT(pers_tipo_documento, ' ',pers_numero_documento) as documento,pers_direccion, pers_telefono, pers_mail, pers_fecha_nacimiento, pers_sexo,  afi.afil_numero,afi.afil_numero_familiar,afi.afil_codigo_persona,afi.afil_estado_civil,(SELECT COUNT(familiar.afil_codigo_persona) FROM ESE_CU_ELE.Afiliado familiar WHERE familiar.afil_numero = afi.afil_numero AND NOT(familiar.afil_numero_familiar = 01) AND NOT(afi.afil_codigo_persona = familiar.afil_codigo_persona)) as cantidadFamiliares, planes.* from ESE_CU_ELE.Persona pers join ESE_CU_ELE.Afiliado afi on pers.pers_codigo = afi.afil_codigo_persona join ESE_CU_ELE.Planes planes on afi.afil_codigo_plan = planes.plan_codigo " + where;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                Afiliado afiliado = new Afiliado();
                afiliado.codigoPersona = (decimal)reader["afil_codigo_persona"];
                afiliado.numeroAfiliado = (decimal)reader["afil_numero"];
                afiliado.codigoFamiliar = (decimal)reader["afil_numero_familiar"];
                afiliado.nombre = (string)reader["nombre"];
                afiliado.numeroCompleto = afiliado.numeroAfiliado.ToString() + afiliado.codigoFamiliar.ToString();
                afiliado.documento = (string)reader["documento"];
                afiliado.direccion = (string)reader["pers_direccion"];
                afiliado.telefono = (decimal)reader["pers_telefono"];
                afiliado.mail = (string)reader["pers_mail"];
                afiliado.fechaNacimiento = (DateTime)reader["pers_fecha_nacimiento"];
                afiliado.sexo = (string)reader["pers_sexo"];
                afiliado.estadoCivil = (string)reader["afil_estado_civil"];
                afiliado.cantidadFamiliares = (int)reader["cantidadFamiliares"];
                Plan plancito = new Plan();
                plancito.codigo = (decimal)reader["plan_codigo"];
                plancito.descripcion = (string)reader["plan_descripcion"];
                plancito.bonoConsulta = (decimal)reader["plan_bono_consulta"];
                plancito.bonoFarmacia = (decimal)reader["plan_bono_farmacia"];
                afiliado.plan = new Plan();
                afiliado.plan = plancito;
                listaAfiliados.Add(afiliado);
            }
            reader.Close();
            conn.Close();
            return listaAfiliados;
        }
    }
}
