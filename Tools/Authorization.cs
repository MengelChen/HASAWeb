using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HASAWeb.Tools
{
    public class Authorization
    {
        public class AdminAuthorizeAttribute : AuthorizeAttribute
        {
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                bool _pass = false;
                if (httpContext.Session["Username"] != null) _pass = true;
                return _pass;
            }
            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                filterContext.Result = new RedirectResult("~/Manager/Login");
            }
        }
    }
}