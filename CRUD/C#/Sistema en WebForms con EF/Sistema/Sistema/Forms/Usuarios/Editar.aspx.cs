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
    public partial class Editar : System.Web.UI.Page
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

                            int id = Convert.ToInt32(Request.QueryString["id"]);

                            Usuario usuario = usuarioDatos.Get(id);

                            hfID.Value = usuario.id.ToString();
                            txtNombre.Text = usuario.nombre;

                            ddlTipo.SelectedValue = usuario.id_tipo.ToString();

                            lblEditar.Text = "Editando al usuario " + usuario.nombre;

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

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && ddlTipo.Text != "")
            {
                int id = Convert.ToInt32(hfID.Value);
                string nombre = txtNombre.Text;
                int id_tipo = Convert.ToInt32(ddlTipo.SelectedValue);

                Usuario usuario = new Usuario();
                usuario.id = id;
                usuario.nombre = nombre;
                usuario.id_tipo = id_tipo;

                if (usuarioDatos.Update(usuario))
                {
                    Application["mensaje"] = funcion.mensaje("Usuarios","Usuario editado","success");
                    Response.Redirect("~/Forms/Usuarios/Index.aspx");
                }
                else
                {
                    Application["mensaje"] = funcion.mensaje("Usuarios","Error editando usuario","error");
                    Response.Redirect("~/Forms/Usuarios/Editar.aspx?id=" + id);
                }

            }
            else
            {
                Application["mensaje"] = funcion.mensaje("Usuarios","Faltan datos","warning");
                Response.Redirect("~/Forms/Usuarios/Editar.aspx?id=" + Request.QueryString["id"]);
            }
        }
    }
}