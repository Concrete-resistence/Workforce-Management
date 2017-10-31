using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Workforce_Management.Models;

namespace Workforce_Management.Controllers
{
    public class TrainingProgramsController : Controller
    {
        private WorkforceManagement db = new WorkforceManagement();

        // GET: TrainingPrograms
        public ActionResult Index()
        {
            return View(db.TrainingProgram.ToList());
        }

        // GET: TrainingPrograms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingProgram trainingProgram = db.TrainingProgram.Find(id);
            if (trainingProgram == null)
            {
                return HttpNotFound();
            }
            return View(trainingProgram);
        }

        // GET: TrainingPrograms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainingPrograms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainingProgramId,TrainingProgramName,Description,StartDate,EndDate,MaxAttendees")] TrainingProgram trainingProgram)
        {
            if (ModelState.IsValid)
            {
                db.TrainingProgram.Add(trainingProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainingProgram);
        }

        // GET: TrainingPrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingProgram trainingProgram = db.TrainingProgram.Find(id);
            if (trainingProgram == null)
            {
                return HttpNotFound();
            }
            return View(trainingProgram);
        }

        // POST: TrainingPrograms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrainingProgramId,TrainingProgramName,Description,StartDate,EndDate,MaxAttendees")] TrainingProgram trainingProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainingProgram);
        }

        // GET: TrainingPrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingProgram trainingProgram = db.TrainingProgram.Find(id);
            if (trainingProgram == null)
            {
                return HttpNotFound();
            }
            return View(trainingProgram);
        }

        // POST: TrainingPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingProgram trainingProgram = db.TrainingProgram.Find(id);
            db.TrainingProgram.Remove(trainingProgram);
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
