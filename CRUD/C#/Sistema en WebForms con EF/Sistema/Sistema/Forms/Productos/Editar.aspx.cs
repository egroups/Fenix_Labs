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
    public partial class Editar : System.Web.UI.Page
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

                        int id = Convert.ToInt32(Request.QueryString["id"]);

                        Producto producto = productoDatos.Get(id);

                        hfID.Value = producto.id.ToString();
                        txtNombre.Text = producto.nombre;
                        txtDescripcion.Text = producto.descripcion;
                        txtPrecio.Text = producto.precio.ToString();

                        ddlProveedor.SelectedValue = producto.id_proveedor.ToString();

                        lblEditar.Text = "Editando al producto " + producto.nombre;

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

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtDescripcion.Text != "" && txtPrecio.Text != "" && ddlProveedor.Text != "")
            {
                int id = Convert.ToInt32(hfID.Value);
                string nombre = txtNombre.Text;
                string descripcion = txtDescripcion.Text;
                double precio = Convert.ToDouble(txtPrecio.Text);
                int id_proveedor = Convert.ToInt32(ddlProveedor.SelectedValue);

                Producto producto = new Producto();
                producto.id = id;
                producto.nombre = nombre;
                producto.descripcion = descripcion;
                producto.precio = precio;
                producto.id_proveedor = id_proveedor;

                if (productoDatos.check_exists_producto_edit(producto.id, producto.nombre))
                {
                    Application["mensaje"] = funcion.mensaje("Productos","El producto " + producto.nombre + " ya existe","warning");
                    Response.Redirect("~/Forms/Productos/Editar.aspx?id=" + id);
                }
                else
                {
                    if (productoDatos.Update(producto))
                    {
                        Application["mensaje"] = funcion.mensaje("Productos", "Proveedor editado", "success");
                        Response.Redirect("~/Forms/Productos/Index.aspx");
                    }
                    else
                    {
                        Application["mensaje"] = funcion.mensaje("Productos", "Error registrando producto", "error");
                        Response.Redirect("~/Forms/Productos/Editar.aspx?id=" + id);
                    }
                }

            }
            else
            {
                Application["mensaje"] = funcion.mensaje("Productos","Faltan datos","warning");
                Response.Redirect("~/Forms/Productos/Editar.aspx?id=" + Request.QueryString["id"]);
            }
        }
    }
}