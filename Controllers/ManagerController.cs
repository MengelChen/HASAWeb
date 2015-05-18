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
    [Tools.Authorization.AdminAuthorize]
    public class ManagerController : Controller
    {
        private ManagerContext db = new ManagerContext();

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
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
        public ActionResult ArticleCreate([Bind(Include = "ArticleId,Title,Column,Keywords,Link, Author,Pictures,Content, Abstraction, ExpiredTime")] Article article)
        {
            if (ModelState.IsValid)
            {
                article.Hits = 0;
                article.PublishTime = DateTime.Now;
                article.ReviseTime = DateTime.Now;
                if (article.ExpiredTime == null) article.ExpiredTime = DateTime.Now.AddDays(7);
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
        public ActionResult ArticleEdit([Bind(Include = "ArticleId, Title, Column, Keywords, Link, Author, Pictures, Content, Abstraction, ExpiredTime")] Article article)
        {
            if (ModelState.IsValid)
            {
                article.ReviseTime = DateTime.Now;
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

        [HttpPost, ActionName("ArticleDelete")]
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
        public ActionResult AdminCreate([Bind(Include = "AdminID, Username, Password, Name, Power")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                admin.Password = Security.Encrypt(admin.Password);
                admin.RegisterTime = admin.LastLogin = DateTime.Now;
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

        [HttpPost, ActionName("AdminDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult AdminDeleteConfirmed(int id)
        {
            Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Admins");
        }

        public ActionResult Pictures()
        {
            List<Picture> Pictures = new List<Picture>();
            Pictures = db.Pictures.ToList();
            return View(Pictures);
        }

        public ActionResult PictureDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        public ActionResult PictureCreate()
        {
            Picture picture = new Picture();
            return View(picture);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PictureCreate([Bind(Include = "Name, Route")] Picture picture)
        {
            if (ModelState.IsValid)
            {
                picture.UploadTime = DateTime.Now;
                db.Pictures.Add(picture);
                db.SaveChanges();
                return RedirectToAction("Pictures");
            }

            return View(picture);
        }

        public ActionResult PictureEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PictureEdit([Bind(Include = "Name, Route, UploadTime")] Picture picture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(picture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Pictures");
            }

            return View(picture);
        }

        public ActionResult PictureDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        [HttpPost, ActionName("PictureDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult PictureDeleteConfirmed(int id)
        {
            Picture picture = db.Pictures.Find(id);
            db.Pictures.Remove(picture);
            db.SaveChanges();
            return RedirectToAction("Pictures");
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
