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
        ManagerContext db = new ManagerContext();

        public ActionResult Index()
        {
            List<Picture> pictures = new List<Picture>();
            List<Picture> backgrounds = new List<Picture>();
            pictures = db.Pictures.ToList<Picture>();
            foreach(var pic in pictures)
            {
                if(pic.Name.IndexOf("HomePage")!=-1)
                {
                    backgrounds.Add(pic);
                }
            }
            return View(backgrounds);
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

        public ActionResult Archieve()
        {
            ViewBag.Message = "HASA Archieve.";
            List<ColumnView> Columns = new List<ColumnView>();

            return View(Columns);
        }

        public ActionResult Experiences()
        {
            ViewBag.Message = "HASA Experiences.";
            List<ColumnView> Columns = new List<ColumnView>();

            return View(Columns);
        }

        public ActionResult JoinUs()
        {
            ViewBag.Message = "Join Us.";

            return View();
        }
    }
}