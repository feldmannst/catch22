using System.Web;
using System.Web.Optimization;

namespace Catch22
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/mainsite").Include(
                      "~/Scripts/swipe.js",
                      "~/Scripts/mainPage.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/css/font-awesome.css",
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/bundles/cssCMS").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/css/font-awesome.css",
                      "~/Content/themes/base/jquery.ui.all.css",
                      "~/Content/admin-custom.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/jquery-ui-1.10.4.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin-custom").Include(
                "~/Scripts/admin-custom.js"));
        }
    }
}
