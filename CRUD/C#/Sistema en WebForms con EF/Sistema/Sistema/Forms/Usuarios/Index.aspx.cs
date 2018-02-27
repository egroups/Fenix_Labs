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
    public partial class Index : System.Web.UI.Page
    {

        UsuarioDatos usuarioDatos = new UsuarioDatos();
        Funciones funcion = new Funciones();

        string session_name = ConfigurationManager.AppSettings["session_name"].ToString();

        private void limpiarMensajes()
        {
            lblMensaje.Text = "";
            Application["mensaje"] = "";
        }

        private void recargarLista()
        {
            List<Usuario> usuariosTotal = usuarioDatos.List("");
            List<Usuario> usuariosEncontrados = usuarioDatos.List(txtBuscar.Text);

            lblUsuarios.Text = "Usuarios disponibles : " + usuariosTotal.Count();
            lblUsuariosEncontrados.Text = "Usuarios encontrados : " + usuariosEncontrados.Count();

            this.gvUsuarios.DataSource = usuariosEncontrados;
            this.gvUsuarios.DataBind();
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
                        if (funcion.valid_cookie_admin(contenido))
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
                            Application["mensaje"] = funcion.mensaje("Usuarios","Acceso Denegado","error");
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            limpiarMensajes();
            recargarLista();
        }
    }
}