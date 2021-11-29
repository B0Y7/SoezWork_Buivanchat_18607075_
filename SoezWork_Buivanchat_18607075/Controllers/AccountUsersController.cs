using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SoezWork_Buivanchat_18607075.Models;

namespace SoezWork_Buivanchat_18607075.Controllers
{
    public class AccountUsersController : Controller
    {
        private Graduation_Project_Work_ManagementEntities db = new Graduation_Project_Work_ManagementEntities();

        // GET: AccountUsers
        public ActionResult Index()
        {
            return View(db.AccountUsers.ToList());
        }

        // GET: AccountUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountUser accountUser = db.AccountUsers.Find(id);
            if (accountUser == null)
            {
                return HttpNotFound();
            }
            return View(accountUser);
        }

        // GET: AccountUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,Password,ConfirmPassword,UserTypeId,Display,LastName,FirstName,Email,Images")] AccountUser accountUser,string password)
        {
            if (ModelState.IsValid)
            {
                accountUser.Password = GetMD5(password);
                db.AccountUsers.Add(accountUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accountUser);
        }

        // GET: AccountUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountUser accountUser = db.AccountUsers.Find(id);
            if (accountUser == null)
            {
                return HttpNotFound();
            }
            return View(accountUser);
        }

        // POST: AccountUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,Password,ConfirmPassword,UserTypeId,Display,LastName,FirstName,Email,Images")] AccountUser accountUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountUser);
        }

        // GET: AccountUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountUser accountUser = db.AccountUsers.Find(id);
            if (accountUser == null)
            {
                return HttpNotFound();
            }
            return View(accountUser);
        }

        // POST: AccountUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountUser accountUser = db.AccountUsers.Find(id);
            db.AccountUsers.Remove(accountUser);
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
        //getmd5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}
