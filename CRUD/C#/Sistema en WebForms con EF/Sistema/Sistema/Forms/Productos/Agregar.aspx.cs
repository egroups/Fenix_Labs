// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema.Models;
using System.Configuration;

namespace Sistema.Forms.Productos
{
    public partial class Agregar : System.Web.UI.Page
    {

        ProductoDatos productoDatos = new ProductoDatos();
        ProveedorDatos proveedorDatos = new ProveedorDatos();
        Funciones funcion = new Funciones();

        string session_name = ConfigurationManager.AppSettings["session_name"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[session_name] != null)
                {
                    string contenido = Session[session_name].ToString();
                    if (funcion.valid_cookie(contenido))
                    {
                        ddlProveedor.DataSource = proveedorDatos.List("");
                        ddlProveedor.DataBind();

                        if (Application["mensaje"] != null)
                        {
                            string mensaje = Application["mensaje"].ToString();
                            lblMensaje.Text = mensaje;
                            Application["mensaje"] = "";
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Forms/Login/Index.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Forms/Login/Index.aspx");
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtDescripcion.Text != "" && txtPrecio.Text != "" && ddlProveedor.Text != "")
            {
                string nombre = txtNombre.Text;
                string descripcion = txtDescripcion.Text;
                double precio = Convert.ToDouble(txtPrecio.Text);
                int id_proveedor = Convert.ToInt32(ddlProveedor.SelectedValue);
                string fecha_registro = funcion.fecha_del_dia();

                Producto producto = new Producto();
                producto.nombre = nombre;
                producto.descripcion = descripcion;
                producto.precio = precio;
                producto.id_proveedor = id_proveedor;
                producto.fecha_registro = fecha_registro;

                if (productoDatos.check_exists_producto_add(producto.nombre))
                {
                    Application["mensaje"] = funcion.mensaje("Productos","El producto " + producto.nombre + " ya existe","warning");
                    Response.Redirect("~/Forms/Productos/Agregar.aspx");
                }
                else
                {
                    if (productoDatos.Add(producto))
                    {
                        Application["mensaje"] = funcion.mensaje("Productos", "Producto agregado", "success");
                        Response.Redirect("~/Forms/Productos/Index.aspx");
                    }
                    else
                    {
                        Application["mensaje"] = funcion.mensaje("Productos", "Error agregando producto", "error");
                        Response.Redirect("~/Forms/Productos/Agregar.aspx");
                    }
                }

            }
            else
            {
                Application["mensaje"] = funcion.mensaje("Productos","Faltan datos","warning");
                Response.Redirect("~/Forms/Productos/Agregar.aspx");
            }
        }
    }
}