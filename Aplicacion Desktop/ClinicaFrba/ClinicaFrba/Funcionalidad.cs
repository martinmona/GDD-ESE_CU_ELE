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
            cmbFuncionalidades.ValueMember = "id";
            cmbFuncionalidades.Focus();
        }

        private void btnFunc_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cmbFuncionalidades.Text);
        }
    }
}
