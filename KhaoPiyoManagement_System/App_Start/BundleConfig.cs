using System.Web;
using System.Web.Optimization;

namespace KhaoPiyoManagement_System
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js","~/vendor/jquery/dist/jquery.min.js", "~/vendor/popper.js/dist/umd/popper.min.js", 
                        "~/vendor/bootstrap/dist/js/bootstrap.min.js", "~/vendor/headroom.js/dist/headroom.min.js", "~/vendor/onscreen/dist/on-screen.umd.min.js",
                        "~/vendor/nouislider/distribute/nouislider.min.js", "~/vendor/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js", "~/vendor/waypoints/lib/jquery.waypoints.min.js",
                        "~/vendor/jarallax/dist/jarallax.min.js", "~/vendor/jquery.counterup/jquery.counterup.min.js", "~/vendor/jquery-countdown/dist/jquery.countdown.min.js"
                        , "~/vendor/smooth-scroll/dist/smooth-scroll.polyfills.min.js", "~/vendor/prismjs/prism.js", "~/assets/js/neumorphism.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}
