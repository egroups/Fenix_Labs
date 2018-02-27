using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Personal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            // Home

            routes.MapRoute(
                name: "Raiz",
                url: "",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            // Empleados

            routes.MapRoute(
                name: "Empleados",
                url: "Empleados",
                defaults: new { controller = "Empleados", action = "Index" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "AgregarEmpleadoGET",
                url: "Empleados/Agregar",
                defaults: new { controller = "Empleados", action = "Agregar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "AgregarEmpleadoPOST",
                url: "Empleados/Agregar",
                defaults: new { controller = "Empleados", action = "Agregar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "EditarEmpleadoGET",
                url: "Empleados/Editar/{id}",
                defaults: new { controller = "Empleados", action = "Editar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "EditarEmpleadoPOST",
                url: "Empleados/Editar",
                defaults: new { controller = "Empleados", action = "GrabarEditar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "BorrarEmpleadoGET",
                url: "Empleados/Borrar/{id}",
                defaults: new { controller = "Empleados", action = "ConfirmarBorrar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "BorrarEmpleadoPOST",
                url: "Empleados/Borrar",
                defaults: new { controller = "Empleados", action = "Borrar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            // Profesiones

            routes.MapRoute(
                name: "Profesiones",
                url: "Profesiones",
                defaults: new { controller = "Profesiones", action = "Index" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "AgregarProfesionGET",
                url: "Profesiones/Agregar",
                defaults: new { controller = "Profesiones", action = "Agregar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "AgregarProfesionPOST",
                url: "Profesiones/Agregar",
                defaults: new { controller = "Profesiones", action = "Agregar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "EditarProfesionGET",
                url: "Profesiones/Editar/{id}",
                defaults: new { controller = "Profesiones", action = "Editar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "EditarProfesionPOST",
                url: "Profesiones/Editar",
                defaults: new { controller = "Profesiones", action = "GrabarEditar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "BorrarProfesionGET",
                url: "Profesiones/Borrar/{id}",
                defaults: new { controller = "Profesiones", action = "ConfirmarBorrar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "BorrarProfesionPOST",
                url: "Profesiones/Borrar",
                defaults: new { controller = "Profesiones", action = "Borrar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

        }
    }
}