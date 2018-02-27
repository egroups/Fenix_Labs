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
    public partial class Index : System.Web.UI.Page
    {

        ProductoDatos productoDatos = new ProductoDatos();
        Funciones funcion = new Funciones();

        string session_name = ConfigurationManager.AppSettings["session_name"].ToString();

        private void limpiarMensajes()
        {
            lblMensaje.Text = "";
            Application["mensaje"] = "";
        }

        private void recargarLista()
        {
            List<Producto> productosTotal = productoDatos.List("");
            List<Producto> productosEncontrados = productoDatos.List(txtBuscar.Text);

            lblProductos.Text = "Productos disponibles : " + productosTotal.Count();
            lblProductosEncontrados.Text = "Productos encontrados : " + productosEncontrados.Count();

            this.gvProductos.DataSource = productosEncontrados;
            this.gvProductos.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session[session_name] != null)
                {
                    string contenido = Session[session_name].ToString();
                    if (funcion.valid_cookie(contenido))
                    {
                        recargarLista();
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            limpiarMensajes();
            recargarLista();
        }

    }
}