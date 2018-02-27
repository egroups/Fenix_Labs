// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Sistema.Models;

namespace Sistema.Forms.Proveedores
{
    public partial class Agregar : System.Web.UI.Page
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
            if (txtNombre.Text != "" && txtDireccion.Text != "" && txtTelefono.Text != "")
            {
                string nombre = txtNombre.Text;
                string direccion = txtDireccion.Text;
                int telefono = Convert.ToInt32(txtTelefono.Text);
                string fecha_registro = funcion.fecha_del_dia();

                Proveedor proveedor = new Proveedor();
                proveedor.nombre = nombre;
                proveedor.direccion = direccion;
                proveedor.telefono = telefono;
                proveedor.fecha_registro = fecha_registro;

                if (proveedorDatos.check_exists_proveedor_add(proveedor.nombre))
                {
                    Application["mensaje"] = funcion.mensaje("Proveedores","El proveedor " + proveedor.nombre + " ya existe","warning");
                    Response.Redirect("~/Forms/Proveedores/Agregar.aspx");
                }
                else
                {
                    if (proveedorDatos.Add(proveedor))
                    {
                        Application["mensaje"] = funcion.mensaje("Proveedores", "Proveedor agregado", "success");
                        Response.Redirect("~/Forms/Proveedores/Index.aspx");
                    }
                    else
                    {
                        Application["mensaje"] = funcion.mensaje("Proveedores", "Error agregando proveedor", "error");
                        Response.Redirect("~/Forms/Proveedores/Agregar.aspx");
                    }
                }

            }
            else
            {
                Application["mensaje"] = funcion.mensaje("Proveedores","Faltan datos","warning");
                Response.Redirect("~/Forms/Proveedores/Agregar.aspx");
            }
        }
    }
}