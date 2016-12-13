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
namespace ClinicaFrba.AbmRol
{
    public partial class Listado : Form
    {
        public Listado()
        {
            InitializeComponent();
        }
        private void Listado_Load(object sender, EventArgs e)
        {
            List<Rol> roles = rolDataAccess.ObtenerRoles("");
            dataGridRol.DataSource = roles;
            comboBox1.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNombre.Text = "";
            comboBox1.Text = "";
            List<Rol> roles = rolDataAccess.ObtenerRoles("");
            dataGridRol.DataSource = roles;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            filtrar();
        }
        private void filtrar()
        {
            string id = txtId.Text;
            string nombre = txtNombre.Text;
            string habilitado = comboBox1.Text;
            int hab = 0;
            if (habilitado == "Si")
            {
                hab = 1;
            }
            else if (habilitado == "No")
            {
                hab = 0;
            }
            else
            {
                hab = -1;
            }


            string where = "where rol_nombre LIKE '%" + nombre + "%'";
            if (id != "")
            {
                where = where + "AND rol_codigo = " + id;
            }
            if (hab != -1)
            {
                where = where + "AND rol_habilitado = " + hab.ToString();
            }

            

          
            List<Rol> roles = rolDataAccess.ObtenerRoles(where);
            dataGridRol.DataSource = roles;
        }


        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            Abm_Rol.Alta formAlta = new Abm_Rol.Alta();
            formAlta.Show();
            this.Hide();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            decimal selected = (decimal)dataGridRol.SelectedRows[0].Cells[0].Value;
            bool habilitado = (bool)dataGridRol.SelectedRows[0].Cells[2].Value;
            if (!habilitado)
            {
                MessageBox.Show("El rol ya esta eliminado logicamente");
                return;
            }
            if (rolDataAccess.EliminarRol(selected))
            {
                MessageBox.Show("Se deshabilito el rol seleccionado correctamente");
                filtrar();
            }
            else
            {
                MessageBox.Show("Fallo la conexion a la BD", "Error");
            }
        }

        private void checkHab_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            Rol selected = (Rol)dataGridRol.SelectedRows[0].DataBoundItem;
            Abm_Rol.Modificacion modificacion = new Abm_Rol.Modificacion(selected);
            modificacion.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
