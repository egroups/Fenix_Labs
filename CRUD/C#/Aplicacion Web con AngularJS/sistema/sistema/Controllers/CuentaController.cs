using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }

        public ActionResult IngresoUsuario()
        {
            bool status = false;
            string msg = "";

            string username_login = Request["username"];
            string password_encoded = funcion.md5_encode(Request["password"]);
            if (conexion_now.ingreso_usuario(username_login, password_encoded))
            {
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

        public ActionResult CheckTipoUsuario()
        {
            bool status = false;
            string msg = "";

            string tipo_usuario = "";

            string username = Request["username"];

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
            var cookie = Request["contenido"];
            string cookie_content = funcion.base64_decode(cookie);
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

        public ActionResult GenerarCookie()
        {
            string username = Request["username"];
            string password = funcion.md5_encode(Request["password"]);
            string output = funcion.base64_encode(username + ":" + password);
            return Json(new { success = true, message = output });
        }

        public ActionResult VerificarCookie()
        {
            bool status = false;
            string msg = "";
            string cookie = Request["contenido"];
            string cookie_content = funcion.base64_decode(cookie);
            if (conexion_now.valid_cookie(cookie_content))
            {
                status = true;
                msg = "1";
            }
            else
            {
                status = true;
                msg = "0";
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

	}
}