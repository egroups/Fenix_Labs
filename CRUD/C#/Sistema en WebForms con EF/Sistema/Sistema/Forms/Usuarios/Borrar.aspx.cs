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
    public partial class Borrar : System.Web.UI.Page
    {

        UsuarioDatos usuarioDatos = new UsuarioDatos();
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
                            int id = Convert.ToInt32(Request.QueryString["id"]);
                            Usuario usuario = usuarioDatos.Get(id);
                            string nombre = usuario.nombre;
                            hfID.Value = id.ToString();
                            lblBorrar.Text = "¿ Estás seguro que deseas eliminar al usuario " + nombre + "?";
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

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.id = Convert.ToInt32(hfID.Value);

            if (usuarioDatos.Delete(usuario))
            {
                Application["mensaje"] = funcion.mensaje("Usuarios","Usuario borrado","success");
                Response.Redirect("~/Forms/Usuarios/Index.aspx");
            }
            else
            {
                Application["mensaje"] = funcion.mensaje("Usuarios","Error borrando usuario","error");
                Response.Redirect("~/Forms/Usuarios/Borrar.aspx?id=" + usuario.id);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Forms/Usuarios/Index.aspx");
        }
    }
}