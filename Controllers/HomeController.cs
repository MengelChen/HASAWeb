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