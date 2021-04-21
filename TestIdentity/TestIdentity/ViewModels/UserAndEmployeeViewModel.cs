using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestIdentity.Models;

namespace TestIdentity.ViewModels
{
    public class UserAndEmployeeViewModel
    {
        public RegisterViewModel User { get; set; }
        //public ApplicationRole Role { get; set; }
        public Employee Employee { get; set; }

        public List<Department> DepartmentsList { get; set; }
        public List<Position> PositionsList { get; set; }
        public List<Status> StatusesList { get; set; }
    }
}