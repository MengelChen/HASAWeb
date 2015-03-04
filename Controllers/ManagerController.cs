using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HASAWeb.Models;

namespace HASAWeb.Controllers
{
    public class ManagerController : Controller
    {
        private ManagerContext db = new ManagerContext();

        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Articles()
        {
            List<Article> Articles = new List<Article>();
            Articles = db.Articles.ToList();
            return View(Articles);
        }

        // GET: Manager/Details/5
        public ActionResult ArticleDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Manager/Create
        public ActionResult ArticleCreate()
        {
            Article article = new Article();
            return View(article);
        }

        // POST: Manager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ArticleCreate([Bind(Include = "ArticleId,Hits,Title,Keywords,Author,Pictures,Content, Abstraction,PublishTime,ReviseTime, ExpiredTime")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Articles");
            }

            return View(article);
        }

        // GET: Manager/Edit/5
        public ActionResult ArticleEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Manager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ArticleEdit([Bind(Include = "ArticleId,Hits,Title,Keywords,Author,Pictures,Content, Abstraction,PublishTime,ReviseTime, ExpiredTime")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Articles");
            }
            return View(article);
        }

        // GET: Manager/Delete/5
        public ActionResult ArticleDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Manager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ArticleDeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Articles");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
