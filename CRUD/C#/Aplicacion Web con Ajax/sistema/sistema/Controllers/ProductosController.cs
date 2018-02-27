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
    public class ProductosController : Controller
    {
        Conexiones.Conexion conexion_now = new Conexiones.Conexion();
        Funciones.Funciones funcion = new Funciones.Funciones();

        public ActionResult Buscador()
        {
            if (Request.Cookies["uid"] != null)
            {
                if (conexion_now.valid_cookie(Request.Cookies["uid"].Value))
                {
                    return View("Buscador");
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

        [ActionName("Buscador"), HttpPost]
        public ActionResult Buscador(BuscadorModel model)
        {
            if (Request.Cookies["uid"] != null)
            {
                if (conexion_now.valid_cookie(Request.Cookies["uid"].Value))
                {
                    ViewBag.buscador_activo = 1;
                    ViewBag.nombre_buscar = model.nombre_buscar;
                    ViewBag.Title = "Productos";
                    return View("Buscador");
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

        public ActionResult Agregar()
        {
            if (Request.Cookies["uid"] != null)
            {
                if (conexion_now.valid_cookie(Request.Cookies["uid"].Value))
                {
                    return View("Agregar");
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

        [ActionName("Agregar"), HttpPost]
        public ActionResult AgregarProducto(ProductoModel model)
        {
            if (Request.Cookies["uid"] != null)
            {
                if (conexion_now.valid_cookie(Request.Cookies["uid"].Value))
                {
                    string respuesta = "";
                    bool done = false;
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
                                done = false;
                            }
                            else
                            {
                                if (conexion_now.agregarProducto(nombre_producto, descripcion, precio, id_proveedor))
                                {
                                    respuesta = "El producto ha sido registrado exitosamente";
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
                            respuesta = "Los datos ingresados en el formulario son invalidos";
                            done = false;
                        }

                    }
                    else
                    {
                        respuesta = "Los datos ingresados en el formulario son invalidos";
                        done = false;
                    }

                    string tipo = "";

                    if (done == true)
                    {
                        tipo = "success";
                    }
                    else
                    {
                        tipo = "warning";
                    }

                    ViewBag.estado = 1;
                    ViewBag.titulo = "Productos";
                    ViewBag.contenido = respuesta;
                    ViewBag.tipo = tipo;
                    ViewBag.Title = "Productos";
                    return View("~/Views/Shared/_ViewMessage.cshtml");
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

        public ActionResult Editar(int id)
        {
            if (Request.Cookies["uid"] != null)
            {
                if (conexion_now.valid_cookie(Request.Cookies["uid"].Value))
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
                    return View("Editar");
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

        [ActionName("Editar"), HttpPost]
        public ActionResult Editar(ProductoModel model)
        {
            if (Request.Cookies["uid"] != null)
            {
                if (conexion_now.valid_cookie(Request.Cookies["uid"].Value))
                {
                    string respuesta = "";
                    bool done = false;
                    if (ModelState.IsValid)
                    {
                        int id_producto = model.id_producto;
                        string nombre_producto = model.nombre_producto;
                        string descripcion = model.descripcion;
                        int precio = model.precio;
                        int id_proveedor = model.id_proveedor;

                        if (funcion.valid_number(id_producto.ToString()) && nombre_producto != "" && descripcion != "" && funcion.valid_number(precio.ToString()) && funcion.valid_number(id_proveedor.ToString()))
                        {
                            if (conexion_now.comprobar_existencia_producto_editar(id_producto, nombre_producto))
                            {
                                respuesta = "El producto " + nombre_producto + " ya existe";
                                done = false;
                            }
                            else
                            {
                                if (conexion_now.editarProducto(id_producto, nombre_producto, descripcion, precio, id_proveedor))
                                {
                                    respuesta = "El producto ha sido editado exitosamente";
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
                            respuesta = "Los datos ingresados en el formulario son invalidos";
                            done = false;
                        }

                    }
                    else
                    {
                        respuesta = "Los datos ingresados en el formulario son invalidos";
                        done = false;
                    }

                    string tipo = "";

                    if (done == true)
                    {
                        tipo = "success";
                    }
                    else
                    {
                        tipo = "warning";
                    }

                    ViewBag.estado = 1;
                    ViewBag.titulo = "Productos";
                    ViewBag.contenido = respuesta;
                    ViewBag.tipo = tipo;

                    ViewBag.Title = "Productos";
                    return View("~/Views/Shared/_ViewMessage.cshtml");
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

        public ActionResult Borrar(int id)
        {
            if (Request.Cookies["uid"] != null)
            {
                if (conexion_now.valid_cookie(Request.Cookies["uid"].Value))
                {
                    bool ok = false;
                    string respuesta = "";
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
                        ViewBag.titulo = "Productos";
                        ViewBag.contenido = "El producto ha sido borrado exitosamente";
                        ViewBag.tipo = "success";
                        ViewBag.controlador = "Administracion";
                        ViewBag.accion = "Productos";
                        ViewBag.Title = "Productos";
                        return View("~/Views/Shared/_ViewMessage.cshtml");
                    }
                    else
                    {
                        ViewBag.estado = 1;
                        ViewBag.titulo = "Productos";
                        ViewBag.contenido = respuesta;
                        ViewBag.tipo = "warning";
                        ViewBag.Title = "Productos";
                        return View("~/Views/Shared/_ViewMessage.cshtml");

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