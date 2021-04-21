using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestIdentity.Common;
using TestIdentity.Models;
using TestIdentity.ViewModels;

namespace TestIdentity.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        // GET: Employee
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Department).Include(e => e.Position).Include(e => e.Status);
            return View(employees.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name");
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name");
            /*UserAndEmployeeViewModel model = new UserAndEmployeeViewModel
            {
                DepartmentsList = db.Departments.ToList()
            };*/
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        //public ActionResult Create([Bind(Include = "Id,Name,IdentificationId,StatusId,DepartmentId,PositionId")] Employee employee)
        public async Task<ActionResult> Create(UserAndEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = String.Format("emp-{0}", model.User.UserName), Email = model.User.Email, CreationDate = DateTime.Today };

                var result = await UserManager.CreateAsync(user, model.User.Password);
                if (result.Succeeded)
                {
                    var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
                    var RoleName = "Employee";

                    if (!RoleManager.RoleExists(RoleName))
                    {
                        RoleManager.Create(new IdentityRole(RoleName));
                        var userTemp = UserManager.FindByName(user.UserName);
                        if (!UserManager.IsInRole(userTemp.Id, RoleName))
                        {
                            UserManager.AddToRole(userTemp.Id, RoleName);
                        }
                    }

                    var employee = new Employee { Id = user.UserName, Name = model.Employee.Name, IdentificationId = model.Employee.IdentificationId,
                    StatusId = 1, Status = model.Employee.Status, DepartmentId = model.Employee.DepartmentId,
                    Department = model.Employee.Department, PositionId = model.Employee.PositionId, Position = model.Employee.Position};

                    db.Employees.Add(employee);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                AddErrors(result);
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", model.Employee.DepartmentId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name", model.Employee.PositionId);
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name", model.Employee.StatusId);
            return View(model);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name", employee.PositionId);
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name", employee.StatusId);
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IdentificationId,StatusId,DepartmentId,PositionId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name", employee.PositionId);
            ViewBag.StatusId = new SelectList(db.Statuses, "Id", "Name", employee.StatusId);
            return View(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
