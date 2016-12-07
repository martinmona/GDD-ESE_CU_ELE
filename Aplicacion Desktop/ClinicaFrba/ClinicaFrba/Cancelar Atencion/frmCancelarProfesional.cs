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

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class frmCancelarProfesional : Form
    {
        private Profesional _profesional;
        public frmCancelarProfesional(Profesional unProf)
        {
            InitializeComponent();
            _profesional = unProf;
            lblPersona.Text = "TURNOS DEL MEDICO: "+_profesional.nombre;
        }

        private void frmCancelarProfesional_Load(object sender, EventArgs e)
        {
            checkRango.Checked = false;
            dtpHasta.Enabled = false;
            dtpDesde.MinDate = DateTime.Now.AddDays(1);
            dtpDesde.Value= DateTime.Now.AddDays(1);
            ActualizarComboBoxTipos(cancelacionDataAccess.ObtenerTipoCancelacion());

        }
        private void ActualizarComboBoxTipos(List<TipoCancelacion> tipos)
        {

            cbTipo.DataSource = null;
            cbTipo.Items.Clear();

            cbTipo.DataSource = tipos;
            cbTipo.ValueMember = "codigo";
            cbTipo.DisplayMember = "descripcion";

        }

        private void checkRango_CheckedChanged(object sender, EventArgs e)
        {
            if (checkRango.Checked)
            {
                dtpHasta.Enabled = true;
            }
            else
            {
                dtpHasta.Enabled = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
