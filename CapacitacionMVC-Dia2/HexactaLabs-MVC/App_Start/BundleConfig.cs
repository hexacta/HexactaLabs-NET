using System.Web;
using System.Web.Optimization;

namespace HexactaLabs_MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                         "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.*"));

            bundles.Add(new StyleBundle("~/Content/bootstrap/bootstrap").Include(
                "~/Content/bootstrap/bootstrap.*"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
