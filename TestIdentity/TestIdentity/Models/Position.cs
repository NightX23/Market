using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestIdentity.Models
{
    public class Position
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Posición")]
        public string Name { get; set; }
    }
}