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

namespace ClinicaFrba.Compra_Bono
{
    public partial class frmCompraBono : Form
    {
        bool habilitaEventoCmb;
        private Persona _unaPersona;
        private Afiliado _afiliadoComprador;
        private decimal _totalPagar;
        public frmCompraBono(Persona laPersona)
        {
            _unaPersona = laPersona;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            habilitaEventoCmb = false;
            _totalPagar = 0;
            List<Afiliado> listaAfiliados = afiliadoDataAccess.ObtenerAfiliados(" where usua_habilitado=1");
            ActualizarComboBoxAfiliado(listaAfiliados);
            if(_unaPersona.GetType() == typeof(Afiliado))
            {
                btnBuscar.Enabled = false;
                txtNumero.Enabled = false;
                cmbAfiliado.SelectedValue = _unaPersona.codigoPersona;
                cmbAfiliado.Enabled = false;

                actualizarCampos();
                _afiliadoComprador = (Afiliado)_unaPersona;
            }else if (_unaPersona.GetType() == typeof(Administrador))
            {
                _afiliadoComprador = (Afiliado)cmbAfiliado.SelectedItem;
                actualizarCampos();
                btnBuscar.Enabled = true;
                txtNumero.Enabled = true;
                cmbAfiliado.Enabled = true;
                
            }
            else if(_unaPersona.GetType() == typeof(Profesional))
            {
                
            }
            habilitaEventoCmb = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void ActualizarComboBoxAfiliado(List<Afiliado> afiliados)
        {
            habilitaEventoCmb = false;
            cmbAfiliado.DataSource = null;
            cmbAfiliado.Items.Clear();

            cmbAfiliado.DataSource = afiliados;
            cmbAfiliado.ValueMember = "codigoPersona";
            cmbAfiliado.DisplayMember = "nombreCompleto";
            habilitaEventoCmb = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                habilitaEventoCmb = false;
                _afiliadoComprador = afiliadoDataAccess.ObtenerAfiliados(" where usua_habilitado=1 and CONCAT(afil_numero,afil_numero_familiar) = " + txtNumero.Text)[0];
                cmbAfiliado.SelectedValue = _afiliadoComprador.codigoPersona;
                actualizarCampos();
                habilitaEventoCmb = true;
            }
            catch
            {
                MessageBox.Show("Afiliado no encontrado","ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizarCampos()
        {
            txtPlan.Text = _afiliadoComprador.plan.descripcion;
            txtNumero.Text = _afiliadoComprador.numeroCompleto;
            txtCosto.Text = Convert.ToString(_afiliadoComprador.plan.bonoConsulta);
            _totalPagar = Convert.ToInt32(dudCantidad.Text) * _afiliadoComprador.plan.bonoConsulta;
            txtTotal.Text = Convert.ToString(_totalPagar);
        }

        private void dudCantidad_SelectedItemChanged(object sender, EventArgs e)
        {
            _totalPagar = Convert.ToInt32(dudCantidad.Text) * _afiliadoComprador.plan.bonoConsulta;
            txtTotal.Text= Convert.ToString(_totalPagar);
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (usuarioDataAccess.verificarUsuarioPorCodigo(_afiliadoComprador.codigoPersona)!=-1)
            {
                Compra laCompra = new Compra();
                laCompra.total = _totalPagar;
                for (int i = 0; i < Convert.ToInt32(dudCantidad.Text); i++)
                {
                    Bono unBono = new Bono();
                    unBono.precio = Convert.ToInt32(txtCosto.Text);
                    laCompra.bonos.Add(unBono);
                }
                if (compraDataAccess.AgregarCompra(laCompra, _afiliadoComprador))
                {
                    MessageBox.Show("Compra de bonos concretada", "COMPRA BONOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("El usuario se encuentra inhabilitado", "COMPRA BONOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbAfiliado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (habilitaEventoCmb)
            {
                habilitaEventoCmb = false;
                _afiliadoComprador = (Afiliado)cmbAfiliado.SelectedItem;

                actualizarCampos();



                habilitaEventoCmb = true;
            }
            
        }
    }
}
