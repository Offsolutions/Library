using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public class Batch
    {
        [Key]
        public int Bid { get; set; }
        [Display (Name ="Batch Name")]
        public string BatchNumber { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}