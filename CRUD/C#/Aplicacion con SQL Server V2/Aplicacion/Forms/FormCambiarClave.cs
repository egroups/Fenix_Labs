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
    public partial class FormCambiarClave : Form
    {

        UsuarioDatos usuarioDatos = new UsuarioDatos();
        Funciones funcion = new Funciones();
        String usuario = "";

        public FormCambiarClave(String usuario_recibido)
        {
            InitializeComponent();
            usuario = usuario_recibido;
        }

        private void FormCambiarContraseña_Load(object sender, EventArgs e)
        {
            txtUsuarioActual.Text = usuario;
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {

            if (txtUsuarioActual.Text == "" || txtClave.Text == "" || txtNuevaClave.Text == "")
            {
                MessageBox.Show("Faltan datos");
            }
            else
            {
                string usuario = txtUsuarioActual.Text;
                string clave = funcion.md5_encode(txtClave.Text);
                string nueva_clave = funcion.md5_encode(txtNuevaClave.Text);

                int id = usuarioDatos.get_id_by_user(usuario);

                if (usuarioDatos.check_login(usuario,clave))
                {
                    if (usuarioDatos.change_password(id, nueva_clave))
                    {
                        MessageBox.Show("La clave ha sido cambiada , reinicie la aplicación");
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error en la base de datos");
                    }
                }
                else
                {
                    MessageBox.Show("Login inválido");
                }
            }
        }
    }
}
