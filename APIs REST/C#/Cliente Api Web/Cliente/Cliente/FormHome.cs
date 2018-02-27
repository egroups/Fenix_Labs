// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Xml.XPath;

using Cliente.Models;

namespace Cliente
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        public String fecha_del_dia()
        {
            DateTime Hoy = DateTime.Today;

            string fecha_actual = Hoy.ToString("yyyy-MM-dd");

            return fecha_actual;
        }

        public string md5_encode(string input)
        {

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString().ToLower();
            }
        }

        private void cargarProveedores()
        {

            lvProveedores.Items.Clear();

            var cliente = new WebClient();

            if (rbJSON.Checked)
            {
                cliente.Headers[HttpRequestHeader.ContentType] = "application/json";
                var contenido = cliente.DownloadString(txtURL.Text + "/Api/Proveedores");
                JArray a = JArray.Parse(contenido);

                foreach (JObject o in a.Children<JObject>())
                {
                    int id_proveedor = Convert.ToInt32(o.GetValue("id_proveedor"));
                    string nombre_empresa = o.GetValue("nombre_empresa").ToString();
                    string direccion = o.GetValue("direccion").ToString();
                    int telefono = Convert.ToInt32(o.GetValue("telefono"));
                    string fecha_registro_proveedor = o.GetValue("fecha_registro_proveedor").ToString();

                    ListViewItem item = new ListViewItem();
                    item.Text = Convert.ToString(nombre_empresa);
                    item.SubItems.Add(Convert.ToString(telefono));
                    item.SubItems.Add(Convert.ToString(fecha_registro_proveedor));
                    item.Tag = Convert.ToString(id_proveedor);
                    lvProveedores.Items.Add(item);
                }
            }

            if (rbXML.Checked)
            {
                cliente.Headers[HttpRequestHeader.ContentType] = "application/xml";
                var contenido = cliente.DownloadString(txtURL.Text + "/Api/Proveedores");
                
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(contenido);

                XmlNamespaceManager manager = new XmlNamespaceManager(xDoc.NameTable);
                manager.AddNamespace("MYNS", "http://schemas.datacontract.org/2004/07/WebApi.Models");

                XmlNodeList nodelist = xDoc.DocumentElement.SelectNodes("MYNS:ProveedorModel", manager);

                foreach (XmlNode node in nodelist)
                {
                    int id_proveedor = Convert.ToInt32(node.SelectSingleNode("MYNS:id_proveedor", manager).InnerText);
                    string nombre_empresa = node.SelectSingleNode("MYNS:nombre_empresa", manager).InnerText;
                    string direccion = node.SelectSingleNode("MYNS:direccion", manager).InnerText;
                    int telefono = Convert.ToInt32(node.SelectSingleNode("MYNS:telefono", manager).InnerText);
                    string fecha_registro_proveedor = node.SelectSingleNode("MYNS:fecha_registro_proveedor", manager).InnerText;

                    ListViewItem item = new ListViewItem();
                    item.Text = Convert.ToString(nombre_empresa);
                    item.SubItems.Add(Convert.ToString(direccion));
                    item.SubItems.Add(Convert.ToString(telefono));
                    item.Tag = Convert.ToString(id_proveedor);
                    lvProveedores.Items.Add(item);

                }
                
            }

        }

        private void cargarProveedor(int id_to_load)
        {
            var cliente = new WebClient();

            if (rbJSON.Checked)
            {
                cliente.Headers[HttpRequestHeader.ContentType] = "application/json";
                var contenido = cliente.DownloadString(txtURL.Text + "/Api/Proveedores/"+id_to_load);
                JObject o = JObject.Parse(contenido);
                int id_proveedor = Convert.ToInt32(o.GetValue("id_proveedor"));
                string nombre_empresa = o.GetValue("nombre_empresa").ToString();
                string direccion = o.GetValue("direccion").ToString();
                int telefono = Convert.ToInt32(o.GetValue("telefono"));
                string fecha_registro_proveedor = o.GetValue("fecha_registro_proveedor").ToString();

                txtID_Proveedor.Text = Convert.ToString(id_proveedor);
                txtNombreEmpresa.Text = nombre_empresa;
                txtDireccion.Text = direccion;
                txtTelefono.Text = Convert.ToString(telefono);
                
            }

            if (rbXML.Checked)
            {
                cliente.Headers[HttpRequestHeader.ContentType] = "application/xml";
                var contenido = cliente.DownloadString(txtURL.Text + "/Api/Proveedores/"+id_to_load);

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(contenido);

                XmlNamespaceManager manager = new XmlNamespaceManager(xDoc.NameTable);
                manager.AddNamespace("MYNS", "http://schemas.datacontract.org/2004/07/WebApi.Models");

                XmlNode node = xDoc.DocumentElement.SelectSingleNode("/MYNS:ProveedorModel", manager);
                int id_proveedor = Convert.ToInt32(node.SelectSingleNode("MYNS:id_proveedor", manager).InnerText);
                string nombre_empresa = node.SelectSingleNode("MYNS:nombre_empresa", manager).InnerText;
                int telefono = Convert.ToInt32(node.SelectSingleNode("MYNS:telefono", manager).InnerText);
                string direccion = node.SelectSingleNode("MYNS:direccion", manager).InnerText;
                string fecha_registro_proveedor = node.SelectSingleNode("MYNS:fecha_registro_proveedor", manager).InnerText;

                txtID_Proveedor.Text = Convert.ToString(id_proveedor);
                txtNombreEmpresa.Text = nombre_empresa;
                txtDireccion.Text = direccion;
                txtTelefono.Text = Convert.ToString(telefono);

            }

        }

        private string cargarNombreEmpresa(int id_to_load)
        {
            string nombre_empresa = "";

            var cliente = new WebClient();

            if (rbJSON.Checked)
            {
                cliente.Headers[HttpRequestHeader.ContentType] = "application/json";
                var contenido = cliente.DownloadString(txtURL.Text + "/Api/Proveedores/" + id_to_load);
                JObject o = JObject.Parse(contenido);
                nombre_empresa = o.GetValue("nombre_empresa").ToString();
            }

            if (rbXML.Checked)
            {
                cliente.Headers[HttpRequestHeader.ContentType] = "application/xml";
                var contenido = cliente.DownloadString(txtURL.Text + "/Api/Proveedores/" + id_to_load);

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(contenido);

                XmlNamespaceManager manager = new XmlNamespaceManager(xDoc.NameTable);
                manager.AddNamespace("MYNS", "http://schemas.datacontract.org/2004/07/WebApi.Models");

                XmlNode node = xDoc.DocumentElement.SelectSingleNode("/MYNS:ProveedorModel", manager);
                nombre_empresa = node.SelectSingleNode("MYNS:nombre_empresa", manager).InnerText;
            }

            return nombre_empresa;

        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() { return Text; }
        }

        private void cargarComboProveedores()
        {

            lvProveedores.Items.Clear();

            var cliente = new WebClient();

            if (rbJSON.Checked)
            {
                cliente.Headers[HttpRequestHeader.ContentType] = "application/json";
                var contenido = cliente.DownloadString(txtURL.Text + "/Api/Proveedores");
                JArray a = JArray.Parse(contenido);

                List<ComboboxItem> items = new List<ComboboxItem>();

                foreach (JObject o in a.Children<JObject>())
                {
                    int id_proveedor = Convert.ToInt32(o.GetValue("id_proveedor"));
                    string nombre_empresa = o.GetValue("nombre_empresa").ToString();
                    string direccion = o.GetValue("direccion").ToString();
                    int telefono = Convert.ToInt32(o.GetValue("telefono"));
                    string fecha_registro_proveedor = o.GetValue("fecha_registro_proveedor").ToString();

                    ComboboxItem item = new ComboboxItem();
                    item.Text = nombre_empresa;
                    item.Value = id_proveedor;

                    items.Add(item);

                }

                cmbProveedor.DataSource = items;
                cmbProveedor.DisplayMember = "Text";
                cmbProveedor.ValueMember = "Value";
            }

            if (rbXML.Checked)
            {
                cliente.Headers[HttpRequestHeader.ContentType] = "application/xml";
                var contenido = cliente.DownloadString(txtURL.Text + "/Api/Proveedores");

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(contenido);

                XmlNamespaceManager manager = new XmlNamespaceManager(xDoc.NameTable);
                manager.AddNamespace("MYNS", "http://schemas.datacontract.org/2004/07/WebApi.Models");

                XmlNodeList nodelist = xDoc.DocumentElement.SelectNodes("MYNS:ProveedorModel", manager);

                List<ComboboxItem> items = new List<ComboboxItem>();

                foreach (XmlNode node in nodelist)
                {
                    int id_proveedor = Convert.ToInt32(node.SelectSingleNode("MYNS:id_proveedor", manager).InnerText);
                    string nombre_empresa = node.SelectSingleNode("MYNS:nombre_empresa", manager).InnerText;
                    string direccion = node.SelectSingleNode("MYNS:direccion", manager).InnerText;
                    int telefono = Convert.ToInt32(node.SelectSingleNode("MYNS:telefono", manager).InnerText);
                    string fecha_registro_proveedor = node.SelectSingleNode("MYNS:fecha_registro_proveedor", manager).InnerText;

                    ComboboxItem item = new ComboboxItem();
                    item.Text = nombre_empresa;
                    item.Value = id_proveedor;

                    items.Add(item);

                }

                cmbProveedor.DataSource = items;
                cmbProveedor.DisplayMember = "Text";
                cmbProveedor.ValueMember = "Value";

            }

        }

        private void agregarProveedor()
        {
            Proveedor proveedor = new Proveedor();
            proveedor.nombre_empresa = txtNombreEmpresa.Text;
            proveedor.telefono = Convert.ToInt32(txtTelefono.Text);
            proveedor.direccion = txtDireccion.Text;
            proveedor.fecha_registro_proveedor = fecha_del_dia();

            try
            {
                var cliente = new WebClient();

                cliente.Headers[HttpRequestHeader.ContentType] = "application/json";

                string data = JsonConvert.SerializeObject(proveedor);

                string response = cliente.UploadString(txtURL.Text+"/Api/Proveedores","POST",data);

                MessageBox.Show("Proveedor agregado");
            }
            catch (WebException ex)
            {
                var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                MessageBox.Show("Status Code : "+statusCode);
            }
                   
        }

        private void editarProveedor()
        {
            Proveedor proveedor = new Proveedor();
            proveedor.id_proveedor = Convert.ToInt32(txtID_Proveedor.Text);
            proveedor.nombre_empresa = txtNombreEmpresa.Text;
            proveedor.telefono = Convert.ToInt32(txtTelefono.Text);
            proveedor.direccion = txtDireccion.Text;
            proveedor.fecha_registro_proveedor = fecha_del_dia();

            try
            {
                var cliente = new WebClient();

                cliente.Headers[HttpRequestHeader.ContentType] = "application/json";

                string data = JsonConvert.SerializeObject(proveedor);

                string response = cliente.UploadString(txtURL.Text + "/Api/Proveedores/"+proveedor.id_proveedor, "PUT", data);

                MessageBox.Show("Proveedor editado");
            }
            catch (WebException ex)
            {
                var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                MessageBox.Show("Status Code : " + statusCode);
            }

        }

        private void borrarProveedor()
        {
            Proveedor proveedor = new Proveedor();
            proveedor.id_proveedor = Convert.ToInt32(txtID_Proveedor.Text);
            proveedor.nombre_empresa = txtNombreEmpresa.Text;
            proveedor.telefono = Convert.ToInt32(txtTelefono.Text);
            proveedor.direccion = txtDireccion.Text;
            proveedor.fecha_registro_proveedor = fecha_del_dia();

            try
            {
                var cliente = new WebClient();

                cliente.Headers[HttpRequestHeader.ContentType] = "application/json";

                string data = JsonConvert.SerializeObject(proveedor);

                string response = cliente.UploadString(txtURL.Text + "/Api/Proveedores/" + proveedor.id_proveedor, "DELETE", data);

                MessageBox.Show("Proveedor borrado");
            }
            catch (WebException ex)
            {
                var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                MessageBox.Show("Status Code : " + statusCode);
            }

        }

        private void cargarProductos()
        {

            lvProductos.Items.Clear();

            var cliente = new WebClient();

            if (rbJSON.Checked)
            {
                cliente.Headers[HttpRequestHeader.ContentType] = "application/json";
                var contenido = cliente.DownloadString(txtURL.Text + "/Api/Productos");
                JArray a = JArray.Parse(contenido);

                foreach (JObject o in a.Children<JObject>())
                {
                    int id_producto = Convert.ToInt32(o.GetValue("id_producto"));
                    string nombre_producto = o.GetValue("nombre_producto").ToString();
                    string descripcion = o.GetValue("descripcion").ToString();
                    int precio = Convert.ToInt32(o.GetValue("precio"));
                    int id_proveedor = Convert.ToInt32(o.GetValue("id_proveedor"));
                    string fecha_registro = o.GetValue("fecha_registro").ToString();

                    ListViewItem item = new ListViewItem();
                    item.Text = Convert.ToString(nombre_producto);
                    item.SubItems.Add(Convert.ToString(descripcion));
                    item.SubItems.Add(Convert.ToString(precio));
                    item.SubItems.Add(Convert.ToString(fecha_registro));
                    item.SubItems.Add(Convert.ToString(cargarNombreEmpresa(id_proveedor)));
                    item.Tag = Convert.ToString(id_producto);
                    lvProductos.Items.Add(item);
                }
            }

            if (rbXML.Checked)
            {
                cliente.Headers[HttpRequestHeader.ContentType] = "application/xml";
                var contenido = cliente.DownloadString(txtURL.Text + "/Api/Productos");

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(contenido);

                XmlNamespaceManager manager = new XmlNamespaceManager(xDoc.NameTable);
                manager.AddNamespace("MYNS", "http://schemas.datacontract.org/2004/07/WebApi.Models");

                XmlNodeList nodelist = xDoc.DocumentElement.SelectNodes("MYNS:ProductoModel", manager);

                foreach (XmlNode node in nodelist)
                {
                    int id_producto = Convert.ToInt32(node.SelectSingleNode("MYNS:id_producto", manager).InnerText);
                    string nombre_producto = node.SelectSingleNode("MYNS:nombre_producto", manager).InnerText;
                    string descripcion = node.SelectSingleNode("MYNS:descripcion", manager).InnerText;
                    int precio = Convert.ToInt32(node.SelectSingleNode("MYNS:precio", manager).InnerText);
                    int id_proveedor = Convert.ToInt32(node.SelectSingleNode("MYNS:id_proveedor", manager).InnerText);
                    string fecha_registro = node.SelectSingleNode("MYNS:fecha_registro", manager).InnerText;

                    ListViewItem item = new ListViewItem();
                    item.Text = Convert.ToString(nombre_producto);
                    item.SubItems.Add(Convert.ToString(descripcion));
                    item.SubItems.Add(Convert.ToString(precio));
                    item.SubItems.Add(Convert.ToString(fecha_registro));
                    item.SubItems.Add(Convert.ToString(cargarNombreEmpresa(id_proveedor)));
                    item.Tag = Convert.ToString(id_producto);
                    lvProductos.Items.Add(item);

                }

            }

        }

        private void cargarProducto(int id_to_load)
        {
            var cliente = new WebClient();

            if (rbJSON.Checked)
            {
                cliente.Headers[HttpRequestHeader.ContentType] = "application/json";
                var contenido = cliente.DownloadString(txtURL.Text + "/Api/Productos/" + id_to_load);
                JObject o = JObject.Parse(contenido);

                int id_producto = Convert.ToInt32(o.GetValue("id_producto"));
                string nombre_producto = o.GetValue("nombre_producto").ToString();
                string descripcion = o.GetValue("descripcion").ToString();
                int precio = Convert.ToInt32(o.GetValue("precio"));
                int id_proveedor = Convert.ToInt32(o.GetValue("id_proveedor"));
                string fecha_registro = o.GetValue("fecha_registro").ToString();

                txtID_Producto.Text = Convert.ToString(id_producto);
                txtNombre.Text = nombre_producto;
                rtbDescripcion.Text = descripcion;
                txtPrecio.Text = Convert.ToString(precio);
                cmbProveedor.SelectedValue = id_proveedor;
            }

            if (rbXML.Checked)
            {
                cliente.Headers[HttpRequestHeader.ContentType] = "application/xml";
                var contenido = cliente.DownloadString(txtURL.Text + "/Api/Productos/" + id_to_load);

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(contenido);

                XmlNamespaceManager manager = new XmlNamespaceManager(xDoc.NameTable);
                manager.AddNamespace("MYNS", "http://schemas.datacontract.org/2004/07/WebApi.Models");

                XmlNode node = xDoc.DocumentElement.SelectSingleNode("/MYNS:ProductoModel", manager);
                int id_producto = Convert.ToInt32(node.SelectSingleNode("MYNS:id_producto", manager).InnerText);
                string nombre_producto = node.SelectSingleNode("MYNS:nombre_producto", manager).InnerText;
                string descripcion = node.SelectSingleNode("MYNS:descripcion", manager).InnerText;
                int precio = Convert.ToInt32(node.SelectSingleNode("MYNS:precio", manager).InnerText);
                int id_proveedor = Convert.ToInt32(node.SelectSingleNode("MYNS:id_proveedor", manager).InnerText);
                string fecha_registro = node.SelectSingleNode("MYNS:fecha_registro", manager).InnerText;

                txtID_Producto.Text = Convert.ToString(id_producto);
                txtNombre.Text = nombre_producto;
                rtbDescripcion.Text = descripcion;
                txtPrecio.Text = Convert.ToString(precio);
                cmbProveedor.SelectedValue = id_proveedor;

            }

        }

        private void agregarProducto()
        {
            Producto producto = new Producto();
            producto.nombre_producto = txtNombre.Text;
            producto.descripcion = rtbDescripcion.Text;
            producto.precio = Convert.ToInt32(txtPrecio.Text);
            producto.id_proveedor = Convert.ToInt32(cmbProveedor.SelectedValue);
            producto.fecha_registro = fecha_del_dia();

            try
            {
                var cliente = new WebClient();

                cliente.Headers[HttpRequestHeader.ContentType] = "application/json";

                string data = JsonConvert.SerializeObject(producto);

                string response = cliente.UploadString(txtURL.Text + "/Api/Productos", "POST", data);

                MessageBox.Show("Producto agregado");
            }
            catch (WebException ex)
            {
                var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                MessageBox.Show("Status Code : " + statusCode);
            }

        }

        private void editarProducto()
        {
            Producto producto = new Producto();
            producto.id_producto = Convert.ToInt32(txtID_Producto.Text);
            producto.nombre_producto = txtNombre.Text;
            producto.descripcion = rtbDescripcion.Text;
            producto.precio = Convert.ToInt32(txtPrecio.Text);
            producto.id_proveedor = Convert.ToInt32(cmbProveedor.SelectedValue);
            producto.fecha_registro = fecha_del_dia();

            try
            {
                var cliente = new WebClient();

                cliente.Headers[HttpRequestHeader.ContentType] = "application/json";

                string data = JsonConvert.SerializeObject(producto);

                string response = cliente.UploadString(txtURL.Text + "/Api/Productos/" + producto.id_producto, "PUT", data);

                MessageBox.Show("Producto editado");
            }
            catch (WebException ex)
            {
                var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                MessageBox.Show("Status Code : " + statusCode);
            }

        }

        private void borrarProducto()
        {
            Producto producto = new Producto();
            producto.id_producto = Convert.ToInt32(txtID_Producto.Text);
            producto.nombre_producto = txtNombre.Text;
            producto.descripcion = rtbDescripcion.Text;
            producto.precio = Convert.ToInt32(txtPrecio.Text);
            producto.id_proveedor = Convert.ToInt32(cmbProveedor.SelectedValue);
            producto.fecha_registro = fecha_del_dia();

            try
            {
                var cliente = new WebClient();

                cliente.Headers[HttpRequestHeader.ContentType] = "application/json";

                string data = JsonConvert.SerializeObject(producto);

                string response = cliente.UploadString(txtURL.Text + "/Api/Productos/" + producto.id_producto, "DELETE", data);

                MessageBox.Show("Producto borrado");
            }
            catch (WebException ex)
            {
                var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                MessageBox.Show("Status Code : " + statusCode);
            }

        }

        private void cargarUsuarios()
        {

            lvUsuarios.Items.Clear();

            var cliente = new WebClient();

            if (rbJSON.Checked)
            {
                cliente.Headers[HttpRequestHeader.ContentType] = "application/json";
                var contenido = cliente.DownloadString(txtURL.Text + "/Api/Usuarios");
                JArray a = JArray.Parse(contenido);

                foreach (JObject o in a.Children<JObject>())
                {
                    int id_usuario = Convert.ToInt32(o.GetValue("id_usuario"));
                    string usuario = o.GetValue("usuario").ToString();
                    string clave = o.GetValue("clave").ToString();
                    int tipo = Convert.ToInt32(o.GetValue("tipo"));
                    string fecha_registro = o.GetValue("fecha_registro").ToString();

                    string tipo_nombre = "";

                    if (tipo == 1)
                    {
                        tipo_nombre = "Administrador";
                    }

                    if (tipo == 2)
                    {
                        tipo_nombre = "Usuario";
                    }

                    ListViewItem item = new ListViewItem();
                    item.Text = Convert.ToString(usuario);
                    item.SubItems.Add(Convert.ToString(tipo_nombre));
                    item.SubItems.Add(Convert.ToString(fecha_registro));
                    item.Tag = Convert.ToString(id_usuario);
                    lvUsuarios.Items.Add(item);
                }
            }

            if (rbXML.Checked)
            {
                cliente.Headers[HttpRequestHeader.ContentType] = "application/xml";
                var contenido = cliente.DownloadString(txtURL.Text + "/Api/Usuarios");

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(contenido);

                XmlNamespaceManager manager = new XmlNamespaceManager(xDoc.NameTable);
                manager.AddNamespace("MYNS", "http://schemas.datacontract.org/2004/07/WebApi.Models");

                XmlNodeList nodelist = xDoc.DocumentElement.SelectNodes("MYNS:ProveedorModel", manager);

                foreach (XmlNode node in nodelist)
                {
                    int id_usuario = Convert.ToInt32(node.SelectSingleNode("MYNS:id_usuario", manager).InnerText);
                    string usuario = node.SelectSingleNode("MYNS:usuario", manager).InnerText;
                    string clave = node.SelectSingleNode("MYNS:clave", manager).InnerText;
                    int tipo = Convert.ToInt32(node.SelectSingleNode("MYNS:tipo", manager).InnerText);
                    string fecha_registro = node.SelectSingleNode("MYNS:fecha_registro", manager).InnerText;

                    string tipo_nombre = "";

                    if (tipo == 1)
                    {
                        tipo_nombre = "Administrador";
                    }

                    if (tipo == 2)
                    {
                        tipo_nombre = "Usuario";
                    }

                    ListViewItem item = new ListViewItem();
                    item.Text = Convert.ToString(usuario);
                    item.SubItems.Add(Convert.ToString(tipo_nombre));
                    item.SubItems.Add(Convert.ToString(fecha_registro));
                    item.Tag = Convert.ToString(id_usuario);
                    lvUsuarios.Items.Add(item);

                }

            }

        }

        private void cargarUsuario(int id_to_load)
        {
            var cliente = new WebClient();

            if (rbJSON.Checked)
            {
                cliente.Headers[HttpRequestHeader.ContentType] = "application/json";
                var contenido = cliente.DownloadString(txtURL.Text + "/Api/Usuarios/" + id_to_load);
                JObject o = JObject.Parse(contenido);

                int id_usuario = Convert.ToInt32(o.GetValue("id_usuario"));
                string usuario = o.GetValue("usuario").ToString();
                string clave = o.GetValue("clave").ToString();
                int tipo = Convert.ToInt32(o.GetValue("tipo"));
                string fecha_registro = o.GetValue("fecha_registro").ToString();

                string tipo_nombre = "";

                if (tipo == 1)
                {
                    tipo_nombre = "Administrador";
                    cmbTipo.SelectedIndex = 1;
                }

                if (tipo == 2)
                {
                    tipo_nombre = "Usuario";
                    cmbTipo.SelectedIndex = 0;
                }

                txtID_Usuario.Text = Convert.ToString(id_usuario);
                txtUsuario.Text = usuario;
                txtPassword.Text = clave;

            }

            if (rbXML.Checked)
            {
                cliente.Headers[HttpRequestHeader.ContentType] = "application/xml";
                var contenido = cliente.DownloadString(txtURL.Text + "/Api/Usuarios/" + id_to_load);

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(contenido);

                XmlNamespaceManager manager = new XmlNamespaceManager(xDoc.NameTable);
                manager.AddNamespace("MYNS", "http://schemas.datacontract.org/2004/07/WebApi.Models");

                XmlNode node = xDoc.DocumentElement.SelectSingleNode("/MYNS:ProveedorModel", manager);

                int id_usuario = Convert.ToInt32(node.SelectSingleNode("MYNS:id_usuario", manager).InnerText);
                string usuario = node.SelectSingleNode("MYNS:usuario", manager).InnerText;
                string clave = node.SelectSingleNode("MYNS:clave", manager).InnerText;
                int tipo = Convert.ToInt32(node.SelectSingleNode("MYNS:tipo", manager).InnerText);
                string fecha_registro = node.SelectSingleNode("MYNS:fecha_registro", manager).InnerText;

                string tipo_nombre = "";

                if (tipo == 1)
                {
                    tipo_nombre = "Administrador";
                    cmbTipo.SelectedIndex = 1;
                }

                if (tipo == 2)
                {
                    tipo_nombre = "Usuario";
                    cmbTipo.SelectedIndex = 0;
                }

                txtID_Usuario.Text = Convert.ToString(id_usuario);
                txtUsuario.Text = usuario;
                txtPassword.Text = clave;

            }

        }

        private void agregarUsuario()
        {
            Usuario usuario = new Usuario();
            usuario.usuario = txtUsuario.Text;
            usuario.clave = md5_encode(txtPassword.Text);
            if (cmbTipo.SelectedIndex == 0)
            {
                usuario.tipo = 2;
            }
            if (cmbTipo.SelectedIndex == 1)
            {
                usuario.tipo = 1;
            }
            usuario.fecha_registro = fecha_del_dia();

            try
            {
                var cliente = new WebClient();

                cliente.Headers[HttpRequestHeader.ContentType] = "application/json";

                string data = JsonConvert.SerializeObject(usuario);

                string response = cliente.UploadString(txtURL.Text + "/Api/Usuarios", "POST", data);

                MessageBox.Show("Usuario agregado");
            }
            catch (WebException ex)
            {
                var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                MessageBox.Show("Status Code : " + statusCode);
            }

        }

        private void editarUsuario()
        {
            Usuario usuario = new Usuario();
            usuario.id_usuario = Convert.ToInt32(txtID_Usuario.Text);
            usuario.usuario = txtUsuario.Text;
            usuario.clave = md5_encode(txtPassword.Text);
            if (cmbTipo.SelectedIndex == 0)
            {
                usuario.tipo = 2;
            }
            if (cmbTipo.SelectedIndex == 1)
            {
                usuario.tipo = 1;
            }
            usuario.fecha_registro = fecha_del_dia();

            try
            {
                var cliente = new WebClient();

                cliente.Headers[HttpRequestHeader.ContentType] = "application/json";

                string data = JsonConvert.SerializeObject(usuario);

                string response = cliente.UploadString(txtURL.Text + "/Api/Usuarios/" + usuario.id_usuario, "PUT", data);

                MessageBox.Show("Usuario editado");
            }
            catch (WebException ex)
            {
                var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                MessageBox.Show("Status Code : " + statusCode);
            }

        }

        private void borrarUsuario()
        {
            Usuario usuario = new Usuario();
            usuario.id_usuario = Convert.ToInt32(txtID_Usuario.Text);
            usuario.usuario = txtUsuario.Text;
            usuario.clave = txtPassword.Text;
            if (cmbTipo.SelectedIndex == 0)
            {
                usuario.tipo = 2;
            }
            if (cmbTipo.SelectedIndex == 1)
            {
                usuario.tipo = 1;
            }
            usuario.fecha_registro = fecha_del_dia();

            try
            {
                var cliente = new WebClient();

                cliente.Headers[HttpRequestHeader.ContentType] = "application/json";

                string data = JsonConvert.SerializeObject(usuario);

                string response = cliente.UploadString(txtURL.Text + "/Api/Usuarios/" + usuario.id_usuario, "DELETE", data);

                MessageBox.Show("Usuario borrado");
            }
            catch (WebException ex)
            {
                var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                MessageBox.Show("Status Code : " + statusCode);
            }

        }

        private void btnCLEAR_Productos_Click(object sender, EventArgs e)
        {
            txtID_Producto.Text = "";
            txtNombre.Text = "";
            rtbDescripcion.Text = "";
            cmbProveedor.SelectedIndex = -1;
            txtPrecio.Text = "";
        }

        private void btnCLEAR_Proveedores_Click(object sender, EventArgs e)
        {
            txtID_Proveedor.Text = "";
            txtNombreEmpresa.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }

        private void btnBuscarProveedores_Click(object sender, EventArgs e)
        {
            cargarProveedores();
        }

        private void lvProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvProveedores.SelectedIndices.Count > 0 && lvProveedores.SelectedIndices[0] != -1)
            {
                cargarProveedor(Convert.ToInt32((lvProveedores.SelectedItems[0].Tag)));
            }
        }

        private void btnPOST_Proveedor_Click(object sender, EventArgs e)
        {
            agregarProveedor();
            cargarProveedores();
        }

        private void btnPUT_Proveedor_Click(object sender, EventArgs e)
        {
            editarProveedor();
            cargarProveedores();
        }

        private void btnDEL_Proveedor_Click(object sender, EventArgs e)
        {
            borrarProveedor();
            cargarProveedores();
        }

        private void btnBuscarProductos_Click(object sender, EventArgs e)
        {
            cargarComboProveedores();
            cargarProductos();
        }

        private void lvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvProductos.SelectedIndices.Count > 0 && lvProductos.SelectedIndices[0] != -1)
            {
                cargarProducto(Convert.ToInt32((lvProductos.SelectedItems[0].Tag)));
            }
        }

        private void btnGET_Producto_Click(object sender, EventArgs e)
        {
            cargarProductos();
            cargarComboProveedores();
        }

        private void btnPOST_Producto_Click(object sender, EventArgs e)
        {
            agregarProducto();
            cargarProductos();
        }

        private void btnPUT_Producto_Click(object sender, EventArgs e)
        {
            editarProducto();
            cargarProductos();
        }

        private void btnDEL_Producto_Click(object sender, EventArgs e)
        {
            borrarProducto();
            cargarProductos();
        }

        private void btnCLEAR_Usuarios_Click(object sender, EventArgs e)
        {
            txtID_Usuario.Text = "";
            txtUsuario.Text = "";
            txtPassword.Text = "";
            cmbTipo.SelectedIndex = -1;
        }

        private void lvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvUsuarios.SelectedIndices.Count > 0 && lvUsuarios.SelectedIndices[0] != -1)
            {
                cargarUsuario(Convert.ToInt32((lvUsuarios.SelectedItems[0].Tag)));
            }
        }

        private void btnGET_Usuario_Click(object sender, EventArgs e)
        {
            cargarUsuarios();
        }

        private void btnPOST_Usuario_Click(object sender, EventArgs e)
        {
            agregarUsuario();
            cargarUsuarios();
        }

        private void btnPUT_Usuario_Click(object sender, EventArgs e)
        {
            editarUsuario();
            cargarUsuarios();
        }

        private void btnDEL_Usuario_Click(object sender, EventArgs e)
        {
            borrarUsuario();
            cargarUsuarios();
        }

        private void btnBuscarUsuarios_Click(object sender, EventArgs e)
        {
            cargarUsuarios();
        }

    }
}
