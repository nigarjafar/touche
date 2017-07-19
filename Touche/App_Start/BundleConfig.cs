using System.Web;
using System.Web.Optimization;

namespace Touche
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jqBootstrapValidation.js",
                        "~/Scripts/jquery.isotope.js"
                        ));
            
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/crud").Include(
                     "~/Scripts/crud.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootbox").Include(
                    "~/Scripts/bootbox.js"));
            bundles.Add(new ScriptBundle("~/bundles/tinymce").Include(
                    "~/Scripts/tinymce/tinymce.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                      "~/Scripts/SmoothScroll.js",
                      "~/Scripts/nivo-lightbox.js",
                      "~/Scripts/contact_me.js",
                      "~/Scripts/main.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      
                      "~/Content/style.css",
                      "~/Content/nivo-lightbox/nivo-lightbox.css",
                      "~/Content/nivo-lightbox/default.css"));
        }
    }
}
