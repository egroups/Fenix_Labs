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
    public class UsuariosController : Controller
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
                    if (conexion_now.valid_cookie_admin(Request.Cookies["uid"].Value))
                    {
                        return View("Buscador");
                    }
                    else
                    {
                        ViewBag.estado = 1;
                        ViewBag.titulo = "Usuarios";
                        ViewBag.contenido = "Acceso Denegado";
                        ViewBag.tipo = "error";
                        ViewBag.controlador = "Administracion";
                        ViewBag.accion = "Index";
                        ViewBag.Title = "Administracion";
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

        [ActionName("Buscador"), HttpPost]
        public ActionResult Buscador(BuscadorModel model)
        {
            if (Request.Cookies["uid"] != null)
            {
                if (conexion_now.valid_cookie(Request.Cookies["uid"].Value))
                {
                    if (conexion_now.valid_cookie_admin(Request.Cookies["uid"].Value))
                    {
                        ViewBag.buscador_activo = 1;
                        ViewBag.nombre_buscar = model.nombre_buscar;
                        ViewBag.Title = "Usuarios";
                        return View("Buscador");
                    }
                    else
                    {
                        ViewBag.estado = 1;
                        ViewBag.titulo = "Usuarios";
                        ViewBag.contenido = "Acceso Denegado";
                        ViewBag.tipo = "error";
                        ViewBag.controlador = "Administracion";
                        ViewBag.accion = "Index";
                        ViewBag.Title = "Administracion";
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

        public ActionResult Agregar()
        {
            if (Request.Cookies["uid"] != null)
            {
                if (conexion_now.valid_cookie(Request.Cookies["uid"].Value))
                {
                    if (conexion_now.valid_cookie_admin(Request.Cookies["uid"].Value))
                    {
                        return View("Agregar");
                    }
                    else
                    {
                        ViewBag.estado = 1;
                        ViewBag.titulo = "Usuarios";
                        ViewBag.contenido = "Acceso Denegado";
                        ViewBag.tipo = "error";
                        ViewBag.controlador = "Administracion";
                        ViewBag.accion = "Index";
                        ViewBag.Title = "Administracion";
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

        [ActionName("Agregar"), HttpPost]
        public ActionResult AgregarUsuario(UsuarioModel model)
        {
            if (Request.Cookies["uid"] != null)
            {
                if (conexion_now.valid_cookie(Request.Cookies["uid"].Value))
                {
                    if (conexion_now.valid_cookie_admin(Request.Cookies["uid"].Value))
                    {
                        string respuesta = "";
                        bool done = false;
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
                                    done = false;
                                }
                                else
                                {
                                    string password_encoded = funcion.md5_encode(clave);
                                    if (conexion_now.agregarUsuario(nombre_usuario, password_encoded, tipo))
                                    {
                                        respuesta = "El usuario ha sido registrado exitosamente";
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

                        string mensaje_tipo = "";

                        if (done == true)
                        {
                            mensaje_tipo = "success";
                        }
                        else
                        {
                            mensaje_tipo = "warning";
                        }

                        ViewBag.estado = 1;
                        ViewBag.titulo = "Usuarios";
                        ViewBag.contenido = respuesta;
                        ViewBag.tipo = mensaje_tipo;
                        ViewBag.Title = "Usuarios";
                        return View("~/Views/Shared/_ViewMessage.cshtml");
                    }
                    else
                    {
                        ViewBag.estado = 1;
                        ViewBag.titulo = "Usuarios";
                        ViewBag.contenido = "Acceso Denegado";
                        ViewBag.tipo = "error";
                        ViewBag.controlador = "Administracion";
                        ViewBag.accion = "Index";
                        ViewBag.Title = "Administracion";
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

        public ActionResult Editar(int id)
        {
            if (Request.Cookies["uid"] != null)
            {
                if (conexion_now.valid_cookie(Request.Cookies["uid"].Value))
                {
                    if (conexion_now.valid_cookie_admin(Request.Cookies["uid"].Value))
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
                        return View("Editar");
                    }
                    else
                    {
                        ViewBag.estado = 1;
                        ViewBag.titulo = "Usuarios";
                        ViewBag.contenido = "Acceso Denegado";
                        ViewBag.tipo = "error";
                        ViewBag.controlador = "Administracion";
                        ViewBag.accion = "Index";
                        ViewBag.Title = "Administracion";
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

        [ActionName("Editar"), HttpPost]
        public ActionResult Editar(AsignarUsuarioModel model)
        {
            if (Request.Cookies["uid"] != null)
            {
                if (conexion_now.valid_cookie(Request.Cookies["uid"].Value))
                {
                    if (conexion_now.valid_cookie_admin(Request.Cookies["uid"].Value))
                    {
                        string respuesta = "";
                        bool done = false;
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
                                respuesta = "Los datos ingresados en el formulario son invalidos";
                                done = false;
                            }

                        }
                        else
                        {
                            respuesta = "Los datos ingresados en el formulario son invalidos";
                            done = false;
                        }

                        string mensaje_tipo = "";

                        if (done == true)
                        {
                            mensaje_tipo = "success";
                        }
                        else
                        {
                            mensaje_tipo = "warning";
                        }

                        ViewBag.estado = 1;
                        ViewBag.titulo = "Usuarios";
                        ViewBag.contenido = respuesta;
                        ViewBag.tipo = mensaje_tipo;
                        ViewBag.Title = "Usuarios";
                        return View("~/Views/Shared/_ViewMessage.cshtml");
                    }
                    else
                    {
                        ViewBag.estado = 1;
                        ViewBag.titulo = "Usuarios";
                        ViewBag.contenido = "Acceso Denegado";
                        ViewBag.tipo = "error";
                        ViewBag.controlador = "Administracion";
                        ViewBag.accion = "Index";
                        ViewBag.Title = "Administracion";
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

        public ActionResult Borrar(int id)
        {
            if (Request.Cookies["uid"] != null)
            {
                if (conexion_now.valid_cookie(Request.Cookies["uid"].Value))
                {
                    if (conexion_now.valid_cookie_admin(Request.Cookies["uid"].Value))
                    {
                        bool ok = false;
                        string respuesta = "";
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
                            ViewBag.titulo = "Usuarios";
                            ViewBag.contenido = "El usuario ha sido borrado exitosamente";
                            ViewBag.tipo = "success";
                            ViewBag.controlador = "Administracion";
                            ViewBag.accion = "Usuarios";
                            ViewBag.Title = "Usuarios";
                            return View("~/Views/Shared/_ViewMessage.cshtml");
                        }
                        else
                        {
                            ViewBag.estado = 1;
                            ViewBag.titulo = "Usuarios";
                            ViewBag.contenido = respuesta;
                            ViewBag.tipo = "warning";
                            ViewBag.Title = "Usuarios";
                            return View("~/Views/Shared/_ViewMessage.cshtml");
                        }
                    }
                    else
                    {
                        ViewBag.estado = 1;
                        ViewBag.titulo = "Usuarios";
                        ViewBag.contenido = "Acceso Denegado";
                        ViewBag.tipo = "error";
                        ViewBag.controlador = "Administracion";
                        ViewBag.accion = "Index";
                        ViewBag.Title = "Administracion";
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