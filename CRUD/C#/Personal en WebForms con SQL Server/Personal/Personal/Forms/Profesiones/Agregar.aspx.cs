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
    public partial class Agregar : System.Web.UI.Page
    {

        ProfesionDatos profesionDatos = new ProfesionDatos();
        Funciones funcion = new Funciones();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Application["mensaje"] != null)
                {
                    string mensaje = Application["mensaje"].ToString();
                    lblMensaje.Text = mensaje;
                    Application["mensaje"] = "";
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                string nombre = txtNombre.Text;

                Profesion profesion = new Profesion();
                profesion.nombre = nombre;

                if (profesionDatos.Add(profesion))
                {
                    Application["mensaje"] = funcion.mensaje("Registro agregado");
                    Response.Redirect("~/Forms/Profesiones/Index.aspx");
                }
                else
                {
                    Application["mensaje"] = funcion.mensaje("Error");
                    Response.Redirect("~/Forms/Profesiones/Agregar.aspx");
                }

            }
            else
            {
                Application["mensaje"] = funcion.mensaje("Faltan datos");
                Response.Redirect("~/Forms/Profesiones/Agregar.aspx");
            }
        }
    }
}