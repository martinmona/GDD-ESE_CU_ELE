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

namespace ClinicaFrba.Cancelar_Atencion
{
    public partial class frmCancelarAfiliado : Form
    {
        private Afiliado _afiliado;
        public frmCancelarAfiliado(Afiliado unafi)
        {
            _afiliado = unafi;
            InitializeComponent();
            lblPersona.Text = "TURNOS DEL PACIENTE: " + _afiliado.nombre;
        }

        private void frmCancelarAfiliado_Load(object sender, EventArgs e)
        {
            ActualizarGrillaTurnos(turnoDataAccess.obtenerTurnosxAfiliado(_afiliado.codigoPersona, "and turn_estado='Pedido' and CONVERT(date, turn_hora)> CONVERT(date," + DateTime.Now +" )"));
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
            fecha.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvTurnos.SelectedRows.Count > 0 && txtMotivo.Text.Length>0)
            {
                Turno turnoElegido = (Turno)dgvTurnos.SelectedRows[0].DataBoundItem;
                if (turnoDataAccess.CancelarTurnoAfiliado(turnoElegido.codigo, (decimal)cbTipo.SelectedValue, txtMotivo.Text)){
                    MessageBox.Show("Turno cancelado con exito", "CANCELACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
            else
            {
                MessageBox.Show("Seleccione un turno y/o complete el campo motivo","ATENCION",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
    }
}
