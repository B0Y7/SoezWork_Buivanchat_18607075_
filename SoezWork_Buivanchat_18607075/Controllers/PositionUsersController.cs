using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SoezWork_Buivanchat_18607075.Models;

namespace SoezWork_Buivanchat_18607075.Controllers
{
    public class PositionUsersController : Controller
    {
        private Graduation_Project_Work_ManagementEntities db = new Graduation_Project_Work_ManagementEntities();

        // GET: PositionUsers
        public ActionResult Index()
        {
            return View(db.PositionUsers.ToList());
        }

        // GET: PositionUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionUser positionUser = db.PositionUsers.Find(id);
            if (positionUser == null)
            {
                return HttpNotFound();
            }
            return View(positionUser);
        }

        // GET: PositionUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PositionUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PositionId,CodePosition,NamePosition,CreateDate,CreateUserId,ModifiedDate,ModifiedUserId,AssignedUserId")] PositionUser positionUser)
        {
            if (ModelState.IsValid)
            {
                db.PositionUsers.Add(positionUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(positionUser);
        }

        // GET: PositionUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionUser positionUser = db.PositionUsers.Find(id);
            if (positionUser == null)
            {
                return HttpNotFound();
            }
            return View(positionUser);
        }

        // POST: PositionUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PositionId,CodePosition,NamePosition,CreateDate,CreateUserId,ModifiedDate,ModifiedUserId,AssignedUserId")] PositionUser positionUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(positionUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(positionUser);
        }

        // GET: PositionUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionUser positionUser = db.PositionUsers.Find(id);
            if (positionUser == null)
            {
                return HttpNotFound();
            }
            return View(positionUser);
        }

        // POST: PositionUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PositionUser positionUser = db.PositionUsers.Find(id);
            db.PositionUsers.Remove(positionUser);
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
