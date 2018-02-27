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
    /// Interaction logic for WindowHome.xaml
    /// </summary>
    public partial class WindowHome : Window
    {

        AccesoDatos datos = new AccesoDatos("Data Source=SIN DECIDIR-PC\\SQLEXPRESS;Initial Catalog=sistema;User ID=admin;Password=123456");
        String username = "";

        public WindowHome(string username_login)
        {
            InitializeComponent();
            username = username_login;  
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (datos.es_admin(username))
            {
                ItemUsuarios.IsEnabled = true;
            }
            else
            {
                ItemUsuarios.IsEnabled = false;
            }
        }

        private void ItemProductos_Click(object sender, RoutedEventArgs e)
        {
            WindowProductos form = new WindowProductos();
            form.Show();
        }

        private void ItemProveedores_Click(object sender, RoutedEventArgs e)
        {
            WindowProveedores form = new WindowProveedores();
            form.Show();
        }

        private void ItemUsuarios_Click(object sender, RoutedEventArgs e)
        {
            WindowUsuarios formUsuarios = new WindowUsuarios();
            formUsuarios.Show();
        }

        private void ItemCambiarNombre_Click(object sender, RoutedEventArgs e)
        {
            WindowCambiarUsuario formCambiarUsuario = new WindowCambiarUsuario(username);
            formCambiarUsuario.Show();
        }

        private void ItemCambiarPassword_Click(object sender, RoutedEventArgs e)
        {
            WindowCambiarPassword formCambiarContraseña = new WindowCambiarPassword(username);
            formCambiarContraseña.Show();
        }

        private void ItemSalir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Esta seguro de salir", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ItemEstadisticas_Click(object sender, RoutedEventArgs e)
        {
            WindowReporte formReporte = new WindowReporte();
            formReporte.Show();
        }

    }
}
