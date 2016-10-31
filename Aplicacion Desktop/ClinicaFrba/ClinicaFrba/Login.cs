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

namespace ClinicaFrba
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                MessageBox.Show("Debe ingresar su nombre de usuario");
            }
            if (txtpass.Text == "")
            {
                MessageBox.Show("Debe ingresar su clave");
            }

            if (txtuser.Text != "" && txtpass.Text != "")
            {
                Usuario myuser = usuarioDataAccess.login(txtuser.Text, txtpass.Text);
                if (myuser.id == -1)
                {
                    MessageBox.Show("El usuario y contraseña no coinciden. Vuelva a intentarlo", "Error");
                }
                else
                {
                    MessageBox.Show("El id = " + myuser.id);
                }
            }
            else
            {
                MessageBox.Show("El usuario y contraseña no coinciden. Vuelva a intentarlo", "Error");
                txtuser.Text = "";
                txtpass.Text = "";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
