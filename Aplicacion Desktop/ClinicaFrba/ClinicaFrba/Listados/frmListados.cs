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

namespace ClinicaFrba.Listados
{
    public partial class frmListados : Form
    {
        public frmListados()
        {
            InitializeComponent();
        }

        private void frmListados_Load(object sender, EventArgs e)
        {
            cbListado.SelectedIndex = 0;
            ocultarPlan();
            ocultarEspecialidad();
            dtpMes.Visible = false;
            ActualizarComboBoxPlanes();
        }
        private void ActualizarComboBoxPlanes(List<Plan> tipos)
        {

            cbPlan.DataSource = null;
            cbPlan.Items.Clear();

            cbPlan.DataSource = tipos;
            cbPlan.ValueMember = "codigo";
            cbPlan.DisplayMember = "descripcion";

        }
        private void rbMes_CheckedChanged(object sender, EventArgs e)
        {
            dtpMes.Visible = true;
        }

        private void rbSegundoSemestre_CheckedChanged(object sender, EventArgs e)
        {
            dtpMes.Visible = false;
        }

        private void rdPrimerSemestre_CheckedChanged(object sender, EventArgs e)
        {
            dtpMes.Visible = false;
        }

        private void cbListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbListado.SelectedIndex)
            {
                case 0: //Especialidades con más cancelaciones
                    
                    ocultarEspecialidad();
                    ocultarPlan();
                    break;
                case 1: //Profesionales más consultados
                    
                    ocultarEspecialidad();
                    mostrarPlan();
                    break;
                case 2: //Profesionales con menos horas trabajadas
                    
                    mostrarEspecialidad();
                    ocultarPlan();
                    break;
                case 3: //Afiliados con más bonos comprados
                    
                    ocultarEspecialidad();
                    ocultarPlan();
                    break;
                case 4: //Especialidades con más bonos

                    ocultarEspecialidad();
                    ocultarPlan();
                    break;
            }
        }

        private void ocultarPlan()
        {
            cbPlan.Visible = false;
            lblPlan.Visible = false;
        }
        private void mostrarPlan()
        {
            cbPlan.Visible = true;
            lblPlan.Visible = true;
        }
        private void ocultarEspecialidad()
        {
            cbEspecialidad.Visible = false;
            cbEspecialidad.Visible = false;
        }
        private void mostrarEspecialidad()
        {
            cbEspecialidad.Visible = true;
            cbEspecialidad.Visible = true;
        }
    }
}

