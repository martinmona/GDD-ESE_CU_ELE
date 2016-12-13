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

namespace ClinicaFrba.Registro_Resultado
{
    public partial class frmResultados : Form
    {
        private Turno _turno;
        public frmResultados(Turno unTurno)
        {
            _turno = unTurno;
            
            InitializeComponent();
            lblPaciente.Text = "Se esta atendiendo al paciente: "+_turno.afiliadoNombre;
            dtpHora.Format = DateTimePickerFormat.Custom;
            dtpHora.CustomFormat = "HH:mm"; 
            dtpHora.ShowUpDown = true;
            dtpHora.Value = BD.obtenerFecha();
            dtpFecha.Value = BD.obtenerFecha();
        }

        private void frmResultados_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            DateTime horaAtencion = new DateTime(dtpFecha.Value.Date.Year, dtpFecha.Value.Date.Month, dtpFecha.Value.Date.Day, dtpHora.Value.Hour, dtpHora.Value.Minute,0);
            ConsultaMedica laConsulta = consultaMedicaDataAccess.ObtenerConsulta(_turno.codigo);
            if (horaAtencion.CompareTo(laConsulta.horaLlegada)<0)
            {
                MessageBox.Show("La hora de atencion es anterior a la de llegada","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if(consultaMedicaDataAccess.registrarLlegada(laConsulta.codigo, horaAtencion, txtSintomas.Text, txtEnfermedades.Text))
                {
                    MessageBox.Show("Se registró la atención del paciente correctamente","Registro de Atencion",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }

            }
        }
    }
}
