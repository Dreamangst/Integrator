using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using System.Web.Optimization;

namespace Integrator.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/JQuery/jquery-{version}.js",
                        "~/Scripts/JQuery/CustomScripts/StickyFooter.js",
                        "~/Scripts/JQuery/jquery.unobtrusive-ajax.min.js")
            );


            bundles.Add(new ScriptBundle("~/Scripts/JQuery").Include(
                        "~/Scripts/JQuery/jquery-{version}.js",
                        "~/Scripts/JQuery/jquery.*",
                        "~/Scripts/JQuery/jquery-ui-{version}.js")
            );
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/JQuery/jquery.validate*",
                        "~/Scripts/JQuery/jquery.unobtrusive*"));
 
          
            /*bundles.Add(new ScriptBundle("~/Scripts/knockout").Include(
                 "~/Scripts/Lib/knockout/knockout-{version}.js",
                 "~/Scripts/Lib/knockout/knockout-deferred-updates.js")
            );*/

             
        }
    }
}