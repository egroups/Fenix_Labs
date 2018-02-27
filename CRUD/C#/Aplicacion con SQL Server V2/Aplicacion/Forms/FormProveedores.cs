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
    public partial class FormProveedores : Form
    {
        ProveedorDatos proveedorDatos = new ProveedorDatos();
        Funciones funcion = new Funciones();
        bool nuevo = true;

        public FormProveedores()
        {
            InitializeComponent();
        }

        // Funciones

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

            if (txtTelefono.Text == "" || !funcion.valid_number(txtTelefono.Text))
            {
                MessageBox.Show("Ingrese el telefono");
                txtTelefono.Focus();
                return false;
            }

            return true;
        }

        private void cargarListaProveedores()
        {

            lvProveedores.Items.Clear();

            string nombre_buscar = txtBuscar.Text;

            List<Proveedor> listaProveedores = proveedorDatos.List(nombre_buscar);

            foreach(Proveedor proveedor in listaProveedores)
            {
                    ListViewItem item = new ListViewItem();
                    item.Text = Convert.ToString(proveedor.nombre);
                    item.SubItems.Add(Convert.ToString(proveedor.direccion));
                    item.SubItems.Add(Convert.ToString(proveedor.telefono));
                    item.SubItems.Add(Convert.ToString(proveedor.fecha_registro));
                    item.Tag = Convert.ToString(proveedor.id);
                    lvProveedores.Items.Add(item);
            }
        }

        private void CargarCamposProveedor(int id)
        {
            Proveedor proveedor = proveedorDatos.Get(id);
            txtID.Text = Convert.ToString(proveedor.id);
            txtNombre.Text = proveedor.nombre;
            txtDireccion.Text = proveedor.direccion;
            txtTelefono.Text = proveedor.telefono.ToString();
        }

        private void limpiar()
        {
            nuevo = true;
            txtID.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {
            cargarListaProveedores();
        }

        private void lvProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvProveedores.SelectedIndices.Count > 0 && lvProveedores.SelectedIndices[0] != -1)
            {
                CargarCamposProveedor(Convert.ToInt32((lvProveedores.SelectedItems[0].Tag)));
            }
        }

        private void grabar()
        {
            if (validar())
            {

                Proveedor proveedor = new Proveedor();
                if (txtID.Text != "")
                {
                    proveedor.id = Convert.ToInt32(txtID.Text);
                }
                proveedor.nombre = txtNombre.Text;
                proveedor.direccion = txtDireccion.Text;
                proveedor.telefono = Convert.ToInt32(txtTelefono.Text);
                proveedor.fecha_registro = funcion.fecha_del_dia();

                bool grabar_ready = false;

                if (nuevo)
                {
                    if (proveedorDatos.check_exists_proveedor_add(proveedor.nombre))
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
                    if (proveedorDatos.check_exists_proveedor_edit(proveedor.id,proveedor.nombre))
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
                        if (proveedorDatos.Add(proveedor))
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
                        if (proveedorDatos.Update(proveedor))
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
                    MessageBox.Show("El proveedor " + proveedor.nombre + " ya existe");
                    tsStatus.Text = "[-] El proveedor " + proveedor.nombre + " ya existe";
                    this.Refresh();
                }

                cargarListaProveedores();
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

            if (lvProveedores.SelectedIndices.Count > 0 && lvProveedores.SelectedIndices[0] != -1)
            {
                id = Convert.ToInt32((lvProveedores.SelectedItems[0].Tag));
            }

            Proveedor proveedor = proveedorDatos.Get(id);

            if (MessageBox.Show("Seguro de borrar a " + proveedor.nombre, "Borrar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                lvProveedores.Items.Clear();

                if (proveedorDatos.Delete(proveedor))
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

                cargarListaProveedores();
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
            cargarListaProveedores();
        }

        private void agregarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agregar();
        }

        private void editarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            grabar();
        }

        private void borrarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            borrar();
        }

        private void agregarProveedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            agregar();
        }

        private void editarProveedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void borrarProveedorToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void grabarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            grabar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            recargarLista();
        }

    }
}
