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

        List<Funcionalidad> funcionalidadesElegidas;
        public SeleccionFuncionalidades(List<Funcionalidad> funcionalidadesEle)
        {
            InitializeComponent();

            if (funcionalidadesEle.Count > 0)
            {
                funcionalidadesElegidas = funcionalidadesEle;
            }
            else
            {
                funcionalidadesElegidas = new List<Funcionalidad>();
            }
        }

        private void dataGridRol_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SeleccionFuncionalidades_Load(object sender, EventArgs e)
        {
            foreach (Funcionalidad func in funcionalidadesElegidas)
            {
                MessageBox.Show(func.descripcion);
            }
            List<Funcionalidad> funcionalidades = funcionalidadDataAccess.obtenerFuncionalidadesFiltradas("");
            if (funcionalidadesElegidas.Count > 0)
            {
                foreach (Funcionalidad func in funcionalidades)
                {
                    if (funcionalidadesElegidas.Exists(x => x.codigo == func.codigo))
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

            List<Funcionalidad> funcionalidades = funcionalidadDataAccess.obtenerFuncionalidadesFiltradas(where);
           if (funcionalidadesElegidas.Count > 0)
           {
               foreach (Funcionalidad func in funcionalidades)
               {
                   if (funcionalidadesElegidas.Exists(x => x.codigo == func.codigo))
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
            List<Funcionalidad> funcionalidades = funcionalidadDataAccess.obtenerFuncionalidadesFiltradas("");
            dataGridFunc.DataSource = funcionalidades;
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
