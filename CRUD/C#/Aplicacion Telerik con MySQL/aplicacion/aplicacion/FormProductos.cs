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
    public partial class FormProductos : Telerik.WinControls.UI.RadForm
    {

        AccesoDatos datos = new AccesoDatos("Data Source=localhost\\SQLEXPRESS;Initial Catalog=sistema;User ID=admin;Password=123456");
        funciones funcion = new funciones();
        bool nuevo = true;

        public FormProductos()
        {
            InitializeComponent();
        }

        private void cargarProductos()
        {

            lvProductos.Items.Clear();

            string nombre_buscar = txtBuscar.Text;

            ArrayList listaProductos = datos.cargarListaProductos(nombre_buscar);

            foreach (Productos producto in listaProductos)
            {

                String nombre_empresa = datos.nombre_proveedor(producto.pId_proveedor);

                ListViewDataItem item = new ListViewDataItem();
                item.SubItems.Add(Convert.ToString(producto.pNombre_producto));
                item.SubItems.Add(Convert.ToString(producto.pDescripcion));
                item.SubItems.Add(Convert.ToString(producto.pPrecio));
                item.SubItems.Add(Convert.ToString(producto.pFecha_registro));
                item.SubItems.Add(Convert.ToString(nombre_empresa));
                item.Tag = Convert.ToString(producto.pId_producto);
                lvProductos.Items.Add(item);
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
                RadMessageBox.Show("Ingrese nombre");
                txtNombre.Focus();
                return false;
            }
            if (txtDescripcion.Text == "")
            {
                RadMessageBox.Show("Ingrese descripcion");
                txtDescripcion.Focus();
                return false;
            }
            if (cmbProveedor.SelectedIndex == -1)
            {
                RadMessageBox.Show("Seleccione proveedor");
                cmbProveedor.Focus();
                return false;
            }
            if (txtPrecio.Text == "" || !valid_number(txtPrecio.Text))
            {
                RadMessageBox.Show("Ingrese precio");
                txtPrecio.Focus();
                return false;
            }

            return true;
        }

        private void cargarCombo(RadDropDownList combo, string tabla)
        {

            DataTable dt = new DataTable();
            dt = datos.consultarTabla(tabla);
            combo.DataSource = datos.consultarTabla(tabla);
            combo.ValueMember = dt.Columns[0].ColumnName;
            combo.DisplayMember = dt.Columns[1].ColumnName;
        }

        private void limpiar()
        {
            nuevo = true;
            txtID.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            cmbProveedor.SelectedIndex = -1;
        }

        private void CargarCamposProductos(int id_producto)
        {
            Productos producto = datos.cargarProducto(id_producto);
            txtID.Text = producto.pId_producto.ToString();
            txtNombre.Text = producto.pNombre_producto;
            txtDescripcion.Text = producto.pDescripcion;
            cmbProveedor.SelectedValue = producto.pId_proveedor;
            txtPrecio.Text = producto.pPrecio.ToString();
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
                p.pDescripcion = txtDescripcion.Text;
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
                    RadMessageBox.Show("El producto " + p.pNombre_producto + " ya existe");
                    status.Text = "[-] El producto " + p.pNombre_producto + " ya existe";
                    this.Refresh();
                }

                cargarProductos();
                limpiar();

            }
        }

        private void agregar()
        {
            status.Text = "[+] Programa en modo nuevo";
            this.Refresh();
            nuevo = true;
            limpiar();
            RadMessageBox.Show("Programa cargado en modo nuevo");

        }

        private void editar()
        {
            status.Text = "[+] Programa en modo editar";
            this.Refresh();
            nuevo = false;
            RadMessageBox.Show("Programa cargado en modo editar");
        }

        private void borrar()
        {
            int id_producto = 0;

            if (lvProductos.SelectedIndex != -1)
            {
                id_producto = Convert.ToInt32((lvProductos.SelectedItems[0].Tag));
            }

            Productos producto = datos.cargarProducto(id_producto);

            if (MessageBox.Show("Seguro de borrar a " + producto.pNombre_producto, "Borrar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                lvProductos.Items.Clear();

                string sql = "delete from productos where id_producto=" + producto.pId_producto;

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

                cargarProductos();
                limpiar();

            }
        }

        private void cancelar()
        {
            status.Text = "[+] Programa cargado";
            this.Refresh();
            nuevo = false;
            limpiar();
            RadMessageBox.Show("Opcion cancelada");
        }

        private void recargarLista()
        {
            cargarCombo(cmbProveedor, "proveedores");
            cargarProductos();
        }

        private void ItemRecargarLista_Click(object sender, EventArgs e)
        {
            recargarLista();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            recargarLista();
        }

        private void lvProductos_SelectedItemChanged(object sender, EventArgs e)
        {
            if (lvProductos.SelectedIndex != -1)
            {
                CargarCamposProductos(Convert.ToInt32((lvProductos.SelectedItems[0].Tag)));
            }
        }

        private void ItemAgregarProducto_Click(object sender, EventArgs e)
        {
            agregar();
        }

        private void ItemEditarProducto_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void ItemBorrarProducto_Click(object sender, EventArgs e)
        {
            borrar();
        }

        private void ItemCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
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
    }
}
