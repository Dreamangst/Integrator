using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
//
using System.Web.Optimization;
using System.Data.Entity;
using Integrator.App_Start;
using Integrator.DAL;

namespace Integrator
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            Database.SetInitializer<IntegratorContext>(new IntegratorInitializer());
            //Database.SetInitializer(new Integrator.DAL.IntegratorInitializer());
            //TestDataFill.seedAll();

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
