using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
//
using System.Web.Optimization;
using System.Data.Entity;

namespace Integrator
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer(new Integrator.DAL.IntegratorInitializer());
            

            Integrator.App_Start.BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
