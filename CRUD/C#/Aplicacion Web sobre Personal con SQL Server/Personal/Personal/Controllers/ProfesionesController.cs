// Written By Ismael Heredia in the year 2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Personal.Functions;
using Personal.Models;

namespace Personal.Controllers
{
    public class ProfesionesController : Controller
    {

        ProfesionDatos profesionDatos = new ProfesionDatos();
        Funciones funcion = new Funciones();

        //
        // GET: /Profesiones/

        public ActionResult Index()
        {
            if (TempData["mensaje"] != null)
            {
                ViewBag.mensaje = TempData["mensaje"].ToString();
            }
            return View(profesionDatos.List(""));
        }

        public ActionResult Agregar()
        {
            if (TempData["mensaje"] != null)
            {
                ViewBag.mensaje = TempData["mensaje"].ToString();
            }
            return View();
        }

        [ActionName("Agregar"), HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Models.Profesion model)
        {
            string texto = "";
            string tipo = "";
            if (ModelState.IsValid)
            {
                Profesion profesion = new Profesion();
                profesion.nombre = model.nombre;
                if (profesionDatos.Add(profesion))
                {
                    texto = "La profesión ha sido registrada exitosamente";
                    tipo = "success";
                }
                else
                {
                    texto = "Ha ocurrido un error en la base de funcion";
                    tipo = "error";
                }
            }
            else
            {
                texto = "Los datos ingresados en el formulario son inválidos";
                tipo = "warning";
            }

            TempData["mensaje"] = funcion.mensaje("Profesiones", texto, tipo);

            if (tipo == "success")
            {
                return RedirectToAction("Index", "Profesiones");
            }
            else
            {
                return RedirectToAction("Agregar", "Profesiones");
            }
        }

        public ActionResult Editar(int id)
        {
            if (TempData["mensaje"] != null)
            {
                ViewBag.mensaje = TempData["mensaje"].ToString();
            }
            Profesion profesion = profesionDatos.Get(id);
            if (profesion == null)
            {
                return HttpNotFound();
            }
            return View(profesion);
        }

        [ActionName("GrabarEditar"), HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GrabarEditar(Models.Profesion model)
        {
            string texto = "";
            string tipo = "";
            if (ModelState.IsValid)
            {
                Profesion profesion = new Profesion();
                profesion.id = model.id;
                profesion.nombre = model.nombre;
                if (profesionDatos.Update(profesion))
                {
                    texto = "La profesión ha sido editada exitosamente";
                    tipo = "success";
                }
                else
                {
                    texto = "Ha ocurrido un error en la base de funcion";
                    tipo = "error";
                }
            }
            else
            {
                texto = "Los datos ingresados en el formulario son inválidos";
                tipo = "warning";
            }

            TempData["mensaje"] = funcion.mensaje("Profesiones", texto, tipo);

            if (tipo == "success")
            {
                return RedirectToAction("Index", "Profesiones");
            }
            else
            {
                return RedirectToAction("Editar", "Profesiones", new { id = model.id });
            }
        }

        public ActionResult ConfirmarBorrar(int id)
        {
            Profesion profesion = profesionDatos.Get(id);
            if (profesion == null)
            {
                return HttpNotFound();
            }
            return View("Borrar", profesion);
        }

        [ActionName("Borrar"), HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Borrar()
        {
            int id = Convert.ToInt32(Request["id"]);
            string texto = "";
            string tipo = "";
            if (profesionDatos.Delete(id))
            {
                texto = "La profesión ha sido borrada exitosamente";
                tipo = "success";
            }
            else
            {
                texto = "Ha ocurrido un error en la base de funcion";
                tipo = "error";
            }
            TempData["mensaje"] = funcion.mensaje("Profesiones", texto, tipo);
            return RedirectToAction("Index", "Profesiones");
        }
    }
}
