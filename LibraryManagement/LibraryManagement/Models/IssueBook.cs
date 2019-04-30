using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public class IssueBook
    {
        [Key]
        public int Sid { get; set; }
        public int Mid { get; set; }
        public string IdCard { get; set; }
        public int Bid { get; set; }
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime LastDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }
        public int? fine { get; set; }
        [NotMapped]
        public int returnfine { get; set; }
        public string Status { get; set; }


    }
    public enum Status
    {
        Issue,Return
    }
}