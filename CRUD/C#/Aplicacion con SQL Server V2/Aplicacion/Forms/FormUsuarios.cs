// Written By Ismael Heredia in the year 2017

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Aplicacion.Models;
using Aplicacion.Data;

namespace aplicacion
{
    public partial class FormUsuarios : Form
    {
        UsuarioDatos usuarioDatos = new UsuarioDatos();
        TipoUsuarioDatos tipoUsuarioDatos = new TipoUsuarioDatos();
        Funciones funcion = new Funciones();
        bool nuevo = true;

        public FormUsuarios()
        {
            InitializeComponent();
        }

        // Funciones

        private void cargarListaUsuarios()
        {

            lvUsuarios.Items.Clear();

            string nombre_buscar = txtBuscar.Text;

            List<Usuario> listaUsuarios = usuarioDatos.List(nombre_buscar);

            foreach (Usuario usuario in listaUsuarios)
            {
                ListViewItem item = new ListViewItem();
                item.Text = usuario.tipo.nombre;
                item.SubItems.Add(usuario.nombre);
                item.SubItems.Add(usuario.fecha_registro);
                item.Tag = usuario.id;
                lvUsuarios.Items.Add(item);
            }
        }

        private void limpiar()
        {
            txtUsuario.Text = "";
            txtClave.Text = "";
            cmbTipo.SelectedIndex = -1;
        }

        private bool validar()
        {

            if (txtUsuario.Text == "")
            {
                MessageBox.Show("Ingrese nombre de usuario");
                txtUsuario.Focus();
                return false;
            }
            if (nuevo)
            {
                if (txtClave.Text == "")
                {
                    MessageBox.Show("Ingrese clave");
                    txtClave.Focus();
                    return false;
                }
            }
            if (cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione tipo");
                cmbTipo.Focus();
                return false;
            }

            return true;
        }

        private void cargarComboTipoUsuario()
        {
            cmbTipo.DataSource = tipoUsuarioDatos.List("");
            cmbTipo.ValueMember = "id";
            cmbTipo.DisplayMember = "nombre";
        }

        private void CargarCamposUsuario(int id)
        {
            Usuario usuario = usuarioDatos.Get(id);
            txtID.Text = usuario.id.ToString();
            txtUsuario.Text = usuario.nombre;

            if (usuario.tipo.id == 1)
            {
                cmbTipo.SelectedIndex = 0;
            }
            else
            {
                cmbTipo.SelectedIndex = 1;
            }
        }

        private void grabar()
        {
            if (validar())
            {

                Usuario usuario = new Usuario();
                Funciones funciones = new Funciones();

                String clave = funciones.md5_encode(txtClave.Text);

                if (txtID.Text != "")
                {
                    usuario.id = Convert.ToInt32(txtID.Text);
                }
                usuario.nombre = txtUsuario.Text;
                usuario.clave = funcion.md5_encode(txtClave.Text);
                usuario.id_tipo = Convert.ToInt32(cmbTipo.SelectedValue);
                usuario.fecha_registro = funcion.fecha_del_dia();

                bool grabar_ready = false;

                if (nuevo)
                {
                    if (usuarioDatos.check_exists_usuario_add(usuario.nombre))
                    {
                        grabar_ready = false;
                    }
                    else
                    {
                        grabar_ready = true;
                    }
                }
                else
                {
                    grabar_ready = true;
                }

                if (grabar_ready)
                {
                    if (nuevo)
                    {
                        if (usuarioDatos.Add(usuario))
                        {
                            MessageBox.Show("Registro agregado");
                            tsStatus.Text = "[+] Registro agregado";
                            this.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error en la base de datos");
                            tsStatus.Text = "[-] Ha ocurrido un error en la base de datos";
                            this.Refresh();
                        }
                    }
                    else
                    {
                        if (usuarioDatos.Update(usuario))
                        {
                            MessageBox.Show("Registro actualizado");
                            tsStatus.Text = "[+] Registro actualizado";
                            this.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error en la base de datos");
                            tsStatus.Text = "[-] Ha ocurrido un error en la base de datos";
                            this.Refresh();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El usuario " + usuario.nombre + " ya existe");
                    tsStatus.Text = "[-] El usuario " + usuario.nombre + " ya existe";
                    this.Refresh();
                }

                cargarListaUsuarios();
                limpiar();

            }
        }

        private void agregar()
        {

            nuevo = true;

            txtID.Text = "";
            txtUsuario.Text = "";
            txtClave.Text = "";

            txtID.Enabled = true;
            txtUsuario.Enabled = true;
            txtClave.Enabled = true;

            cmbTipo.SelectedIndex = 0;

            tsStatus.Text = "[+] Programa en modo nuevo";
            this.Refresh();
            limpiar();
            MessageBox.Show("Programa cargado en modo nuevo");

        }

        private void editar()
        {

            nuevo = false;

            txtID.Enabled = false;
            txtUsuario.Enabled = false;
            txtClave.Enabled = false;

            tsStatus.Text = "[+] Programa en modo editar";
            this.Refresh();
            nuevo = false;
            MessageBox.Show("Programa cargado en modo editar");
        }

        private void borrar()
        {
            int id = 0;

            if (lvUsuarios.SelectedIndices.Count > 0 && lvUsuarios.SelectedIndices[0] != -1)
            {
                id = Convert.ToInt32((lvUsuarios.SelectedItems[0].Tag));
            }

            Usuario usuario = usuarioDatos.Get(id);

            if (MessageBox.Show("Seguro de borrar a " + usuario.nombre, "Borrar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                lvUsuarios.Items.Clear();

                if (usuarioDatos.Delete(usuario))
                {
                    MessageBox.Show("Registro borrado");
                    tsStatus.Text = "[+] Registro borrado";
                    this.Refresh();

                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error en la base de datos");
                    tsStatus.Text = "[-] Ha ocurrido un error en la base de datos";
                    this.Refresh();
                }

                cargarListaUsuarios();
                limpiar();

            }
        }

        private void asignar(string tipo_usuario)
        {
            int id = 0;

            if (lvUsuarios.SelectedIndices.Count > 0 && lvUsuarios.SelectedIndices[0] != -1)
            {
                id = Convert.ToInt32((lvUsuarios.SelectedItems[0].Tag));
            }

            Usuario usuario = usuarioDatos.Get(id);

            String nombre_usuario = usuario.nombre;

            int id_tipo = 0;
            String rango = "";

            if (tipo_usuario == "admin")
            {
                id_tipo = 1;
                rango = "Administrador";
            }
            else if (tipo_usuario == "user")
            {
                id_tipo = 2;
                rango = "Usuario";
            }
            else
            {
                id_tipo = 2;
                rango = "Usuario";
            }

            usuario.id_tipo = id_tipo;

            if (MessageBox.Show("Seguro de asignar como " + rango + " a " + nombre_usuario, "Asignar", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                lvUsuarios.Items.Clear();

                if (usuarioDatos.Update(usuario))
                {
                    tsStatus.Text = "[+] Asignacion realizada";
                    this.Refresh();

                    limpiar();

                    MessageBox.Show("Asignacion realizada");
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error en la base de datos");
                    tsStatus.Text = "[-] Ha ocurrido un error en la base de datos";
                    this.Refresh();
                }

                cargarListaUsuarios();
            }
        }


        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            cargarComboTipoUsuario();
            cargarListaUsuarios();
        }

        private void recargarListaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cargarListaUsuarios();
        }

        private void eliminarUsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            borrar();
        }

        private void usuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            asignar("user");
        }

        private void administradorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            asignar("admin");
        }

        private void agregarUsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            agregar();
        }

        private void agregarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agregar();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            asignar("user");
        }

        private void administradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            asignar("admin");
        }

        private void eliminarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            borrar();
        }

        private void recargarListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarListaUsuarios();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            grabar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarListaUsuarios();
        }

        private void lvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvUsuarios.SelectedIndices.Count > 0 && lvUsuarios.SelectedIndices[0] != -1)
            {
                CargarCamposUsuario(Convert.ToInt32((lvUsuarios.SelectedItems[0].Tag)));
            }
        }

        private void editarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void editarUsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void grabarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            grabar();
        }

        private void grabarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grabar();
        }
    }
}
