using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestIdentity.Models
{
    public class Status
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Estado")]
        [StringLength(15)]
        public string Name { get; set; }
    }
}