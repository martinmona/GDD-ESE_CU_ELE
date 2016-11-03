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

namespace ClinicaFrba.Abm_Rol
{
    public partial class SeleccionFuncionalidades : Form
    {

        List<IlanFuncionalidad> funcionalidadesElegidas;
        public SeleccionFuncionalidades(List<IlanFuncionalidad> funcionalidadesEle)
        {
            InitializeComponent();

            if (funcionalidadesEle.Count > 0)
            {
                funcionalidadesElegidas = funcionalidadesEle;
            }
            else
            {
                funcionalidadesElegidas = new List<IlanFuncionalidad>();
            }
        }

        private void dataGridRol_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SeleccionFuncionalidades_Load(object sender, EventArgs e)
        {
            List<IlanFuncionalidad> funcionalidades = funcionalidadDataAccess.obtenerFuncionalidadesFiltradas("");
            if (funcionalidadesElegidas.Count > 0)
            {
                foreach (IlanFuncionalidad func in funcionalidades)
                {
                    if (funcionalidadesElegidas.Exists(x => x.id == func.id))
                    {
                        funcionalidades.Remove(func);
                    }
                }
            }

            dataGridFunc.DataSource = funcionalidades;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string desc = txtFunc.Text;

            string where = "where func_descripcion LIKE '%" + desc + "%'";
            if (id != "")
            {
                where = where + "AND func_codigo = " + id;
            }

           List<IlanFuncionalidad> funcionalidades = funcionalidadDataAccess.obtenerFuncionalidadesFiltradas(where);
           if (funcionalidadesElegidas.Count > 0)
           {
               foreach (IlanFuncionalidad func in funcionalidades)
               {
                   if (funcionalidadesElegidas.Exists(x => x.id == func.id))
                   {
                       funcionalidades.Remove(func);
                   }
               }
           }

           dataGridFunc.DataSource = funcionalidades;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtFunc.Text = "";
            List<IlanFuncionalidad> funcionalidades = funcionalidadDataAccess.obtenerFuncionalidadesFiltradas("");
            dataGridFunc.DataSource = funcionalidades;
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
