using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HASAWeb.Models;

namespace HASAWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*ManageDBContext MDB = new ManageDBContext();
            MDB.Database.Create();
            Admin ad = new Admin();
            ad.AdminId = 1;
            ad.Name = "a";
            ad.Password = "b";
            ad.Username = "c";
            try
            {
                MDB.Admins.Add(ad);
            }
            catch
            {
                ViewData["DB"] = "error";
            }*/
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is HASA, Hunan Association of Students Abroad.";

            return View();
        }

        public ActionResult News()
        {
            ViewBag.Message = "HASA News.";

            return View();
        }
    }
}