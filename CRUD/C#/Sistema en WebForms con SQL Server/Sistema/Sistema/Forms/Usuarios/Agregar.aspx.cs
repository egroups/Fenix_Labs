// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema.Models;
using System.Configuration;

namespace Sistema.Forms.Usuarios
{
    public partial class Agregar : System.Web.UI.Page
    {

        UsuarioDatos usuarioDatos = new UsuarioDatos();
        TipoUsuarioDatos tipoUsuarioDatos = new TipoUsuarioDatos();
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
                        if (funcion.valid_cookie_admin(contenido))
                        {
                            ddlTipo.DataSource = tipoUsuarioDatos.List("");
                            ddlTipo.DataBind();

                            if (Application["mensaje"] != null)
                            {
                                string mensaje = Application["mensaje"].ToString();
                                lblMensaje.Text = mensaje;
                                Application["mensaje"] = "";
                            }
                        }
                        else
                        {
                            Application["mensaje"] = funcion.mensaje("Usuarios", "Acceso Denegado", "error");
                            Response.Redirect("~/Forms/Administracion/Index.aspx");
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
            if (txtNombre.Text != "" && txtClave.Text != "" && ddlTipo.Text != "")
            {
                string nombre = txtNombre.Text;
                string clave = funcion.md5_encode(txtClave.Text);
                int id_tipo = Convert.ToInt32(ddlTipo.SelectedValue);
                string fecha_registro = funcion.fecha_del_dia();

                Usuario usuario = new Usuario();
                usuario.nombre = nombre;
                usuario.clave = clave;
                usuario.id_tipo = id_tipo;
                usuario.fecha_registro = fecha_registro;

                if (usuarioDatos.check_exists_usuario_add(usuario.nombre))
                {
                    Application["mensaje"] = funcion.mensaje("Usuarios","El usuario " + usuario.nombre + " ya existe","warning");
                    Response.Redirect("~/Forms/Usuarios/Agregar.aspx");
                }
                else
                {
                    if (usuarioDatos.Add(usuario))
                    {
                        Application["mensaje"] = funcion.mensaje("Usuarios", "Usuario agregado", "success");
                        Response.Redirect("~/Forms/Usuarios/Index.aspx");
                    }
                    else
                    {
                        Application["mensaje"] = funcion.mensaje("Usuarios", "Error agregando usuario", "error");
                        Response.Redirect("~/Forms/Usuarios/Agregar.aspx");
                    }
                }

            }
            else
            {
                Application["mensaje"] = funcion.mensaje("Usuarios","Faltan datos","warning");
                Response.Redirect("~/Forms/Usuarios/Agregar.aspx");
            }
        }
    }
}