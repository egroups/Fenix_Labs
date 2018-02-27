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
    public partial class Agregar : System.Web.UI.Page
    {

        EmpleadoDatos empleadoDatos = new EmpleadoDatos();
        ProfesionDatos profesionDatos = new ProfesionDatos();
        Funciones funcion = new Funciones();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProfesiones.DataSource = profesionDatos.List("");
                ddlProfesiones.DataBind();

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
            if (txtNombre.Text != "" && txtDireccion.Text != "" && txtTelefono.Text != "" && ddlProfesiones.SelectedValue != "")
            {
                string nombre = txtNombre.Text;
                string direccion = txtDireccion.Text;
                int telefono = Convert.ToInt32(txtTelefono.Text);

                string sexo = "";

                if (rbMasculino.Checked)
                {
                    sexo = "Masculino";
                }
                else
                {
                    sexo = "Femenino";
                }

                int id_profesion = Convert.ToInt32(ddlProfesiones.SelectedValue);

                Empleado empleado = new Empleado();

                empleado.nombre = nombre;
                empleado.direccion = direccion;
                empleado.telefono = telefono;
                empleado.sexo = sexo;
                empleado.id_profesion = id_profesion;

                if (empleadoDatos.Add(empleado))
                {
                    Application["mensaje"] = funcion.mensaje("Registro agregado");
                    Response.Redirect("~/Forms/Empleados/Index.aspx");
                }
                else
                {
                    Application["mensaje"] = funcion.mensaje("Error");
                    Response.Redirect("~/Forms/Empleados/Agregar.aspx");
                }
            }
            else
            {
                Application["mensaje"] = funcion.mensaje("Faltan datos");
                Response.Redirect("~/Forms/Empleados/Agregar.aspx");
            }
        }
    }
}