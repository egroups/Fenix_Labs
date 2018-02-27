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
    public partial class FormLogin : Telerik.WinControls.UI.RadForm
    {

        AccesoDatos datos = new AccesoDatos("Data Source=localhost\\SQLEXPRESS;Initial Catalog=sistema;User ID=admin;Password=123456");

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtPassword.Text == "")
            {
                RadMessageBox.Show("Datos incorrectos");
            }
            else
            {

                if (datos.ingreso_usuario(txtUsuario.Text, txtPassword.Text))
                {
                    if (datos.es_admin(txtUsuario.Text))
                    {
                        RadMessageBox.Show("Bienvenido administrador " + txtUsuario.Text + " al sistema");

                        FormLogin.ActiveForm.Hide();

                        FormHome formHome = new FormHome(txtUsuario.Text);
                        formHome.Show();
                    }
                    else
                    {
                        RadMessageBox.Show("Bienvenido usuario " + txtUsuario.Text + " al sistema");

                        FormLogin.ActiveForm.Hide();

                        FormHome formHome = new FormHome(txtUsuario.Text);
                        formHome.Show();
                    }
                }
                else
                {
                    RadMessageBox.Show("Datos incorrectos");
                }

            }
        }
    }
}
