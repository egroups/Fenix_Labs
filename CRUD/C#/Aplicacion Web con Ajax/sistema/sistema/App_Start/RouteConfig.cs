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
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Home

            routes.MapRoute(
                name: "raiz",
                url: "",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            // Login

            routes.MapRoute(
                name: "login",
                url: "Login/LogOn",
                defaults: new { controller = "Login", action = "Index" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "logoff",
                url: "LogOut",
                defaults: new { controller = "Login", action = "LogOut" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "LoginStart",
                url: "Login/LogOn",
                defaults: new { controller = "Login", action = "LogOn" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            // Admin

            routes.MapRoute(
                name: "admin",
                url: "Administracion",
                defaults: new { controller = "Administracion", action = "Index" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            // Reporte

            routes.MapRoute(
                name: "DescargarReporte",
                url: "Administracion/DescargarReporte",
                defaults: new { controller = "Administracion", action = "DescargarReporte" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            // Productos

            routes.MapRoute(
                name: "BuscadorProductos",
                url: "Administracion/Productos/Buscador",
                defaults: new { controller = "Productos", action = "Buscador" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "BuscarProductosPOST",
                url: "Administracion/Productos/Buscador",
                defaults: new { controller = "Productos", action = "Buscador" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "AgregarProducto",
                url: "Administracion/Productos/Agregar",
                defaults: new { controller = "Productos", action = "Agregar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "AgregarProductoPOST",
                url: "Administracion/Productos/Agregar",
                defaults: new { controller = "Productos", action = "Agregar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "EditarProducto",
                url: "Administracion/Productos/Editar/{id}",
                defaults: new { controller = "Productos", action = "Editar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }), id = @"\d+" }
            );

            routes.MapRoute(
                name: "EditarProductoPOST",
                url: "Administracion/Productos/Editar",
                defaults: new { controller = "Productos", action = "Editar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "BorrarProducto",
                url: "Administracion/Productos/Borrar/{id}",
                defaults: new { controller = "Productos", action = "Borrar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }), id = @"\d+" }
            );

            // Proveedores

            routes.MapRoute(
                name: "BuscadorProveedores",
                url: "Administracion/Proveedores/Buscador",
                defaults: new { controller = "Proveedores", action = "Buscador" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "BuscarProveedoresPOST",
                url: "Administracion/Proveedores/Buscador",
                defaults: new { controller = "Proveedores", action = "Buscador" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "AgregarProveedor",
                url: "Administracion/Proveedores/Agregar",
                defaults: new { controller = "Proveedores", action = "Agregar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "AgregarProveedorPOST",
                url: "Administracion/Proveedores/Agregar",
                defaults: new { controller = "Proveedores", action = "Agregar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "EditarProveedor",
                url: "Administracion/Proveedores/Editar/{id}",
                defaults: new { controller = "Proveedores", action = "Editar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }), id = @"\d+" }
            );

            routes.MapRoute(
                name: "EditarProveedorPOST",
                url: "Administracion/Proveedores/Editar",
                defaults: new { controller = "Proveedores", action = "Editar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "BorrarProveedor",
                url: "Administracion/Proveedores/Borrar/{id}",
                defaults: new { controller = "Proveedores", action = "Borrar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }), id = @"\d+" }
            );

            // Usuarios

            routes.MapRoute(
                name: "BuscadorUsuarios",
                url: "Administracion/Usuarios/Buscador",
                defaults: new { controller = "Usuarios", action = "Buscador" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "BuscarUsuariosPOST",
                url: "Administracion/Usuarios/Buscador",
                defaults: new { controller = "Usuarios", action = "Buscador" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "AgregarUsuario",
                url: "Administracion/Usuarios/Agregar",
                defaults: new { controller = "Usuarios", action = "Agregar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "AgregarUsuarioPOST",
                url: "Administracion/Usuarios/Agregar",
                defaults: new { controller = "Usuarios", action = "Agregar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "EditarUsuario",
                url: "Administracion/Usuarios/Editar/{id}",
                defaults: new { controller = "Usuarios", action = "Editar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }), id = @"\d+" }
            );

            routes.MapRoute(
                name: "EditarUsuarioPOST",
                url: "Administracion/Usuarios/Editar",
                defaults: new { controller = "Usuarios", action = "Editar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "BorrarUsuario",
                url: "Administracion/Usuarios/Borrar/{id}",
                defaults: new { controller = "Usuarios", action = "Borrar" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }), id = @"\d+" }
            );

            // Cuenta

            routes.MapRoute(
                name: "CambiarUsuario",
                url: "Administracion/Cuenta/CambiarUsuario",
                defaults: new { controller = "Cuenta", action = "CambiarUsuario" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "CambiarUsuarioPOST",
                url: "Administracion/Cuenta/CambiarUsuario",
                defaults: new { controller = "Cuenta", action = "CambiarUsuario" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "CambiarPassword",
                url: "Administracion/Cuenta/CambiarPassword",
                defaults: new { controller = "Cuenta", action = "CambiarPassword" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "CambiarPasswordPOST",
                url: "Administracion/Cuenta/CambiarPassword",
                defaults: new { controller = "Cuenta", action = "CambiarPassword" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

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

        }
    }
}
