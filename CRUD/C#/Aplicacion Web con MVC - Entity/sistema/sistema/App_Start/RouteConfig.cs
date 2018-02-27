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

            // Cambiar usuario

            routes.MapRoute(
                name: "CambiarUsuario",
                url: "Administracion/CambiarUsuario",
                defaults: new { controller = "Administracion", action = "CambiarUsuario" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "CambiarUsuarioPOST",
                url: "Administracion/EditarUsuario",
                defaults: new { controller = "Administracion", action = "EditarUsuario" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "CambiarUsuarioGET",
                url: "Administracion/EditarUsuario",
                defaults: new { controller = "Administracion", action = "CambiarUsuario" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            // Cambiar password

            routes.MapRoute(
                name: "CambiarPassword",
                url: "Administracion/CambiarPassword",
                defaults: new { controller = "Administracion", action = "CambiarPassword" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "CambiarPasswordPOST",
                url: "Administracion/EditarPassword",
                defaults: new { controller = "Administracion", action = "EditarPassword" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "CambiarPasswordGET",
                url: "Administracion/EditarPassword",
                defaults: new { controller = "Administracion", action = "CambiarPassword" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            // Tester

            routes.MapRoute(
                name: "test",
                url: "test",
                defaults: new { controller = "Test", action = "Index" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            // Proveedores

            routes.MapRoute(
                name: "proveedores",
                url: "Administracion/Proveedores",
                defaults: new { controller = "Administracion", action = "Proveedores" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "buscarProveedoresPOST",
                url: "Administracion/BuscarProveedores",
                defaults: new { controller = "Administracion", action = "BuscarProveedores" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "buscarProveedoresGET",
                url: "Administracion/BuscarProveedores",
                defaults: new { controller = "Administracion", action = "Proveedores" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "agregarProveedorGET",
                url: "Administracion/AgregarProveedor",
                defaults: new { controller = "Administracion", action = "Proveedores" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "agregarProveedor",
                url: "Administracion/AgregarProveedor",
                defaults: new { controller = "Administracion", action = "AgregarProveedor" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "CargarEditarProveedorGET",
                url: "Administracion/Proveedores/Editar/{id}",
                defaults: new { controller = "Administracion", action = "CargarEditarProveedor" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "editarProveedorPOST",
                url: "Administracion/EditarProveedor",
                defaults: new { controller = "Administracion", action = "EditarProveedor" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "editarProveedorGET",
                url: "Administracion/EditarProveedor",
                defaults: new { controller = "Administracion", action = "Proveedores" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "borrarProveedor",
                url: "Administracion/Proveedores/Borrar/{id}",
                defaults: new { controller = "Administracion", action = "BorrarProveedor" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            // Productos

            routes.MapRoute(
                name: "productos",
                url: "Administracion/Productos",
                defaults: new { controller = "Administracion", action = "Productos" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "buscarProductosPOST",
                url: "Administracion/BuscarProductos",
                defaults: new { controller = "Administracion", action = "BuscarProductos" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "buscarProductosGET",
                url: "Administracion/BuscarProductos",
                defaults: new { controller = "Administracion", action = "Productos" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "agregarProductoGET",
                url: "Administracion/AgregarProducto",
                defaults: new { controller = "Administracion", action = "Productos" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "agregarProducto",
                url: "Administracion/AgregarProducto",
                defaults: new { controller = "Administracion", action = "AgregarProducto" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "CargarEditarProductoGET",
                url: "Administracion/Productos/Editar/{id}",
                defaults: new { controller = "Administracion", action = "CargarEditarProducto" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "editarProductoPOST",
                url: "Administracion/EditarProducto",
                defaults: new { controller = "Administracion", action = "EditarProducto" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "editarProductoGET",
                url: "Administracion/EditarProducto",
                defaults: new { controller = "Administracion", action = "Productos" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "borrarProducto",
                url: "Administracion/Productos/Borrar/{id}",
                defaults: new { controller = "Administracion", action = "BorrarProducto" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );


            // Usuarios

            routes.MapRoute(
                name: "usuarios",
                url: "Administracion/Usuarios",
                defaults: new { controller = "Administracion", action = "Usuarios" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "buscarUsuariosPOST",
                url: "Administracion/BuscarUsuarios",
                defaults: new { controller = "Administracion", action = "BuscarUsuarios" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "buscarUsuariosGET",
                url: "Administracion/BuscarUsuarios",
                defaults: new { controller = "Administracion", action = "Usuarios" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "agregarUsuarioGET",
                url: "Administracion/AgregarUsuario",
                defaults: new { controller = "Administracion", action = "Usuarios" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "agregarUsuario",
                url: "Administracion/AgregarUsuario",
                defaults: new { controller = "Administracion", action = "AgregarUsuario" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "CargarEditarUsuarioGET",
                url: "Administracion/Usuarios/Editar/{id}",
                defaults: new { controller = "Administracion", action = "CargarEditarUsuario" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "editarUsuarioPOST",
                url: "Administracion/AsignarUsuario",
                defaults: new { controller = "Administracion", action = "AsignarUsuario" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "editarUsuarioGET",
                url: "Administracion/EditarUsuario",
                defaults: new { controller = "Administracion", action = "Usuarios" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );

            routes.MapRoute(
                name: "borrarUsuario",
                url: "Administracion/Usuarios/Borrar/{id}",
                defaults: new { controller = "Administracion", action = "BorrarUsuario" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            );
            
        }
    }
}