using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public class Publisher
    {
        [Key]
        public int Pid { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Books> Books { get; set; }
    }
}