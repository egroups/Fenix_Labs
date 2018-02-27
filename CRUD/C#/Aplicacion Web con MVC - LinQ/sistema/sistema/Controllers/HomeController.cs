// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sistema.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            if (Request.Cookies["user_login"] != null)
            {
                Conexiones.Conexion conexion_now = new Conexiones.Conexion();

                if (conexion_now.valid_cookie(Request.Cookies["user_login"].Value))
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
