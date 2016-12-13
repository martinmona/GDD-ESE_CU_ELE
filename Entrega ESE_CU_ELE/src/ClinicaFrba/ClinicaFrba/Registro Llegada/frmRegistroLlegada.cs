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
using System.Data.SqlClient;
using ClinicaFrba.DataAccess;

namespace ClinicaFrba.Registro_Llegada
{
    public partial class frmRegistroLlegada : Form
    {

        public Bono bonoElegido;
        bool habilitaEventocb;
        public frmRegistroLlegada()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = BD.obtenerFecha();
            List<Especialidad> especialidades = especialidadDataAccess.ObtenerEspecialidades("");

            ActualizarComboBoxEsp(especialidades);
            List<Profesional> profesionales = profesionalDataAccess.ObtenerProfesionalesXEspecialidad(((Especialidad)cbEspecialidadProfesional.SelectedItem).codigo);
            ActualizarComboBoxProf(profesionales);
            dtpFecha.Value = BD.obtenerFecha();
            habilitaEventocb = true;
        }

        private void cbNombreProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (habilitaEventocb)
            {
                habilitaEventocb = false;

                ActualizarGrillaTurnos(turnoDataAccess.obtenerTurnosxFecha(dtpFecha.Value, (decimal)cbEspecialidadProfesional.SelectedValue,(decimal)cbNombreProfesional.SelectedValue,"and turn_estado not like 'Cancelado'"));

                habilitaEventocb = true;
            }

        }

        private void ActualizarComboBoxProf(List<Profesional> profesionales)
        {
            cbNombreProfesional.DataSource = null;
            cbNombreProfesional.Items.Clear();

            cbNombreProfesional.DataSource = profesionales;
            cbNombreProfesional.ValueMember = "codigoPersona";
            cbNombreProfesional.DisplayMember = "nombre";

        }
        private void ActualizarComboBoxEsp(List<Especialidad> especialidades)
        {
            cbEspecialidadProfesional.DataSource = null;
            cbEspecialidadProfesional.Items.Clear();

            cbEspecialidadProfesional.DataSource = especialidades;
            cbEspecialidadProfesional.ValueMember = "codigo";
            cbEspecialidadProfesional.DisplayMember = "descripcion";

        }

        private void cbEspecialidadProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (habilitaEventocb)
            {
                habilitaEventocb = false;
                List<Profesional> profesionales = profesionalDataAccess.ObtenerProfesionalesXEspecialidad(((Especialidad)cbEspecialidadProfesional.SelectedItem).codigo);
                ActualizarComboBoxProf(profesionales);
                ActualizarGrillaTurnos(turnoDataAccess.obtenerTurnosxFecha(dtpFecha.Value, (decimal)cbEspecialidadProfesional.SelectedValue, (decimal)cbNombreProfesional.SelectedValue, "and turn_estado not like 'Cancelado'"));
                habilitaEventocb = true;
            }
        }

        private void dgvTurnos_DoubleClick(object sender, EventArgs e)
        {
            if (dgvTurnos.SelectedRows.Count > 0)
            { 
            List<Bono> lstBonosAfiliado;
            Turno turnoElegido = (Turno)dgvTurnos.SelectedRows[0].DataBoundItem;
                if (turnoElegido.estado.Equals("Esperando") || turnoElegido.estado.Equals("Atendido"))

                {
                    MessageBox.Show("Ya se registró la llegada del usuario a la clínica", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (turnoElegido.fecha.Date < BD.obtenerFecha())
                {
                    MessageBox.Show("No se puede modificar un turno luego de pasada la hora del mismo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {

                    DialogResult dialogResult = MessageBox.Show("¿Desea marcar la llegada del afiliado " + turnoElegido.afiliadoNombre, "Registrar Llegada", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        lstBonosAfiliado = bonoDataAccess.obtenerBonosSinUsar(turnoElegido.afiliado);
                        //Verifico que tenga bonos disponibles
                        if (lstBonosAfiliado.Count() > 0)
                        {
                            //Selecciona el bono a usar
                            frmElegirBono formElegirBono = new frmElegirBono(lstBonosAfiliado);
                            formElegirBono.Text = "Seleccionar bono del Afiliado";
                            formElegirBono.Owner = this;
                            formElegirBono.ShowDialog(this);
                            if (turnoDataAccess.registrarLlegada(turnoElegido.afiliado.codigoPersona, bonoElegido.codigo, turnoElegido.codigo))
                            {
                                MessageBox.Show("Se registró la llegada del afiliado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ActualizarGrillaTurnos(turnoDataAccess.obtenerTurnosxFecha(dtpFecha.Value, (decimal)cbEspecialidadProfesional.SelectedValue, (decimal)cbNombreProfesional.SelectedValue, "and turn_estado not like 'Cancelado'"));
                            }

                        }
                        else
                        {
                            //No tiene bonos. Pregunta si desea comprar ahora
                            DialogResult drCompraBono = MessageBox.Show("El afiliado no dispone de bonos para utilizar. ¿Desea adquirir bonos ahora?", "Comprar Bonos", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (drCompraBono == DialogResult.Yes)
                            {
                                MessageBox.Show("Luego finalizar la compra, cierre la ventana y vuelva a seleccionar el turno", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Compra_Bono.frmCompraBono formCompraBono = new Compra_Bono.frmCompraBono(turnoElegido.afiliado);
                                formCompraBono.ShowDialog();
                            }
                        }

                    }
                }
           }
            
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

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (habilitaEventocb)
            {
                habilitaEventocb = false;

                ActualizarGrillaTurnos(turnoDataAccess.obtenerTurnosxFecha(dtpFecha.Value, (decimal)cbEspecialidadProfesional.SelectedValue, (decimal)cbNombreProfesional.SelectedValue, "and turn_estado not like 'Cancelado'"));

                habilitaEventocb = true;
            }
        }
    }
}
