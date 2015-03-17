﻿using System;
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