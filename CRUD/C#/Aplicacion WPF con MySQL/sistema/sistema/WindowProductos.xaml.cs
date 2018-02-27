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
    /// Interaction logic for WindowProductos.xaml
    /// </summary>
    public partial class WindowProductos : Window
    {

        AccesoDatos datos = new AccesoDatos("Data Source=SIN DECIDIR-PC\\SQLEXPRESS;Initial Catalog=sistema;User ID=admin;Password=123456");
        funciones funcion = new funciones();
        bool nuevo = true;

        public WindowProductos()
        {
            InitializeComponent();
        }

        public class Producto
        {
            public int ID { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public double Precio { get; set; }
            public string Fecha { get; set; }
            public string Proveedor { get; set; }
        }

        private void cargarProductos()
        {

            lvProductos.Items.Clear();

            string nombre_buscar = txtBuscar.Text;

            ArrayList listaProductos = datos.cargarListaProductos(nombre_buscar);

            foreach (Productos producto in listaProductos)
            {

                String nombre_empresa = datos.nombre_proveedor(producto.pId_proveedor);

                lvProductos.Items.Add(new Producto() { ID = producto.pId_producto , Nombre = producto.pNombre_producto , Descripcion = producto.pDescripcion , Precio = producto.pPrecio , Fecha = producto.pFecha_registro , Proveedor = nombre_empresa });
            }
        }

        public class ListaProveedores
        {
            public int ID { get; set; }
            public string Nombre { get; set; }
        }

        private void cargarCombo(ComboBox combo)
        {

            combo.Items.Clear();

            combo.SelectedValuePath = "ID";
            combo.DisplayMemberPath = "Nombre";

            ArrayList listaProveedores = datos.cargarListaProveedores("");

            foreach (Proveedores proveedor in listaProveedores)
            {
                combo.Items.Add(new ListaProveedores() { ID = proveedor.pId_proveedor, Nombre = proveedor.pNombre_empresa });
            }
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
                MessageBox.Show("Ingrese nombre");
                txtNombre.Focus();
                return false;
            }

            string contenido = new TextRange(txtDescripcion.Document.ContentStart, txtDescripcion.Document.ContentEnd).Text;

            if (contenido == "")
            {
                MessageBox.Show("Ingrese descripcion");
                txtDescripcion.Focus();
                return false;
            }
            if (cmbProveedor.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione proveedor");
                cmbProveedor.Focus();
                return false;
            }
            if (txtPrecio.Text == "" || !valid_number(txtPrecio.Text))
            {
                MessageBox.Show("Ingrese precio");
                txtPrecio.Focus();
                return false;
            }

            return true;
        }

        private void limpiar()
        {
            nuevo = true;
            txtID.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Document.Blocks.Clear();
            txtPrecio.Text = "";
            cmbProveedor.SelectedIndex = -1;
        }

        private void CargarCamposProductos(int id_producto)
        {
            Productos producto = datos.cargarProducto(id_producto);
            txtID.Text = producto.pId_producto.ToString();
            txtNombre.Text = producto.pNombre_producto;

            txtDescripcion.Document.Blocks.Clear();
            txtDescripcion.AppendText(producto.pDescripcion);

            cmbProveedor.SelectedValue = producto.pId_proveedor;
            txtPrecio.Text = producto.pPrecio.ToString();
        }

        public void recargarLista()
        {
            cargarProductos();
            cargarCombo(cmbProveedor);
        }

        private void grabar()
        {
            if (validar())
            {

                Productos p = new Productos();
                if (txtID.Text != "")
                {
                    p.pId_producto = Convert.ToInt32(txtID.Text);
                }
                p.pNombre_producto = txtNombre.Text;

                string contenido = new TextRange(txtDescripcion.Document.ContentStart, txtDescripcion.Document.ContentEnd).Text;
                p.pDescripcion = contenido;
                
                p.pPrecio = Convert.ToDouble(txtPrecio.Text);
                p.pId_proveedor = Convert.ToInt32(cmbProveedor.SelectedValue);
                p.pFecha_registro = funcion.fecha_del_dia();

                string sql = "";

                if (nuevo)
                {
                    sql = "insert into productos(nombre_producto,descripcion,precio,id_proveedor,fecha_registro) values('" + p.pNombre_producto + "','" + p.pDescripcion + "'," + p.pPrecio + "," + p.pId_proveedor + ",'" + p.pFecha_registro + "')";
                }
                else
                {
                    sql = "update productos set nombre_producto='" + p.pNombre_producto + "',descripcion='" + p.pDescripcion + "',precio=" + p.pPrecio + ",id_proveedor='" + p.pId_proveedor + "'" + " where id_producto=" + p.pId_producto;
                }

                bool grabar_ready = false;

                if (nuevo)
                {
                    if (datos.comprobar_existencia_producto_crear(p.pNombre_producto))
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
                    if (datos.comprobar_existencia_producto_editar(p.pId_producto, p.pNombre_producto))
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
                    MessageBox.Show("El producto " + p.pNombre_producto + " ya existe");
                    status.Content = "[-] El producto " + p.pNombre_producto + " ya existe";
                }

                cargarProductos();
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
            int id_producto = 0;

            if (lvProductos.SelectedItems.Count > 0)
            {
                Producto producto_load = (Producto)lvProductos.SelectedItems[0];
                id_producto = producto_load.ID;
            }

            Productos producto = datos.cargarProducto(id_producto);

            if (MessageBox.Show("Seguro de borrar a " + producto.pNombre_producto, "Borrar registro", MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
            {
                lvProductos.Items.Clear();

                string sql = "delete from productos where id_producto=" + producto.pId_producto;

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

                cargarProductos();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            recargarLista();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            recargarLista();
        }

        private void lvProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvProductos.SelectedItems.Count > 0)
            {
                Producto producto = (Producto) lvProductos.SelectedItems[0];
                CargarCamposProductos(producto.ID);
            }
        }

        private void ItemAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            agregar();
        }

        private void ItemEditarProducto_Click(object sender, RoutedEventArgs e)
        {
            editar();
        }

        private void ItemBorrarProducto_Click(object sender, RoutedEventArgs e)
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

        private void ItemAgregarProducto2_Click(object sender, RoutedEventArgs e)
        {
            agregar();
        }

        private void ItemEditarProducto2_Click(object sender, RoutedEventArgs e)
        {
            editar();
        }

        private void ItemBorrarProducto2_Click(object sender, RoutedEventArgs e)
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
