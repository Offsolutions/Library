using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public class Account
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
    public enum Role
    {
        Admin,
        Library,
        Accountant
    }
}