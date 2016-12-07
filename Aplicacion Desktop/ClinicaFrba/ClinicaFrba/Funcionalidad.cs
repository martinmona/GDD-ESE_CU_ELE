using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Class;
using ClinicaFrba.DataAccess;
namespace ClinicaFrba
{
    public partial class FrmFuncionalidad : Form
    {
        private decimal idRol, _idUsuario;
        private Persona unaPersona;
        
        public FrmFuncionalidad(decimal idRolLoc, decimal idUsuario)
        {
            _idUsuario = idUsuario;
            switch(personaDataAccess.ObtenerTipoPersona(idUsuario))
            {
                case "Afiliado":
                    unaPersona = new Afiliado();
                    unaPersona = afiliadoDataAccess.ObtenerAfiliados("where afil_codigo_persona = " + idUsuario)[0];
                    break;
                case "Profesional":
                    unaPersona = new Profesional();
                    unaPersona = profesionalDataAccess.ObtenerProfesionales("where prof_codigo_persona =" + idUsuario)[0];
                    break;
                case "Admin":
                    unaPersona = new Administrador();
                    unaPersona.codigoPersona = idUsuario;
                    unaPersona.nombre = "Admin";
                    break;
            }
            

            idRol = idRolLoc;
            InitializeComponent();
        }



        private void Funcionalidad_Load(object sender, EventArgs e)
        {
           
            System.Console.WriteLine("entro");
            List<Funcionalidad> funcionalidades = funcionalidadDataAccess.obtenerFuncionalidadesPorRol(idRol);
            cmbFuncionalidades.DataSource = funcionalidades;
            cmbFuncionalidades.DisplayMember = "descripcion";
            cmbFuncionalidades.ValueMember = "codigo";
            cmbFuncionalidades.Focus();
        }

        private void btnFunc_Click(object sender, EventArgs e)
        {
            try
            {

                irAFuncionalidad((decimal)cmbFuncionalidades.SelectedValue);
            }
            catch
            {
                MessageBox.Show("Se produjo un error","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Login lgn = new Login();
            lgn.Show();
            this.Close();
        }

        private void irAFuncionalidad(decimal idFunc)
        {
            switch (idFunc.ToString())
            {
                case "1":
                    AbmRol.Listado formRol = new AbmRol.Listado();
                    formRol.ShowDialog();
                    break;
                case "3":
                    Abm_Afiliado.Listado formAfi = new Abm_Afiliado.Listado();
                    formAfi.ShowDialog();
                    break;
                case "7":
                    Registrar_Agenta_Medico.RegistrarAgenda formRegAg= new Registrar_Agenta_Medico.RegistrarAgenda();
                    formRegAg.ShowDialog();
                    break;
                case "8":
                    Compra_Bono.frmCompraBono formCompraBono = new Compra_Bono.frmCompraBono(unaPersona);
                    formCompraBono.ShowDialog();
                    break;
                case "10":
                    Registro_Llegada.frmRegistroLlegada formRegistroLlegada = new Registro_Llegada.frmRegistroLlegada();
                    formRegistroLlegada.ShowDialog();
                    break;
                default:
                    MessageBox.Show("Funcionalidad no implementada","INFO",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    break;
            }
        }
    }
}
