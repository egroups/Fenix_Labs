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
    /// Interaction logic for WindowCambiarPassword.xaml
    /// </summary>
    public partial class WindowCambiarPassword : Window
    {

        AccesoDatos datos = new AccesoDatos("Data Source=SINDECIDIR-PC\\SQLEXPRESS;Initial Catalog=sistema;User ID=admin;Password=123456");
        String username = "";

        public WindowCambiarPassword(String username_login)
        {
            InitializeComponent();
            username = username_login;
        }

        private void btnCambiar_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsuarioActual.Text == "" || txtContraseña.Password == "" || txtNuevaContraseña.Password == "")
            {
                MessageBox.Show("Faltan datos");
            }
            else
            {
                if (datos.ingreso_usuario(txtUsuarioActual.Text, txtContraseña.Password))
                {
                    if (datos.cambiar_contraseña(txtUsuarioActual.Text, txtNuevaContraseña.Password))
                    {
                        MessageBox.Show("La contraseña ha sido cambiada , reinicie la aplicacion");
                        Application.Current.Shutdown();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error en la base de datos");
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
