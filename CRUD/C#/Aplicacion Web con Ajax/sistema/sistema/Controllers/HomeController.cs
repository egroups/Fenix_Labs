using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sistema.Controllers
{
    public class HomeController : Controller
    {
        Conexiones.Conexion conexion_now = new Conexiones.Conexion();

        public ActionResult Index()
        {
            if (Request.Cookies["uid"] != null)
            {
                if (conexion_now.valid_cookie(Request.Cookies["uid"].Value))
                {
                    return RedirectToAction("Index", "Administracion");
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