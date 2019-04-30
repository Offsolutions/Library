using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public class Membership
    {
        [Key]
        public int Mid { get; set; }
        public int Did { get; set; }
        public virtual Department Departments { get; set; }
        public int Bid { get; set; }
        public virtual Batch Batches { get; set; }
        public string Rollno { get; set; }
        public string StudentName { get; set; }
        public string Contact { get; set; }
        [Display(Name ="Id Card")]
        public string Idnumber { get; set; }
        public Boolean Status { get; set; }



    }
}