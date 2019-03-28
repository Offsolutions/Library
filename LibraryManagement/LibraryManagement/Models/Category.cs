using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public class Category
    {
        [Key]
        public int Cid { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}