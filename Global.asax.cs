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
                context.Articles.Add(new Article { Title = "A", Author = "a", Content = "Aa", Abstraction = "a", Keywords = "a,a", Column = "活动新闻", Link = string.Empty, Pictures = "1,2,3", Hits = 0, PublishTime = DateTime.Now, ReviseTime = DateTime.Now, ExpiredTime = DateTime.Now });
                context.Articles.Add(new Article { Title = "B", Author = "a", Content = "Bb", Abstraction = "b", Keywords = "b,b", Column = "留学经验", Link = string.Empty, Pictures = "4,5,6", Hits = 0, PublishTime = DateTime.Now, ReviseTime = DateTime.Now, ExpiredTime = DateTime.Now });
                context.Admins.Add(new Admin { Name = "HZD", Power = 2, Username = "admin", Password = "jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=", LastLogin = DateTime.Now, RegisterTime = DateTime.Now });
                //context.Admins.Add(new Admin { Name = "XQW", Power = 1, Username = "XiongQinWen", Password = "827CCB0EEA8A706C4C34A16891F84E7B", LastLogin = DateTime.Now, RegisterTime = DateTime.Now });
                context.Pictures.Add(new Picture { Name = "HomePage1", Route = @"/Content/1.png", UploadTime = DateTime.Now });
                context.Pictures.Add(new Picture { Name = "HomePage2", Route = @"/Content/2.png", UploadTime = DateTime.Now });
                context.Pictures.Add(new Picture { Name = "HomePage3", Route = @"/Content/3.png", UploadTime = DateTime.Now });
                context.Pictures.Add(new Picture { Name = "HomePage4", Route = @"/Content/4.png", UploadTime = DateTime.Now });
                context.Pictures.Add(new Picture { Name = "HomePage5", Route = @"/Content/5.png", UploadTime = DateTime.Now });
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
