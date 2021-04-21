using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TestIdentity.Models
{
    public class ComplaintAndClaimStatus
    {
        public int Id { get; set; }
        [DisplayName("Estado")]
        public string Name { get; set; }
    }
}