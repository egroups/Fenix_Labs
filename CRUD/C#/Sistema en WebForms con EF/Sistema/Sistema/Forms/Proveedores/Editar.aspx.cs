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
    public partial class Editar : System.Web.UI.Page
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

                        hfID.Value = proveedor.id.ToString();
                        txtNombre.Text = proveedor.nombre;
                        txtDireccion.Text = proveedor.direccion;
                        txtTelefono.Text = proveedor.telefono.ToString();

                        lblEditar.Text = "Editando al proveedor " + proveedor.nombre;

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
            if (txtNombre.Text != "" && txtDireccion.Text != "" && txtTelefono.Text != "")
            {
                int id = Convert.ToInt32(hfID.Value);
                string nombre = txtNombre.Text;
                string direccion = txtDireccion.Text;
                int telefono = Convert.ToInt32(txtTelefono.Text);

                Proveedor proveedor = new Proveedor();
                proveedor.id = id;
                proveedor.nombre = nombre;
                proveedor.direccion = direccion;
                proveedor.telefono = telefono;

                if (proveedorDatos.check_exists_proveedor_edit(proveedor.id, proveedor.nombre))
                {
                    Application["mensaje"] = funcion.mensaje("Proveedores","El proveedor " + proveedor.nombre + " ya existe","warning");
                    Response.Redirect("~/Forms/Proveedores/Editar.aspx?id=" + id);
                }
                else
                {
                    if (proveedorDatos.Update(proveedor))
                    {
                        Application["mensaje"] = funcion.mensaje("Proveedores", "Proveedor editado", "success");
                        Response.Redirect("~/Forms/Proveedores/Index.aspx");
                    }
                    else
                    {
                        Application["mensaje"] = funcion.mensaje("Proveedores", "Error editando proveedor", "error");
                        Response.Redirect("~/Forms/Proveedores/Editar.aspx?id=" + id);
                    }
                }

            }
            else
            {
                Application["mensaje"] = funcion.mensaje("Proveedores","Faltan datos","warning");
                Response.Redirect("~/Forms/Proveedores/Editar.aspx?id=" + Request.QueryString["id"]);
            }
        }
    }
}