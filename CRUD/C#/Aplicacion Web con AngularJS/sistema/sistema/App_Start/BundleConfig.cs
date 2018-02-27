using System.Web;
using System.Web.Optimization;

namespace sistema
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
            "~/Content/bootstrap/css/bootstrap.min.css",
            "~/Content/css/style.css",
            "~/Content/dist/sweetalert.css"));

            bundles.Add(new ScriptBundle("~/Content/Scripts").Include(
                        "~/Content/js/jquery2.2.0.js",
                        "~/Content/bootstrap/js/bootstrap.js", "~/Content/dist/sweetalert-dev.js", "~/Content/chart/js/highcharts.js", "~/Content/chart/js/modules/exporting.js"));

             bundles.Add(new ScriptBundle("~/Content/AngularJS").Include(
                        "~/Content/js/angular.js", "~/Content/js/app.js", "~/Content/js/controllers.js"
                        , "~/Content/js/controllers/ProductosCtrl.js", "~/Content/js/controllers/ProveedoresCtrl.js", "~/Content/js/controllers/UsuariosCtrl.js"
                        , "~/Content/js/controllers/CuentaCtrl.js", "~/Content/js/controllers/EstadisticasCtrl.js", "~/Content/js/services/loginService.js"));

        }
    }
}
