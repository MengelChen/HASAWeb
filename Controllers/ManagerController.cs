using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HASAWeb.Models;
using HASAWeb.Tools;

namespace HASAWeb.Controllers
{
    public class ManagerController : Controller
    {
        private ManagerContext db = new ManagerContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.LoginView login)
        {
            if (ModelState.IsValid)
            {
                List<Admin> admins = db.Admins.ToList<Admin>();
                Admin admin=null;
                foreach(Admin i in admins)
                {
                    if(i.Username==login.Username && Security.Equal(login.Password, i.Password))
                    {
                        admin = i;
                        break;
                    }
                }
                if (admin == null) ModelState.AddModelError("Username", "Wrong Username or Password");
                else
                {
                    admin.LastLogin = DateTime.Now;
                    db.Entry(admin).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Session.Add("Username", admin.Username);
                    Session.Add("Password", admin.Password);
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Login");
        }

        // GET: Manager
        [Tools.Authorization.AdminAuthorize]
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

        public ActionResult ArticleCreate()
        {
            Article article = new Article();
            return View(article);
        }

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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ArticleDeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Articles");
        }

        public ActionResult Admins()
        {
            List<Admin> Admins = new List<Admin>();
            Admins = db.Admins.ToList();
            return View(Admins);
        }

        public ActionResult AdminDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        public ActionResult AdminCreate()
        {
            Admin admin = new Admin();
            return View(admin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminCreate([Bind(Include = "AdminID, Username, Password, Name, Power, RegisterTime, LastLogin")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                admin.Password = Security.Encrypt(admin.Password);
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Admins");
            }

            return View(admin);
        }

        public ActionResult AdminEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminEdit([Bind(Include = "AdminID, Username, Password, Name, Power, RegisterTime, LastLogin")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Admins");
            }
            return View(admin);
        }

        public ActionResult AdminDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult AdminDeleteConfirmed(int id)
        {
            Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Admins");
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
