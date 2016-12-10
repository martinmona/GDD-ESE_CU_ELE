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
        }

        private void frmResultados_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            DateTime horaAtencion = new DateTime();
            ConsultaMedica laConsulta = consultaMedicaDataAccess.ObtenerConsulta(_turno.codigo);
            horaAtencion = dtpFecha.Value;
            horaAtencion.Add(dtpHora.Value.TimeOfDay);
            if (horaAtencion<laConsulta.horaLlegada)
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
