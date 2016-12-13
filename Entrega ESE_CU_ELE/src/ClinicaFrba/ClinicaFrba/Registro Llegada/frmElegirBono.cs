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

namespace ClinicaFrba.Registro_Llegada
{
    public partial class frmElegirBono : Form
    {
        public frmElegirBono(List<Bono> listaBonos)
        {
            InitializeComponent();
            ActualizarGrillaBonos(listaBonos);
        }

        private void frmElegirBono_Load(object sender, EventArgs e)
        {

        }
        private void ActualizarGrillaBonos(List<Bono> turnos)
        {
            dgvBonos.Columns.Clear();
            dgvBonos.AutoGenerateColumns = false;

            dgvBonos.DataSource = turnos;
            

            DataGridViewTextBoxColumn codigoBono = new DataGridViewTextBoxColumn();
            codigoBono.DataPropertyName = "codigo";
            codigoBono.HeaderText = "Codigo";
            codigoBono.Width = 100;
            codigoBono.ReadOnly = true;

            DataGridViewTextBoxColumn precio = new DataGridViewTextBoxColumn();
            precio.DataPropertyName = "precio";
            precio.HeaderText = "Precio";
            precio.Width = 100;
            precio.ReadOnly = true;

            DataGridViewTextBoxColumn plan = new DataGridViewTextBoxColumn();
            plan.DataPropertyName = "planDescripcion";
            plan.HeaderText = "Nombre Plan";
            plan.Width = 100;
            plan.ReadOnly = true;

            DataGridViewTextBoxColumn fechaCompra = new DataGridViewTextBoxColumn();
            fechaCompra.DefaultCellStyle.Format = "dd/MM/yyyy";
            fechaCompra.DataPropertyName = "fechaCompra";
            fechaCompra.HeaderText = "Fecha de Compra";
            fechaCompra.Width = 100;
            fechaCompra.ReadOnly = true;


            dgvBonos.Columns.Add(codigoBono);
            dgvBonos.Columns.Add(precio);
            dgvBonos.Columns.Add(plan);
            dgvBonos.Columns.Add(fechaCompra);

            dgvBonos.AutoResizeColumns();
        }

        private void dgvBonos_DoubleClick(object sender, EventArgs e)
        {
            if (dgvBonos.SelectedRows.Count > 0)
            {
                ((frmRegistroLlegada)this.Owner).bonoElegido = (Bono)dgvBonos.SelectedRows[0].DataBoundItem;
                this.Close();
            }
        }
    }
}
