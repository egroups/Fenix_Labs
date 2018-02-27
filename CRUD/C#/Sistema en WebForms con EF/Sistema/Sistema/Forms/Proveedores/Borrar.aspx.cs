// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema.Models;
using System.Configuration;

namespace Sistema.Forms.Proveedores
{
    public partial class Borrar : System.Web.UI.Page
    {

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
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        Proveedor proveedor = proveedorDatos.Get(id);
                        string nombre = proveedor.nombre;
                        hfID.Value = id.ToString();
                        lblBorrar.Text = "¿ Estás seguro que deseas eliminar al proveedor " + nombre + "?";
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
            Proveedor proveedor = new Proveedor();
            proveedor.id = Convert.ToInt32(hfID.Value);

            if (proveedorDatos.Delete(proveedor))
            {
                Application["mensaje"] = funcion.mensaje("Proveedores","Proveedor borrado","success");
                Response.Redirect("~/Forms/Proveedores/Index.aspx");
            }
            else
            {
                Application["mensaje"] = funcion.mensaje("Proveedores","Error borrando proveedor","error");
                Response.Redirect("~/Forms/Proveedores/Borrar.aspx?id=" + proveedor.id);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Proveedores/Index.aspx");
        }
    }
}