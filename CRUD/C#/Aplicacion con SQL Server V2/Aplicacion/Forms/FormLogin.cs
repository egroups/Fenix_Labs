// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Aplicacion.Data;

namespace aplicacion
{
    public partial class FormLogin : Form
    {

        UsuarioDatos usuarioDatos = new UsuarioDatos();
        Funciones funcion = new Funciones();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtClave.Text == "")
            {
                MessageBox.Show("Faltan datos");
            }
            else
            {
                string usuario = txtUsuario.Text;
                string clave = funcion.md5_encode(txtClave.Text);

                if (usuarioDatos.check_login(usuario,clave))
                {
                    if (usuarioDatos.get_user_type(usuario)=="Administrador")
                    {
                        MessageBox.Show("Bienvenido administrador " + usuario + " al sistema");
                    }
                    else
                    {
                        MessageBox.Show("Bienvenido usuario " + usuario + " al sistema");
                    }

                    FormLogin.ActiveForm.Hide();

                    FormHome formHome = new FormHome(txtUsuario.Text);
                    formHome.Show();
                }
                else
                {
                    MessageBox.Show("Login inválido");
                }

            }
        }
    }
}
