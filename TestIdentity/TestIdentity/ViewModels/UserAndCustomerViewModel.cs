using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestIdentity.Models;

namespace TestIdentity.ViewModels
{
    public class UserAndCustomerViewModel
    {
        public RegisterViewModel User { get; set; }
        //public ApplicationRole Role { get; set; }
        public Customer Customer { get; set; }
    }
}