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
    public partial class FormCambiarContraseña : Telerik.WinControls.UI.RadForm
    {

        AccesoDatos datos = new AccesoDatos("Data Source=localhost\\SQLEXPRESS;Initial Catalog=sistema;User ID=admin;Password=123456");
        String username = "";

        public FormCambiarContraseña(String username_login)
        {
            InitializeComponent();
            username = username_login;
        }

        private void FormCambiarContraseña_Load(object sender, EventArgs e)
        {
            txtUsuarioActual.Text = username;
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            if (txtUsuarioActual.Text == "" || txtContraseña.Text == "" || txtNuevaContraseña.Text == "")
            {
                MessageBox.Show("Faltan datos");
            }
            else
            {
                if (datos.ingreso_usuario(txtUsuarioActual.Text, txtContraseña.Text))
                {
                    if (datos.cambiar_contraseña(txtUsuarioActual.Text, txtNuevaContraseña.Text))
                    {
                        MessageBox.Show("La contraseña ha sido cambiada , reinicie la aplicacion");
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error en la base de datos");
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
