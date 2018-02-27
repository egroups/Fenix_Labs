// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Sistema.Forms.Login
{
    public partial class Index : System.Web.UI.Page
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
                        Response.Redirect("~/Forms/Administracion/Index.aspx");
                    }
                }
                if (Application["mensaje"] != null)
                {
                    string mensaje = Application["mensaje"].ToString();
                    lblMensaje.Text = mensaje;
                    Application["mensaje"] = "";
                }
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "" && txtClave.Text != "")
            {
                string usuario = txtUsuario.Text;
                string clave = funcion.md5_encode(txtClave.Text);

                if (usuarioDatos.check_login(usuario, clave))
                {
                    Session[session_name] = usuario + "-" + clave;
                    string tipo_usuario = usuarioDatos.get_user_type(usuario);
                    string texto = "Bienvenido a la administración " + tipo_usuario + " " + usuario;
                    string mensaje = funcion.mensaje_con_redireccion("Login",texto,"success", "/Forms/Administracion/Index.aspx");
                    lblMensaje.Text = mensaje;
                }
                else
                {
                    string mensaje = funcion.mensaje("Login", "Login incorrecto", "warning");
                    lblMensaje.Text = mensaje;
                }
            }
            else
            {
                string mensaje = funcion.mensaje("Login", "Faltan datos", "warning");
                lblMensaje.Text = mensaje;
            }
        }
    }
}