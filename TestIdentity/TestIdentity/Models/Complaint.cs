using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestIdentity.Models
{
    public class Complaint
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Descripción")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Tipo")]
        public int TypeId { get; set; }
        [DisplayName("Tipo")]
        public virtual ComplaintType Type { get; set; }
        //----USUARIO---------------------------------------------------
        [Required]
        [DisplayName("Usuario")]
        public string CustomerId { get; set; }
        [DisplayName("Usuario")]
        public virtual Customer Customer { get; set; }
        //--------------------------------------------------------------

        //----STATUS---------------------------------------------------
        [Required]
        [DisplayName("Estatus")]
        public int StatusId { get; set; }
        [DisplayName("Estatus")]
        public virtual ComplaintAndClaimStatus Status { get; set; }
        //--------------------------------------------------------------

        //----DEPARTAMENTO RESPONSABLE------------------------------------
        [Required]
        [DisplayName("Depto. Responsable")]
        public int RespDepartmentId { get; set; }
        [DisplayName("Depto. Responsable")]
        public virtual Department RespDepartment { get; set; }
        //--------------------------------------------------------------

        [DisplayName("Fecha de Creación")]
        public DateTime CreationDate { get; set; }

        [DisplayName("Comentario")]
        public string Feedback { get; set; }

        //----DEPARTAMENTO RESPONSABLE------------------------------------
        [DisplayName("Atendido por")]
        public string EmployeeId { get; set; }
        //public virtual Employee Employee { get; set; }
        //--------------------------------------------------------------

        [DisplayName("Valoración")]
        public string RateId { get; set; }
        [DisplayName("Valoración")]
        public virtual Rate Rate { get; set; }

    }
}