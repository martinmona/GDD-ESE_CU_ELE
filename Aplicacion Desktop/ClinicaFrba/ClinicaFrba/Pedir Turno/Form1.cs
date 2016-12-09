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
        DateTime fecha;
        public Turno(Afiliado afi)
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
            List<Profesional> profesionales = profesionalDataAccess.ObtenerProfesionales("");
            actualizarComboBoxProf(profesionales);
           
        }

        private void actualizarComboBoxProf(List<Profesional> listaProfesionales) 
        {
            cmbProfesional.DataSource = null;
            cmbProfesional.Items.Clear();

            cmbProfesional.DataSource = listaProfesionales;
            cmbProfesional.ValueMember = "prof_codigo_persona";
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

        private void Calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            fecha = Calendario.SelectionEnd.Date;
            //0 es domingo
            int dia = (int)fecha.DayOfWeek;
            switch (dia)
            {
                case 0:
                    MessageBox.Show("No se atiende los dias domingos");
                    break;
                default:
                    actualizarGrilla(fecha);
                    break;
            }
                      
        }

        
          private void actualizarGrilla(DateTime fecha)
        {
            cmbProfesional.ValueMember = "prof_codigo_persona";
            cmbEspecialidad.ValueMember = "espe_codigo";
            decimal idProfesional = (decimal)cmbProfesional.SelectedValue;
            decimal codigoEspecialidad = (decimal)cmbEspecialidad.SelectedValue;
            dataGridTurnos.Enabled = true;
            dataGridTurnos.Columns.Clear();
            string where = "";
            List<Turno> listaturnos = turnoDataAccess.obtenerTurnosxFecha(fecha, codigoEspecialidad, idProfesional, where);

            dataGridTurnos.AutoGenerateColumns = false;
            List<Turno> lista = new List<Turno>();
            for (double i = 07; i <= 20; i = i + 0.5)
            {
                Turno turno = new Turno();
                 
                if (i.ToString().Length <= 2)
                {
                    string hoi = i.ToString() + ":00";
                    turno.horaI = hoi;
                    string hof = i.ToString() + ":30";
                    turno.horaT = hof;
                }
                else
                {
                    string ho = i.ToString().Substring(0, 2);
                    string hoi = ho + ":30";
                    turno.horaI = hoi;
                    string hok = (int.Parse(ho) + 1).ToString();
                    string hof = hok + ":00";
                    turno.horaT = hof;
                }

                turno.nombreAfiliado = "";
                turno.nombreProfesional = "";

                lista.Add(turno);
            }
            dataGridTurnos.DataSource = lista;

            DataGridViewTextBoxColumn Codigo = new DataGridViewTextBoxColumn();
            Codigo.DataPropertyName = "codigo";
            Codigo.HeaderText = "Codigo turno";
            Codigo.Width = 100;
            Codigo.ReadOnly = true;

            DataGridViewTextBoxColumn HoraI = new DataGridViewTextBoxColumn();
            HoraI.DataPropertyName = "horaI";
            HoraI.HeaderText = "Hora Inicio";
            HoraI.Width = 100;
            HoraI.ReadOnly = true;

            DataGridViewTextBoxColumn HoraT = new DataGridViewTextBoxColumn();
            HoraT.DataPropertyName = "horaT";
            HoraT.HeaderText = "Hora Término";
            HoraT.Width = 100;
            HoraT.ReadOnly = true;

            DataGridViewTextBoxColumn NombreAfiliado = new DataGridViewTextBoxColumn();
            NombreAfiliado.DataPropertyName = "nombreAfiliado";
            NombreAfiliado.HeaderText = "Afiliado";
            NombreAfiliado.Width = 100;
            NombreAfiliado.ReadOnly = true;

            DataGridViewTextBoxColumn NombreProfesional = new DataGridViewTextBoxColumn();
            NombreProfesional.DataPropertyName = "nombreProfesional";
            NombreProfesional.HeaderText = "Profesional";
            NombreProfesional.Width = 100;
            NombreProfesional.ReadOnly = true;



            dataGridTurnos.Columns.Add(Codigo);
            dataGridTurnos.Columns.Add(HoraI);
            dataGridTurnos.Columns.Add(HoraT);
            dataGridTurnos.Columns.Add(NombreAfiliado);
            dataGridTurnos.Columns.Add(NombreProfesional);

            foreach (Turno t in listaturnos)
            {
                for (int i = 0; i <= dataGridTurnos.Rows.Count - 1; i++)
                {
                    if (t.horaI == (string)dataGridTurnos.Rows[i].Cells[1].Value)
                    {
                        dataGridTurnos.Rows[i].Cells[0].Value = t.codigo;
                        dataGridTurnos.Rows[i].Cells[3].Value = t.nombreAfiliado;
                        dataGridTurnos.Rows[i].Cells[4].Value = t.nombreProfesional;
                    }
                }
            }
            dataGridTurnos.Columns[0].Visible = false;
        }

          private void dataGridTurnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
          {
              if ((string)dataGridTurnos.CurrentRow.Cells[3].Value == "") //al hacer doble click en una celda, si la celda 3 (nombreAfi) esta vacia
              {
                  DialogResult respuesta = MessageBox.Show("¿Confirma Turno? ", "Información", MessageBoxButtons.YesNo);
                  if (respuesta == DialogResult.Yes)
                  {
                      string horain = (string)dataGridTurnos.CurrentRow.Cells[1].Value;
                      string horafin = (string)dataGridTurnos.CurrentRow.Cells[2].Value;
                      cmbProfesional.ValueMember = "prof_codigo_persona";
                      decimal idProfesional = cmbProfesional.SelectedValue;
                      turnoDataAccess.reservarTurno(afi, horain, horafin, idProfesional, fecha);
                      MessageBox.Show("Turno reservado");
                      actualizarGrilla(fecha);

                  }
                  else 
                  {
                  }
              }
              else 
              {
                  MessageBox.Show("Este horario ya se encuentra reservado");
              }
          }


    }
}
