using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Workforce_Management.Models;

namespace Workforce_Management.Controllers
{
    public class EmployeesController : Controller
    {
        private WorkforceManagement db = new WorkforceManagement();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employee.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,EmployeeFirstName,EmployeeLastName,HiringDate,ComputerId,DepartementId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.AvailableCourses = db.TrainingProgram.ToList();
            ViewBag.AvailableComputers = db.Computer
                .Where(x => x.Available == true)
                .ToList();
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,EmployeeFirstName,EmployeeLastName,HiringDate,ComputerId,DepartementId,TrainingPrograms.TrainingProgramId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                //var oldComputerId = db.Employee.Find(employee.EmployeeId).ComputerId;
                //db.Computer.Find(oldComputerId).Available = true;
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AvailableCourses = db.TrainingProgram.ToList();
            ViewBag.AvailableComputers = db.Computer.ToList();
            return View(employee);
        }

        public ActionResult AddCourse(int courseId , int empId)
        {
            ViewBag.AvailableCourses = db.TrainingProgram.ToList();
            var trainingCourse = from C in db.TrainingProgram
                                 where C.TrainingProgramId == courseId
                                 select C;
            db.Employee.Find(empId).TrainingPrograms.Add(trainingCourse.First());
            db.SaveChanges();
            Employee employee = db.Employee.Find(empId);
            return View("Edit", employee);
        }

        public ActionResult RemoveCourse(int courseId ,int empId)
        {
            ViewBag.AvailableCourses = db.TrainingProgram.ToList();
            var trainingCourse = from C in db.TrainingProgram
                                 where C.TrainingProgramId == courseId
                                 select C;
            db.Employee.Find(empId).TrainingPrograms.Remove(trainingCourse.First());
            db.SaveChanges();
            Employee employee = db.Employee.Find(empId);
            return View("Edit", employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
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
