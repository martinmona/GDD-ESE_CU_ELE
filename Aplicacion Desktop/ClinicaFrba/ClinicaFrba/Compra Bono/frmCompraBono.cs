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

namespace ClinicaFrba.Compra_Bono
{
    public partial class frmCompraBono : Form
    {
        private decimal _idUsuario;
        private Persona _unaPersona;
        public frmCompraBono(Persona laPersona)
        {
            _unaPersona = laPersona;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(_unaPersona.GetType() == typeof(Afiliado))
            {
                MessageBox.Show("es afiliado");
            }else if (_unaPersona.GetType() == typeof(Administrador))
            {
                MessageBox.Show("es administrador");
            }
            else if(_unaPersona.GetType() == typeof(Profesional))
            {
                MessageBox.Show("es profesional");
            }


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
