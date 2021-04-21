using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestIdentity.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Departamento")]
        public string Name { get; set; }
    }
}