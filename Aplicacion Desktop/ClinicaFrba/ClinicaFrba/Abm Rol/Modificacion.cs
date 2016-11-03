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
    public partial class Modificacion : Form
    {
        List<Funcionalidad> listaFuncionalidades;
        Rol rol;
        public Modificacion(Rol rolModificar)
        {
            InitializeComponent();
            rol = rolModificar;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Modificacion_Load(object sender, EventArgs e)
        {
            listaFuncionalidades = funcionalidadDataAccess.obtenerFuncionalidadesPorRol(rol.codigo);
            txtNom.Text = rol.nombre;
            if (rol.habilitado)
            {
                checkHab.Visible = false;
                checkHab.Checked = true;
            }
            else
            {
                checkHab.Checked = false;
            }
            dataGridFun.DataSource = listaFuncionalidades;
        }

        private void refrescarDataGrid()
        {
            List<Funcionalidad> listaFuncionalidadesNew = new List<Funcionalidad>();//CREO NUEVA LISTA PQ NO DEJA ASIGNAR LA LISTA GLOBAL A LA DATAGRID
            foreach (Funcionalidad fun in listaFuncionalidades)
            {
                listaFuncionalidadesNew.Add(fun);
            }
            dataGridFun.DataSource = listaFuncionalidadesNew;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Abm_Rol.SeleccionFuncionalidades testDialog = new Abm_Rol.SeleccionFuncionalidades(listaFuncionalidades);
            testDialog.ShowDialog();

            if (testDialog.dataGridFunc.SelectedRows.Count == 1)
            {
                Funcionalidad selected = (Funcionalidad)testDialog.dataGridFunc.SelectedRows[0].DataBoundItem;
                listaFuncionalidades.Add(selected);
                refrescarDataGrid();
            }
            testDialog.Dispose(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Funcionalidad selected = (Funcionalidad)dataGridFun.SelectedRows[0].DataBoundItem;
            listaFuncionalidades.Remove(selected);
            refrescarDataGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listaFuncionalidades.Clear();
            refrescarDataGrid();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            listaFuncionalidades.Clear();
            refrescarDataGrid();
            txtNom.Text = "";
            txtNom.Focus();
        }

        private void btnAg_Click(object sender, EventArgs e)
        {
            if (txtNom.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre", "error");
            }
            else
            {
                if (listaFuncionalidades.Count < 1)
                {
                    MessageBox.Show("Debe tener seleccionada al menos una funcionalidad", "error");
                }
                else
                {
                    int hab = 0;
                    if (checkHab.Visible == true)
                    {
                        hab = 1;
                    }
                    if (rolDataAccess.ModificarRol(rol.codigo,txtNom.Text, listaFuncionalidades, hab))
                    {
                        AbmRol.Listado listado = new AbmRol.Listado();
                        listado.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Fallo la conexion a la BD", "Error");

                    }

                }
            }
        }

        private void btnRet_Click(object sender, EventArgs e)
        {
            AbmRol.Listado listado = new AbmRol.Listado();
            listado.Show();
            this.Hide();
        }
    }
}
