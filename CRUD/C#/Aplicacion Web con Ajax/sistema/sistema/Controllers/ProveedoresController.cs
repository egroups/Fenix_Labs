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
    public class ProveedoresController : Controller
    {
        Conexiones.Conexion conexion_now = new Conexiones.Conexion();
        Funciones.Funciones funcion = new Funciones.Funciones();
        //

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
                    ViewBag.Title = "Proveedores";
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
        public ActionResult Agregar(ProveedorModel model)
        {
            if (Request.Cookies["uid"] != null)
            {
                if (conexion_now.valid_cookie(Request.Cookies["uid"].Value))
                {
                    string respuesta = "";

                    bool done = false;

                    if (ModelState.IsValid)
                    {
                        string nombre_empresa = model.nombre_empresa;
                        string direccion = model.direccion;
                        int telefono = model.telefono;
                        if (nombre_empresa != "" && direccion != "" && funcion.valid_number(telefono.ToString()))
                        {
                            if (conexion_now.comprobar_existencia_proveedor_crear(nombre_empresa))
                            {
                                respuesta = "El proveedor " + nombre_empresa + " ya existe";
                                done = false;
                            }
                            else
                            {
                                if (conexion_now.agregarProveedor(nombre_empresa, direccion, telefono))
                                {
                                    respuesta = "El proveedor ha sido registrado exitosamente";
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
                    ViewBag.titulo = "Proveedores";
                    ViewBag.contenido = respuesta;
                    ViewBag.tipo = tipo;
                    ViewBag.Title = "Proveedores";

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
                    ViewBag.id_proveedor = id;
                    ViewBag.Title = "Proveedores";
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
        public ActionResult Editar(ProveedorModel model)
        {
            if (Request.Cookies["uid"] != null)
            {
                if (conexion_now.valid_cookie(Request.Cookies["uid"].Value))
                {
                    string respuesta = "";
                    bool done = false;
                    if (ModelState.IsValid)
                    {
                        int id_proveedor = model.id_proveedor;
                        string nombre_empresa = model.nombre_empresa;
                        string direccion = model.direccion;
                        int telefono = model.telefono;
                        if (funcion.valid_number(id_proveedor.ToString()) && nombre_empresa != "" && direccion != "" && funcion.valid_number(telefono.ToString()))
                        {
                            if (conexion_now.comprobar_existencia_proveedor_editar(id_proveedor, nombre_empresa))
                            {
                                respuesta = "El proveedor " + nombre_empresa + " ya existe";
                                done = false;
                            }
                            else
                            {
                                if (conexion_now.editarProveedor(id_proveedor, nombre_empresa, direccion, telefono))
                                {
                                    respuesta = "El proveedor ha sido editado exitosamente";
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
                    ViewBag.titulo = "Proveedores";
                    ViewBag.contenido = respuesta;
                    ViewBag.tipo = tipo;
                    ViewBag.Title = "Proveedores";
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
                        ViewBag.titulo = "Proveedores";
                        ViewBag.contenido = "El proveedor ha sido borrado exitosamente";
                        ViewBag.tipo = "success";
                        ViewBag.controlador = "Administracion";
                        ViewBag.accion = "Proveedores";
                        ViewBag.Title = "Proveedores";
                        return View("~/Views/Shared/_ViewMessage.cshtml");
                    }
                    else
                    {
                        ViewBag.estado = 1;
                        ViewBag.titulo = "Proveedores";
                        ViewBag.contenido = respuesta;
                        ViewBag.tipo = "warning";
                        ViewBag.Title = "Proveedores";
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