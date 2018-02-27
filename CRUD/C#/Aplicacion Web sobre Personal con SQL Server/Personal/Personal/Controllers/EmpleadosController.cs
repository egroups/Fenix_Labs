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
    public class EmpleadosController : Controller
    {

        EmpleadoDatos empleadoDatos = new EmpleadoDatos();
        ProfesionDatos profesionDatos = new ProfesionDatos();
        Funciones funcion = new Funciones();

        //
        // GET: /Empleados/

        public ActionResult Index()
        {
            if (TempData["mensaje"] != null)
            {
                ViewBag.mensaje = TempData["mensaje"].ToString();
            }
            return View(empleadoDatos.List(""));
        }

        public ActionResult Agregar()
        {
            if (TempData["mensaje"] != null)
            {
                ViewBag.mensaje = TempData["mensaje"].ToString();
            }
            ViewBag.profesiones = profesionDatos.List(""); 
            return View();
        }

        [ActionName("Agregar"), HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Models.Empleado model)
        {
            string texto = "";
            string tipo = "";
            if (ModelState.IsValid)
            {

                Empleado empleado = new Empleado();
                empleado.nombre = model.nombre;
                empleado.direccion = model.direccion;
                empleado.telefono = model.telefono;
                empleado.sexo = model.sexo;
                empleado.id_profesion = model.id_profesion;

                if (empleadoDatos.Add(empleado))
                {
                    texto = "El empleado ha sido registrado exitosamente";
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

            TempData["mensaje"] = funcion.mensaje("Empleados", texto, tipo);

            if (tipo == "success")
            {
                return RedirectToAction("Index", "Empleados");
            }
            else
            {
                return RedirectToAction("Agregar", "Empleados");
            }
        }

        public ActionResult Editar(int id)
        {
            if (TempData["mensaje"] != null)
            {
                ViewBag.mensaje = TempData["mensaje"].ToString();
            }
            Empleado empleado = empleadoDatos.Get(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.profesiones = profesionDatos.List(""); 
            return View(empleado);
        }

        [ActionName("GrabarEditar"), HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GrabarEditar(Models.Empleado model)
        {
            string texto = "";
            string tipo = "";
            if (ModelState.IsValid)
            {

                Empleado empleado = new Empleado();
                empleado.id = model.id;
                empleado.nombre = model.nombre;
                empleado.direccion = model.direccion;
                empleado.telefono = model.telefono;
                empleado.sexo = model.sexo;
                empleado.id_profesion = model.id_profesion;

                if (empleadoDatos.Update(empleado))
                {
                    texto = "El empleado ha sido editado exitosamente";
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

            TempData["mensaje"] = funcion.mensaje("Empleados", texto, tipo);

            if (tipo == "success")
            {
                return RedirectToAction("Index", "Empleados");
            }
            else
            {
                return RedirectToAction("Editar", "Empleados", new { id = model.id });
            }
        }

        public ActionResult ConfirmarBorrar(int id)
        {
            Empleado empleado = empleadoDatos.Get(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View("Borrar", empleado);
        }

        [ActionName("Borrar"), HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Borrar()
        {
            int id = Convert.ToInt32(Request["id"]);
            string texto = "";
            string tipo = "";
            if (empleadoDatos.Delete(id))
            {
                texto = "El empleado ha sido borrado exitosamente";
                tipo = "success";
            }
            else
            {
                texto = "Ha ocurrido un error en la base de funcion";
                tipo = "error";
            }
            TempData["mensaje"] = funcion.mensaje("Empleados", texto, tipo);
            return RedirectToAction("Index", "Empleados");
        }

    }
}
