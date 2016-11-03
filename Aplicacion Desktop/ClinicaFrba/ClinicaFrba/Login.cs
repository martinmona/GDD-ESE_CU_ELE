﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFrba.Class;

namespace ClinicaFrba
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                MessageBox.Show("Debe ingresar su nombre de usuario");
                txtuser.Focus();
                return;
            }
            if (txtpass.Text == "")
            {
                MessageBox.Show("Debe ingresar su clave");
                txtpass.Focus();
                return;
            }

            if (txtuser.Text != "" && txtpass.Text != "")
            {
                decimal idUser = usuarioDataAccess.verificarUsuario(txtuser.Text);
                if (idUser == -1)
                {
                    MessageBox.Show("El usuario no existe o esta deshabilitado", "Error");
                    return;
                }
                else 
                { 
                    IlanUsuario myuser = usuarioDataAccess.login(txtuser.Text, txtpass.Text);
                    if (myuser.id == -1)//No existe el usuario
                    {
                        int intentos = usuarioDataAccess.sumarIntentoFallido(idUser);
                        if (intentos == -1)
                        {
                            MessageBox.Show("Fallo la conexion a la BD", "Error");
                        }
                        else
                        {
                            if (intentos == 3)
                            {
                                if (usuarioDataAccess.deshabilitar(idUser))
                                {
                                    MessageBox.Show("El usuario y contraseña no coinciden. Se Deshabilito al usuario", "Error");
                                    txtuser.Text = "";
                                    txtpass.Text = "";
                                    txtuser.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Fallo la conexion a la BD", "Error");
                                }
                            }
                            else
                            {
                                MessageBox.Show("El usuario y contraseña no coinciden. Vuelva a intentarlo, tiene " + intentos.ToString() + " fallidos", "Error");
                                txtuser.Text = "";
                                txtpass.Text = "";
                                txtuser.Focus();
                            }
                            
                        }
                        
                    }
                    else
                    {
                        //ENTRO, AHORA LOS ROLES
                        if (usuarioDataAccess.resetIntentos(idUser))
                        {
                            List<IlanRol> roles = rolDataAccess.ObtenerRolesPorUsuario(idUser);
                            
                            if (roles.Count() > 1) //Si tiene mas de un rol, debe seleccionar con cual entrar 
                            {
                                MessageBox.Show("Se ingresó al sistema, seleccione un rol");
                                cmbRoles.Visible = true;
                                btnRol.Visible = true;
                                lblRol.Visible = true;
                                btnlogin.Enabled = false;
                                txtpass.Enabled = false;
                                txtuser.Enabled = false;
                                cmbRoles.DataSource = roles;
                                cmbRoles.DisplayMember = "nombre";
                                cmbRoles.ValueMember = "id";
                                cmbRoles.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Se ingresó al sistema");
                                IlanRol rol = roles[0];
                                irAForm(rol.id);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Fallo la conexion a la BD", "Error");
                        }
                    }
                }
            }
            else
            {
                txtuser.Text = "";
                txtpass.Text = "";
                txtuser.Focus();
            }
        }

        private void irAForm(decimal idRol) 
        {
            FrmFuncionalidad frmFunc = new FrmFuncionalidad(idRol);
            frmFunc.Show();
            this.Hide();
        }

        private void btnRol_Click(object sender, EventArgs e)
        {
            decimal idRol = (decimal)cmbRoles.SelectedValue;
            irAForm(idRol);
        }
    }
}
