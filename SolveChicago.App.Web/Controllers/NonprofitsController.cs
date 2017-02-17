﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SolveChicago.Entities;

namespace SolveChicago.App.Web.Controllers
{
    public class NonprofitsController : BaseController
    {
        // GET: Nonprofits
        public ActionResult Index()
        {
            return View(db.Nonprofits.ToList());
        }

        // GET: Nonprofits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nonprofit nonprofit = db.Nonprofits.Find(id);
            if (nonprofit == null)
            {
                return HttpNotFound();
            }
            return View(nonprofit);
        }

        // GET: Nonprofits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nonprofits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Phone,Address1,Address2,City,Province,Country,CreatedDate")] Nonprofit nonprofit)
        {
            if (ModelState.IsValid)
            {
                db.Nonprofits.Add(nonprofit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nonprofit);
        }

        // GET: Nonprofits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nonprofit nonprofit = db.Nonprofits.Find(id);
            if (nonprofit == null)
            {
                return HttpNotFound();
            }
            return View(nonprofit);
        }

        // POST: Nonprofits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Phone,Address1,Address2,City,Province,Country,CreatedDate")] Nonprofit nonprofit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nonprofit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nonprofit);
        }

        // GET: Nonprofits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nonprofit nonprofit = db.Nonprofits.Find(id);
            if (nonprofit == null)
            {
                return HttpNotFound();
            }
            return View(nonprofit);
        }

        // POST: Nonprofits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nonprofit nonprofit = db.Nonprofits.Find(id);
            db.Nonprofits.Remove(nonprofit);
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
