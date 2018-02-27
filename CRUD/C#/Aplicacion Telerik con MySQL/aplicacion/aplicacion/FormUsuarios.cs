// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace aplicacion
{
    public partial class FormUsuarios : Telerik.WinControls.UI.RadForm
    {

        AccesoDatos datos = new AccesoDatos("Data Source=localhost\\SQLEXPRESS;Initial Catalog=sistema;User ID=admin;Password=123456");
        funciones funcion = new funciones();
        bool nuevo = true;

        public FormUsuarios()
        {
            InitializeComponent();
        }

        // Funciones

        private void cargarUsuarios()
        {

            lvUsuarios.Items.Clear();

            string nombre_buscar = txtBuscar.Text;

            ArrayList listaUsuarios = datos.cargarListaUsuarios(nombre_buscar);

            foreach (Usuarios usuario in listaUsuarios)
            {

                int tipo = usuario.pTipo;
                String nombre_tipo = "";

                if (tipo == 1)
                {
                    nombre_tipo = "Administrador";
                }
                else
                {
                    nombre_tipo = "Usuario";
                }

                ListViewDataItem item = new ListViewDataItem();
                item.SubItems.Add(Convert.ToString(nombre_tipo));
                item.SubItems.Add(Convert.ToString(usuario.pNombre));
                item.SubItems.Add(Convert.ToString(usuario.pFecha_registro));
                item.Tag = Convert.ToString(usuario.pId_usuario);
                lvUsuarios.Items.Add(item);
            }
        }

        private void limpiar()
        {
            txtUsuario.Text = "";
            txtPassword.Text = "";
            cmbTipo.SelectedIndex = -1;
        }

        private void recargarLista()
        {
            cargarUsuarios();
        }

        private bool validar()
        {

            if (txtUsuario.Text == "")
            {
                RadMessageBox.Show("Ingrese nombre de usuario");
                txtUsuario.Focus();
                return false;
            }
            if (nuevo)
            {
                if (txtPassword.Text == "")
                {
                    RadMessageBox.Show("Ingrese contraseña");
                    txtPassword.Focus();
                    return false;
                }
            }
            if (cmbTipo.SelectedIndex == -1)
            {
                RadMessageBox.Show("Seleccione tipo");
                cmbTipo.Focus();
                return false;
            }

            return true;
        }

        private void cargarCombo(ComboBox combo, string tabla)
        {

            DataTable dt = new DataTable();
            dt = datos.consultarTabla(tabla);
            combo.DataSource = datos.consultarTabla(tabla);
            combo.ValueMember = dt.Columns[0].ColumnName;
            combo.DisplayMember = dt.Columns[1].ColumnName;
        }

        private void CargarCamposUsuario(int id_usuario)
        {
            Usuarios usuario = datos.cargarUsuario(id_usuario);
            txtID.Text = Convert.ToString(usuario.pId_usuario);
            txtUsuario.Text = usuario.pNombre;

            if (usuario.pTipo == 1)
            {
                cmbTipo.SelectedIndex = 1;
            }
            else
            {
                cmbTipo.SelectedIndex = 0;
            }
        }

        private void grabar()
        {
            if (validar())
            {

                int tipo = 0;

                if (cmbTipo.SelectedIndex == 1)
                {
                    tipo = 1;
                }
                else
                {
                    tipo = 2;
                }

                Usuarios u = new Usuarios();
                funciones funciones = new funciones();

                String password = funciones.md5_encode(txtPassword.Text);

                u.pNombre = txtUsuario.Text;
                u.pPassword = password;
                u.pTipo = tipo;
                u.pFecha_registro = funcion.fecha_del_dia();

                String sql = "";

                if (nuevo)
                {
                    sql = "insert into usuarios(usuario,clave,tipo,fecha_registro) values('" + u.pNombre + "','" + u.pPassword + "'," + u.pTipo + ",'" + u.pFecha_registro + "')";
                }
                else
                {
                    sql = "update usuarios set tipo=" + tipo + " where usuario='" + u.pNombre + "'";
                }

                bool grabar_ready = false;

                if (nuevo)
                {
                    if (datos.comprobar_existencia_usuario_crear(u.pNombre))
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
                    if (datos.CargarConsulta(sql))
                    {
                        if (nuevo)
                        {
                            RadMessageBox.Show("Registro agregado");
                            status.Text = "[+] Registro agregado";
                            this.Refresh();
                        }
                        else
                        {
                            RadMessageBox.Show("Registro actualizado");
                            status.Text = "[+] Registro actualizado";
                            this.Refresh();
                        }
                    }
                    else
                    {
                        RadMessageBox.Show("Ha ocurrido un error en la base de datos");
                        status.Text = "[-] Ha ocurrido un error en la base de datos";
                        this.Refresh();
                    }
                }
                else
                {
                    RadMessageBox.Show("El usuario " + u.pNombre + " ya existe");
                    status.Text = "[-] El usuario " + u.pNombre + " ya existe";
                    this.Refresh();
                }

                cargarUsuarios();
                limpiar();

            }
        }

        private void agregar()
        {

            nuevo = true;

            txtID.Text = "";
            txtUsuario.Text = "";
            txtPassword.Text = "";

            txtID.Enabled = true;
            txtUsuario.Enabled = true;
            txtPassword.Enabled = true;

            cmbTipo.SelectedIndex = 0;

            status.Text = "[+] Programa en modo nuevo";
            this.Refresh();
            limpiar();
            RadMessageBox.Show("Programa cargado en modo nuevo");

        }

        private void editar()
        {

            nuevo = false;

            txtID.Enabled = false;
            txtUsuario.Enabled = false;
            txtPassword.Enabled = false;

            status.Text = "[+] Programa en modo editar";
            this.Refresh();
            nuevo = false;
            RadMessageBox.Show("Programa cargado en modo editar");
        }

        private void borrar()
        {
            int id_usuario = 0;

            if (lvUsuarios.SelectedIndex != -1)
            {
                id_usuario = Convert.ToInt32((lvUsuarios.SelectedItems[0].Tag));
            }

            Usuarios usuario = datos.cargarUsuario(id_usuario);

            if (MessageBox.Show("Seguro de borrar a " + usuario.pNombre, "Borrar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                lvUsuarios.Items.Clear();

                string sql = "delete from usuarios where id_usuario=" + usuario.pId_usuario;

                if (datos.CargarConsulta(sql))
                {
                    RadMessageBox.Show("Registro borrado");
                    status.Text = "[+] Registro borrado";
                    this.Refresh();

                }
                else
                {
                    RadMessageBox.Show("Ha ocurrido un error en la base de datos");
                    status.Text = "[-] Ha ocurrido un error en la base de datos";
                    this.Refresh();
                }

                cargarUsuarios();
                limpiar();

            }
        }

        private void asignar(string tipo_usuario)
        {
            int id_usuario = 0;

            if (lvUsuarios.SelectedIndex != -1)
            {
                id_usuario = Convert.ToInt32((lvUsuarios.SelectedItems[0].Tag));
            }

            Usuarios usuario = datos.cargarUsuario(id_usuario);

            String nombre_usuario = usuario.pNombre;

            int tipo = 0;
            String rango = "";

            if (tipo_usuario == "admin")
            {
                tipo = 1;
                rango = "Administrador";
            }
            else if (tipo_usuario == "user")
            {
                tipo = 2;
                rango = "Usuario";
            }
            else
            {
                tipo = 2;
                rango = "Usuario";
            }

            if (MessageBox.Show("Seguro de asignar como " + rango + " a " + nombre_usuario, "Asignar", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                lvUsuarios.Items.Clear();

                String sql = "update usuarios set tipo=" + tipo + " where usuario='" + nombre_usuario + "'";

                if (datos.CargarConsulta(sql))
                {
                    status.Text = "[+] Asignacion realizada";
                    this.Refresh();

                    RadMessageBox.Show("Asignacion realizada");
                }
                else
                {
                    RadMessageBox.Show("Ha ocurrido un error en la base de datos");
                    status.Text = "[-] Ha ocurrido un error en la base de datos";
                    this.Refresh();
                }

                cargarUsuarios();

                limpiar();

            }
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = 0;
            recargarLista();
        }

        private void lvUsuarios_SelectedItemChanged(object sender, EventArgs e)
        {
            if (lvUsuarios.SelectedIndex != -1)
            {
                CargarCamposUsuario(Convert.ToInt32((lvUsuarios.SelectedItems[0].Tag)));
            }
        }

        private void ItemAgregarUsuario_Click(object sender, EventArgs e)
        {
            agregar();
        }

        private void ItemEditarUsuario_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void ItemBorrarUsuario_Click(object sender, EventArgs e)
        {
            borrar();
        }

        private void ItemCancelar_Click(object sender, EventArgs e)
        {
            //cancelar();
        }

        private void ItemRecargarLista_Click(object sender, EventArgs e)
        {
            recargarLista();
        }

        private void ItemGrabar_Click(object sender, EventArgs e)
        {
            grabar();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            grabar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            recargarLista();
        }

        private void ItemCambiarTipoUsuario_Click(object sender, EventArgs e)
        {
            //
        }

        private void ItemUsuario_Click(object sender, EventArgs e)
        {
            asignar("user");
        }

        private void ItemAdministrador_Click(object sender, EventArgs e)
        {
            asignar("admin");
        }
    }
}
