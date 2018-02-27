using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace Sistema
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Content/css").Include(
            "~/Content/bootstrap/css/bootstrap.css",
            "~/Content/css/style.css",
            "~/Content/dist/sweetalert.css"));

            bundles.Add(new ScriptBundle("~/Content/scripts").Include(
                            "~/Content/js/jquery-3.2.1.js",
                            "~/Content/dist/sweetalert-dev.js",
                            "~/Content/bootstrap/js/bootstrap.js"
                            ));
        }
    }
}