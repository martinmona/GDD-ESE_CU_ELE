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

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class frmCancelar : Form
    {
        public frmCancelar(Persona unaPersona)
        {
            InitializeComponent();
            if (unaPersona.GetType() == typeof(Afiliado))
            {
                Afiliado unAfiliado = (Afiliado)unaPersona;
                frmCancelarAfiliado formCancelarAfiliado = new frmCancelarAfiliado(unAfiliado);
                formCancelarAfiliado.Show();
            }
            else if(unaPersona.GetType() == typeof(Profesional))
            {
                Profesional unProfesional = (Profesional)unaPersona;
                frmCancelarProfesional formCancelarProfesional = new frmCancelarProfesional(unProfesional);
                formCancelarProfesional.Show();
            }
            this.Close();
        }
        private void frmCancelar_Load(object sender, EventArgs e)
        {
        }
    }
}
