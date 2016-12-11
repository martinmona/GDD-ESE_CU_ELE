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

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class frmCancelarProfesional : Form
    {
        private Profesional _profesional;
        public frmCancelarProfesional(Profesional unProf)
        {
            InitializeComponent();
            _profesional = unProf;
            lblPersona.Text = "TURNOS DEL MEDICO: "+_profesional.nombre;
        }

        private void frmCancelarProfesional_Load(object sender, EventArgs e)
        {
            checkRango.Checked = false;
            dtpHasta.Enabled = false;
            dtpDesde.MinDate = BD.obtenerFecha().AddDays(1);
            dtpDesde.Value= BD.obtenerFecha().AddDays(1);
            ActualizarComboBoxTipos(cancelacionDataAccess.ObtenerTipoCancelacion());

        }
        private void ActualizarComboBoxTipos(List<TipoCancelacion> tipos)
        {

            cbTipo.DataSource = null;
            cbTipo.Items.Clear();

            cbTipo.DataSource = tipos;
            cbTipo.ValueMember = "codigo";
            cbTipo.DisplayMember = "descripcion";

        }

        private void checkRango_CheckedChanged(object sender, EventArgs e)
        {
            if (checkRango.Checked)
            {
                dtpHasta.Enabled = true;
            }
            else
            {
                dtpHasta.Enabled = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Verifico que elija una fecha despues de hoy y haya ingresado motivo
            if(dtpDesde.Value>BD.obtenerFecha() && txtMotivo.TextLength > 0)
            {

                if (checkRango.Checked)
                {
                    //ES UN RANGO DE FECHAS
                    if (dtpDesde.Value < dtpHasta.Value)
                    {
                        if(turnoDataAccess.CancelarTurnoProfesional(_profesional.codigoPersona, dtpDesde.Value, dtpHasta.Value, (decimal)cbTipo.SelectedValue, txtMotivo.Text))
                        {
                            //SE CANCELARON LOS TURNOS
                            MessageBox.Show("Turnos cancelados con exito", "CANCELACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        }
                        else
                        {
                            //ERROR AL INTENTAR CANCELAR
                            MessageBox.Show("No se pudo cancelar el turno", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Elija un rango de fechas valido", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (turnoDataAccess.CancelarTurnoProfesional(_profesional.codigoPersona, dtpDesde.Value, dtpDesde.Value, (decimal)cbTipo.SelectedValue, txtMotivo.Text))
                    {
                        //SE CANCELARON LOS TURNOS
                        MessageBox.Show("Turnos cancelados con exito", "CANCELACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        //ERROR AL INTENTAR CANCELAR
                        MessageBox.Show("No se pudo cancelar el turno", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Elija una fecha posterior a hoy y/o complete el campo motivo", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
