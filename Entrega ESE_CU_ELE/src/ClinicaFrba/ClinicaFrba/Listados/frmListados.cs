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

namespace ClinicaFrba.Listados
{
    public partial class frmListados : Form
    {
        public frmListados()
        {
            InitializeComponent();
        }

        private void frmListados_Load(object sender, EventArgs e)
        {
            cbListado.SelectedIndex = 0;
            ocultarPlan();
            ocultarEspecialidad();
            dtpMes.Visible = false;
            List<Plan> listaPlanes = afiliadoDataAccess.ObtenerPlanes();
            listaPlanes.RemoveAt(0);
            ActualizarComboBoxPlanes(listaPlanes);
            ActualizarComboBoxEsp(especialidadDataAccess.ObtenerEspecialidades(""));
        }
        private void ActualizarComboBoxPlanes(List<Plan> tipos)
        {

            cbPlan.DataSource = null;
            cbPlan.Items.Clear();

            cbPlan.DataSource = tipos;
            cbPlan.ValueMember = "codigo";
            cbPlan.DisplayMember = "descripcion";

        }
        private void ActualizarComboBoxEsp(List<Especialidad> especialidades)
        {
            cbEspecialidad.DataSource = null;
            cbEspecialidad.Items.Clear();

            cbEspecialidad.DataSource = especialidades;
            cbEspecialidad.ValueMember = "codigo";
            cbEspecialidad.DisplayMember = "descripcion";

        }
        private void rbMes_CheckedChanged(object sender, EventArgs e)
        {
            dtpMes.Visible = true;
        }

        private void rbSegundoSemestre_CheckedChanged(object sender, EventArgs e)
        {
            dtpMes.Visible = false;
        }

        private void rdPrimerSemestre_CheckedChanged(object sender, EventArgs e)
        {
            dtpMes.Visible = false;
        }

        private void cbListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbListado.SelectedIndex)
            {
                case 0: //Especialidades con más cancelaciones
                    
                    ocultarEspecialidad();
                    ocultarPlan();
                    break;
                case 1: //Profesionales más consultados
                    
                    ocultarEspecialidad();
                    mostrarPlan();
                    break;
                case 2: //Profesionales con menos horas trabajadas
                    
                    mostrarEspecialidad();
                    ocultarPlan();
                    break;
                case 3: //Afiliados con más bonos comprados
                    
                    ocultarEspecialidad();
                    ocultarPlan();
                    break;
                case 4: //Especialidades con más bonos

                    ocultarEspecialidad();
                    ocultarPlan();
                    break;
            }
        }

        private void ocultarPlan()
        {
            cbPlan.Visible = false;
            lblPlan.Visible = false;
        }
        private void mostrarPlan()
        {
            cbPlan.Visible = true;
            lblPlan.Visible = true;
        }
        private void ocultarEspecialidad()
        {
            cbEspecialidad.Visible = false;
            lblEspe.Visible = false;
        }
        private void mostrarEspecialidad()
        {
            cbEspecialidad.Visible = true;
            lblEspe.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde = new DateTime();
            DateTime fechaHasta=new DateTime();

            //VERIFICO QUE SELECCIONO EN EL RADIO BUTTON
            if (rdPrimerSemestre.Checked)
            {
                fechaDesde = new DateTime(dtpAno.Value.Year, 1, 1);
                fechaHasta = new DateTime(dtpAno.Value.Year, 6, 30);
            }else if (rbSegundoSemestre.Checked)
            {
                fechaDesde = new DateTime(dtpAno.Value.Year, 7, 1);
                fechaHasta = new DateTime(dtpAno.Value.Year, 12, 31);
            }
            else if (rbMes.Checked)
            {
                fechaDesde = new DateTime(dtpAno.Value.Year, dtpMes.Value.Month, 1);
                fechaHasta = fechaDesde.AddMonths(1).AddDays(-1);
            }

            switch (cbListado.SelectedIndex)
            {
                case 0: //Especialidades con más cancelaciones
                    actualizarGrillaListadoCancelaciones(listadosDataAccess.listadoCancelaciones(fechaDesde, fechaHasta));

                    break;
                case 1: //Profesionales más consultados
                    actualizarGrillaListadoProfesionalesPorPlan(listadosDataAccess.listadoProfesionalesPorPlan(fechaDesde, fechaHasta, (decimal)cbPlan.SelectedValue));
                    break;
                case 2: //Profesionales con menos horas trabajadas
                    actualizarGrillaListadoProfesionalesMenosHoras(listadosDataAccess.listadoProfesionalesMenosHoras(fechaDesde, fechaHasta, (decimal)cbEspecialidad.SelectedValue));

                    break;
                case 3: //Afiliados con más bonos comprados
                    actualizarGrillaListadoAfiliadosBonos(listadosDataAccess.listadoAfiliadosBonos(fechaDesde, fechaHasta));

                    break;
                case 4: //Especialidades con más bonos
                    actualizarGrillaListadoEspecialidadesBonos(listadosDataAccess.listadoEspecialidadesBonos(fechaDesde, fechaHasta));

                    break;
            }
        }
        private void actualizarGrillaListadoCancelaciones(List<listadoCancelaciones> listaCancelaciones)
        {
            dgListados.Columns.Clear();
            dgListados.AutoGenerateColumns = false;
            dgListados.DataSource = listaCancelaciones;

            DataGridViewTextBoxColumn especialidad = new DataGridViewTextBoxColumn();
            especialidad.DataPropertyName = "Especialidad";
            especialidad.HeaderText = "Especialidad";
            especialidad.Width = 100;
            especialidad.ReadOnly = true;

            DataGridViewTextBoxColumn cantidad = new DataGridViewTextBoxColumn();

            cantidad.DataPropertyName = "CantidadCancelaciones";
            cantidad.HeaderText = "Cantidad de Cancelaciones";
            cantidad.Width = 100;
            cantidad.ReadOnly = true;



            dgListados.Columns.Add(especialidad);
            dgListados.Columns.Add(cantidad);
   
            dgListados.AutoResizeColumns();
        }
        private void actualizarGrillaListadoProfesionalesPorPlan(List<listadoProfesionalesPorPlan> listaProfxPlan)
        {
            dgListados.Columns.Clear();
            dgListados.AutoGenerateColumns = false;
            dgListados.DataSource = listaProfxPlan;

            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.DataPropertyName = "Nombre";
            nombre.HeaderText = "Nombre";
            nombre.Width = 100;
            nombre.ReadOnly = true;

            DataGridViewTextBoxColumn apellido = new DataGridViewTextBoxColumn();
            apellido.DataPropertyName = "Apellido";
            apellido.HeaderText = "Apellido";
            apellido.Width = 100;
            apellido.ReadOnly = true;

            DataGridViewTextBoxColumn matricula = new DataGridViewTextBoxColumn();
            matricula.DataPropertyName = "Matricula";
            matricula.HeaderText = "Matricula";
            matricula.Width = 100;
            matricula.ReadOnly = true;

            DataGridViewTextBoxColumn especialidad = new DataGridViewTextBoxColumn();
            especialidad.DataPropertyName = "Especialidad";
            especialidad.HeaderText = "Especialidad";
            especialidad.Width = 100;
            especialidad.ReadOnly = true;

            DataGridViewTextBoxColumn cantidad = new DataGridViewTextBoxColumn();
            cantidad.DataPropertyName = "CantidadConsultas";
            cantidad.HeaderText = "Cantidad de Consultas";
            cantidad.Width = 100;
            cantidad.ReadOnly = true;



            dgListados.Columns.Add(nombre);
            dgListados.Columns.Add(apellido);
            dgListados.Columns.Add(matricula);
            dgListados.Columns.Add(especialidad);
            dgListados.Columns.Add(cantidad);

            dgListados.AutoResizeColumns();
        }
        private void actualizarGrillaListadoProfesionalesMenosHoras(List<listadoProfesionalesMenosHoras> listaProfMenosHoras)
        {
            dgListados.Columns.Clear();
            dgListados.AutoGenerateColumns = false;
            dgListados.DataSource = listaProfMenosHoras;

            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.DataPropertyName = "Nombre";
            nombre.HeaderText = "Nombre";
            nombre.Width = 100;
            nombre.ReadOnly = true;

            DataGridViewTextBoxColumn apellido = new DataGridViewTextBoxColumn();
            apellido.DataPropertyName = "Apellido";
            apellido.HeaderText = "Apellido";
            apellido.Width = 100;
            apellido.ReadOnly = true;

            DataGridViewTextBoxColumn matricula = new DataGridViewTextBoxColumn();
            matricula.DataPropertyName = "Matricula";
            matricula.HeaderText = "Matricula";
            matricula.Width = 100;
            matricula.ReadOnly = true;

            DataGridViewTextBoxColumn cantidad = new DataGridViewTextBoxColumn();
            cantidad.DataPropertyName = "CantidadHoras";
            cantidad.HeaderText = "Cantidad de Horas";
            cantidad.Width = 100;
            cantidad.ReadOnly = true;



            dgListados.Columns.Add(nombre);
            dgListados.Columns.Add(apellido);
            dgListados.Columns.Add(matricula);
            dgListados.Columns.Add(cantidad);

            dgListados.AutoResizeColumns();
        }
        private void actualizarGrillaListadoAfiliadosBonos(List<listadoAfiliadosBonos> listaAfiliadosBonos)
        {
            dgListados.Columns.Clear();
            dgListados.AutoGenerateColumns = false;
            dgListados.DataSource = listaAfiliadosBonos;

            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.DataPropertyName = "Nombre";
            nombre.HeaderText = "Nombre";
            nombre.Width = 100;
            nombre.ReadOnly = true;

            DataGridViewTextBoxColumn apellido = new DataGridViewTextBoxColumn();
            apellido.DataPropertyName = "Apellido";
            apellido.HeaderText = "Apellido";
            apellido.Width = 100;
            apellido.ReadOnly = true;

            DataGridViewTextBoxColumn numeroAfiliado = new DataGridViewTextBoxColumn();
            numeroAfiliado.DataPropertyName = "NumeroCompleto";
            numeroAfiliado.HeaderText = "Numero de Afiliado";
            numeroAfiliado.Width = 100;
            numeroAfiliado.ReadOnly = true;

            DataGridViewTextBoxColumn cantidad = new DataGridViewTextBoxColumn();
            cantidad.DataPropertyName = "CantidadBonos";
            cantidad.HeaderText = "Cantidad de Bonos";
            cantidad.Width = 100;
            cantidad.ReadOnly = true;

            DataGridViewTextBoxColumn perteneceGrupoFamiliar = new DataGridViewTextBoxColumn();
            perteneceGrupoFamiliar.DataPropertyName = "perteneceGrupoFamiliar";
            perteneceGrupoFamiliar.HeaderText = "Pertenece a un Grupo Familiar";
            perteneceGrupoFamiliar.Width = 100;
            perteneceGrupoFamiliar.ReadOnly = true;


            dgListados.Columns.Add(nombre);
            dgListados.Columns.Add(apellido);
            dgListados.Columns.Add(numeroAfiliado);
            dgListados.Columns.Add(perteneceGrupoFamiliar);
            dgListados.Columns.Add(cantidad);

            dgListados.AutoResizeColumns();
        }
        private void actualizarGrillaListadoEspecialidadesBonos(List<listadoEspecialidadesBonos> listaEspecialidadesBonos)
        {
            dgListados.Columns.Clear();
            dgListados.AutoGenerateColumns = false;
            dgListados.DataSource = listaEspecialidadesBonos;

            DataGridViewTextBoxColumn especialidad = new DataGridViewTextBoxColumn();
            especialidad.DataPropertyName = "Especialidad";
            especialidad.HeaderText = "Especialidad";
            especialidad.Width = 100;
            especialidad.ReadOnly = true;

            DataGridViewTextBoxColumn cantidad = new DataGridViewTextBoxColumn();
            cantidad.DataPropertyName = "CantidadBonos";
            cantidad.HeaderText = "Cantidad de Bonos";
            cantidad.Width = 100;
            cantidad.ReadOnly = true;


            dgListados.Columns.Add(especialidad);

            dgListados.Columns.Add(cantidad);

            dgListados.AutoResizeColumns();
        }
        }
}

