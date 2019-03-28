using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public class Books
    {
        [Key]
        public int boid { get; set; }
        [Display(Name ="Book Name")]
        public string Name { get; set; }
        public string ISBN { get; set; }
        public int Cid { get; set; }
        public virtual Category Categories { get; set; }

        public int Aid { get; set; }
        public virtual Author Authors { get; set; }

        public int Pid { get; set; }
        public virtual Publisher Publishers { get; set; }
        [Display(Name="Book Copies")]
        public int BookCopies { get; set; }
        public int Price { get; set; }
        [Display(Name ="Copyright Year")]
        public int Copyright { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateRecieved { get; set; }

        public string Notes { get; set; }
        [Display(Name ="Cover Image")]
        public string Image { get; set; }

    }
}