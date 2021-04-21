using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestIdentity.Models;

namespace TestIdentity.Common
{
    public class Repository
    {
        public ApplicationDbContext _db { get; }
        //private UserManager _userManager;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void InsertCustomer(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();
        }

        public List<Department> GetDepartments()
        {
            return _db.Departments.ToList();
        }

    }
}