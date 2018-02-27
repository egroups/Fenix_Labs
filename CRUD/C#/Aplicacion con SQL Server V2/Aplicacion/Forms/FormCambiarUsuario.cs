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
    public partial class FormCambiarUsuario : Form
    {

        UsuarioDatos usuarioDatos = new UsuarioDatos();
        Funciones funcion = new Funciones();
        String usuario = "";

        public FormCambiarUsuario(String usuario_recibido)
        {
            InitializeComponent();
            usuario = usuario_recibido;
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if (txtUsuarioActual.Text == "" || txtClave.Text == "" || txtNuevoNombre.Text == "")
            {
                MessageBox.Show("Faltan datos");
            }
            else
            {
                string usuario = txtUsuarioActual.Text;
                string clave = funcion.md5_encode(txtClave.Text);
                string nuevo_nombre = txtNuevoNombre.Text;

                int id = usuarioDatos.get_id_by_user(usuario);

                if (usuarioDatos.check_login(usuario,clave))
                {

                    bool grabar_ready = false;

                    if (usuarioDatos.check_exists_usuario_add(nuevo_nombre))
                    {
                        grabar_ready = false;
                    }
                    else
                    {
                        grabar_ready = true;
                    }

                    if (grabar_ready)
                    {
                        if (usuarioDatos.change_username(id,nuevo_nombre))
                        {
                            MessageBox.Show("El nombre de usuario ha sido cambiado , reinicie la aplicación");
                            Application.Exit();
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error en la base de datos");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario " + nuevo_nombre + " ya existe");
                    }
                }
                else
                {
                    MessageBox.Show("Login inválido");
                }
            }
        }

        private void FormCambiarUsuario_Load(object sender, EventArgs e)
        {
            txtUsuarioActual.Text = usuario;
        }
    }
}
