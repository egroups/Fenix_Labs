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
    public class AdministracionController : Controller
    {
        Conexiones.Conexion conexion_now = new Conexiones.Conexion();

        //
        // GET: /Administracion/
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

        // Reportes
        public ActionResult DescargarReporte()
        {

            CrystalDecisions.CrystalReports.Engine.ReportDocument reporte = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            reporte.Load(Server.MapPath("~/Reportes/Reporte.rpt"));
            reporte.SetDatabaseLogon("admin", "123456", "localhost\\SQLEXPRESS", "sistema");
            reporte.Refresh();

            try
            {
                Stream stream = reporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "Sistema_Reporte.pdf");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //

	}
}