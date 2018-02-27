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
    public partial class Index : System.Web.UI.Page
    {

        ProfesionDatos profesionDatos = new ProfesionDatos();
        Funciones funcion = new Funciones();

        private void recargarLista()
        {
            this.gvProfesiones.DataSource = profesionDatos.List("");
            this.gvProfesiones.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                recargarLista();

                if (Application["mensaje"] != null)
                {
                    string mensaje = Application["mensaje"].ToString();
                    lblMensaje.Text = mensaje;
                    Application["mensaje"] = "";
                }
            }
        }

        protected void lbBorrar_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            HiddenField hd = (HiddenField)lb.FindControl("hfID");
            int id = Convert.ToInt32(hd.Value);
            Profesion profesion = new Profesion();
            profesion.id = id;
            if (profesionDatos.Delete(profesion))
            {
                Application["mensaje"] = funcion.mensaje("Registro borrado");
            }
            else
            {
                Application["mensaje"] = funcion.mensaje("Error");
            }
            Response.Redirect("~/Forms/Profesiones/Index.aspx");
        }
    }
}