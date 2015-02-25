using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using HASAWeb.Models;

namespace HASAWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public class ManagerInitializer : DropCreateDatabaseAlways<ManagerContext>
        {
            protected override void Seed(ManagerContext context)
            {
                context.Articles.Add(new Article { });
                base.Seed(context);
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
