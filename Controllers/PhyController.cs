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

namespace Practice.Controllers
{
    public class PhyController : Controller
    {
        private NoticeContext db = new NoticeContext();

        // GET: Phy
        public ActionResult Index()
        {
            return View(db.Physics.ToList());
        }

        // GET: Phy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phy phy = db.Physics.Find(id);
            if (phy == null)
            {
                return HttpNotFound();
            }
            return View(phy);
        }

        // GET: Phy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Phy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] Phy phy)
        {
            if (ModelState.IsValid)
            {
                phy.Total = phy.SBA + phy.Final;
                if (phy.Total >= 80)
                    phy.GPA = 4.00;
                else if (phy.Total >= 75 && phy.Total < 80)
                    phy.GPA = 3.75;
                else if (phy.Total >= 70 && phy.Total < 75)
                    phy.GPA = 3.50;
                else if (phy.Total >= 65 && phy.Total < 70)
                    phy.GPA = 3.25;
                else if (phy.Total >= 60 && phy.Total < 65)
                    phy.GPA = 3.00;
                else if (phy.Total >= 55 && phy.Total < 60)
                    phy.GPA = 2.75;
                else if (phy.Total >= 50 && phy.Total < 55)
                    phy.GPA = 2.50;
                else if (phy.Total >= 45 && phy.Total < 50)
                    phy.GPA = 2.25;
                else if (phy.Total >= 40 && phy.Total < 45)
                    phy.GPA = 2.00;
                else if (phy.Total < 40)
                    phy.GPA = 0.00;

                if (phy.Total >= 80)
                    phy.Grade = "A+";
                else if (phy.Total >= 75 && phy.Total < 80)
                    phy.Grade = "A";
                else if (phy.Total >= 70 && phy.Total < 75)
                    phy.Grade = "A-";
                else if (phy.Total >= 65 && phy.Total < 70)
                    phy.Grade = "B+";
                else if (phy.Total >= 60 && phy.Total < 65)
                    phy.Grade = "B";
                else if (phy.Total >= 55 && phy.Total < 60)
                    phy.Grade = "B-";
                else if (phy.Total >= 50 && phy.Total < 55)
                    phy.Grade = "C+";
                else if (phy.Total >= 45 && phy.Total < 50)
                    phy.Grade = "C";
                else if (phy.Total >= 40 && phy.Total < 45)
                    phy.Grade = "D";
                else if (phy.Total < 40)
                    phy.Grade = "F";
                db.Physics.Add(phy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phy);
        }

        // GET: Phy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phy phy = db.Physics.Find(id);
            if (phy == null)
            {
                return HttpNotFound();
            }
            return View(phy);
        }

        // POST: Phy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Roll,SBA,Final,Total,GPA,Grade")] Phy phy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phy);
        }

        // GET: Phy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phy phy = db.Physics.Find(id);
            if (phy == null)
            {
                return HttpNotFound();
            }
            return View(phy);
        }

        // POST: Phy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phy phy = db.Physics.Find(id);
            db.Physics.Remove(phy);
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
    }
}
