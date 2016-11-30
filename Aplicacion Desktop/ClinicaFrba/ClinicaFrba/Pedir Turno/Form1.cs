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

namespace ClinicaFrba.Pedir_Turno
{
    public partial class Turno : Form
    {
        public Turno()
        {
            InitializeComponent();
        }


        private void Turno_Load(object sender, EventArgs e)
        {
            List<Especialidad> especialidades = especialidadDataAccess.ObtenerEspecialidades("");
            cmbEspecialidad.DataSource = null;
            cmbEspecialidad.Items.Clear();

            cmbEspecialidad.DataSource = especialidades;
            cmbEspecialidad.ValueMember = "espe_codigo";
            cmbEspecialidad.DisplayMember = "espe_descripcion";
           
        }

        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            Especialidad espe = (Especialidad)cmbEspecialidad.SelectedItem;
            List<Profesional> profesionales = profesionalDataAccess.ObtenerProfesionalesXEspecialidad(espe.codigo);
            cmbProfesional.DataSource = null;
            cmbProfesional.Items.Clear();

            cmbProfesional.DataSource = profesionales;
            cmbProfesional.ValueMember = "prof_codigo_persona";
            cmbProfesional.DisplayMember = "nombre";
        }

        private void cmbProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Calendario_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
