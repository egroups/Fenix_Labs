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
    public partial class FormProductos : Form
    {
        ProductoDatos productoDatos = new ProductoDatos();
        ProveedorDatos proveedorDatos = new ProveedorDatos();
        Funciones funcion = new Funciones();
        bool nuevo = true;

        public FormProductos()
        {
            InitializeComponent();
        }

        // Funciones

        private void cargarListaProductos()
        {

            lvProductos.Items.Clear();

            string nombre_buscar = txtNombreBuscar.Text;

            List<Producto> listaProductos = productoDatos.List(nombre_buscar);

            foreach (Producto producto in listaProductos)
            {
                ListViewItem item = new ListViewItem();
                item.Text = producto.nombre;
                item.SubItems.Add(producto.descripcion);
                item.SubItems.Add(producto.precio.ToString());
                item.SubItems.Add(producto.proveedor.nombre);
                item.SubItems.Add(producto.fecha_registro);
                item.Tag = producto.id;
                lvProductos.Items.Add(item);
            }
        }

        private bool validar()
        {

            if(txtNombre.Text=="") {
                MessageBox.Show("Ingrese nombre");
                txtNombre.Focus();
                return false;
            }
            if(rtbDescripcion.Text=="") {
                MessageBox.Show("Ingrese descripcion");
                rtbDescripcion.Focus();
                return false;
            }
            if(cmbProveedor.SelectedIndex==-1) {
                MessageBox.Show("Seleccione proveedor");
                cmbProveedor.Focus();
                return false;
            }
            if (txtPrecio.Text == "")
            {
                MessageBox.Show("Ingrese precio");
                txtPrecio.Focus();
                return false;
            }

            return true;
        }

        private void cargarComboProveedores()
        {
            cmbProveedor.DataSource = proveedorDatos.List("");
            cmbProveedor.ValueMember = "id";
            cmbProveedor.DisplayMember = "nombre";
        }

        private void limpiar()
        {
            nuevo = true;
            txtID.Text = "";
            txtNombre.Text = "";
            rtbDescripcion.Text = "";
            txtPrecio.Text = "";
            cmbProveedor.SelectedIndex = -1;
        }

        private void CargarCamposProducto(int id)
        {
            Producto producto = productoDatos.Get(id);
            txtID.Text = producto.id.ToString();
            txtNombre.Text = producto.nombre;
            rtbDescripcion.Text = producto.descripcion;
            cmbProveedor.SelectedValue = producto.id_proveedor;
            txtPrecio.Text = producto.precio.ToString();
        }

        private void grabar()
        {
            if (validar())
            {

                Producto producto = new Producto();
                if (txtID.Text != "")
                {
                    producto.id = Convert.ToInt32(txtID.Text);
                }
                producto.nombre = txtNombre.Text;
                producto.descripcion = rtbDescripcion.Text;
                producto.precio = Convert.ToDouble(txtPrecio.Text);
                producto.id_proveedor = Convert.ToInt32(cmbProveedor.SelectedValue);
                producto.fecha_registro = funcion.fecha_del_dia();

                bool grabar_ready = false;

                if (nuevo)
                {
                    if (productoDatos.check_exists_producto_add(producto.nombre))
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
                    if (productoDatos.check_exists_producto_edit(producto.id, producto.nombre))
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
                    if (nuevo)
                    {
                        if (productoDatos.Add(producto))
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
                        if (productoDatos.Update(producto))
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
                    MessageBox.Show("El producto " + producto.nombre + " ya existe");
                    tsStatus.Text = "[-] El producto " + producto.nombre + " ya existe";
                    this.Refresh();
                }

                cargarListaProductos();
                limpiar();
            }
        }

        private void agregar()
        {
            tsStatus.Text = "[+] Programa en modo nuevo";
            this.Refresh();
            nuevo = true;
            limpiar();
            MessageBox.Show("Programa cargado en modo nuevo");

        }

        private void editar()
        {
            tsStatus.Text = "[+] Programa en modo editar";
            this.Refresh();
            nuevo = false;
            MessageBox.Show("Programa cargado en modo editar");
        }

        private void borrar()
        {
            int id = 0;

            if (lvProductos.SelectedIndices.Count > 0 && lvProductos.SelectedIndices[0] != -1)
            {
                id = Convert.ToInt32((lvProductos.SelectedItems[0].Tag));
            }

            Producto producto = productoDatos.Get(id);

            if (MessageBox.Show("Seguro de borrar a " + producto.nombre, "Borrar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                lvProductos.Items.Clear();

                if (productoDatos.Delete(producto))
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

                cargarListaProductos();
                limpiar();

            }
        }

        private void cancelar()
        {
            tsStatus.Text = "[+] Programa cargado";
            this.Refresh();
            nuevo = false;
            limpiar();
            MessageBox.Show("Opcion cancelada");
        }

        private void recargarLista()
        {
            cargarListaProductos();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            cargarComboProveedores();
            cargarListaProductos();
        }

        private void lvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvProductos.SelectedIndices.Count > 0 && lvProductos.SelectedIndices[0] != -1)
            {
                CargarCamposProducto(Convert.ToInt32((lvProductos.SelectedItems[0].Tag)));
            }
        }

        private void agregarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agregar();
        }

        private void editarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void borrarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            borrar();
        }

        private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cancelar();
        }

        private void recargarListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            recargarLista();
        }

        private void grabarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grabar();
        }

        private void agregarProductoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            agregar();
        }

        private void editarProductoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void borrarProductoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            borrar();
        }

        private void cancelarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cancelar();
        }

        private void recargarListaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            recargarLista();
        }

        private void grabarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            grabar();
        }

        private void btn_Grabar_Click(object sender, EventArgs e)
        {
            grabar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            recargarLista();
        }

    }
}