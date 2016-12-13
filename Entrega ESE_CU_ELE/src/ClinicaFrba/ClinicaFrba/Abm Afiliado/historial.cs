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
namespace ClinicaFrba.Abm_Afiliado
{
    public partial class historial : Form
    {
        decimal codigoPersona;
        public historial(decimal codigoPersona1)
        {
            codigoPersona = codigoPersona1;
            InitializeComponent();
        }

        private void historial_Load(object sender, EventArgs e)
        {
            List<Modificacion> modificaciones =afiliadoDataAccess.obtenerModificaciones(codigoPersona);
            dataGridHistorial.DataSource = modificaciones;
        }
    }
}
