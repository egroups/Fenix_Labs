// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
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
    /// Interaction logic for WindowCambiarUsuario.xaml
    /// </summary>
    public partial class WindowCambiarUsuario : Window
    {

        AccesoDatos datos = new AccesoDatos("Data Source=SINDECIDIR-PC\\SQLEXPRESS;Initial Catalog=sistema;User ID=admin;Password=123456");
        String username = "";

        public WindowCambiarUsuario(String username_login)
        {
            InitializeComponent();
            username = username_login;
        }

        private void btnCambiar_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsuarioActual.Text == "" || txtContraseña.Password == "" || txtNuevoNombre.Text == "")
            {
                MessageBox.Show("Faltan datos");
            }
            else
            {
                if (datos.ingreso_usuario(txtUsuarioActual.Text, txtContraseña.Password))
                {

                    bool grabar_ready = false;

                    if (datos.comprobar_existencia_usuario_editar(txtNuevoNombre.Text))
                    {
                        grabar_ready = false;
                    }
                    else
                    {
                        grabar_ready = true;
                    }

                    if (grabar_ready)
                    {
                        if (datos.cambiar_usuario(txtUsuarioActual.Text, txtNuevoNombre.Text))
                        {
                            MessageBox.Show("El nombre de usuario ha sido cambiado , reinicie la aplicacion");
                            Application.Current.Shutdown();
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error en la base de datos");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario " + txtNuevoNombre.Text + " ya existe");
                    }
                }
                else
                {
                    MessageBox.Show("Datos incorrectos");
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUsuarioActual.Text = username;
        }
    }
}
