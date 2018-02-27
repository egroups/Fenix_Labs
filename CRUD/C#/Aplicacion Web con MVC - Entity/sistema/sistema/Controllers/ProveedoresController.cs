// Written By Ismael Heredia in the year 2016

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sistema.Models;

namespace sistema.Controllers
{
    public class ProveedoresController : Controller
    {

        private SistemaEntidades conexion_now = new SistemaEntidades();

        //
        // GET: /Proveedores/

        public ActionResult Index()
        {
            //return View();
            return View(conexion_now.proveedores.ToList());
        }

    }
}
