// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Sistema.Forms.Cuenta
{
    public partial class CambiarUsuario : System.Web.UI.Page
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
                        string usuario = funcion.get_username_in_cookie(contenido);
                        txtUsuario.Text = usuario;
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

        protected void btnCambiarUsuario_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "" && txtNuevoUsuario.Text != "" && txtClave.Text != "")
            {
                string usuario = txtUsuario.Text;
                string nuevo_usuario = txtNuevoUsuario.Text;
                string clave = funcion.md5_encode(txtClave.Text);

                int id = usuarioDatos.get_id_by_user(usuario);

                if (usuarioDatos.check_login(usuario, clave))
                {
                    if (usuarioDatos.check_exists_usuario_add(nuevo_usuario))
                    {
                        Application["mensaje"] = funcion.mensaje("El usuario " + nuevo_usuario + " ya existe");
                        Response.Redirect("~/Forms/Cuenta/CambiarUsuario.aspx");
                    }
                    else
                    {
                        if (usuarioDatos.change_username(id, nuevo_usuario))
                        {
                            Session[session_name] = null;
                            Application["mensaje"] = funcion.mensaje("El usuario ha sido cambiando exitosamente, reinicie la aplicación");
                            Response.Redirect("~/Forms/Login/Index.aspx");
                        }
                        else
                        {
                            Application["mensaje"] = funcion.mensaje("Ha ocurrido un error cambiando el usuario");
                            Response.Redirect("~/Forms/Cuenta/CambiarUsuario.aspx");
                        }
                    }
                }
                else
                {
                    Application["mensaje"] = funcion.mensaje("Login inválido");
                    Response.Redirect("~/Forms/Cuenta/CambiarUsuario.aspx");
                }
            }
            else
            {
                Application["mensaje"] = funcion.mensaje("Faltan datos");
                Response.Redirect("~/Forms/Cuenta/CambiarUsuario.aspx");
            }
        }
    }
}