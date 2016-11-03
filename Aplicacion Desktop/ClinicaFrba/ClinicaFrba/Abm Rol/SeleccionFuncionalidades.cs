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
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            if (funcionalidadesElegidas.Count > 0)
            {
                string whereNotInFunc = crearFiltroNotIn();
                funcionalidades = funcionalidadDataAccess.obtenerFuncionalidadesFiltradas(whereNotInFunc);
            }
            else
            {
                funcionalidades = funcionalidadDataAccess.obtenerFuncionalidadesFiltradas("");
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

           
           if (funcionalidadesElegidas.Count > 0)
           {
               where += "AND func_codigo NOT IN (";
               foreach (Funcionalidad func in funcionalidadesElegidas)
               {
                   where += func.codigo.ToString() + ", ";
               }
               where = where.Substring(0, where.Length - 2);
               where += ")";
           }

           List<Funcionalidad> funcionalidades = funcionalidadDataAccess.obtenerFuncionalidadesFiltradas(where);
           dataGridFunc.DataSource = funcionalidades;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtFunc.Text = "";
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            if (funcionalidadesElegidas.Count > 0)
            {
                string whereNotInFunc = crearFiltroNotIn();
                funcionalidades = funcionalidadDataAccess.obtenerFuncionalidadesFiltradas(whereNotInFunc);
            }
            else
            {
                funcionalidades = funcionalidadDataAccess.obtenerFuncionalidadesFiltradas("");
            }
            dataGridFunc.DataSource = funcionalidades;
            txtId.Focus();
        }

        private string crearFiltroNotIn()
        {
            string whereNotInFunc = "WHERE func_codigo NOT IN (";
            foreach (Funcionalidad func in funcionalidadesElegidas)
            {
                whereNotInFunc += func.codigo.ToString() + ", ";
            }
            whereNotInFunc = whereNotInFunc.Substring(0, whereNotInFunc.Length - 2);
            whereNotInFunc += ")";
            return whereNotInFunc;
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtFunc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
