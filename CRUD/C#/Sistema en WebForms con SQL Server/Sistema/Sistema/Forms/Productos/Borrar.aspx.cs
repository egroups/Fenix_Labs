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
    public partial class Borrar : System.Web.UI.Page
    {

        ProductoDatos productoDatos = new ProductoDatos();
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
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        Producto producto = productoDatos.Get(id);
                        string nombre = producto.nombre;
                        hfID.Value = id.ToString();
                        lblBorrar.Text = "¿ Estás seguro que deseas eliminar al producto " + nombre + "?";
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

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.id = Convert.ToInt32(hfID.Value);

            if (productoDatos.Delete(producto))
            {
                Application["mensaje"] = funcion.mensaje("Productos","Producto borrado","success");
                Response.Redirect("~/Forms/Productos/Index.aspx");
            }
            else
            {
                Application["mensaje"] = funcion.mensaje("Productos","Error borrando producto","error");
                Response.Redirect("~/Forms/Productos/Borrar.aspx?id=" + producto.id);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Productos/Index.aspx");
        }
    }
}