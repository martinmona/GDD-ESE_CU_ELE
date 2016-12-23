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
using ClinicaFrba.DataAccess;

namespace ClinicaFrba.Pedir_Turno
{
    public partial class frmPedirTurno : Form
    {
        private Afiliado _elAfiliado;
        private bool habilitoCargar;
        private bool estoyCargandoTodo;
        public frmPedirTurno(Persona afi)
        {
            InitializeComponent();
            estoyCargandoTodo = true;
            //SI ENTRO UN AFILIADO PEDIRA TURNOS POR EL SOLO. SINO SE DARÁ A ELEGIR EL AFILIADO QUE OBTENDRA EL TURNO
            if (afi.GetType() == typeof(Afiliado))
            {
                _elAfiliado = (Afiliado)afi;
                cbAfiliado.Visible = false;
                lblAfiliado.Visible = false;

            }
            else
            {
                List<Afiliado> listaAfiliados = afiliadoDataAccess.ObtenerAfiliados(" where usua_habilitado=1");
                ActualizarComboBoxAfiliado(listaAfiliados);
                _elAfiliado = (Afiliado)cbAfiliado.SelectedItem;
                cbAfiliado.Visible = true;
                lblAfiliado.Visible = true;
            }
            estoyCargandoTodo = false;
        }
        private void ActualizarComboBoxAfiliado(List<Afiliado> afiliados)
        {
            
            cbAfiliado.DataSource = null;
            cbAfiliado.Items.Clear();

            cbAfiliado.DataSource = afiliados;
            cbAfiliado.ValueMember = "codigoPersona";
            cbAfiliado.DisplayMember = "nombreCompleto";
            
        }

        private void Turno_Load(object sender, EventArgs e)
        {
            estoyCargandoTodo = true;
            List<Especialidad> especialidades = especialidadDataAccess.ObtenerEspecialidades("");
            cmbEspecialidad.DataSource = null;
            cmbEspecialidad.Items.Clear();
            
            cmbEspecialidad.DataSource = especialidades;
            cmbEspecialidad.ValueMember = "codigo";
            cmbEspecialidad.DisplayMember = "descripcion";
            List<Profesional> profesionales = profesionalDataAccess.ObtenerProfesionalesXEspecialidad(((Especialidad)cmbEspecialidad.SelectedItem).codigo);
            actualizarComboBoxProf(profesionales);
            dtpDia.MinDate = BD.obtenerFecha();
            dtpDia.Value = BD.obtenerFecha();
            actualizarGrilla(dtpDia.Value);
            estoyCargandoTodo = false;
        }

        private void actualizarComboBoxProf(List<Profesional> listaProfesionales) 
        {
            cmbProfesional.DataSource = null;
            cmbProfesional.Items.Clear();

            cmbProfesional.DataSource = listaProfesionales;
            cmbProfesional.ValueMember = "codigoPersona";
            cmbProfesional.DisplayMember = "nombre";
        } 

        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            Especialidad espe = (Especialidad)cmbEspecialidad.SelectedItem;
            List<Profesional> profesionales = profesionalDataAccess.ObtenerProfesionalesXEspecialidad(espe.codigo);
            actualizarComboBoxProf(profesionales);
        }

        private void cmbProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        
          private void actualizarGrilla(DateTime fecha)
        {
            List<Turno> listaTurnos = turnoDataAccess.obtenerTurnosxFecha(dtpDia.Value, (decimal)cmbEspecialidad.SelectedValue, (decimal)cmbProfesional.SelectedValue, "and turn_estado not like 'Cancelado'");
            List<Agenda> listaAgendas = agendaDataAccess.ObtenerAgendas((decimal)cmbProfesional.SelectedValue,(decimal)cmbEspecialidad.SelectedValue, dtpDia.Value);
            List<TimeSpan> listaHorariosDisponibles = new List<TimeSpan>();
            //MessageBox.Show("Esp: "+ (decimal)cmbEspecialidad.SelectedValue +" prof: "+ (decimal)cmbProfesional.SelectedValue +" Dia: "+ dtpDia.Value + " Cant turnos: "+listaTurnos.Count +" Cantidad Agendas: "+listaAgendas.Count);
            foreach (Agenda unaAgenda in listaAgendas)
            {
                for (TimeSpan i = unaAgenda.horaInicio; i.CompareTo(unaAgenda.horaFin)<0; i=i.Add(new TimeSpan(0,30,0)))
                {
                    if (i.Minutes == 60)
                    {
                        i.Add(new TimeSpan(1, 0, 0));
                        i.Subtract(new TimeSpan(0, 60, 0));
                    }
                    if(!listaTurnos.Any(x => x.fecha.TimeOfDay == i))
                    {
                        listaHorariosDisponibles.Add(i);
                    }
                }
            }
            dgHorarios.Columns.Clear();
            dgHorarios.AutoGenerateColumns = false;

            dgHorarios.DataSource = listaHorariosDisponibles;
            
            DataGridViewTextBoxColumn horario = new DataGridViewTextBoxColumn();
            //horario.DefaultCellStyle.Format = "HH:mm";
            horario.DataPropertyName = "Hours";
            horario.HeaderText = "Hora";
            horario.Width = 100;
            horario.ReadOnly = true;
            dgHorarios.Columns.Add(horario);
            DataGridViewTextBoxColumn minutos = new DataGridViewTextBoxColumn();
            //horario.DefaultCellStyle.Format = "HH:mm";
            minutos.DataPropertyName = "Minutes";
            minutos.HeaderText = "Minutos";
            minutos.Width = 100;
            minutos.ReadOnly = true;
            dgHorarios.Columns.Add(minutos);
            dgHorarios.AutoResizeColumns();

        }

          private void dataGridTurnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
          {
            
          }

        private void cmbEspecialidad_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            habilitoCargar = false;
            List<Profesional> profesionales = profesionalDataAccess.ObtenerProfesionalesXEspecialidad(((Especialidad)cmbEspecialidad.SelectedItem).codigo);
            actualizarComboBoxProf(profesionales);
            habilitoCargar = true;
            if(!estoyCargandoTodo)
                actualizarGrilla(dtpDia.Value);
        }

        private void cmbProfesional_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(habilitoCargar && !estoyCargandoTodo)
            actualizarGrilla(dtpDia.Value);
        }

        private void Calendario_DateChanged_1(object sender, DateRangeEventArgs e)
        {
            
        }

        private void dtpDia_ValueChanged(object sender, EventArgs e)
        {
            int dia = (int)dtpDia.Value.DayOfWeek;
            switch (dia)
            {
                case 0:
                    MessageBox.Show("No se atiende los dias domingos");
                    break;
                default:
                    if (habilitoCargar && !estoyCargandoTodo)
                        actualizarGrilla(dtpDia.Value);
                    break;
            }
        }

        private void dgHorarios_DoubleClick(object sender, EventArgs e)
        {
            if (dgHorarios.SelectedRows.Count>0)
            {
                TimeSpan horarioElegido = (TimeSpan)dgHorarios.SelectedRows[0].DataBoundItem;
                Turno nuevoTurno = new Turno();
                nuevoTurno.afiliado = _elAfiliado;
                nuevoTurno.estado = "Pedido";
                nuevoTurno.fecha = new DateTime(dtpDia.Value.Year, dtpDia.Value.Month, dtpDia.Value.Day, horarioElegido.Hours, horarioElegido.Minutes, 0);
                nuevoTurno.profesional = (Profesional)cmbProfesional.SelectedItem;
                nuevoTurno.especialidad = (Especialidad)cmbEspecialidad.SelectedItem;
                if (turnoDataAccess.reservarTurno(nuevoTurno))
                {
                    MessageBox.Show("Turno reservado correctamente", "Registro de Agenda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    actualizarGrilla(dtpDia.Value);
                }
            }
        }

        private void cbAfiliado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!estoyCargandoTodo)
            {
                _elAfiliado = (Afiliado)cbAfiliado.SelectedItem;
            }
        }
    }
}
