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
using ClinicaFrba.Config;

namespace ClinicaFrba.Registro_Resultado
{
    public partial class frmElegirTurno : Form
    {
        private bool cargando,cambiaProf;
        private Profesional _profesional;
        public frmElegirTurno(Persona elProf)
        {
            InitializeComponent();
            cargando = true;
            cambiaProf = false;
            //VERIFICO SI LA PERSONA QUE ACCEDIO ES UN PROFESIONAL. SI NO SE DA A ELEGIR EL PROFESIONAL QUE SE DESEA
            if (elProf.GetType() == typeof(Profesional))
            {
                _profesional = (Profesional)elProf;
                cbProfesionales.Visible = false;
                lblCBProf.Visible = false;
                lblProf.Visible = true;
            }
            else //ACCEDIO UN AFILIADO O ADMINISTRADOR
            {
                List<Profesional> profesionales = profesionalDataAccess.ObtenerProfesionales("");
                ActualizarComboBoxProf(profesionales);
                _profesional = (Profesional)cbProfesionales.SelectedItem;
                cbProfesionales.Visible = true;
                lblCBProf.Visible = true;
                lblProf.Visible = false;
            }
            
            //CARGA LAS ESPECIALIDADES DEL PROFESIONAL
            dtpFecha.Value = BD.obtenerFecha();
            List<Especialidad> especialidades = especialidadDataAccess.ObtenerEspecialidadesXProfesional(_profesional.codigoPersona);
            ActualizarComboBoxEsp(especialidades);
            lblProf.Text = "Turnos del profesional: "+_profesional.nombre;
            ActualizarGrillaTurnos(turnoDataAccess.obtenerTurnosxFecha(dtpFecha.Value, (decimal)cbEspecialidad.SelectedValue, _profesional.codigoPersona, "and turn_estado = 'Esperando'"));
            cargando = false;
        }
        private void ActualizarComboBoxProf(List<Profesional> profesionales)
        {
            cbProfesionales.DataSource = null;
            cbProfesionales.Items.Clear();

            cbProfesionales.DataSource = profesionales;
            cbProfesionales.ValueMember = "codigoPersona";
            cbProfesionales.DisplayMember = "nombre";

        }
        private void frmElegirTurno_Load(object sender, EventArgs e)
        {

        }
        private void ActualizarComboBoxEsp(List<Especialidad> especialidades)
        {
            cbEspecialidad.DataSource = null;
            cbEspecialidad.Items.Clear();

            cbEspecialidad.DataSource = especialidades;
            cbEspecialidad.ValueMember = "codigo";
            cbEspecialidad.DisplayMember = "descripcion";

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

            DataGridViewTextBoxColumn estado = new DataGridViewTextBoxColumn();
            estado.DataPropertyName = "estado";
            estado.HeaderText = "Estado";
            estado.Width = 100;
            estado.ReadOnly = true;

            dgvTurnos.Columns.Add(codigoTurno);
            dgvTurnos.Columns.Add(fecha);
            dgvTurnos.Columns.Add(afiliadoNombre);
            dgvTurnos.Columns.Add(afiliadoNumero);
            dgvTurnos.Columns.Add(estado);
            dgvTurnos.AutoResizeColumns();
        }

        private void cbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!cargando && !cambiaProf)
                ActualizarGrillaTurnos(turnoDataAccess.obtenerTurnosxFecha(dtpFecha.Value, (decimal)cbEspecialidad.SelectedValue, _profesional.codigoPersona, "and turn_estado = 'Esperando'"));
        }

        private void dgvTurnos_DoubleClick(object sender, EventArgs e)
        {
            if (dgvTurnos.SelectedRows.Count > 0)
            {
                Turno turnoElegido = (Turno)dgvTurnos.SelectedRows[0].DataBoundItem;

                DialogResult dialogResult = MessageBox.Show("¿Desea atender al afiliado " + turnoElegido.afiliadoNombre, "Resultados de Atencion", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    frmResultados formResultado = new frmResultados(turnoElegido);
                    formResultado.ShowDialog(this);
                    ActualizarGrillaTurnos(turnoDataAccess.obtenerTurnosxFecha(dtpFecha.Value, (decimal)cbEspecialidad.SelectedValue, _profesional.codigoPersona, "and turn_estado = 'Esperando'"));

                }
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (!cargando)
                ActualizarGrillaTurnos(turnoDataAccess.obtenerTurnosxFecha(dtpFecha.Value, (decimal)cbEspecialidad.SelectedValue, _profesional.codigoPersona, "and turn_estado = 'Esperando'"));
        }

        private void cbProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cargando)
            {
                cambiaProf = true;
                _profesional = (Profesional)cbProfesionales.SelectedItem;
                List<Especialidad> especialidades = especialidadDataAccess.ObtenerEspecialidadesXProfesional(_profesional.codigoPersona);
                ActualizarComboBoxEsp(especialidades);
                ActualizarGrillaTurnos(turnoDataAccess.obtenerTurnosxFecha(dtpFecha.Value, (decimal)cbEspecialidad.SelectedValue, _profesional.codigoPersona, "and turn_estado = 'Esperando'"));
                cambiaProf = false;
            }
        }
    }
}
