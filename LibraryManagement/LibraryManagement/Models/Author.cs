using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public class Author
    {
        [Key]
        public int Aid { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Books> Books { get; set; }
    }
}