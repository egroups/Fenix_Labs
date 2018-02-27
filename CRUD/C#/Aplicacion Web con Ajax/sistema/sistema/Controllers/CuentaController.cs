using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sistema.Conexiones;
using sistema.Funciones;
using sistema.Models;

namespace sistema.Controllers
{

    public class CuentaController : Controller
    {

        Conexiones.Conexion conexion_now = new Conexiones.Conexion();
        Funciones.Funciones funcion = new Funciones.Funciones();

        //
        // GET: /Cuenta/
        public ActionResult Index()
        {
            if (Request.Cookies["uid"] != null)
            {
                if (conexion_now.valid_cookie(Request.Cookies["uid"].Value))
                {
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

        public ActionResult IngresoUsuario(string username,string password)
        {
            bool status = false;
            string msg = "";

            string username_login = username;
            string password_encoded = funcion.md5_encode(password);
            if (conexion_now.ingreso_usuario(username_login, password_encoded))
            {
                var userCookie = new HttpCookie("uid", funcion.base64_encode(username_login + ':' + password_encoded));
                userCookie.Expires.AddDays(365);
                HttpContext.Response.Cookies.Add(userCookie);
                status = true;
                msg = "1";
            }
            else
            {
                status = false;
                msg = "0";
            }
            return Json(new { success = status, message = msg });
        }

        public ActionResult CheckTipoUsuario(string username)
        {
            bool status = false;
            string msg = "";

            string tipo_usuario = "";

            if (conexion_now.es_admin(username))
            {
                tipo_usuario = "administrador";
            }
            else
            {
                tipo_usuario = "usuario";
            }

            msg = tipo_usuario;

            return Json(new { success = status, message = msg });
        }

        public ActionResult GetUsernameInCookie()
        {
            bool status = false;
            string msg = "";
            var cookie = Request.Cookies["uid"];
            string cookie_content = cookie.Value;
            string username = "";
            try
            {
                username = conexion_now.get_username_in_cookie(cookie_content);
                status = true;
                msg = username;
            }
            catch
            {
                status = false;
                msg = username;
            }
            return Json(new { success = status, message = msg });
        }

        public ActionResult CerrarSesion()
        {
            bool status = false;
            string msg = "";

            if (Request.Cookies["uid"] != null)
            {
                var userCookie = new HttpCookie("uid");
                userCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(userCookie);
                status = true;
                msg = "1";
            }
            else
            {
                status = false;
                msg = "0";
            }
            return Json(new { success = status, message = msg });
        }

        public ActionResult CambiarUsuario()
        {
            if (Request.Cookies["uid"] != null)
            {
                if (conexion_now.valid_cookie(Request.Cookies["uid"].Value))
                {
                    return View("CambiarUsuario");
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

        [ActionName("CambiarUsuario"), HttpPost]
        public ActionResult CambiarUsuario(CambiarUsuarioModel model)
        {
            if (Request.Cookies["uid"] != null)
            {
                if (conexion_now.valid_cookie(Request.Cookies["uid"].Value))
                {
                    string respuesta = "";
                    bool done = false;
                    if (ModelState.IsValid)
                    {
                        string nombre_usuario = model.username;
                        string password = model.password;
                        string nuevo_usuario = model.new_username;

                        if (nombre_usuario != "" && password != "" && nuevo_usuario != "")
                        {
                            if (conexion_now.cambiar_usuario(nombre_usuario,nuevo_usuario))
                            {
                                respuesta = "El usuario ha sido cambiado exitosamente, reinicie la aplicacion";
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
                        respuesta = "Los datos ingresados en el formulario son invalidos " + "-"+model.username+"-"+model.password+"-"+model.new_username+"-";
                        done = false;
                    }

                    string tipo = "";

                    if (done == true)
                    {
                        tipo = "success";
                        if (Request.Cookies["uid"] != null)
                        {
                            var content = new HttpCookie("uid");
                            content.Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies.Add(content);
                        }
                    }
                    else
                    {
                        tipo = "warning";
                    }

                    ViewBag.estado = 1;
                    ViewBag.titulo = "Cambiar Usuario";
                    ViewBag.contenido = respuesta;
                    ViewBag.tipo = tipo;
                    ViewBag.url = "/Login/LogOn";
                    if (tipo == "success")
                    {
                        return View("~/Views/Shared/_ViewRedirect.cshtml");
                    }
                    else
                    {
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

        public ActionResult CambiarPassword()
        {
            if (Request.Cookies["uid"] != null)
            {
                if (conexion_now.valid_cookie(Request.Cookies["uid"].Value))
                {
                    return View("CambiarPassword");
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

        [ActionName("CambiarPassword"), HttpPost]
        public ActionResult CambiarPassword(CambiarPasswordModel model)
        {
            if (Request.Cookies["uid"] != null)
            {
                if (conexion_now.valid_cookie(Request.Cookies["uid"].Value))
                {
                    string respuesta = "";
                    bool done = false;
                    if (ModelState.IsValid)
                    {
                        string nombre_usuario = model.username;
                        string password = model.password;
                        string nuevo_password = model.new_password;

                        if (nombre_usuario != "" && password != "" && nuevo_password != "")
                        {
                            if (conexion_now.cambiar_password(nombre_usuario,funcion.md5_encode(nuevo_password)))
                            {
                                respuesta = "El password ha sido cambiado exitosamente, reinicie la aplicacion";
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

                    string tipo = "";

                    if (done == true)
                    {
                        tipo = "success";
                        if (Request.Cookies["uid"] != null)
                        {
                            var content = new HttpCookie("uid");
                            content.Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies.Add(content);
                        }
                    }
                    else
                    {
                        tipo = "warning";
                    }

                    ViewBag.estado = 1;
                    ViewBag.titulo = "Cambiar Password";
                    ViewBag.contenido = respuesta;
                    ViewBag.tipo = tipo;
                    ViewBag.url = "/Login/LogOn";
                    if (tipo == "success")
                    {
                        return View("~/Views/Shared/_ViewRedirect.cshtml");
                    }
                    else
                    {
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