using System.Web;
using System.Web.Optimization;

namespace sistema
{
    public class BundleConfig
    {
        // Para obtener más información acerca de Bundling, consulte http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            // CSS Login

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/css/style.css"));

            // CSS Admin

            bundles.Add(new StyleBundle("~/Content/Admin/css").Include(
                        "~/Content/css/Site.css",
                        "~/Content/css/main.css",
                        "~/Content/css/more_style.css",
                        "~/Content/css/style2.css"));

            // JavaScript Admin

            bundles.Add(new ScriptBundle("~/Content/Admin/Scripts").Include(
                        "~/Content/js/jquery.js",
                        "~/Content/js/jquery_002.js",
                        "~/Content/js/skel.js",
                        "~/Content/js/skel-viewport.js",
                        "~/Content/js/util.js",
                        "~/Content/js/main.js"));

            //

        }
    }
}