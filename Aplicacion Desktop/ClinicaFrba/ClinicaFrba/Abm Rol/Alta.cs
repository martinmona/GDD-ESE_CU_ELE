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
    public partial class Alta : Form
    {
        public Alta()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            List<Funcionalidad> listaFunc = (List<Funcionalidad>)dataGridFun.DataSource;
            Abm_Rol.SeleccionFuncionalidades testDialog = new Abm_Rol.SeleccionFuncionalidades(listaFunc);

            testDialog.ShowDialog();

            if (testDialog.dataGridFunc.SelectedRows.Count == 1)
            {
                Funcionalidad selected = (Funcionalidad)testDialog.dataGridFunc.SelectedRows[0].DataBoundItem;
                listaFunc.Add(selected);
                dataGridFun.DataSource=listaFunc;
            }
           
            testDialog.Dispose();
            
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Alta_Load(object sender, EventArgs e)
        {
            List<Funcionalidad> listaFunc = new List<Funcionalidad>();
            dataGridFun.DataSource = listaFunc;
            List<Funcionalidad> funcionalidades = funcionalidadDataAccess.obtenerFuncionalidadesFiltradas("");
            dataGridFun.DataSource = funcionalidades;
        }
    }
}
