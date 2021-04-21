using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestIdentity.Models
{
    public class Employee
    {
        
        public string Id { get; set; }

        [Required]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [Required]
        [DisplayName("DNI")]
        public string IdentificationId { get; set; }

        
        //public int AddressHistoryId { get; set; }


        [Required]
        [DisplayName("Estatus")]
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        [Required]
        [DisplayName("Departamento")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }


        [Required]
        [DisplayName("Posición")]
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
    }
}