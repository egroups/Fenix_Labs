using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace sistema
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            // Home

            routes.MapRoute(
                name: "raiz",
                url: "",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            // Cuenta

            routes.MapRoute(
                name: "IngresoUsuarioPOST",
                url: "Cuenta/IngresoUsuario",
                defaults: new { controller = "Cuenta", action = "IngresoUsuario" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "CheckTipoUsuarioPOST",
                url: "Cuenta/CheckTipoUsuario",
                defaults: new { controller = "Cuenta", action = "CheckTipoUsuario" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "GetUsernameInCookiePOST",
                url: "Cuenta/GetUsernameInCookie",
                defaults: new { controller = "Cuenta", action = "GetUsernameInCookie" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "CerrarSesionPOST",
                url: "Cuenta/CerrarSesion",
                defaults: new { controller = "Cuenta", action = "CerrarSesion" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            // Reporte

            routes.MapRoute(
                name: "DescargarReporte",
                url: "Administracion/DescargarReporte",
                defaults: new { controller = "CRUD", action = "DescargarReporte" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            // CRUD

            routes.MapRoute(
                name: "ListarProductosPOST",
                url: "CRUD/ListarProductos",
                defaults: new { controller = "CRUD", action = "ListarProductos" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "ListarProveedoresPOST",
                url: "CRUD/ListarProveedores",
                defaults: new { controller = "CRUD", action = "ListarProveedores" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "ListarUsuariosPOST",
                url: "CRUD/ListarUsuarios",
                defaults: new { controller = "CRUD", action = "ListarUsuarios" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "GenerarCookiePOST",
                url: "Cuenta/GenerarCookie",
                defaults: new { controller = "Cuenta", action = "GenerarCookie" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "ValidarCookiePOST",
                url: "Cuenta/VerificarCookie",
                defaults: new { controller = "Cuenta", action = "VerificarCookie" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "GeUsernameInCookiePOST",
                url: "Cuenta/GetUsernameInCookie",
                defaults: new { controller = "Cuenta", action = "GetUsernameInCookie" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            // CRUD

            routes.MapRoute(
                name: "AgregarProductoPOST",
                url: "Administracion/Productos/Agregar",
                defaults: new { controller = "CRUD", action = "AgregarProducto" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "EditarProductoPOST",
                url: "Administracion/Productos/Editar",
                defaults: new { controller = "CRUD", action = "EditarProducto" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "BorrarProductoPOST",
                url: "Administracion/Productos/Borrar",
                defaults: new { controller = "CRUD", action = "BorrarProducto" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "AgregarProveedorPOST",
                url: "Administracion/Proveedores/Agregar",
                defaults: new { controller = "CRUD", action = "AgregarProveedor" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "EditarProveedorPOST",
                url: "Administracion/Proveedores/Editar",
                defaults: new { controller = "CRUD", action = "EditarProveedor" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "BorrrarProveedorPOST",
                url: "Administracion/Proveedores/Borrar",
                defaults: new { controller = "CRUD", action = "BorrarProveedor" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "AgregarUsuarioPOST",
                url: "Administracion/Usuarios/Agregar",
                defaults: new { controller = "CRUD", action = "AgregarUsuario" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "EditarUsuarioPOST",
                url: "Administracion/Usuarios/Editar",
                defaults: new { controller = "CRUD", action = "EditarUsuario" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "BorrarUsuarioPOST",
                url: "Administracion/Usuarios/Borrar",
                defaults: new { controller = "CRUD", action = "BorrarUsuario" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "CambiarUsuarioPOST",
                url: "Cuenta/CambiarUsuario",
                defaults: new { controller = "CRUD", action = "CambiarUsuario" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "CambiarPasswordPOST",
                url: "Cuenta/CambiarPassword",
                defaults: new { controller = "CRUD", action = "CambiarPassword" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

        }
    }
}
