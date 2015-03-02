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
                context.Articles.Add(new Article { Title = "A", Author = "a", Content = "Aa", Hits=0, PublishTime=DateTime.Now, ReviseTime=DateTime.Now, ExpiredTime=DateTime.Now});
                context.Articles.Add(new Article { Title = "B", Author = "a", Content = "Bb", Hits = 0, PublishTime = DateTime.Now, ReviseTime = DateTime.Now, ExpiredTime = DateTime.Now });
                context.Admins.Add(new Admin { Name = "HZD", Power = 2, Username = "HuZhengDai", LastLogin=DateTime.Now, RegisterTime=DateTime.Now});
                context.Admins.Add(new Admin { Name = "XQW", Power = 1, Username = "XiongQinWen", LastLogin = DateTime.Now, RegisterTime = DateTime.Now });
                context.Pictures.Add(new Picture { Name = "Logo", Route = "~/Content/LOGO.png", UploadTime=DateTime.Now});
                context.Pictures.Add(new Picture { Name = "News", Route = "~/Content/News_CH.png", UploadTime=DateTime.Now});
                context.SaveChanges();
                base.Seed(context);
            }
        }

        protected void Application_Start()
        {
            Database.SetInitializer(new ManagerInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
