// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sistema.Models;
using sistema.Funciones;

namespace sistema.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            ViewBag.Title = "Login";
            return View("LogOn");
        }

        public ActionResult LogOut()
        {
            if (Request.Cookies["user_login"] != null)
            {
                var userCookie = new HttpCookie("user_login");
                userCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(userCookie);
            }

            ViewBag.estado = 1;
            ViewBag.mensaje = "Las cookies han sido borradas";
            ViewBag.controlador = "Login";
            ViewBag.accion = "LogOn";
            ViewBag.Title = "Login";
            return View("Redirect");
        }

        // POST: /Login/LogOn

        [ActionName("LogOn"), HttpPost]
        public ActionResult LogOn(LogOnModel model)
        {

            string respuesta = "";

            Funciones.Funciones funcion = new Funciones.Funciones();
            Conexiones.Conexion conexion_now = new Conexiones.Conexion();
            
            if (ModelState.IsValid)
            {
                string username_login = model.UserName;
                string password_encoded = funcion.md5_encode(model.Password);
                if (conexion_now.ingreso_usuario(username_login, password_encoded))
                {
                    var userCookie = new HttpCookie("user_login", username_login + '-' + password_encoded);
                    userCookie.Expires.AddDays(365);
                    HttpContext.Response.Cookies.Add(userCookie);

                    string tipo_usuario = "";

                    if (conexion_now.es_admin(username_login))
                    {
                        tipo_usuario = "administrador";
                    }
                    else
                    {
                        tipo_usuario = "usuario";
                    }

                    ViewBag.estado = 1;
                    ViewBag.mensaje = "Bienvenido a la seccion de administracion " + tipo_usuario + " " + username_login;
                    ViewBag.controlador = "Home";
                    ViewBag.accion = "Index";
                    ViewBag.Title = "Administracion";
                    return View("Redirect");

                }
                else
                {
                    respuesta = "Datos incorrectos";
                }
            }
            else
            {
                respuesta = "Faltan datos";
            }
            ViewBag.estado = 1;
            ViewBag.mensaje = respuesta;
            ViewBag.Title = "Login";
            return View("LogOn", model);
        }

    }
}
