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
            MiComando.CommandText = "SELECT usua_habilitado,pers_tipo_documento,pers_numero_documento,pers_nombre, pers_apellido, pers_nombre + ' ' + pers_apellido as nombre, CONCAT(pers_tipo_documento, ' ',pers_numero_documento) as documento,pers_direccion, pers_telefono, pers_mail, pers_fecha_nacimiento, pers_sexo,  afi.afil_numero,afi.afil_numero_familiar,afi.afil_codigo_persona,afi.afil_estado_civil,(SELECT COUNT(DISTINCT familiar.afil_codigo_persona) FROM ESE_CU_ELE.Afiliado familiar WHERE familiar.afil_numero = afi.afil_numero AND NOT(familiar.afil_numero_familiar = 01) AND (afi.afil_numero_familiar = 01) AND NOT(afi.afil_codigo_persona = familiar.afil_codigo_persona)) as cantidadFamiliares, planes.* from ESE_CU_ELE.Persona pers join ESE_CU_ELE.Afiliado afi on pers.pers_codigo = afi.afil_codigo_persona join ESE_CU_ELE.Planes planes on afi.afil_codigo_plan = planes.plan_codigo join ESE_CU_ELE.Usuario on afi.afil_codigo_persona = usua_codigo " + where;
            SqlDataReader reader = MiComando.ExecuteReader();
            while (reader.Read())
            {
                Afiliado afiliado = new Afiliado();
                afiliado.codigoPersona = (decimal)reader["afil_codigo_persona"];
                bool habi = (bool)reader["usua_habilitado"];
                if (habi == true)
                {
                    afiliado.habilitado = "True";
                }
                else
                {
                    afiliado.habilitado = "False";
                }
                afiliado.numeroAfiliado = (decimal)reader["afil_numero"];
                afiliado.codigoFamiliar = (decimal)reader["afil_numero_familiar"];
                afiliado.nombreCompleto = (string)reader["nombre"];
                afiliado.nombre = (string)reader["pers_nombre"];
                afiliado.apellido = (string)reader["pers_apellido"];
                afiliado.numeroCompleto = afiliado.numeroAfiliado.ToString() + afiliado.codigoFamiliar.ToString();
                afiliado.documento = (string)reader["documento"];
                afiliado.numeroDocumento = (decimal)reader["pers_numero_documento"];
                afiliado.tipoDocumento = (string)reader["pers_tipo_documento"];
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

        public static List<Plan> ObtenerPlanes()
        {
            List<Plan> listaPlanes = new List<Plan>();
            SqlConnection conn = conectar();
            SqlCommand MiComando = new SqlCommand();
            MiComando.Connection = conn;
            MiComando.CommandText = "Select * from ESE_CU_ELE.Planes ";
            SqlDataReader reader = MiComando.ExecuteReader();

            Plan plan1 = new Plan();
            plan1.codigo = 00000;
            plan1.descripcion = "";
            listaPlanes.Add(plan1);
            while (reader.Read())
            {
                Plan plan = new Plan();
                plan.codigo= (decimal)reader["plan_codigo"];
                plan.descripcion = (string)reader["plan_descripcion"];
                listaPlanes.Add(plan);
            }
            reader.Close();
            conn.Close();
            return listaPlanes;
        }

        public static bool AgregarAfiliado(Afiliado afiliado,decimal numeroFamilia,decimal codigoPers)
        {
            try
            {
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.CommandText = "insert into ESE_CU_ELE.Persona(pers_nombre,pers_apellido,pers_sexo,pers_fecha_nacimiento,pers_tipo_documento,pers_numero_documento,pers_mail,pers_direccion,pers_telefono,pers_tipo) VALUES('" + afiliado.nombre + "','" + afiliado.apellido + "','" + afiliado.sexo + "','" + afiliado.fechaNacimiento.ToString() + "','" + afiliado.tipoDocumento + "'," + afiliado.numeroDocumento.ToString() + ",'" + afiliado.mail + "','" + afiliado.direccion + "',"+afiliado.telefono.ToString()+",'Afiliado')";
                MiComando.ExecuteNonQuery();
                decimal codigoPersona;
                decimal codigoAfiliado;
                codigoPersona = obtenerCodigoPersona();
                if (numeroFamilia == 1)
                {
                    codigoAfiliado = codigoPersona;
                }
                else
                {
                    codigoAfiliado = codigoPers;
                }
                MiComando.CommandText = "INSERT INTO ESE_CU_ELE.Afiliado(afil_codigo_persona,afil_estado_civil,afil_numero,afil_numero_familiar,afil_codigo_plan) VALUES(" + codigoPersona.ToString() + ",'" + afiliado.estadoCivil + "'," + codigoAfiliado.ToString() + "," + numeroFamilia.ToString() + "," + afiliado.plan.codigo.ToString() + ")";
                MiComando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }

        
        public static decimal obtenerCodigoPersona()
        {
            decimal codigo = -1;
            try
            {
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.CommandText = "SELECT MAX(pers_codigo) as maxim from ESE_CU_ELE.Persona";
                codigo = (decimal)MiComando.ExecuteScalar();
                conn.Close();
            }
            catch
            {
            }
            return codigo;
        }

        public static decimal obtenerUltimoCodigoFamilia(decimal codigoGral)
        {
            decimal codigo = -1;
            try
            {
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.CommandText = "SELECT MAX(afil_numero_familiar) as maximo FROM ESE_CU_ELE.Afiliado WHERE afil_numero ="+codigoGral.ToString();
                codigo = (decimal)MiComando.ExecuteScalar();
                conn.Close();
            }
            catch
            {
            }
            return codigo;
        }
        public static decimal obtenerUltimoCodigoAfiliado()
        {
            decimal codigo = -1;
            try
            {
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.CommandText = "SELECT MAX(afil_numero) as maximo FROM ESE_CU_ELE.Afiliado";
                codigo = (decimal)MiComando.ExecuteScalar();
                conn.Close();
            }
            catch
            {
            }
            return codigo;
        }



        public static bool modificarAfiliado(decimal codigo, decimal telefono, string mail,string estadoCivil,string direccion,string sexo,decimal codigoPlan)
        {
            try
            {
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.CommandText = "UPDATE ESE_CU_ELE.Persona SET pers_sexo = '" + sexo + "', pers_mail = '" + mail + "',pers_direccion = '" + direccion + "',pers_telefono =" + telefono.ToString() + " where pers_codigo ="+codigo.ToString();
                MiComando.ExecuteNonQuery();
                MiComando.CommandText = "UPDATE ESE_CU_ELE.Afiliado set afil_estado_civil = '" + estadoCivil + "', afil_codigo_plan = " + codigoPlan.ToString() + " where afil_codigo_persona ="+ codigo.ToString();
                MiComando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }

          public static bool agregarModificacion(decimal codigoPersona,string motivo,decimal planViejo)
        {
            try
            {
                SqlConnection conn = conectar();
                SqlCommand MiComando = new SqlCommand();
                MiComando.Connection = conn;
                MiComando.CommandText = " INSERT INTO ESE_CU_ELE.Modificacion(modi_afiliado,modi_fecha,modi_motivo,modi_plan_viejo) VALUES(" + codigoPersona.ToString() + ",GETDATE(),'" + motivo + "'," + planViejo.ToString() + ")";
                MiComando.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }


          public static List<Modificacion> obtenerModificaciones(decimal codigoPers)
          {
              List<Modificacion> listaModificaciones = new List<Modificacion>();
              SqlConnection conn = conectar();
              SqlCommand MiComando = new SqlCommand();
              MiComando.Connection = conn;
              MiComando.CommandText = "select modi.*, plan_descripcion from ESE_CU_ELE.Modificacion as modi join ESE_CU_ELE.Planes on modi_plan_viejo = plan_codigo where modi_afiliado = " + codigoPers.ToString();
              SqlDataReader reader = MiComando.ExecuteReader();
              while (reader.Read())
              {
                  Modificacion modificacion = new Modificacion();

                  modificacion.afiliado = codigoPers;
                    modificacion.fecha = (DateTime)reader["modi_fecha"];
                  modificacion.motivo = (string)reader["modi_motivo"];
                  modificacion.planAntiguo= (string)reader["plan_descripcion"];
                  listaModificaciones.Add(modificacion);
              }
              reader.Close();
              conn.Close();
              return listaModificaciones;
          }

       
    }
}
