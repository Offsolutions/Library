using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public class Department
    {
        [Key]
        public int Did { get; set; }
        [Required]
        [Display(Name ="Department")]
        public string DepartmentName { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}