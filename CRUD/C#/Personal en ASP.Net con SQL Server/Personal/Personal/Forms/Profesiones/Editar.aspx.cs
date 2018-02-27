// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Personal.Functions;
using Personal.Models;

namespace Personal.Forms.Profesiones
{
    public partial class Editar : System.Web.UI.Page
    {

        ProfesionDatos profesionDatos = new ProfesionDatos();
        Funciones funcion = new Funciones();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);

                Profesion profesion = profesionDatos.Get(id);

                hfID.Value = profesion.id.ToString();
                txtNombre.Text = profesion.nombre;

                if (Application["mensaje"] != null)
                {
                    string mensaje = Application["mensaje"].ToString();
                    lblMensaje.Text = mensaje;
                    Application["mensaje"] = "";
                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                int id = Convert.ToInt32(hfID.Value);
                string nombre = txtNombre.Text;

                Profesion profesion = new Profesion();
                profesion.id = id;
                profesion.nombre = nombre;

                if (profesionDatos.Update(profesion))
                {
                    Application["mensaje"] = funcion.mensaje("Registro editado");
                    Response.Redirect("~/Forms/Profesiones/Index.aspx");
                }
                else
                {
                    Application["mensaje"] = funcion.mensaje("Error");
                    Response.Redirect("~/Forms/Profesiones/Editar.aspx?id=" + id);
                }
            }
            else
            {
                Application["mensaje"] = funcion.mensaje("Faltan datos");
                Response.Redirect("~/Forms/Profesiones/Editar.aspx?id=" + Request.QueryString["id"]);
            }
        }
    }
}