// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace aplicacion
{
    public partial class FormCambiarUsuario : Telerik.WinControls.UI.RadForm
    {
        AccesoDatos datos = new AccesoDatos("Data Source=localhost\\SQLEXPRESS;Initial Catalog=sistema;User ID=admin;Password=123456");
        String username = "";

        public FormCambiarUsuario(String username_login)
        {
            InitializeComponent();
            username = username_login;
        }

        private void FormCambiarUsuario_Load(object sender, EventArgs e)
        {
            txtUsuarioActual.Text = username;
        }

        private void btnCambiarUsuario_Click(object sender, EventArgs e)
        {
            if (txtUsuarioActual.Text == "" || txtContraseña.Text == "" || txtNuevoNombre.Text == "")
            {
                MessageBox.Show("Faltan datos");
            }
            else
            {
                if (datos.ingreso_usuario(txtUsuarioActual.Text, txtContraseña.Text))
                {

                    bool grabar_ready = false;

                    if (datos.comprobar_existencia_usuario_editar(txtNuevoNombre.Text))
                    {
                        grabar_ready = false;
                    }
                    else
                    {
                        grabar_ready = true;
                    }

                    if (grabar_ready)
                    {
                        if (datos.cambiar_usuario(txtUsuarioActual.Text, txtNuevoNombre.Text))
                        {
                            MessageBox.Show("El nombre de usuario ha sido cambiado , reinicie la aplicacion");
                            Application.Exit();
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error en la base de datos");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario " + txtNuevoNombre.Text + " ya existe");
                    }
                }
                else
                {
                    MessageBox.Show("Datos incorrectos");
                }
            }
        }
    }
}
