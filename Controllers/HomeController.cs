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
            List<Article> articles = db.Articles.Where(item => item.Column == "活动新闻").ToList<Article>();
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

        public ActionResult Archieve(int? id)
        {
            ViewBag.Message = "HASA Archieve.";

            const int NumberOfOnePage = 4;
            int n;
            if (id == null) n = 0;
            else n = (int)id;
            List<Article> articles = db.Articles.Where(item => item.Column == "活动历程").ToList<Article>();
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

        public ActionResult Experiences(int? id)
        {
            ViewBag.Message = "HASA Experiences.";

            const int NumberOfOnePage = 4;
            int n;
            if (id == null) n = 0;
            else n = (int)id;
            List<Article> articles = db.Articles.Where(item => item.Column == "留学经验").ToList<Article>();
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

        public ActionResult JoinUs()
        {
            ViewBag.Message = "Join Us.";

            return View();
        }
    }
}