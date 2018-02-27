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
    public partial class FormProveedores : Telerik.WinControls.UI.RadForm
    {

        AccesoDatos datos = new AccesoDatos("Data Source=localhost\\SQLEXPRESS;Initial Catalog=sistema;User ID=admin;Password=123456");
        funciones funcion = new funciones();
        bool nuevo = true;

        public FormProveedores()
        {
            InitializeComponent();
        }

        // Funciones

        private bool valid_number(String numberString)
        {
            int number;
            return int.TryParse(numberString, out number);
        }

        private bool validar()
        {

            if (txtNombre.Text == "")
            {
                RadMessageBox.Show("Ingrese el nombre");
                txtNombre.Focus();
                return false;
            }

            if (txtDireccion.Text == "")
            {
                RadMessageBox.Show("Ingrese la direccion");
                txtDireccion.Focus();
                return false;
            }

            if (txtTelefono.Text == "" || !valid_number(txtTelefono.Text))
            {
                RadMessageBox.Show("Ingrese el telefono");
                txtTelefono.Focus();
                return false;
            }

            return true;
        }

        private void cargarProveedores()
        {

            lvProveedores.Items.Clear();

            string nombre_buscar = txtBuscar.Text;

            ArrayList listaProveedores = datos.cargarListaProveedores(nombre_buscar);

            foreach (Proveedores proveedor in listaProveedores)
            {
                ListViewDataItem item = new ListViewDataItem();
                item.SubItems.Add(Convert.ToString(proveedor.pNombre_empresa));
                item.SubItems.Add(Convert.ToString(proveedor.pDireccion));
                item.SubItems.Add(Convert.ToString(proveedor.pTelefono));
                item.SubItems.Add(Convert.ToString(proveedor.pFecha_registro));
                item.Tag = Convert.ToString(proveedor.pId_proveedor);
                lvProveedores.Items.Add(item);
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

        public void recargarLista()
        {
            cargarProveedores();
        }

        private void ItemAgregarProducto_Click(object sender, EventArgs e)
        {
            agregar();
        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {
            recargarLista();
        }

        private void lvProveedores_SelectedItemChanged(object sender, EventArgs e)
        {
            if (lvProveedores.SelectedIndex != -1)
            {
                CargarCamposProveedor(Convert.ToInt32((lvProveedores.SelectedItems[0].Tag)));
            }
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
                    RadMessageBox.Show("El proveedor " + p.pNombre_empresa + " ya existe");
                    status.Text = "[-] El proveedor " + p.pNombre_empresa + " ya existe";
                    this.Refresh();
                }

                cargarProveedores();
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

            int id_proveedor = 0;

            if (lvProveedores.SelectedIndex != -1)
            {
                id_proveedor = Convert.ToInt32((lvProveedores.SelectedItems[0].Tag));
            }

            Proveedores proveedor = datos.cargarProveedor(id_proveedor);

            if (MessageBox.Show("Seguro de borrar a " + proveedor.pNombre_empresa, "Borrar registro",MessageBoxButtons.YesNo, MessageBoxIcon.Stop,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                lvProveedores.Items.Clear();

                string sql = "delete from proveedores where id_proveedor=" + proveedor.pId_proveedor;

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

                cargarProveedores();
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

        private void ItemEditarProveedor_Click(object sender, EventArgs e)
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

        private void ItemRecargarLista_Click(object sender, EventArgs e)
        {
            recargarLista();
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
