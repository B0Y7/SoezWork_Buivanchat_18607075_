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
    public class WWorksController : Controller
    {
        private Graduation_Project_Work_ManagementEntities db = new Graduation_Project_Work_ManagementEntities();

        // GET: WWorks
        public ActionResult Index()
        {
            return View(db.WWorks.ToList());
        }

        // GET: WWorks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WWork wWork = db.WWorks.Find(id);
            if (wWork == null)
            {
                return HttpNotFound();
            }
            return View(wWork);
        }

        // GET: WWorks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WWorks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Workid,Title,Point,PointTotal,StartDate,EndDate,Note,IsOnepersion,ExcuSequenceDocumentid,SequencedocumentStepid,TimeremindFinish,IsRating,TypeRating,TypeWork,WorkLevel,Documentaryid,Status,IsTemplate,IsDeleted,CreatedDate,CreatedUserId,ModifiedDate,ModifiedUserId,AssignedUserId,MaDviqly")] WWork wWork)
        {
            if (ModelState.IsValid)
            {
                db.WWorks.Add(wWork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wWork);
        }

        // GET: WWorks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WWork wWork = db.WWorks.Find(id);
            if (wWork == null)
            {
                return HttpNotFound();
            }
            return View(wWork);
        }

        // POST: WWorks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Workid,Title,Point,PointTotal,StartDate,EndDate,Note,IsOnepersion,ExcuSequenceDocumentid,SequencedocumentStepid,TimeremindFinish,IsRating,TypeRating,TypeWork,WorkLevel,Documentaryid,Status,IsTemplate,IsDeleted,CreatedDate,CreatedUserId,ModifiedDate,ModifiedUserId,AssignedUserId,MaDviqly")] WWork wWork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wWork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wWork);
        }

        // GET: WWorks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WWork wWork = db.WWorks.Find(id);
            if (wWork == null)
            {
                return HttpNotFound();
            }
            return View(wWork);
        }

        // POST: WWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WWork wWork = db.WWorks.Find(id);
            db.WWorks.Remove(wWork);
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
        public ActionResult Dashboard()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            //return View();
        }

        #region login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);

                var data = db.AccountUsers.Where(s => s.UserName.Equals(username) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session               
                    Session["UserName"] = data.FirstOrDefault().UserName;
                    Session["Id"] = data.FirstOrDefault().UserId;
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }



        //create a string MD5
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
        #endregion
        //END LOGIN
        public ActionResult ListWork()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            //return View();
        }

    }
}
