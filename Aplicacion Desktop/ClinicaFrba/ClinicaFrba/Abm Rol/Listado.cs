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

        }

        private void dataGridRol_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

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
            string id = txtId.Text;
            string nombre = txtNombre.Text;
            bool habilitado = checkHab.Checked;
            int hab = 0;
            if (habilitado == true)
            {
                hab = 1;
            }


            string where = "where rol_nombre LIKE '%" + nombre + "%'";
            if (id != "")
            {
                where = where + "AND rol_codigo = " + id;
            }
            where = where + "AND rol_habilitado = " + hab.ToString();

            MessageBox.Show(where);
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

        private void dataGridRol_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridRol_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          
        }

    }
}
