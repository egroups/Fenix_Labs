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
    public partial class FormHome : Telerik.WinControls.UI.RadForm
    {

        AccesoDatos datos = new AccesoDatos("Data Source=localhost\\SQLEXPRESS;Initial Catalog=sistema;User ID=admin;Password=123456");
        String username = "";

        public FormHome(string username_login)
        {
            InitializeComponent();
            username = username_login;
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            if (datos.es_admin(username))
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

        private void ItemUsuarios_Click(object sender, EventArgs e)
        {
            FormUsuarios form = new FormUsuarios();
            form.Show();
        }

        private void ItemCambiarUsuario_Click(object sender, EventArgs e)
        {
            FormCambiarUsuario form = new FormCambiarUsuario(username);
            form.Show();
        }

        private void ItemCambiarPassword_Click(object sender, EventArgs e)
        {
            FormCambiarContraseña form = new FormCambiarContraseña(username);
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

        private void ItemEstadisticas_Click(object sender, EventArgs e)
        {
            FormReporte form = new FormReporte();
            form.Show();
        }
    }
}
