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
namespace ClinicaFrba.Abm_Afiliado
{
    public partial class alta : Form
    {
        public static Plan planactual;
        public static Afiliado afiliadoModificar;
        public static Afiliado afiliadoNuevoo;
        public int opcionelegida;
        public alta(Afiliado afil, int opcion)
        {
            InitializeComponent();
            afiliadoModificar = afil;
            opcionelegida = opcion;
            txtNombre.CharacterCasing = CharacterCasing.Upper;
            txtApellido.CharacterCasing = CharacterCasing.Normal;
            cargarPlanes();
            if (opcion == 1)/*DANDO DE ALTA UN AFILIADO*/
            {
                btnHabilitar.Visible = false;
                cmbPlan.Enabled = true;
                button1.Visible = false;/*
                cmbSexo.SelectedText = "No especificado";
                cmbEstadoCivil.SelectedValue = "No Especifica";*/
            }
            else if (opcion == 2) /*MODIFICANDO USUARIO*/
            {
                
                comboBox1.Enabled = false;
                comboBox1.Text = afiliadoModificar.tipoDocumento;
                txtNombre.Text = afiliadoModificar.nombre;
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtApellido.Text = afiliadoModificar.apellido;
                txtDni.Text = afiliadoModificar.numeroDocumento.ToString();
                txtDni.Enabled = false;
                cmbPlan.Text = afiliadoModificar.plan.descripcion;
                txtMail.Text = afiliadoModificar.mail;
                cmbEstadoCivil.Text = afiliadoModificar.estadoCivil;
                txtTelefono.Text = afiliadoModificar.telefono.ToString();
                txtDireccion.Text = afiliadoModificar.direccion;
                dtpFecha.Value = afiliadoModificar.fechaNacimiento;
                dtpFecha.Enabled = false;
                planactual = (Plan)cmbPlan.SelectedItem;
                
                //ckbEstado.Checked = usuario.Activo;
                cmbSexo.Text = afiliadoModificar.sexo;
                cmbPlan.Enabled = true;
                button1.Visible = true;
                if (afiliadoModificar.codigoFamiliar == 1)
                {
                    button1.Visible = true;
                }
                else
                {
                    button1.Visible = false;
                }
                if (afiliadoModificar.habilitado == "False")
                {
                    btnHabilitar.Visible = true;
                }
            }
            else if (opcion == 3 || opcion == 4)
            {
                //SE ESTA AGREGANDO UN FAMILIAR (EL NRO DE AFILIADO ES EL MISMO QUE LE PASO CON EL AFILIADO POR PARAMETRO, SE LE SUMA 1 DIRECTO EN LA BASE)
                if (opcion == 3)/*ESTA AGREGANDO A SU CONYUGE*/
                {
                    cmbEstadoCivil.Text = "Casado/a";
                    cmbEstadoCivil.Enabled = false;
                }
                btnHabilitar.Visible = false;
                cmbPlan.Text = afiliadoModificar.plan.descripcion;
                cmbPlan.Enabled = false;
                button1.Visible = false;
            }
        }

        private void alta_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = BD.obtenerFecha();
        }

        private void cargarPlanes()
        {
            List<Plan> planes = afiliadoDataAccess.ObtenerPlanes();
            cmbPlan.DataSource = planes;
            cmbPlan.DisplayMember = "descripcion";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (opcionelegida == 1)
            {
                txtApellido.Text = "";
                txtMotivo.Text = "";
                txtDireccion.Text = "";
                txtDni.Text = "";
                txtMail.Text = "";
                txtNombre.Text = "";
                txtTelefono.Text = "";
                cmbEstadoCivil.SelectedItem = cmbEstadoCivil.Items[0];
                cmbPlan.SelectedItem = cmbPlan.Items[0];
                cmbSexo.SelectedItem = cmbSexo.Items[0];
            }
            else if (opcionelegida == 3 || opcionelegida == 4)
            {
                txtApellido.Text = "";
                txtMotivo.Text = "";
                txtDireccion.Text = "";
                txtDni.Text = "";
                txtMail.Text = "";
                txtNombre.Text = "";
                txtTelefono.Text = "";
                cmbEstadoCivil.SelectedItem = cmbEstadoCivil.Items[0];
                cmbSexo.SelectedItem = cmbSexo.Items[0];
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre");
                return;
            }
            if (txtTelefono.Text == "")
            {
                MessageBox.Show("Debe ingresar el telefono");
                return;
            }
            if (txtMail.Text == "")
            {
                MessageBox.Show("Debe ingresar el mail");
                return;
            }
              if (txtDni.Text == "")
            {
                MessageBox.Show("Debe ingresar el dni");
                return;
            }
              if (txtDireccion.Text == "")
            {
                MessageBox.Show("Debe ingresar la direccion");
                return;
            }
              if (txtApellido.Text == "")
            {
                MessageBox.Show("Debe ingresar el apellido");
                return;
            }
              if (cmbSexo.Text == "")
              {
                  MessageBox.Show("Debe seleccionar el sexo");
                  return;
              }
             if (cmbPlan.Text == "")
            {
                MessageBox.Show("Debe seleccionar el plan");
                return;
            }
             if (cmbEstadoCivil.Text == "")
             {
                 MessageBox.Show("Debe ingresar el estado civil");
                 return;
             }
            
            if (opcionelegida == 1)
            {
                Plan planElegido = (Plan)cmbPlan.SelectedValue;
                Afiliado afiliadoNuevo = new Afiliado();
                afiliadoNuevo.nombre = txtNombre.Text;
                afiliadoNuevo.tipoDocumento = comboBox1.Text.ToString();
                afiliadoNuevo.numeroDocumento = Convert.ToDecimal(txtDni.Text);
                afiliadoNuevo.apellido = txtApellido.Text;
                afiliadoNuevo.mail = txtMail.Text;
                afiliadoNuevo.telefono = Convert.ToDecimal(txtTelefono.Text);
                afiliadoNuevo.direccion = txtDireccion.Text;
                afiliadoNuevo.cantidadFamiliares = 0;
                afiliadoNuevo.estadoCivil = cmbEstadoCivil.Text;
                afiliadoNuevo.fechaNacimiento = dtpFecha.Value;
                afiliadoNuevo.plan = planElegido;
                afiliadoNuevo.sexo = cmbSexo.Text;
                bool anduvo = afiliadoDataAccess.AgregarAfiliado(afiliadoNuevo, 1,0);
                afiliadoNuevo.numeroAfiliado = afiliadoDataAccess.obtenerUltimoCodigoAfiliado();
                afiliadoNuevo.codigoPersona = afiliadoDataAccess.obtenerCodigoPersona();
                if (anduvo == true)
                {
                    usuarioDataAccess.agregarUsuario(afiliadoNuevo.numeroAfiliado);
                    afiliadoNuevoo = afiliadoNuevo;
                    button1.Visible = true;
                    if (cmbEstadoCivil.Text == "Casado/a")
                    {
                        DialogResult dialogResult = MessageBox.Show("Desea agregar un conyugue", "Conyugue", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Abm_Afiliado.alta formAlta = new Abm_Afiliado.alta(afiliadoNuevo, 3);
                            formAlta.ShowDialog();
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //do something else
                        }
                    }
                   
                }
            }
            else if (opcionelegida == 2)
            {
                Plan planElegido = (Plan)cmbPlan.SelectedValue;
                if (txtMotivo.Text == "" && planElegido.codigo != planactual.codigo)
                {
                    MessageBox.Show("Debe ingresar el motivo");
                    return;
                }
               
                Afiliado afiliadoNuevo = new Afiliado();
                afiliadoNuevo.nombre = txtNombre.Text;
                afiliadoNuevo.tipoDocumento = comboBox1.Text.ToString();
                afiliadoNuevo.numeroDocumento = Convert.ToDecimal(txtDni.Text);
                afiliadoNuevo.apellido = txtApellido.Text;
                afiliadoNuevo.mail = txtMail.Text;
                afiliadoNuevo.telefono = Convert.ToDecimal(txtTelefono.Text);
                afiliadoNuevo.direccion = txtDireccion.Text;
                afiliadoNuevo.cantidadFamiliares = 0;
                afiliadoNuevo.estadoCivil = cmbEstadoCivil.Text;
                afiliadoNuevo.fechaNacimiento = dtpFecha.Value;
                afiliadoNuevo.plan = planElegido;
                afiliadoNuevo.sexo = cmbSexo.Text;
                bool anduvo = afiliadoDataAccess.modificarAfiliado(afiliadoModificar.codigoPersona, afiliadoNuevo.telefono, afiliadoNuevo.mail, afiliadoNuevo.estadoCivil, afiliadoNuevo.direccion, afiliadoNuevo.sexo, afiliadoNuevo.plan.codigo);
                if (planElegido.codigo != planactual.codigo)
                {
                    bool anduvo2 = afiliadoDataAccess.agregarModificacion(afiliadoModificar.codigoPersona,txtMotivo.Text,planactual.codigo);
                }
                if (anduvo == true)
                {
                    this.Close();
                }
            }
            else if (opcionelegida == 3) //alta conyuge
            {
                Plan planElegido = (Plan)cmbPlan.SelectedValue;
                Afiliado afiliadoNuevo = new Afiliado();
                afiliadoNuevo.nombre = txtNombre.Text;
                afiliadoNuevo.tipoDocumento = comboBox1.Text.ToString();
                afiliadoNuevo.numeroDocumento = Convert.ToDecimal(txtDni.Text);
                afiliadoNuevo.apellido = txtApellido.Text;
                afiliadoNuevo.mail = txtMail.Text;
                afiliadoNuevo.telefono = Convert.ToDecimal(txtTelefono.Text);
                afiliadoNuevo.direccion = txtDireccion.Text;
                afiliadoNuevo.cantidadFamiliares = 0;
                afiliadoNuevo.estadoCivil = cmbEstadoCivil.Text;
                afiliadoNuevo.fechaNacimiento = dtpFecha.Value;
                afiliadoNuevo.plan = planElegido;
                afiliadoNuevo.sexo = cmbSexo.Text;
                bool anduvo = afiliadoDataAccess.AgregarAfiliado(afiliadoNuevo, 2, afiliadoModificar.numeroAfiliado);
                if (anduvo==true)
                {
                    afiliadoNuevo.codigoPersona = afiliadoDataAccess.obtenerCodigoPersona();
                    bool anduvo2 = usuarioDataAccess.agregarUsuario(afiliadoNuevo.codigoPersona);
                    this.Close();
                }
            }
            else if (opcionelegida == 4) //alta familiar
            {
                Afiliado afiliadoNuevo = new Afiliado();
                Plan planElegido = (Plan)cmbPlan.SelectedValue;
                afiliadoNuevo.nombre = txtNombre.Text;
                afiliadoNuevo.tipoDocumento = comboBox1.Text.ToString();
                afiliadoNuevo.numeroDocumento = Convert.ToDecimal(txtDni.Text);
                afiliadoNuevo.apellido = txtApellido.Text;
                afiliadoNuevo.mail = txtMail.Text;
                afiliadoNuevo.telefono = Convert.ToDecimal(txtTelefono.Text);
                afiliadoNuevo.direccion = txtDireccion.Text;
                afiliadoNuevo.cantidadFamiliares = 0;
                afiliadoNuevo.estadoCivil = cmbEstadoCivil.Text;
                afiliadoNuevo.fechaNacimiento = dtpFecha.Value;
                afiliadoNuevo.plan = planElegido;
                afiliadoNuevo.sexo = cmbSexo.Text;
                decimal ultimoNumero = afiliadoDataAccess.obtenerUltimoCodigoFamilia(afiliadoModificar.numeroAfiliado);
                bool anduvo = afiliadoDataAccess.AgregarAfiliado(afiliadoNuevo, ultimoNumero + 1, afiliadoModificar.numeroAfiliado);
                if (anduvo == true)
                {
                    afiliadoNuevo.codigoPersona = afiliadoDataAccess.obtenerCodigoPersona();
                    bool anduvo2 = usuarioDataAccess.agregarUsuario(afiliadoNuevo.codigoPersona);
                    this.Close();
                }
            }
            MessageBox.Show("Se dio correctamente de alta al afiliado","ALTA CORRECTA",MessageBoxButtons.OK,MessageBoxIcon.Information);      
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Abm_Afiliado.alta formAlta = new Abm_Afiliado.alta(afiliadoNuevoo, 4);
            formAlta.Show();
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            usuarioDataAccess.habilitar(afiliadoModificar.codigoPersona);
            this.Hide();
        }

        private void cmbPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Plan planElegido = (Plan)cmbPlan.SelectedValue;
            if (planactual != null && planElegido != null)
            {
                if (planElegido.codigo != planactual.codigo)
                {
                    lblMotivo.Visible = true;
                    txtMotivo.Visible = true;
                }
                else
                {
                    lblMotivo.Visible = false;
                    txtMotivo.Visible = false;
                }
            }
           
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
