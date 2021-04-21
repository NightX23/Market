using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestIdentity.Models
{
    public class ApplicationRole:IdentityRole
    {
        public bool Enabled { get; set; }
    }
}