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
    public partial class FormHome : Form
    {
        UsuarioDatos usuarioDatos = new UsuarioDatos();
        String usuario = "";

        public FormHome(string usuario_recibido)
        {
            InitializeComponent();
            usuario = usuario_recibido;
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            if (usuarioDatos.get_user_type(usuario)=="Administrador")
            {
                ItemUsuarios.Enabled = true;
            }
            else
            {
                ItemUsuarios.Enabled = false;
            }
        }

        private void ItemProductos_Click(object sender, EventArgs e)
        {
            FormProductos form = new FormProductos();
            form.Show();
        }

        private void ItemProveedores_Click(object sender, EventArgs e)
        {
            FormProveedores form = new FormProveedores();
            form.Show();
        }

        private void ItemSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿ Esta seguro de salir del programa ?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FormHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ItemCambiarNombreDeUsuario_Click(object sender, EventArgs e)
        {
            FormCambiarUsuario formCambiarUsuario = new FormCambiarUsuario(usuario);
            formCambiarUsuario.Show();
        }

        private void ItemCambiarClave_Click(object sender, EventArgs e)
        {
            FormCambiarClave formCambiarContraseña = new FormCambiarClave(usuario);
            formCambiarContraseña.Show();
        }

        private void ItemUsuarios_Click(object sender, EventArgs e)
        {
            FormUsuarios formUsuarios = new FormUsuarios();
            formUsuarios.Show();
        }

        private void tsEstadisticas_Click(object sender, EventArgs e)
        {
            FormReporte formReporte = new FormReporte();
            formReporte.Show();
        }
    }
}
