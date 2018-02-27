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
using System.Windows.Navigation;
using System.Windows.Shapes;

using aplicacion;

namespace sistema
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        AccesoDatos datos = new AccesoDatos("Data Source=SINDECIDIR-PC\\SQLEXPRESS;Initial Catalog=sistema;User ID=admin;Password=123456");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsuario.Text == "" || txtPassword.Password == "")
            {
                MessageBox.Show("Datos incorrectos");
            }
            else
            {

                if (datos.ingreso_usuario(txtUsuario.Text, txtPassword.Password))
                {
                    if (datos.es_admin(txtUsuario.Text))
                    {
                        MessageBox.Show("Bienvenido administrador " + txtUsuario.Text + " al sistema");

                        this.Hide();

                        WindowHome formHome = new WindowHome(txtUsuario.Text);
                        formHome.Show();
                    }
                    else
                    {
                        MessageBox.Show("Bienvenido usuario " + txtUsuario.Text + " al sistema");

                        this.Hide();

                        WindowHome formHome = new WindowHome(txtUsuario.Text);
                        formHome.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Datos incorrectos");
                }

            }
        }
    }
}
