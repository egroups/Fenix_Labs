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
    public partial class CambiarClave : System.Web.UI.Page
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

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "" && txtActualClave.Text != "" && txtNuevaClave.Text != "")
            {
                string usuario = txtUsuario.Text;
                string actual_clave = funcion.md5_encode(txtActualClave.Text);
                string nueva_clave = funcion.md5_encode(txtNuevaClave.Text);

                int id = usuarioDatos.get_id_by_user(usuario);

                if (usuarioDatos.check_login(usuario, actual_clave))
                {
                    if (usuarioDatos.change_password(id, nueva_clave))
                    {
                        Session[session_name] = null;
                        Application["mensaje"] = funcion.mensaje("Cambiar Clave","La clave ha sido cambianda exitosamente, reinicie la aplicación","success");
                        Response.Redirect("~/Forms/Login/Index.aspx");
                    }
                    else
                    {
                        Application["mensaje"] = funcion.mensaje("Cambiar Clave","Ha ocurrido un error cambiando el usuario","error");
                        Response.Redirect("~/Forms/Cuenta/CambiarClave.aspx");
                    }
                }
                else
                {
                    Application["mensaje"] = funcion.mensaje("Cambiar Clave","Login inválido","warning");
                    Response.Redirect("~/Forms/Cuenta/CambiarClave.aspx");
                }
            }
            else
            {
                Application["mensaje"] = funcion.mensaje("Cambiar Clave","Faltan datos","warning");
                Response.Redirect("~/Forms/Cuenta/CambiarClave.aspx");
            }
        }
    }
}