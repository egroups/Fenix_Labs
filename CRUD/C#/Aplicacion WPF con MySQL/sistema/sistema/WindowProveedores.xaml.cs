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
    /// Interaction logic for WindowProveedores.xaml
    /// </summary>
    public partial class WindowProveedores : Window
    {

        AccesoDatos datos = new AccesoDatos("Data Source=SIN DECIDIR-PC\\SQLEXPRESS;Initial Catalog=sistema;User ID=admin;Password=123456");
        funciones funcion = new funciones();
        bool nuevo = true;

        public WindowProveedores()
        {
            InitializeComponent();
        }

        public class Proveedor
        {
            public int ID { get; set; }
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public double Telefono { get; set; }
        }

        private void cargarProveedores()
        {

            lvProveedores.Items.Clear();

            string nombre_buscar = txtBuscar.Text;

            ArrayList listaProveedores = datos.cargarListaProveedores(nombre_buscar);

            foreach (Proveedores proveedor in listaProveedores)
            {
                lvProveedores.Items.Add(new Proveedor() { ID = proveedor.pId_proveedor , Nombre = proveedor.pNombre_empresa , Direccion = proveedor.pDireccion , Telefono = proveedor.pTelefono });
            }
        }

        private void CargarCamposProveedor(int id_proveedor)
        {
            Proveedores proveedor = datos.cargarProveedor(id_proveedor);
            txtID.Text = Convert.ToString(proveedor.pId_proveedor);
            txtNombre.Text = proveedor.pNombre_empresa;
            txtDireccion.Text = proveedor.pDireccion;
            txtTelefono.Text = proveedor.pTelefono.ToString();
        }

        private void limpiar()
        {
            nuevo = true;
            txtID.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }

        private bool valid_number(String numberString)
        {
            int number;
            return int.TryParse(numberString, out number);
        }

        private bool validar()
        {

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingrese el nombre");
                txtNombre.Focus();
                return false;
            }

            if (txtDireccion.Text == "")
            {
                MessageBox.Show("Ingrese la direccion");
                txtDireccion.Focus();
                return false;
            }

            if (txtTelefono.Text == "" || !valid_number(txtTelefono.Text))
            {
                MessageBox.Show("Ingrese el telefono");
                txtTelefono.Focus();
                return false;
            }

            return true;
        }

        private void grabar()
        {
            if (validar())
            {

                Proveedores p = new Proveedores();
                if (txtID.Text != "")
                {
                    p.pId_proveedor = Convert.ToInt32(txtID.Text);
                }
                p.pNombre_empresa = txtNombre.Text;
                p.pDireccion = txtDireccion.Text;
                p.pTelefono = Convert.ToInt32(txtTelefono.Text);
                p.pFecha_registro = funcion.fecha_del_dia();

                string sql = "";

                if (nuevo)
                {
                    sql = "insert into proveedores(nombre_empresa,direccion,telefono,fecha_registro_proveedor) values('" + p.pNombre_empresa + "','" + p.pDireccion + "'," + p.pTelefono + ",'" + p.pFecha_registro + "')";
                }
                else
                {
                    sql = "update proveedores set nombre_empresa='" + p.pNombre_empresa + "',direccion='" + p.pDireccion + "',telefono=" + p.pTelefono + " where id_proveedor=" + p.pId_proveedor;
                }

                bool grabar_ready = false;

                if (nuevo)
                {
                    if (datos.comprobar_existencia_proveedor_crear(p.pNombre_empresa))
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
                    if (datos.comprobar_existencia_proveedor_editar(p.pId_proveedor, p.pNombre_empresa))
                    {
                        grabar_ready = false;
                    }
                    else
                    {
                        grabar_ready = true;
                    }
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
                    MessageBox.Show("El proveedor " + p.pNombre_empresa + " ya existe");
                    status.Content = "[-] El proveedor " + p.pNombre_empresa + " ya existe";
                }

                cargarProveedores();
                limpiar();

            }
        }

        private void agregar()
        {
            status.Content = "[+] Programa en modo nuevo";
            nuevo = true;
            limpiar();
            MessageBox.Show("Programa cargado en modo nuevo");

        }

        private void editar()
        {
            status.Content = "[+] Programa en modo editar";
            nuevo = false;
            MessageBox.Show("Programa cargado en modo editar");
        }

        private void borrar()
        {

            int id_proveedor = 0;

            if (lvProveedores.SelectedItems.Count > 0)
            {
                Proveedor proveedor_load = (Proveedor)lvProveedores.SelectedItems[0];
                id_proveedor = proveedor_load.ID;
            }

            Proveedores proveedor = datos.cargarProveedor(id_proveedor);

            if (MessageBox.Show("Seguro de borrar a " + proveedor.pNombre_empresa, "Borrar registro", MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
            {
                lvProveedores.Items.Clear();

                string sql = "delete from proveedores where id_proveedor=" + proveedor.pId_proveedor;

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

                cargarProveedores();
                limpiar();

            }

        }

        private void cancelar()
        {
            status.Content = "[+] Programa cargado";
            nuevo = false;
            limpiar();
            MessageBox.Show("Opcion cancelada");
        }

        public void recargarLista()
        {
            cargarProveedores();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            recargarLista();
        }

        private void lvProveedores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvProveedores.SelectedItems.Count > 0)
            {
                Proveedor proveedor = (Proveedor)lvProveedores.SelectedItems[0];
                CargarCamposProveedor(proveedor.ID);
            }
        }

        private void ItemAgregarProveedor_Click(object sender, RoutedEventArgs e)
        {
            agregar();
        }

        private void ItemEditarProveedor_Click(object sender, RoutedEventArgs e)
        {
            editar();
        }

        private void ItemBorrarProveedor_Click(object sender, RoutedEventArgs e)
        {
            borrar();
        }

        private void ItemCancelar_Click(object sender, RoutedEventArgs e)
        {
            cancelar();
        }

        private void ItemRecargarLista_Click(object sender, RoutedEventArgs e)
        {
            recargarLista();
        }

        private void ItemGrabar_Click(object sender, RoutedEventArgs e)
        {
            grabar();
        }

        private void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            grabar();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            recargarLista();
        }

        private void ItemAgregarProveedor2_Click(object sender, RoutedEventArgs e)
        {
            agregar();
        }

        private void ItemEditarProveedor2_Click(object sender, RoutedEventArgs e)
        {
            editar();
        }

        private void ItemBorrarProveedor2_Click(object sender, RoutedEventArgs e)
        {
            borrar();
        }

        private void ItemCancelar2_Click(object sender, RoutedEventArgs e)
        {
            cancelar();
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
