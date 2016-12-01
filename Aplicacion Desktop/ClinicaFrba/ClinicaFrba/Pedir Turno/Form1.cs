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

        }

        /*private void ActualizarGrilla(DateTime fecha)
        {
            cmbM.ValueMember = "Id";
            int idmedico = (int)cmbM.SelectedValue;
            GrillaTurnos.Enabled = true;
            GrillaTurnos.Columns.Clear();
            List<Turno> listaturnos = TurnosDataAcces.ObtenerTurnos(fecha, idmedico);
            GrillaTurnos.AutoGenerateColumns = false;
            List<Turno> lista = new List<Turno>();
            for (double i = 12; i <= 19; i = i + 0.5)
            {
                Turno turno = new Turno();
                if (i.ToString().Length <= 2)
                {
                    string hoi = i.ToString() + ":00";
                    turno.HoraI = hoi;
                    string hof = i.ToString() + ":30";
                    turno.HoraT = hof;
                }
                else
                {
                    string ho = i.ToString().Substring(0, 2);
                    string hoi = ho + ":30";
                    turno.HoraI = hoi;
                    string hok = (int.Parse(ho) + 1).ToString();
                    string hof = hok + ":00";
                    turno.HoraT = hof;
                }
                turno.NombreM = "";
                turno.NombreP = "";
                turno.ApellidoM = "";
                turno.ApellidoP = "";

                lista.Add(turno);
            }
            GrillaTurnos.DataSource = lista;

            DataGridViewTextBoxColumn Id = new DataGridViewTextBoxColumn();
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Codigo turno";
            Id.Width = 100;
            Id.ReadOnly = true;

            DataGridViewTextBoxColumn HoraI = new DataGridViewTextBoxColumn();
            HoraI.DataPropertyName = "HoraI";
            HoraI.HeaderText = "Hora Inicio";
            HoraI.Width = 100;
            HoraI.ReadOnly = true;

            DataGridViewTextBoxColumn HoraT = new DataGridViewTextBoxColumn();
            HoraT.DataPropertyName = "HoraT";
            HoraT.HeaderText = "Hora Término";
            HoraT.Width = 100;
            HoraT.ReadOnly = true;

            DataGridViewTextBoxColumn NombreP = new DataGridViewTextBoxColumn();
            NombreP.DataPropertyName = "NombreP";
            NombreP.HeaderText = "Nombre Paciente";
            NombreP.Width = 100;
            NombreP.ReadOnly = true;

            DataGridViewTextBoxColumn ApellidoP = new DataGridViewTextBoxColumn();
            ApellidoP.DataPropertyName = "ApellidoP";
            ApellidoP.HeaderText = "Apellido Paciente";
            ApellidoP.Width = 100;
            ApellidoP.ReadOnly = true;

            DataGridViewTextBoxColumn ApellidoM = new DataGridViewTextBoxColumn();
            ApellidoM.DataPropertyName = "ApellidoM";
            ApellidoM.HeaderText = "Apellido Medico";
            ApellidoM.Width = 100;
            ApellidoM.ReadOnly = true;

            DataGridViewTextBoxColumn NombreM = new DataGridViewTextBoxColumn();
            NombreM.DataPropertyName = "NombreM";
            NombreM.HeaderText = "Nombre Medico";
            NombreM.Width = 100;
            NombreM.ReadOnly = true;



            GrillaTurnos.Columns.Add(Id);
            GrillaTurnos.Columns.Add(HoraI);
            GrillaTurnos.Columns.Add(HoraT);
            GrillaTurnos.Columns.Add(NombreP);
            GrillaTurnos.Columns.Add(ApellidoP);
            GrillaTurnos.Columns.Add(NombreM);
            GrillaTurnos.Columns.Add(ApellidoM);

            foreach (Turno t in listaturnos)
            {
                for (int i = 0; i <= GrillaTurnos.Rows.Count - 1; i++)
                {
                    if (t.HoraI == (string)GrillaTurnos.Rows[i].Cells[1].Value)
                    {
                        GrillaTurnos.Rows[i].Cells[0].Value = t.Id;
                        GrillaTurnos.Rows[i].Cells[3].Value = t.NombreP;
                        GrillaTurnos.Rows[i].Cells[4].Value = t.ApellidoP;
                        GrillaTurnos.Rows[i].Cells[5].Value = t.NombreM;
                        GrillaTurnos.Rows[i].Cells[6].Value = t.ApellidoM;

                    }
                }
            }
            GrillaTurnos.Columns[0].Visible = false;
        }
        private void Calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            fecha = Calendario.SelectionEnd.Date;
            if (Calendario.BoldedDates.Contains(fecha))
            {
                ActualizarGrilla(fecha);
                BtnTurno.Enabled = true;
                this.Size = new Size(930, 518);
            }
            else
            {
                BtnTurno.Enabled = false; this.Size = new Size(260, 518);
            }
        }*/
    }
}
