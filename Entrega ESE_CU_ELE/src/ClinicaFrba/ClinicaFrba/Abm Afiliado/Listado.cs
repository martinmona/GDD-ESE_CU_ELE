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
    public partial class Listado : Form
    {
        public Listado()
        {
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            List<Afiliado> afiliados = afiliadoDataAccess.ObtenerAfiliados("");
            ActualizarGrilla(afiliados);
            List<Plan> planes = afiliadoDataAccess.ObtenerPlanes();
            cmbPlan.DataSource = planes;
            cmbPlan.DisplayMember = "descripcion";
            /*dateTimePicker1.Visible = false;*/
        }

        private void ActualizarGrilla(List<Afiliado> afiliados)
        {

            dataGridAfiliados.Columns.Clear();
            dataGridAfiliados.AutoGenerateColumns = false;

            dataGridAfiliados.DataSource = afiliados;
           
          
            DataGridViewTextBoxColumn Nombre = new DataGridViewTextBoxColumn();
            Nombre.DataPropertyName = "nombreCompleto";
            Nombre.HeaderText = "Nombre";
            Nombre.Width = 100;
            Nombre.ReadOnly = true;

            DataGridViewTextBoxColumn DNI = new DataGridViewTextBoxColumn();
            DNI.DataPropertyName = "documento";
            DNI.HeaderText = "Documento";
            DNI.Width = 100;
            DNI.ReadOnly = true;

            DataGridViewTextBoxColumn Direccion = new DataGridViewTextBoxColumn();
            Direccion.DataPropertyName = "direccion";
            Direccion.HeaderText = "Direccion";
            Direccion.Width = 100;
            Direccion.ReadOnly = true;

            DataGridViewTextBoxColumn Telefono = new DataGridViewTextBoxColumn();
            Telefono.DataPropertyName = "telefono";
            Telefono.HeaderText = "Telefono";
            Telefono.Width = 100;
            Telefono.ReadOnly = true;


            DataGridViewTextBoxColumn Mail = new DataGridViewTextBoxColumn();
            Mail.DataPropertyName = "mail";
            Mail.HeaderText = "Mail";
            Mail.Width = 100;
            Mail.ReadOnly = true;

            DataGridViewTextBoxColumn FechaNacimiento = new DataGridViewTextBoxColumn();
            FechaNacimiento.DataPropertyName = "fechaNacimiento";
            FechaNacimiento.HeaderText = "Nacimiento";
            FechaNacimiento.Width = 100;
            FechaNacimiento.ReadOnly = true;

           

            DataGridViewTextBoxColumn Sexo = new DataGridViewTextBoxColumn();
            Sexo.DataPropertyName = "sexo";
            Sexo.HeaderText = "Sexo";
            Sexo.Width = 100;
            Sexo.ReadOnly = true;

            DataGridViewTextBoxColumn EstadoCivil = new DataGridViewTextBoxColumn();
            EstadoCivil.DataPropertyName = "estadoCivil";
            EstadoCivil.HeaderText = "Estado";
            EstadoCivil.Width = 100;
            EstadoCivil.ReadOnly = true;

            DataGridViewTextBoxColumn CantHijos = new DataGridViewTextBoxColumn();
            CantHijos.DataPropertyName = "cantidadFamiliares";
            CantHijos.HeaderText = "Familiares a cargo";
            CantHijos.Width = 100;
            CantHijos.ReadOnly = true;

            DataGridViewTextBoxColumn Plan = new DataGridViewTextBoxColumn();
            Plan.DataPropertyName = "planDescripcion";
            Plan.HeaderText = "Plan";
            Plan.Width = 100;
            Plan.ReadOnly = true;

            DataGridViewTextBoxColumn NumeroAfi = new DataGridViewTextBoxColumn();
            NumeroAfi.DataPropertyName = "numeroCompleto";
            NumeroAfi.HeaderText = "Numero Afiliado";
            NumeroAfi.Width = 100;
            NumeroAfi.ReadOnly = true;

            DataGridViewTextBoxColumn Habilitado = new DataGridViewTextBoxColumn();
            NumeroAfi.DataPropertyName = "habilitado";
            NumeroAfi.HeaderText = "Habilitado";
            NumeroAfi.Width = 100;
            NumeroAfi.ReadOnly = true;


          


            dataGridAfiliados.Columns.Add(Nombre);
            dataGridAfiliados.Columns.Add(Telefono);
            dataGridAfiliados.Columns.Add(DNI);
            dataGridAfiliados.Columns.Add(Direccion);
            dataGridAfiliados.Columns.Add(Mail);
            dataGridAfiliados.Columns.Add(FechaNacimiento);
            dataGridAfiliados.Columns.Add(Sexo);
            dataGridAfiliados.Columns.Add(EstadoCivil);
            dataGridAfiliados.Columns.Add(CantHijos);
            dataGridAfiliados.Columns.Add(Plan);
            dataGridAfiliados.Columns.Add(NumeroAfi);
            dataGridAfiliados.Columns.Add(Habilitado);
            
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            Afiliado selected = (Afiliado)dataGridAfiliados.SelectedRows[0].DataBoundItem;
            Abm_Afiliado.alta formAlta = new Abm_Afiliado.alta(selected, 2);
            formAlta.ShowDialog();
            List<Afiliado> afiliados = afiliadoDataAccess.ObtenerAfiliados("");
            ActualizarGrilla(afiliados);
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            Afiliado afi = new Afiliado();
            Abm_Afiliado.alta formAlta = new Abm_Afiliado.alta(afi,1);
            formAlta.ShowDialog();
            List<Afiliado> afiliados = afiliadoDataAccess.ObtenerAfiliados("");
            ActualizarGrilla(afiliados);
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            /*dateTimePicker1.Visible = true;*/
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
           /* txtFecha.Text = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            dateTimePicker1.Visible = false;*/
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string where = filtrar();
            List<Afiliado> afiliados = afiliadoDataAccess.ObtenerAfiliados(where);
            ActualizarGrilla(afiliados);
        }
        private string filtrar()
        {
            string where = "where (pers_nombre LIKE '%" + txtNombre.Text + "%' OR pers_apellido LIKE '%" + txtNombre.Text + "%')";
            if (txtTelefono.Text != "")
            {
                where = where + "AND pers_telefono LIKE '%" + txtTelefono.Text + "%'";
            }
            if (txtDocumento.Text != "")
            {
                where = where + "AND pers_numero_documento LIKE '%" + txtDocumento.Text + "%'";
            }
            if (txtDireccion.Text != "")
            {
                where = where + "AND pers_direccion LIKE '%" + txtDireccion.Text + "%'";
            }
            if (txtMail.Text != "")
            {
                where = where + "AND pers_mail LIKE '%" + txtMail.Text + "%'";
            }
            if (cmbSexo.Text != "")
            {
                where = where + "AND pers_sexo LIKE '%" + cmbSexo.Text + "%'";
            }
            if (cmbEstado.Text != "")
            {
                where = where + "AND afil_estado_civil LIKE '%" + cmbEstado.Text + "%'";
            }
            if (txtFamiliares.Text != "")
            {
                where = where + "AND (SELECT COUNT(familiar.afil_codigo_persona) FROM ESE_CU_ELE.Afiliado familiar WHERE familiar.afil_numero = afi.afil_numero AND NOT(familiar.afil_numero_familiar = 01) AND NOT(afi.afil_codigo_persona = familiar.afil_codigo_persona)) =" + txtFamiliares.Text;
            }
            if (cmbPlan.Text != "")
            {
                where = where + "AND plan_descripcion ='" + cmbPlan.Text + "'";
            }
            if (txtNumero.Text != "")
            {
                where = where + "AND (SELECT CONVERT(varchar(10),afil_numero) + CONVERT(varchar(10),afil_numero_familiar)) ='" + txtNumero.Text + "'";
            }
            if (cmbHabilitado.Text != "")
            {
                int hab = -1;
                if (cmbHabilitado.Text == "True")
                {
                    hab = 1;
                }
                else
                {
                    hab = 0;
                }
                where = where + "AND usua_habilitado="+hab.ToString()+"";
            }
            return where;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            List<Afiliado> afiliados = afiliadoDataAccess.ObtenerAfiliados("");
            ActualizarGrilla(afiliados);
            cmbPlan.Text = "";
            cmbEstado.Text = "";
            cmbSexo.Text = "";
            txtTelefono.Text = "";
            txtNumero.Text = "";
            txtNombre.Text = "";
            txtMail.Text = "";
            txtFamiliares.Text = "";
            txtDocumento.Text = "";
            txtDireccion.Text = "";
            cmbHabilitado.Text = "";
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtFamiliares_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void dataGridAfiliados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnHistorialCambiosPlan_Click(object sender, EventArgs e)
        {
            Afiliado selected = (Afiliado)dataGridAfiliados.SelectedRows[0].DataBoundItem;
            Abm_Afiliado.historial formAlta = new  Abm_Afiliado.historial(selected.codigoPersona);
            formAlta.Show();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            Afiliado selected = (Afiliado)dataGridAfiliados.SelectedRows[0].DataBoundItem;

            List<Turno> listaTurnos = turnoDataAccess.obtenerTurnosxAfiliado(selected.codigoPersona, "and turn_estado LIKE'%edido%' OR turn_estado LIKE '%sperando%'");
            foreach (Turno turnito in listaTurnos)
            {
                turnoDataAccess.CancelarTurnoAfiliado(turnito.codigo, 3, "Baja de usuario");
            }


            string habilitado = (string)dataGridAfiliados.SelectedRows[0].Cells[10].Value;
            if (habilitado == "False")
            {
                MessageBox.Show("El afiliado ya esta eliminado logicamente");
                return;
            }
            if (usuarioDataAccess.deshabilitar(selected.codigoPersona))
            {
                MessageBox.Show("Se deshabilito el afiliado seleccionado correctamente");
                string where = filtrar();
                List<Afiliado> afiliados = afiliadoDataAccess.ObtenerAfiliados(where);
                ActualizarGrilla(afiliados);
            }
            else
            {
                MessageBox.Show("Fallo la conexion a la BD", "Error");
            }
        }
    }
}
