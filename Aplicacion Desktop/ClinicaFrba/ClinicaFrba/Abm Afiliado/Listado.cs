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
            dateTimePicker1.Visible = false;
        }

        private void ActualizarGrilla(List<Afiliado> afiliados)
        {

            dataGridAfiliados.Columns.Clear();
            dataGridAfiliados.AutoGenerateColumns = false;

            dataGridAfiliados.DataSource = afiliados;
           
          
            DataGridViewTextBoxColumn Nombre = new DataGridViewTextBoxColumn();
            Nombre.DataPropertyName = "nombre";
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
        }

        private void btnMod_Click(object sender, EventArgs e)
        {

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {

        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            txtFecha.Text = dateTimePicker1.Value.ToShortDateString();
            dateTimePicker1.Visible = false;
        }
    }
}
