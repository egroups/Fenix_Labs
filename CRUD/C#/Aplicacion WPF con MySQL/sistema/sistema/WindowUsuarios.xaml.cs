// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using aplicacion;

namespace sistema
{
    /// <summary>
    /// Interaction logic for WindowUsuarios.xaml
    /// </summary>
    public partial class WindowUsuarios : Window
    {

        AccesoDatos datos = new AccesoDatos("Data Source=SIN DECIDIR-PC\\SQLEXPRESS;Initial Catalog=sistema;User ID=admin;Password=123456");
        funciones funcion = new funciones();
        bool nuevo = true;

        public WindowUsuarios()
        {
            InitializeComponent();
        }

        public class Usuario
        {
            public int ID { get; set; }
            public string Tipo { get; set; }
            public string Nombre { get; set; }
            public string Fecha { get; set; }
        }

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

                lvUsuarios.Items.Add(new Usuario() { ID = usuario.pId_usuario, Tipo = nombre_tipo, Nombre = usuario.pNombre, Fecha = usuario.pFecha_registro });
            }
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

        private void limpiar()
        {
            txtUsuario.Text = "";
            txtPassword.Password = "";
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
                if (txtPassword.Password == "")
                {
                    MessageBox.Show("Ingrese contraseña");
                    txtPassword.Focus();
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

                String password = funciones.md5_encode(txtPassword.Password);

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
                            MessageBox.Show("Registro agregado");
                            status.Content = "[+] Registro agregado";
                        }
                        else
                        {
                            MessageBox.Show("Registro actualizado");
                            status.Content = "[+] Registro actualizado";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error en la base de datos");
                        status.Content = "[-] Ha ocurrido un error en la base de datos";
                    }
                }
                else
                {
                    MessageBox.Show("El usuario " + u.pNombre + " ya existe");
                    status.Content = "[-] El usuario " + u.pNombre + " ya existe";
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
            txtPassword.Password = "";

            txtID.IsEnabled = true;
            txtUsuario.IsEnabled = true;
            txtPassword.IsEnabled = true;

            cmbTipo.SelectedIndex = 0;

            status.Content = "[+] Programa en modo nuevo";
            limpiar();
            MessageBox.Show("Programa cargado en modo nuevo");

        }

        private void editar()
        {

            nuevo = false;

            txtID.IsEnabled = false;
            txtUsuario.IsEnabled = false;
            txtPassword.IsEnabled = false;

            status.Content = "[+] Programa en modo editar";
            nuevo = false;
            MessageBox.Show("Programa cargado en modo editar");
        }

        private void borrar()
        {
            int id_usuario = 0;

            if (lvUsuarios.SelectedItems.Count > 0)
            {
                Usuario usuario_load = (Usuario)lvUsuarios.SelectedItems[0];
                id_usuario = usuario_load.ID;
            }

            Usuarios usuario = datos.cargarUsuario(id_usuario);

            if (MessageBox.Show("Seguro de borrar a " + usuario.pNombre, "Borrar registro", MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
            {
                lvUsuarios.Items.Clear();

                string sql = "delete from usuarios where id_usuario=" + usuario.pId_usuario;

                if (datos.CargarConsulta(sql))
                {
                    MessageBox.Show("Registro borrado");
                    status.Content = "[+] Registro borrado";
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error en la base de datos");
                    status.Content = "[-] Ha ocurrido un error en la base de datos";
                }

                cargarUsuarios();
                limpiar();

            }
        }

        private void asignar(string tipo_usuario)
        {
            int id_usuario = 0;

            if (lvUsuarios.SelectedItems.Count > 0)
            {
                Usuario usuario_load = (Usuario)lvUsuarios.SelectedItems[0];
                id_usuario = usuario_load.ID;
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

            if (MessageBox.Show("Seguro de asignar como " + rango + " a " + nombre_usuario, "Asignar", MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
            {
                lvUsuarios.Items.Clear();

                String sql = "update usuarios set tipo=" + tipo + " where usuario='" + nombre_usuario + "'";

                if (datos.CargarConsulta(sql))
                {
                    status.Content = "[+] Asignacion realizada";
                    MessageBox.Show("Asignacion realizada");
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error en la base de datos");
                    status.Content = "[-] Ha ocurrido un error en la base de datos";
                }

                cargarUsuarios();

                limpiar();

            }
        }

        private void recargarLista()
        {
            cargarUsuarios();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            recargarLista();
        }

        private void lvUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvUsuarios.SelectedItems.Count > 0)
            {
                Usuario usuario = (Usuario)lvUsuarios.SelectedItems[0];
                CargarCamposUsuario(usuario.ID);
            }
        }

        private void ItemAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            agregar();
        }

        private void ItemEditarUsuario_Click(object sender, RoutedEventArgs e)
        {
            editar();
        }

        private void ItemBorrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            borrar();
        }

        private void ItemCancelar_Click(object sender, RoutedEventArgs e)
        {
            //cancelar();
        }

        private void ItemRecargarLista_Click(object sender, RoutedEventArgs e)
        {
            recargarLista();
        }

        private void ItemGrabar_Click(object sender, RoutedEventArgs e)
        {
            grabar();
        }

        private void ItemAsignarUsuario_Click(object sender, RoutedEventArgs e)
        {
            asignar("user");
        }

        private void ItemAsignarAdministrador_Click(object sender, RoutedEventArgs e)
        {
            asignar("admin");
        }

        private void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            grabar();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            recargarLista();
        }

        private void ItemAgregarUsuario2_Click(object sender, RoutedEventArgs e)
        {
            agregar();
        }

        private void ItemEditarUsuario2_Click(object sender, RoutedEventArgs e)
        {
            editar();
        }

        private void ItemAsignarUsuario2_Click(object sender, RoutedEventArgs e)
        {
            asignar("user");
        }

        private void ItemAsignarAdministrador2_Click(object sender, RoutedEventArgs e)
        {
            asignar("admin");
        }

        private void ItemBorrarUsuario2_Click(object sender, RoutedEventArgs e)
        {
            borrar();
        }

        private void ItemCancelar2_Click(object sender, RoutedEventArgs e)
        {
            //cancelar();
        }

        private void ItemRecargarLista2_Click(object sender, RoutedEventArgs e)
        {
            recargarLista();
        }

        private void ItemGrabar2_Click(object sender, RoutedEventArgs e)
        {
            grabar();
        }
    }
}
