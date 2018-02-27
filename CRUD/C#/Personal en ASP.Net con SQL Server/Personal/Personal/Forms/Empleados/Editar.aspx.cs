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
    public partial class Editar : System.Web.UI.Page
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

                int id = Convert.ToInt32(Request.QueryString["id"]);

                Empleado empleado = empleadoDatos.Get(id);

                hfID.Value = empleado.id.ToString();
                txtNombre.Text = empleado.nombre;
                txtDireccion.Text = empleado.direccion;
                txtTelefono.Text = empleado.telefono.ToString();

                if (empleado.sexo == "Masculino")
                {
                    rbMasculino.Checked = true;
                    rbFemenino.Checked = false;
                }

                if (empleado.sexo == "Femenino")
                {
                    rbMasculino.Checked = false;
                    rbFemenino.Checked = true;
                }

                ddlProfesiones.SelectedValue = empleado.id_profesion.ToString();

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
            if (txtNombre.Text != "" && txtDireccion.Text != "" && txtTelefono.Text != "" && ddlProfesiones.SelectedValue != "")
            {
                int id = Convert.ToInt32(hfID.Value);
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

                empleado.id = id;
                empleado.nombre = nombre;
                empleado.direccion = direccion;
                empleado.telefono = telefono;
                empleado.sexo = sexo;
                empleado.id_profesion = id_profesion;

                if (empleadoDatos.Update(empleado))
                {
                    Application["mensaje"] = funcion.mensaje("Registro editado");
                    Response.Redirect("~/Forms/Empleados/Index.aspx");
                }
                else
                {
                    Application["mensaje"] = funcion.mensaje("Error");
                    Response.Redirect("~/Forms/Empleados/Editar.aspx?id="+id);
                }
            }
            else
            {
                Application["mensaje"] = funcion.mensaje("Faltan datos");
                Response.Redirect("~/Forms/Empleados/Editar.aspx?id=" + Request.QueryString["id"]);
            }
        }
    }
}