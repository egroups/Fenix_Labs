using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sistema.Models;

namespace sistema.Controllers
{
    public class LoginController : Controller
    {
        Conexiones.Conexion conexion_now = new Conexiones.Conexion();

        //
        // GET: /Login/
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
                    return View("LogOn");
                }
            }
            else
            {
                return View("LogOn");
            }
        }
	}
}