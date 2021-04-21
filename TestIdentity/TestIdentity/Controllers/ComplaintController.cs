using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestIdentity.Models;
using Microsoft.AspNet.Identity;

namespace TestIdentity.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class ComplaintController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Complaint
        public ActionResult Index()
        {
            var userTemp = User.Identity.GetUserName();

            if (!User.Identity.IsAuthenticated)
            {
                RedirectToAction("Index", "Home");
            }

            if (User.IsInRole("Customer"))
            {
                var complaints = db.Complaints
                    .Include(c => c.RespDepartment).Include(c => c.Status).Include(c => c.Type)
                    .Where(c => c.CustomerId == userTemp);
                return View(complaints.ToList());
            }
            else
            {
                var complaints = db.Complaints
                    .Include(c => c.RespDepartment).Include(c => c.Status).Include(c => c.Type);
                return View(complaints.ToList());
            }
           
        }

        // GET: Complaint/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // GET: Complaint/Create
        [Authorize(Roles ="Customer")]
        public ActionResult Create()
        {
            ViewBag.RespDepartmentId = new SelectList(db.Departments, "Id", "Name");
            ViewBag.StatusId = new SelectList(db.ComplaintAndClaimStatuses, "Id", "Name");
            ViewBag.TypeId = new SelectList(db.ComplaintTypes, "Id", "Name");
            return View();
        }
        
        // POST: Complaint/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public ActionResult Create([Bind(Include = "Id,Description,TypeId,CustomerId,StatusId,RespDepartmentId,CreationDate,Feedback")] Complaint complaint)
        {
            complaint.CustomerId = User.Identity.GetUserName();
            complaint.StatusId = 1;
            complaint.CreationDate = DateTime.Today;
            
            if (ModelState.IsValid)
            {
                db.Complaints.Add(complaint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RespDepartmentId = new SelectList(db.Departments, "Id", "Name", complaint.RespDepartmentId);
            ViewBag.StatusId = new SelectList(db.ComplaintAndClaimStatuses, "Id", "Name", complaint.StatusId);
            ViewBag.TypeId = new SelectList(db.ComplaintTypes, "Id", "Name", complaint.TypeId);
            return View(complaint);
        }

        // GET: Complaint/Edit/5
        [Authorize(Roles = "Customer")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            ViewBag.RespDepartmentId = new SelectList(db.Departments, "Id", "Name", complaint.RespDepartmentId);
            ViewBag.StatusId = new SelectList(db.ComplaintAndClaimStatuses, "Id", "Name", complaint.StatusId);
            ViewBag.TypeId = new SelectList(db.ComplaintTypes, "Id", "Name", complaint.TypeId);
            return View(complaint);
        }

        // POST: Complaint/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public ActionResult Edit([Bind(Include = "Id,Description,TypeId,CustomerId,StatusId,RespDepartmentId,CreationDate,Feedback")] Complaint complaint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complaint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RespDepartmentId = new SelectList(db.Departments, "Id", "Name", complaint.RespDepartmentId);
            ViewBag.StatusId = new SelectList(db.ComplaintAndClaimStatuses, "Id", "Name", complaint.StatusId);
            ViewBag.TypeId = new SelectList(db.ComplaintTypes, "Id", "Name", complaint.TypeId);
            return View(complaint);
        }

        [Authorize(Roles = "Admin, Employee")]
        public ActionResult CheckComplaint(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            ViewBag.RespDepartmentId = new SelectList(db.Departments, "Id", "Name", complaint.RespDepartmentId);
            ViewBag.StatusId = new SelectList(db.ComplaintAndClaimStatuses, "Id", "Name", complaint.StatusId);
            ViewBag.TypeId = new SelectList(db.ComplaintTypes, "Id", "Name", complaint.TypeId);
            return View(complaint);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult CheckComplaint([Bind(Include = "Id,Description,TypeId,CustomerId,StatusId,RespDepartmentId,CreationDate,Feedback")] Complaint complaint)
        {
            if (complaint.EmployeeId == null) { complaint.EmployeeId = User.Identity.GetUserName(); }
            
            if (ModelState.IsValid)
            {
                db.Entry(complaint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RespDepartmentId = new SelectList(db.Departments, "Id", "Name", complaint.RespDepartmentId);
            ViewBag.StatusId = new SelectList(db.ComplaintAndClaimStatuses, "Id", "Name", complaint.StatusId);
            ViewBag.TypeId = new SelectList(db.ComplaintTypes, "Id", "Name", complaint.TypeId);
            return View(complaint);
        }


        [Authorize(Roles = "Customer")]
        public ActionResult Evaluate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            ViewBag.RateId = new SelectList(db.Rates, "Id", "Name", complaint.RateId);
            ViewBag.RespDepartmentId = new SelectList(db.Departments, "Id", "Name", complaint.RespDepartmentId);
            ViewBag.StatusId = new SelectList(db.ComplaintAndClaimStatuses, "Id", "Name", complaint.StatusId);
            ViewBag.TypeId = new SelectList(db.ComplaintTypes, "Id", "Name", complaint.TypeId);
            return View(complaint);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public ActionResult Evaluate([Bind(Include = "Id,Description,TypeId,CustomerId,EmployeeId,StatusId,RespDepartmentId,CreationDate,Feedback,RateId")] Complaint complaint)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(complaint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RateId = new SelectList(db.Rates, "Id", "Name", complaint.RateId);
            ViewBag.RespDepartmentId = new SelectList(db.Departments, "Id", "Name", complaint.RespDepartmentId);
            ViewBag.StatusId = new SelectList(db.ComplaintAndClaimStatuses, "Id", "Name", complaint.StatusId);
            ViewBag.TypeId = new SelectList(db.ComplaintTypes, "Id", "Name", complaint.TypeId);
            return View(complaint);
        }

        // GET: Complaint/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // POST: Complaint/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public ActionResult DeleteConfirmed(int id)
        {
            Complaint complaint = db.Complaints.Find(id);
            db.Complaints.Remove(complaint);
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
