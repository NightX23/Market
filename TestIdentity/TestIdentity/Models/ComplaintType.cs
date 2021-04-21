using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TestIdentity.Models
{
    public class ComplaintType
    {
        public int Id { get; set; }

        [DisplayName("Queja")]
        public string Name { get; set; }
    }
}