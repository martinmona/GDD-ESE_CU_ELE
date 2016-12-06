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
using ClinicaFrba.Config;
using System.Data.SqlClient;
using ClinicaFrba.DataAccess;

namespace ClinicaFrba.Registro_Llegada
{
    public partial class frmRegistroLlegada : Form
    {
        
        bool habilitaEventocb;
        public frmRegistroLlegada()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Now;
            List<Especialidad> especialidades = especialidadDataAccess.ObtenerEspecialidades("");

            ActualizarComboBoxEsp(especialidades);
            List<Profesional> profesionales = profesionalDataAccess.ObtenerProfesionalesXEspecialidad(((Especialidad)cbEspecialidadProfesional.SelectedItem).codigo);
            ActualizarComboBoxProf(profesionales);

            habilitaEventocb = true;
        }

        private void cbNombreProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (habilitaEventocb)
            {
                habilitaEventocb = false;

                ActualizarGrillaTurnos(turnoDataAccess.obtenerTurnosxFecha(dtpFecha.Value, (decimal)cbEspecialidadProfesional.SelectedValue,(decimal)cbNombreProfesional.SelectedValue));

                habilitaEventocb = true;
            }

        }

        private void ActualizarComboBoxProf(List<Profesional> profesionales)
        {
            cbNombreProfesional.DataSource = null;
            cbNombreProfesional.Items.Clear();

            cbNombreProfesional.DataSource = profesionales;
            cbNombreProfesional.ValueMember = "codigoPersona";
            cbNombreProfesional.DisplayMember = "nombre";

        }
        private void ActualizarComboBoxEsp(List<Especialidad> especialidades)
        {
            cbEspecialidadProfesional.DataSource = null;
            cbEspecialidadProfesional.Items.Clear();

            cbEspecialidadProfesional.DataSource = especialidades;
            cbEspecialidadProfesional.ValueMember = "codigo";
            cbEspecialidadProfesional.DisplayMember = "descripcion";

        }

        private void cbEspecialidadProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (habilitaEventocb)
            {
                habilitaEventocb = false;
                List<Profesional> profesionales = profesionalDataAccess.ObtenerProfesionalesXEspecialidad(((Especialidad)cbEspecialidadProfesional.SelectedItem).codigo);
                ActualizarComboBoxProf(profesionales);
                ActualizarGrillaTurnos(turnoDataAccess.obtenerTurnosxFecha(dtpFecha.Value, (decimal)cbEspecialidadProfesional.SelectedValue, (decimal)cbNombreProfesional.SelectedValue));
                habilitaEventocb = true;
            }
        }

        private void dgvTurnos_DoubleClick(object sender, EventArgs e)
        {
            Turno turnoElegido = (Turno)dgvTurnos.SelectedRows[0].DataBoundItem;
            DialogResult dialogResult = MessageBox.Show("¿Desea marcar la llegada del afiliado "+ turnoElegido.afiliadoNombre, "Registrar Llegada", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                
            }
        }

        private void ActualizarGrillaTurnos(List<Turno> turnos)
        {
            dgvTurnos.Columns.Clear();
            dgvTurnos.AutoGenerateColumns = false;

            dgvTurnos.DataSource = turnos;
            

            DataGridViewTextBoxColumn codigoTurno = new DataGridViewTextBoxColumn();
            codigoTurno.DataPropertyName = "codigo";
            codigoTurno.HeaderText = "Codigo";
            codigoTurno.Width = 100;
            codigoTurno.ReadOnly = true;
            
            DataGridViewTextBoxColumn fecha = new DataGridViewTextBoxColumn();
            fecha.DefaultCellStyle.Format = "HH:mm";
            fecha.DataPropertyName = "fecha";
            fecha.HeaderText = "Hora";
            fecha.Width = 100;
            fecha.ReadOnly = true;
            
            DataGridViewTextBoxColumn afiliadoNombre = new DataGridViewTextBoxColumn();
            afiliadoNombre.DataPropertyName = "afiliadoNombre";
            afiliadoNombre.HeaderText = "Nombre Afiliado";
            afiliadoNombre.Width = 100;
            afiliadoNombre.ReadOnly = true;

            DataGridViewTextBoxColumn afiliadoNumero = new DataGridViewTextBoxColumn();
            afiliadoNumero.DataPropertyName = "afiliadoNumeroCompleto";
            afiliadoNumero.HeaderText = "Numero Afiliado";
            afiliadoNumero.Width = 100;
            afiliadoNumero.ReadOnly = true; 
            
            dgvTurnos.Columns.Add(codigoTurno);
            dgvTurnos.Columns.Add(fecha);
            dgvTurnos.Columns.Add(afiliadoNombre);
            dgvTurnos.Columns.Add(afiliadoNumero);
            dgvTurnos.AutoResizeColumns();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (habilitaEventocb)
            {
                habilitaEventocb = false;

                ActualizarGrillaTurnos(turnoDataAccess.obtenerTurnosxFecha(dtpFecha.Value, (decimal)cbEspecialidadProfesional.SelectedValue, (decimal)cbNombreProfesional.SelectedValue));

                habilitaEventocb = true;
            }
        }
    }
}
