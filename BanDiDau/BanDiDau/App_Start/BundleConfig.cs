﻿using System.Web;
using System.Web.Optimization;

namespace BanDiDau
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
                            "~/Scripts/respond.js",
                           // < !-- / TEMPLATE IS-- >
                           "~/Scripts/js/slimmenu.js",
                            "~/Scripts/js/bootstrap-datepicker.js",
                            "~/Scripts/js/bootstrap-timepicker.js",
                            "~/Scripts/js/nicescroll.js",
                            "~/Scripts/js/dropit.js",
                            "~/Scripts/js/ionrangeslider.js",
                             "~/Scripts/js/icheck.js",
                            "~/Scripts/js/dropit.js",
                            "~/Scripts/js/fotorama.js",
                            "~/Scripts/js/typeahead.js",
                            "~/Scripts/js/card-payment.js",
                            "~/Scripts/js/magnific.js",
                            "~/Scripts/js/owl-carousel.js",
                            "~/Scripts/js/fitvids.js",
                            "~/Scripts/js/tweet.js",
                            "~/Scripts/js/countdown.js",
                            "~/Scripts/js/gridrotator.js",
                            "~/Scripts/js/mapsgoogle.js",
                            "~/Scripts/js/custom.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        // < !-- / TEMPALTE CSS-- >
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/font-awesome.css",
                      "~/Content/css/icomoon.css",
                      "~/Content/css/styles.css",
                        //"~/Content/css/style_add.css",
                      "~/Content/css/mystyles.css"));
                   



        }
    }
}

       