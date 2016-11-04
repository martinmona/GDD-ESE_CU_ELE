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
        private decimal idRol;
        public FrmFuncionalidad(decimal idRolLoc)
        {
            idRol = idRolLoc;
            InitializeComponent();
        }



        private void Funcionalidad_Load(object sender, EventArgs e)
        {
            List<Funcionalidad> funcionalidades = funcionalidadDataAccess.obtenerFuncionalidadesPorRol(idRol);
            cmbFuncionalidades.DataSource = funcionalidades;
            cmbFuncionalidades.DisplayMember = "descripcion";
            cmbFuncionalidades.ValueMember = "codigo";
            cmbFuncionalidades.Focus();
        }

        private void btnFunc_Click(object sender, EventArgs e)
        {
            irAFuncionalidad((decimal)cmbFuncionalidades.SelectedValue);
        }

        private void irAFuncionalidad(decimal idFunc)
        {
            switch (idFunc.ToString())
            {
                case "1":
                    AbmRol.Listado formRol = new AbmRol.Listado();
                    formRol.Show();
                    break;
                case "3":
                    Abm_Afiliado.Listado formAfi = new Abm_Afiliado.Listado();
                    formAfi.Show();
                    break;
            }
        }
    }
}
