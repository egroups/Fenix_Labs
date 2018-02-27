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
                        "~/Content/js/jquery2.2.0.js","~/Content/js/app.js",
                        "~/Content/bootstrap/js/bootstrap.js", "~/Content/dist/sweetalert-dev.js"));
        }
    }
}
