using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public class Setting
    {
        public int id { get; set; }
        [Display(Name ="Institute Name")]
        public string InstituteName { get; set; }
        public string Address { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Fine { get; set; }
        public int BookAlert { get; set; }
        public string BusinessEmail { get; set; }
        public string EmailPassword { get; set; }
        [Display(Name ="Terms & Condition")]
        public string Terms { get; set; }

    }
}