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
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is HASA, Hunan Association of Students Abroad.";

            return View();
        }

        public ActionResult News(int? id)
        {
            ViewBag.Message = "HASA News.";

            const int NumberOfOnePage = 4;
            int n;
            if (id == null) n = 0;
            else n = (int)id;
            List<Article> articles = db.Articles.ToList<Article>();
            List<Article> art = new List<Article>();
            if (articles.Count <= NumberOfOnePage) art = articles;
            else
            {
                for (int i = n * NumberOfOnePage; i < (n + 1) * NumberOfOnePage; i++)
                {
                    art.Add(articles[i]);
                }
            }

            return View(art);
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