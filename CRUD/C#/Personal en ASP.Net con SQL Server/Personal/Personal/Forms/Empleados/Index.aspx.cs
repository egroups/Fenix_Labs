// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Personal.Functions;
using Personal.Models;

namespace Personal.Forms.Empleados
{
    public partial class Index : System.Web.UI.Page
    {

        EmpleadoDatos empleadoDatos = new EmpleadoDatos();
        Funciones funcion = new Funciones();

        private void recargarLista()
        {
            this.gvEmpleados.DataSource = empleadoDatos.List("");
            this.gvEmpleados.DataBind();
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
            Empleado empleado = new Empleado();
            empleado.id = id;
            if (empleadoDatos.Delete(empleado))
            {
                Application["mensaje"] = funcion.mensaje("Registro borrado");
            }
            else
            {
                Application["mensaje"] = funcion.mensaje("Error");
            }
            Response.Redirect("~/Forms/Empleados/Index.aspx");
        }

    }
}