using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practice.DAL;
using Practice.Models;
using System.Threading.Tasks;

namespace Practice.Controllers
{
    public class AllTheTeacherController : Controller
    {
        private NoticeContext db = new NoticeContext();

        // GET: AllTheTeacher
        public ActionResult Index()
        {
         
            return View(db.AllTheTeachers.ToList());
        }

        // GET: AllTheTeacher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllTheTeacher allTheTeacher = db.AllTheTeachers.Find(id);
            if (allTheTeacher == null)
            {
                return HttpNotFound();
            }
            return View(allTheTeacher);
        }

        // GET: AllTheTeacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllTheTeacher/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,Cell,NameOfClass,Subject")] AllTheTeacher allTheTeacher)
        {
            if (ModelState.IsValid)
            {
                db.AllTheTeachers.Add(allTheTeacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(allTheTeacher);
        }

        // GET: AllTheTeacher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllTheTeacher allTheTeacher = db.AllTheTeachers.Find(id);
            if (allTheTeacher == null)
            {
                return HttpNotFound();
            }
            return View(allTheTeacher);
        }

        // POST: AllTheTeacher/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Cell,NameOfClass,Subject")] AllTheTeacher allTheTeacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allTheTeacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(allTheTeacher);
        }

        // GET: AllTheTeacher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllTheTeacher allTheTeacher = db.AllTheTeachers.Find(id);
            if (allTheTeacher == null)
            {
                return HttpNotFound();
            }
            return View(allTheTeacher);
        }

        // POST: AllTheTeacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AllTheTeacher allTheTeacher = db.AllTheTeachers.Find(id);
            db.AllTheTeachers.Remove(allTheTeacher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult ClassOneTeacher()
        {


           IQueryable<AllTheTeacher> AllTheTeachers = db.AllTheTeachers
           .Where(c => c.NameOfClass.Equals("One"));
           var sql = AllTheTeachers.ToString();
           return View(AllTheTeachers.ToList());

        }
    }
}
