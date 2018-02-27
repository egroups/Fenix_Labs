// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sistema.Models;
using sistema.Conexiones;
using sistema.Funciones;
using System.IO;

namespace sistema.Controllers
{
    public class AdministracionController : Controller
    {

        // Index

        public ActionResult Index()
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {
                    ViewBag.Title = "Administracion";
                    return View();
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        // Reportes

        public ActionResult DescargarReporte()
        {

            CrystalDecisions.CrystalReports.Engine.ReportDocument reporte = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            reporte.Load(Server.MapPath("~/Reportes/Reporte.rpt"));
            reporte.SetDatabaseLogon("admin", "123456", "localhost\\SQLEXPRESS", "sistema");
            reporte.Refresh();

            try
            {
                Stream stream = reporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "Sistema_Reporte.pdf");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //

        // Cambiar usuario

        public ActionResult CambiarUsuario()
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {
                    ViewBag.Title = "Cambiar Usuario";
                    return View();
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        [ActionName("EditarUsuario"), HttpPost]
        public ActionResult EditarUsuario(CambiarUsuarioModel model)
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {

                    Funciones.Funciones funcion = new Funciones.Funciones();
                    string respuesta = "";
                    bool done = false;
                    if (ModelState.IsValid)
                    {
                        string usuario = model.nombre_usuario;
                        string password = model.password;
                        string nuevo_usuario = model.nuevo_usuario;
                        if (usuario != "" && password != "" && nuevo_usuario != "")
                        {
                            string password_encoded = funcion.md5_encode(password);
                            if (conexion_now.ingreso_usuario(usuario, password_encoded))
                            {
                                if (conexion_now.comprobar_existencia_usuario_editar(nuevo_usuario))
                                {
                                    respuesta = "El usuario " + nuevo_usuario + " ya existe";
                                    done = false;
                                }
                                else
                                {
                                    if (conexion_now.cambiar_usuario(usuario, nuevo_usuario))
                                    {
                                        respuesta = "El usuario ha sido cambiado exitosamente";
                                        done = true;
                                    }
                                    else
                                    {
                                        respuesta = "Ha ocurrido un error en la base de datos";
                                        done = false;
                                    }
                                }
                            }
                            else
                            {
                                respuesta = "Los datos del usuario son invalidos";
                                done = false;
                            }
                        }
                        else
                        {
                            respuesta = "Los datos son invalidos";
                            done = false;
                        }
                    }
                    else
                    {
                        respuesta = "Los datos son invalidos";
                        done = false;
                    }
                    if (done == true)
                    {

                        if (Request.Cookies["user_login"] != null)
                        {
                            var userCookie = new HttpCookie("user_login");
                            userCookie.Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies.Add(userCookie);
                        }

                        ViewBag.estado = 1;
                        ViewBag.mensaje = respuesta;
                        ViewBag.controlador = "Login";
                        ViewBag.accion = "LogOn";
                        ViewBag.Title = "Cambiar usuario";
                        return View("Redirect");
                    }
                    else
                    {
                        ViewBag.estado = 1;
                        ViewBag.mensaje = respuesta;
                        ViewBag.Title = "Cambiar usuario";
                        return View("CambiarUsuario", model);
                    }
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        // Editar Password

        public ActionResult CambiarPassword()
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {
                    ViewBag.Title = "Cambiar Password";
                    return View();
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        [ActionName("EditarPassword"), HttpPost]
        public ActionResult EditarPassword(CambiarPasswordModel model)
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {

                    Funciones.Funciones funcion = new Funciones.Funciones();
                    string respuesta = "";
                    bool done = false;
                    if (ModelState.IsValid)
                    {
                        string usuario = model.nombre_usuario;
                        string password = model.password;
                        string nuevo_password = model.nuevo_password;
                        if (usuario != "" && password != "" && nuevo_password != "")
                        {
                            string password_encoded = funcion.md5_encode(password);
                            string new_password_encoded = funcion.md5_encode(nuevo_password);
                            if (conexion_now.ingreso_usuario(usuario, password_encoded))
                            {
                                if (conexion_now.cambiar_password(usuario, new_password_encoded))
                                {
                                    respuesta = "El password ha sido cambiado exitosamente";
                                    done = true;
                                }
                                else
                                {
                                    respuesta = "Ha ocurrido un error en la base de datos";
                                    done = false;
                                }
                            }
                            else
                            {
                                respuesta = "Los datos del usuario son invalidos";
                                done = false;
                            }
                        }
                        else
                        {
                            respuesta = "Los datos son invalidos";
                            done = false;
                        }
                    }
                    else
                    {
                        respuesta = "Los datos son invalidos";
                        done = false;
                    }
                    if (done == true)
                    {

                        if (Request.Cookies["user_login"] != null)
                        {
                            var userCookie = new HttpCookie("user_login");
                            userCookie.Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies.Add(userCookie);
                        }

                        ViewBag.estado = 1;
                        ViewBag.mensaje = respuesta;
                        ViewBag.controlador = "Login";
                        ViewBag.accion = "LogOn";
                        ViewBag.Title = "Administracion";
                        return View("Redirect");
                    }
                    else
                    {
                        ViewBag.estado = 1;
                        ViewBag.mensaje = respuesta;
                        ViewBag.Title = "Cambiar Password";
                        return View("CambiarPassword", model);
                    }
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        // Proveedores

        public ActionResult Proveedores()
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {
                    ViewBag.Title = "Proveedores";
                    return View();
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        [ActionName("AgregarProveedor"), HttpPost]
        public ActionResult AgregarProveedor(ProveedorModel model)
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {
                    Funciones.Funciones funcion = new Funciones.Funciones();
                    string respuesta = "";
                    if (ModelState.IsValid)
                    {
                        string nombre_empresa = model.nombre_empresa;
                        string direccion = model.direccion;
                        int telefono = model.telefono;
                        if (nombre_empresa != "" && direccion != "" && funcion.valid_number(telefono.ToString()))
                        {
                            if (conexion_now.comprobar_existencia_proveedor_crear(nombre_empresa))
                            {
                                respuesta = "El proveedor "+nombre_empresa+" ya existe";
                            }
                            else
                            {
                                if (conexion_now.agregarProveedor(nombre_empresa, direccion, telefono))
                                {
                                    respuesta = "El proveedor ha sido registrado exitosamente";
                                }
                                else
                                {
                                    respuesta = "Ha ocurrido un error en la base de datos";
                                }
                            }
                        }
                        else
                        {
                            respuesta = "Los datos ingresados en el formulario son invalidos";
                        }

                    }
                    else
                    {
                        respuesta = "Los datos ingresados en el formulario son invalidos";
                    }

                    ViewBag.estado = 1;
                    ViewBag.mensaje = respuesta;
                    ViewBag.Title = "Proveedores";
                    return View("Proveedores", model);
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        public ActionResult CargarEditarProveedor(int id)
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {
                    if (id > 0)
                    {
                        ViewBag.modoEditar = 1;
                    }
                    else
                    {
                        ViewBag.modoEditar = 0;
                    }
                    ViewBag.id_proveedor = id;
                    ViewBag.Title = "Proveedores";
                    return View("Proveedores");
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        [ActionName("EditarProveedor"), HttpPost]
        public ActionResult EditarProveedor(ProveedorModel model)
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {
                    Funciones.Funciones funcion = new Funciones.Funciones();
                    string respuesta = "";
                    if (ModelState.IsValid)
                    {
                        int id_proveedor = model.id_proveedor;
                        string nombre_empresa = model.nombre_empresa;
                        string direccion = model.direccion;
                        int telefono = model.telefono;
                        if (funcion.valid_number(id_proveedor.ToString()) && nombre_empresa != "" && direccion != "" && funcion.valid_number(telefono.ToString()))
                        {
                            if (conexion_now.comprobar_existencia_proveedor_editar(id_proveedor,nombre_empresa))
                            {
                                respuesta = "El proveedor "+nombre_empresa+" ya existe";
                            }
                            else
                            {
                                if (conexion_now.editarProveedor(id_proveedor, nombre_empresa, direccion, telefono))
                                {
                                    respuesta = "El proveedor ha sido editado exitosamente";
                                }
                                else
                                {
                                    respuesta = "Ha ocurrido un error en la base de datos";
                                }
                            }
                        }
                        else
                        {
                            respuesta = "Los datos ingresados en el formulario son invalidos";
                        }

                    }
                    else
                    {
                        respuesta = "Los datos ingresados en el formulario son invalidos";
                    }

                    ViewBag.estado = 1;
                    ViewBag.mensaje = respuesta;
                    ViewBag.Title = "Proveedores";
                    return View("Proveedores", model);
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        public ActionResult borrarProveedor(int id)
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {
                    bool ok = false;
                    string respuesta = "";
                    Funciones.Funciones funcion = new Funciones.Funciones();
                    if (funcion.valid_number(id.ToString()))
                    {
                        if (conexion_now.borrarProveedor(id))
                        {
                            respuesta = "El proveedor ha sido borrado exitosamente";
                            ok = true;
                        }
                        else
                        {
                            respuesta = "Ha ocurrido un error en la base de datos";
                            ok = false;
                        }
                    }
                    else
                    {
                        respuesta = "ID invalido";
                        ok = false;
                    }
                    if (ok == true)
                    {
                        ViewBag.estado = 1;
                        ViewBag.mensaje = "El proveedor ha sido borrado exitosamente";
                        ViewBag.controlador = "Administracion";
                        ViewBag.accion = "Proveedores";
                        ViewBag.Title = "Proveedores";
                        return View("Redirect");
                    }
                    else
                    {
                        ViewBag.estado = 1;
                        ViewBag.mensaje = respuesta;
                        ViewBag.Title = "Proveedores";
                        return View("Proveedores");
                    }
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        [ActionName("BuscarProveedores"), HttpPost]
        public ActionResult BuscarProveedores(BuscadorModel model)
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {
                    ViewBag.buscador_activo = 1;
                    ViewBag.nombre_buscar = model.nombre_buscar;
                    ViewBag.Title = "Proveedores";
                    return View("Proveedores");
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        // Productos

        public ActionResult Productos()
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {
                    ViewBag.Title = "Productos";
                    return View();
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        [ActionName("AgregarProducto"), HttpPost]
        public ActionResult AgregarProducto(ProductoModel model)
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {
                    Funciones.Funciones funcion = new Funciones.Funciones();
                    string respuesta = "";
                    if (ModelState.IsValid)
                    {
                        string nombre_producto = model.nombre_producto;
                        string descripcion = model.descripcion;
                        int precio = model.precio;
                        int id_proveedor = model.id_proveedor;
                        if (nombre_producto != "" && descripcion != "" && funcion.valid_number(precio.ToString()) && funcion.valid_number(id_proveedor.ToString()))
                        {
                            if (conexion_now.comprobar_existencia_producto_crear(nombre_producto))
                            {
                                respuesta = "El producto " + nombre_producto + " ya existe";
                            }
                            else
                            {
                                if (conexion_now.agregarProducto(nombre_producto, descripcion, precio, id_proveedor))
                                {
                                    respuesta = "El producto ha sido registrado exitosamente";
                                }
                                else
                                {
                                    respuesta = "Ha ocurrido un error en la base de datos";
                                }
                            }
                        }
                        else
                        {
                            respuesta = "Los datos ingresados en el formulario son invalidos";
                        }

                    }
                    else
                    {
                        respuesta = "Los datos ingresados en el formulario son invalidos";
                    }

                    ViewBag.estado = 1;
                    ViewBag.mensaje = respuesta;
                    ViewBag.Title = "Productos";
                    return View("Productos", model);
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        public ActionResult CargarEditarProducto(int id)
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {
                    if (id > 0)
                    {
                        ViewBag.modoEditar = 1;
                    }
                    else
                    {
                        ViewBag.modoEditar = 0;
                    }
                    ViewBag.id_producto = id;
                    ViewBag.Title = "Productos";
                    return View("Productos");
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        [ActionName("EditarProducto"), HttpPost]
        public ActionResult EditarProducto(ProductoModel model)
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {
                    Funciones.Funciones funcion = new Funciones.Funciones();
                    string respuesta = "";
                    if (ModelState.IsValid)
                    {
                        int id_producto = model.id_producto;
                        string nombre_producto = model.nombre_producto;
                        string descripcion = model.descripcion;
                        int precio = model.precio;
                        int id_proveedor = model.id_proveedor;

                        if (funcion.valid_number(id_producto.ToString()) && nombre_producto != "" && descripcion != "" && funcion.valid_number(precio.ToString()) && funcion.valid_number(id_proveedor.ToString()))
                        {
                            if (conexion_now.comprobar_existencia_producto_editar(id_producto,nombre_producto))
                            {
                                respuesta = "El producto " + nombre_producto + " ya existe";
                            }
                            else
                            {
                                if (conexion_now.editarProducto(id_producto, nombre_producto, descripcion, precio, id_proveedor))
                                {
                                    respuesta = "El producto ha sido editado exitosamente";
                                }
                                else
                                {
                                    respuesta = "Ha ocurrido un error en la base de datos";
                                }
                            }
                        }
                        else
                        {
                            respuesta = "Los datos ingresados en el formulario son invalidos";
                        }

                    }
                    else
                    {
                        respuesta = "Los datos ingresados en el formulario son invalidos";
                    }

                    ViewBag.estado = 1;
                    ViewBag.mensaje = respuesta;
                    ViewBag.Title = "Productos";
                    return View("Productos", model);
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        public ActionResult borrarProducto(int id)
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {
                    bool ok = false;
                    string respuesta = "";
                    Funciones.Funciones funcion = new Funciones.Funciones();
                    if (funcion.valid_number(id.ToString()))
                    {
                        if (conexion_now.borrarProducto(id))
                        {
                            respuesta = "El producto ha sido borrado exitosamente";
                            ok = true;
                        }
                        else
                        {
                            respuesta = "Ha ocurrido un error en la base de datos";
                            ok = false;
                        }
                    }
                    else
                    {
                        respuesta = "ID invalido";
                        ok = false;
                    }
                    if (ok == true)
                    {
                        ViewBag.estado = 1;
                        ViewBag.mensaje = "El producto ha sido borrado exitosamente";
                        ViewBag.controlador = "Administracion";
                        ViewBag.accion = "Productos";
                        ViewBag.Title = "Productos";
                        return View("Redirect");
                    }
                    else
                    {
                        ViewBag.estado = 1;
                        ViewBag.mensaje = respuesta;
                        ViewBag.Title = "Productos";
                        return View("Productos");
                    }
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        [ActionName("BuscarProductos"), HttpPost]
        public ActionResult BuscarProductos(BuscadorModel model)
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {
                    ViewBag.buscador_activo = 1;
                    ViewBag.nombre_buscar = model.nombre_buscar;
                    ViewBag.Title = "Productos";
                    return View("Productos");
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        //

        // Usuarios

        public ActionResult Usuarios()
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {
                    if (conexion_now.valid_cookie_admin(Request.Cookies["user_login"].Value))
                    {
                        ViewBag.Title = "Usuarios";
                        return View();
                    }
                    else
                    {
                        ViewBag.estado = 1;
                        ViewBag.mensaje = "Acceso Denegado";
                        ViewBag.controlador = "Administracion";
                        ViewBag.accion = "Index";
                        ViewBag.Title = "Administracion";
                        return View("Redirect");
                    }
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        [ActionName("AgregarUsuario"), HttpPost]
        public ActionResult AgregarUsuario(UsuarioModel model)
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {
                    if (conexion_now.valid_cookie_admin(Request.Cookies["user_login"].Value))
                    {
                        Funciones.Funciones funcion = new Funciones.Funciones();
                        string respuesta = "";
                        if (ModelState.IsValid)
                        {
                            string nombre_usuario = model.nombre_usuario;
                            string clave = model.password;
                            int tipo = model.tipo;

                            if (nombre_usuario != "" && clave != "" && funcion.valid_number(tipo.ToString()))
                            {
                                if (conexion_now.comprobar_existencia_usuario_crear(nombre_usuario))
                                {
                                    respuesta = "El usuario " + nombre_usuario + " ya existe";
                                }
                                else
                                {
                                    string password_encoded = funcion.md5_encode(clave);
                                    if (conexion_now.agregarUsuario(nombre_usuario, password_encoded, tipo))
                                    {
                                        respuesta = "El usuario ha sido registrado exitosamente";
                                    }
                                    else
                                    {
                                        respuesta = "Ha ocurrido un error en la base de datos";
                                    }
                                }
                            }
                            else
                            {
                                respuesta = "Los datos ingresados en el formulario son invalidos";
                            }

                        }
                        else
                        {
                            respuesta = "Los datos ingresados en el formulario son invalidos";
                        }

                        ViewBag.estado = 1;
                        ViewBag.mensaje = respuesta;
                        ViewBag.Title = "Usuarios";
                        return View("Usuarios", model);
                    }
                    else
                    {
                        ViewBag.estado = 1;
                        ViewBag.mensaje = "Acceso Denegado";
                        ViewBag.controlador = "Administracion";
                        ViewBag.accion = "Index";
                        ViewBag.Title = "Administracion";
                        return View("Redirect");
                    }
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        public ActionResult CargarEditarUsuario(int id)
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {
                    if (conexion_now.valid_cookie_admin(Request.Cookies["user_login"].Value))
                    {
                        if (id > 0)
                        {
                            ViewBag.modoEditar = 1;
                        }
                        else
                        {
                            ViewBag.modoEditar = 0;
                        }
                        ViewBag.id_usuario = id;
                        ViewBag.Title = "Usuarios";
                        return View("Usuarios");
                    }
                    else
                    {
                        ViewBag.estado = 1;
                        ViewBag.mensaje = "Acceso Denegado";
                        ViewBag.controlador = "Administracion";
                        ViewBag.accion = "Index";
                        ViewBag.Title = "Administracion";
                        return View("Redirect");
                    }
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        [ActionName("AsignarUsuario"), HttpPost]
        public ActionResult AsignarUsuario(AsignarUsuarioModel model)
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {
                    if (conexion_now.valid_cookie_admin(Request.Cookies["user_login"].Value))
                    {
                        Funciones.Funciones funcion = new Funciones.Funciones();
                        string respuesta = "";
                        if (ModelState.IsValid)
                        {
                            int id_usuario = model.id_usuario;
                            string nombre_usuario = model.nombre_usuario;
                            int tipo = model.tipo;
                            if (funcion.valid_number(id_usuario.ToString()) && nombre_usuario != "" && funcion.valid_number(tipo.ToString()))
                            {
                                if (conexion_now.asignar_usuario(id_usuario, tipo))
                                {
                                    respuesta = "El usuario ha sido asignado exitosamente";
                                }
                                else
                                {
                                    respuesta = "Ha ocurrido un error en la base de datos";
                                }
                            }
                            else
                            {
                                respuesta = "Los datos ingresados en el formulario son invalidos";
                            }

                        }
                        else
                        {
                            respuesta = "Los datos ingresados en el formulario son invalidos";
                        }

                        ViewBag.estado = 1;
                        ViewBag.mensaje = respuesta;
                        ViewBag.Title = "Usuarios";
                        return View("Usuarios", model);
                    }
                    else
                    {
                        ViewBag.estado = 1;
                        ViewBag.mensaje = "Acceso Denegado";
                        ViewBag.controlador = "Administracion";
                        ViewBag.accion = "Index";
                        ViewBag.Title = "Administracion";
                        return View("Redirect");
                    }
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        public ActionResult borrarUsuario(int id)
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {
                    if (conexion_now.valid_cookie_admin(Request.Cookies["user_login"].Value))
                    {

                        bool ok = false;
                        string respuesta = "";
                        Funciones.Funciones funcion = new Funciones.Funciones();
                        if (funcion.valid_number(id.ToString()))
                        {
                            if (conexion_now.borrarUsuario(id))
                            {
                                respuesta = "El usuario ha sido borrado exitosamente";
                                ok = true;
                            }
                            else
                            {
                                respuesta = "Ha ocurrido un error en la base de datos";
                                ok = false;
                            }
                        }
                        else
                        {
                            respuesta = "ID invalido";
                            ok = false;
                        }
                        if (ok == true)
                        {
                            ViewBag.estado = 1;
                            ViewBag.mensaje = "El usuario ha sido borrado exitosamente";
                            ViewBag.controlador = "Administracion";
                            ViewBag.accion = "Usuarios";
                            ViewBag.Title = "Usuarios";
                            return View("Redirect");
                        }
                        else
                        {
                            ViewBag.estado = 1;
                            ViewBag.mensaje = respuesta;
                            ViewBag.Title = "Usuarios";
                            return View("Usuarios");
                        }
                    }
                    else
                    {
                        ViewBag.estado = 1;
                        ViewBag.mensaje = "Acceso Denegado";
                        ViewBag.controlador = "Administracion";
                        ViewBag.accion = "Index";
                        ViewBag.Title = "Administracion";
                        return View("Redirect");
                    }
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

        [ActionName("BuscarUsuarios"), HttpPost]
        public ActionResult BuscarUsuarios(BuscadorModel model)
        {
            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
                {
                    if (conexion_now.valid_cookie_admin(Request.Cookies["user_login"].Value))
                    {
                        ViewBag.buscador_activo = 1;
                        ViewBag.nombre_buscar = model.nombre_buscar;
                        ViewBag.Title = "Usuarios";
                        return View("Usuarios");
                    }
                    else
                    {
                        ViewBag.estado = 1;
                        ViewBag.mensaje = "Acceso Denegado";
                        ViewBag.controlador = "Administracion";
                        ViewBag.accion = "Index";
                        ViewBag.Title = "Administracion";
                        return View("Redirect");
                    }
                }
                else
                {
                    return RedirectToAction("LogOn", "Login");
                }
            }
            else
            {
                return RedirectToAction("LogOn", "Login");
            }
        }

    }
}
