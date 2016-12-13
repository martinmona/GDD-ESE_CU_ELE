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

namespace ClinicaFrba.Registrar_Agenta_Medico
{
    
    public partial class RegistrarAgenda : Form
    {


        List<Dia> dataSource;

        public RegistrarAgenda(Persona unaPersona)
        {
            InitializeComponent();
            cargarTodo();
            if (unaPersona.GetType() == typeof(Profesional))
            {
                cbProfesional.SelectedValue = unaPersona.codigoPersona;
                cbProfesional.Enabled = false;
                
            }
                
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cargarTodo()
        {
            dataSource = new List<Dia>();
            dataSource.Add(new Dia() { Name = "Lunes", Value = 1 });
            dataSource.Add(new Dia() { Name = "Martes", Value = 2 });
            dataSource.Add(new Dia() { Name = "Miercoles", Value = 3 });
            dataSource.Add(new Dia() { Name = "Jueves", Value = 4 });
            dataSource.Add(new Dia() { Name = "Viernes", Value = 5 });
            dataSource.Add(new Dia() { Name = "Sabado", Value = 6 });
            this.cbDia.DataSource = dataSource;
            this.cbDia.DisplayMember = "Name";
            this.cbDia.ValueMember = "Value";
            this.cbDia.DropDownStyle = ComboBoxStyle.DropDownList;


            List<Profesional> profesionales = profesionalDataAccess.ObtenerProfesionales("");
            ActualizarComboBoxProf(profesionales);
            //List<Especialidad> especialidades = especialidadDataAccess.ObtenerEspecialidadesXProfesional((decimal)cbProfesional.SelectedValue);
            //ActualizarComboBoxEsp(especialidades);
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraInicio.CustomFormat = "HH:mm";
            dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpHoraFin.ShowUpDown = true;
            dtpHoraFin.CustomFormat = "HH:mm";
            dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpHoraInicio.MinDate = DateTime.Parse("7:00");
            dtpHoraInicio.MaxDate = DateTime.Parse("19:30");
            dtpHoraFin.MinDate = DateTime.Parse("7:30");
            dtpHoraFin.MaxDate = DateTime.Parse("20:00");

            dtpHoraInicio.Value = DateTime.Parse("10:00");
            mPrevDate1 = dtpHoraInicio.Value;
            dtpHoraInicio.ValueChanged += new EventHandler(dateTimePicker1_ValueChanged);
            dtpHoraFin.Value = DateTime.Parse("14:00");
            mPrevDate2 = dtpHoraFin.Value;
            dtpHoraFin.ValueChanged += new EventHandler(dateTimePicker2_ValueChanged);
            cbDia.SelectedIndex = 1;
            dtpInicio.Value = BD.obtenerFecha();
            dtpFin.Value = BD.obtenerFecha();

        }
        private DateTime mPrevDate1;
        private bool mBusy1;
        private DateTime mPrevDate2;
        private bool mBusy2;

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
            
        }



        private void ActualizarComboBoxProf(List<Profesional> profesionales)
        {
            cbProfesional.DataSource = null;
            cbProfesional.Items.Clear();

            cbProfesional.DataSource = profesionales;
            cbProfesional.ValueMember = "codigoPersona";
            cbProfesional.DisplayMember = "nombre";

        }
        private void ActualizarComboBoxEsp(List<Especialidad> especialidades)
        {
            cbEspecialidad.DataSource = null;
            cbEspecialidad.Items.Clear();

            cbEspecialidad.DataSource = especialidades;
            cbEspecialidad.ValueMember = "codigo";
            cbEspecialidad.DisplayMember = "descripcion";

        }

        private void dtpHoraInicio_ValueChanged(object sender, EventArgs e)
        {
            if (!mBusy1)
            {
                mBusy1 = true;
                DateTime dt = dtpHoraInicio.Value;
                if ((dt.Minute * 60 + dt.Second) % 300 != 0)
                {
                    TimeSpan diff = dt - mPrevDate1;
                    if (diff.Ticks < 0) dtpHoraInicio.Value = mPrevDate1.AddMinutes(-30);
                    else dtpHoraInicio.Value = mPrevDate1.AddMinutes(30);
                }
                mPrevDate1 = dtpHoraInicio.Value;
                mBusy1 = false;
            }
        }

        private void cbProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            Profesional prof = (Profesional)cbProfesional.SelectedItem;
            List<Especialidad> especialidades = new List<Especialidad>();
            especialidades = especialidadDataAccess.ObtenerEspecialidadesXProfesional(prof.codigoPersona);
            ActualizarComboBoxEsp(especialidades);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dtpHoraFin.Value > dtpHoraInicio.Value && dtpFin.Value>=dtpInicio.Value && cbDia.SelectedIndex>=0 && cbDia.SelectedIndex<6)
            {
                Profesional prof = new Profesional();
                prof = (Profesional)cbProfesional.SelectedItem;
                Agenda nuevaAgenda = new Agenda();
                nuevaAgenda.dia = (Byte)cbDia.SelectedValue;
                nuevaAgenda.especialidad = (Especialidad)cbEspecialidad.SelectedItem;
                nuevaAgenda.fechaFin = dtpFin.Value.Date;
                nuevaAgenda.horaFin = dtpHoraFin.Value.TimeOfDay;
                nuevaAgenda.horaInicio = dtpHoraInicio.Value.TimeOfDay;
                nuevaAgenda.fechaInicio = dtpInicio.Value.Date;
                if (agendaDataAccess.AgregarAgenda(nuevaAgenda, prof))
                {
                    MessageBox.Show("Agenda agregada correctamente","Registro de Agenda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            else MessageBox.Show("Error en los datos ingresados. Verifique que el día ingresado sea correcto, la hora de fin sea mayor que la de inicio, y el día de finalizacion posterior al día de inicio","ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            
        }

        private void cbDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDia.SelectedIndex == 6)
            {
                dtpHoraInicio.Value = DateTime.Parse("10:00");
                dtpHoraFin.Value = DateTime.Parse("14:00");
                dtpHoraInicio.MinDate = DateTime.Parse("10:00");
                dtpHoraInicio.MaxDate = DateTime.Parse("14:30");
                dtpHoraFin.MinDate = DateTime.Parse("10:30");
                dtpHoraFin.MaxDate = DateTime.Parse("15:00");

            }
            else
            {
                dtpHoraInicio.Value = DateTime.Parse("10:00");
                dtpHoraFin.Value = DateTime.Parse("14:00");
                dtpHoraInicio.MinDate = DateTime.Parse("7:00");
                dtpHoraInicio.MaxDate = DateTime.Parse("19:30");
                dtpHoraFin.MinDate = DateTime.Parse("7:30");
                dtpHoraFin.MaxDate = DateTime.Parse("20:00");

            }
        }

        private void dtpHoraFin_ValueChanged(object sender, EventArgs e)
        {
            if (!mBusy2)
            {
                mBusy2 = true;
                DateTime dt = dtpHoraFin.Value;
                if ((dt.Minute * 60 + dt.Second) % 300 != 0)
                {
                    TimeSpan diff = dt - mPrevDate2;
                    if (diff.Ticks < 0) dtpHoraFin.Value = mPrevDate2.AddMinutes(-30);
                    else dtpHoraFin.Value = mPrevDate2.AddMinutes(30);
                }
                mPrevDate2 = dtpHoraFin.Value;
                mBusy2 = false;
            }
        }
    }

}
